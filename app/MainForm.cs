using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Linq;

using Microsoft.WindowsAPICodePack.Shell;

namespace fql
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TheListView.ContextMenuStrip = SearchResultsContextMenu;
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private SettingsFile m_settingsFile;

        private bool m_shown = false;
        private bool m_cancel = false;
        private bool m_updating = false;

        private List<string> m_searchResults;
        private View m_view = View.Details;

        private DateTime m_lastWatcherHit = DateTime.MinValue;

        private List<FileSystemWatcher> m_watchers;

        private void ResetUi(string msg = null)
        {
            StatusBarLabel.Text = msg == null ? "Ready." : msg;
            ProgressBar.Value = 0;
            m_cancel = false;
        }

        private void HandleError(Exception exp)
        {
            if (exp is StopException)
                MessageBox.Show("Update cancelled", "My Media Search");
            else
                MessageBox.Show($"Sorry, an error occurred.\r\n\r\n{exp.GetType().FullName}: {exp.Message}", "My Media Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnSearchInfoUpdate(UpdateInfo update)
        {
            StatusBarLabel.Text = update.ToString();

            int progressVal = (int)(100.0 * (double)update.current / update.total);
            progressVal = Math.Min(progressVal, 100);
            progressVal = Math.Max(progressVal, 0);
            ProgressBar.Value = progressVal;

            Application.DoEvents();

            if (m_cancel)
                throw new StopException();
        }

        private void UpdateView(View newView)
        {
            string readyState = null;
            try
            {
                if (m_searchResults ==  null)
                {
                    PutMessageInSearchResult("Search results", "Use the search box above to find your files");
                    return;
                }

                m_view = newView;

                TheListView.Items.Clear();
                TheListView.Columns.Clear();

                TheListView.SmallImageList = null;
                TheListView.LargeImageList = null;

                TheListView.View = m_view;

                if (m_view != View.Details)
                {
                    UpdateInfo update = new UpdateInfo("Loading tiles...");
                    update.total = m_searchResults.Count;
                    OnSearchInfoUpdate(update);

                    ImageList largeImages = new ImageList();
                    largeImages.ColorDepth = ColorDepth.Depth32Bit;
                    largeImages.ImageSize = new Size(128, 128);
                    foreach (var result in m_searchResults)
                    {
                        try
                        {
                            ShellFile shellFile = ShellFile.FromFilePath(result);

                            var largeImage = shellFile.Thumbnail.LargeIcon;
                            largeImages.Images.Add(result, largeImage);
                        }
                        catch
                        {
                            largeImages.Images.Add(result, this.Icon);
                        }

                        ++update.current;
                        if ((update.current % 10) == 0)
                            OnSearchInfoUpdate(update);
                    }
                    TheListView.LargeImageList = largeImages;
                }
                else
                {
                    UpdateInfo update = new UpdateInfo("Loading icons...");
                    update.total = m_searchResults.Count;
                    OnSearchInfoUpdate(update);

                    ImageList smallImages = new ImageList();
                    smallImages.ColorDepth = ColorDepth.Depth32Bit;
                    smallImages.ImageSize = new Size(48, 48);
                    foreach (var result in m_searchResults)
                    {
                        try
                        {
                            ShellFile shellFile = ShellFile.FromFilePath(result);

                            var smallImage = shellFile.Thumbnail.SmallIcon;
                            smallImages.Images.Add(result, smallImage);
                        }
                        catch
                        {
                            smallImages.Images.Add(result, this.Icon);
                        }

                        ++update.current;
                        if ((update.current % 10) == 0)
                            OnSearchInfoUpdate(update);
                    }
                    TheListView.SmallImageList = smallImages;
                }

                {
                    UpdateInfo update = new UpdateInfo("Listing results...");
                    update.total = m_searchResults.Count;
                    OnSearchInfoUpdate(update);

                    TheListView.Columns.Add("Filename");
                    TheListView.Columns.Add("Type");
                    TheListView.Columns.Add("Path");

                    int imageIndex = 0;
                    foreach (var result in m_searchResults)
                    {
                        string[] columns = 
                            new[] 
                            { 
                                Path.GetFileNameWithoutExtension(result), 
                                Path.GetExtension(result).Trim('.').ToLower(), 
                                result.Substring(SearchInfo.UserRoot.Length) 
                            };
                        var newItem = new ListViewItem(columns, imageIndex);
                        newItem.Tag = result;
                        TheListView.Items.Add(newItem);
                        ++imageIndex;
                    }
                }

                TheListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                TheListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                TheListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                readyState = $"{m_searchResults.Count} search results";
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi(readyState);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetUi();

            string moduleName = Assembly.GetEntryAssembly().Modules.First().Name;
            var ourProcs = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(moduleName));
            if (ourProcs.Length > 1)
            {
                MessageBox.Show("My Media Search is already running, let's see...");
                int myProcessId = Process.GetCurrentProcess().Id;
                foreach (var proc in ourProcs)
                {
                    if (proc.Id != myProcessId)
                        SetForegroundWindow(proc.MainWindowHandle);
                }
                Close();
                return;
            }

            m_settingsFile = new SettingsFile();

            if (m_settingsFile.Settings.IncludeDirs.Count == 0)
            {
                MessageBox.Show("Welcome to My Media Search!\n\nPick media folders you want to search in, and let the good times roll!", "My Media Search");
                ChooseDirsButton_Click(null, null);
            }
            else
                SearchBox.Focus();

            Show();

            WindowState = FormWindowState.Maximized;

            PutMessageInSearchResult("Update In Progress", "Please wait while the search index is updated");

            UpdateButton_Click(sender, e);

            PutMessageInSearchResult("Update Complete", "Use the search box above to find your files");

            m_shown = true;
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                SearchButton_Click(null, null);
            }
        }

        private void PutMessageInSearchResult(string header, string msg)
        {
            TheListView.Items.Clear();
            TheListView.Columns.Clear();

            TheListView.Columns.Add(header);
            TheListView.View = View.Details;
            TheListView.Items.Add(msg);
            
            TheListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string resetMsg = null;
            try
            {
                if (string.IsNullOrWhiteSpace(SearchBox.Text))
                {
                    MessageBox.Show("Enter some search terms and try again", "My Media Search");
                    return;
                }

                TheListView.Items.Clear();
                TheListView.Columns.Clear();

                StatusBarLabel.Text = "Searching...";
                Application.DoEvents();

                int maxResults = 1000;
                var results = await SearchInfo.SearchAsync(SearchBox.Text, maxResults);
                if (results.Count == 0)
                {
                    PutMessageInSearchResult("Search Results", "No results found");
                    return;
                }

                bool maxedOut = results.Count == maxResults;
                if (maxedOut)
                    resetMsg = $"{results.Count} search results, there may be more";
                else
                    resetMsg = $"{results.Count} search results";

                m_searchResults = results;
                UpdateView(m_view);
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi(resetMsg);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TheListView.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Select a file to Open", "My Media Search");
                    return;
                }

                string filePath = Path.Combine(SearchInfo.UserRoot, (string)TheListView.SelectedItems[0].Tag);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Sorry, that file does not exist", "My Media Search");
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo(filePath);
                psi.UseShellExecute = true;
                Process.Start(psi);
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi();
            }
        }

        private void SearchResultsListBox_DoubleClick(object sender, EventArgs e)
        {
            OpenButton_Click(null, null);
        }

        private void ShowInFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TheListView.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Select a file to Show In Folder", "My Media Search");
                    return;
                }

                string filePath = Path.Combine(SearchInfo.UserRoot, (string)TheListView.SelectedItems[0].Tag);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Sorry, that file does not exist", "My Media Search");
                    return;
                }

                Process.Start("explorer.exe", $"/select,{filePath}");
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            string resetMsg = null;
            try
            {
                if (m_updating)
                    return;

                m_updating = true;
                var filesChanges = 
                    await SearchInfo.UpdateAsync
                    (
                        m_settingsFile.Settings.IncludeDirs, 
                        m_settingsFile.Settings.ExcludeDirs, 
                        OnSearchInfoUpdate
                    );
                resetMsg = $"Update complete.  Changes: {filesChanges.filesAdded + filesChanges.filesModified + filesChanges.filesRemoved} - Search Index: {filesChanges.indexSize} files";

                // Invoke updating watchers, until we're, um, inside a watcher!
                this.BeginInvoke((MethodInvoker)delegate { SetupFsWatcher(); });
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                m_updating = false;
                ResetUi(resetMsg);
            }
        }

        private void SetupFsWatcher()
        {
            if (m_watchers != null)
            {
                foreach (var watcher in m_watchers)
                    watcher.Dispose();
                m_watchers.Clear();
            }

            m_watchers = new List<FileSystemWatcher>();
            foreach (var path in m_settingsFile.Settings.IncludeDirs)
            {
                var watcher = new FileSystemWatcher();
                m_watchers.Add(watcher);

                watcher.Path = path;

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            m_lastWatcherHit = DateTime.UtcNow;
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            m_lastWatcherHit = DateTime.UtcNow;
        }

        private void ResetDbButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset the search index?", "My Media Search", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SearchInfo.Reset();
                MessageBox.Show("The search index is reset\r\n\r\nUpdate it to reload info about your files", "My Media Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SearchBox_Click(object sender, EventArgs e)
        {
            SearchBox.SelectAll();
        }

        private void ChooseDirsButton_Click(object sender, EventArgs e)
        {
            DirectoriesInPicker inDlg = new DirectoriesInPicker(m_settingsFile);
            if (inDlg.ShowDialog() != DialogResult.OK)
                return;

            DirectoriesExPicker exDlg = new DirectoriesExPicker(m_settingsFile);
            if (exDlg.ShowDialog() != DialogResult.OK)
                return;

            if (m_shown)
                UpdateButton_Click(sender, e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill(); // simple and clean, thanks transactions!
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            m_cancel = true;
        }

        private void GetInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TheListView.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Select a file to Get Info", "My Media Search");
                    return;
                }

                string filePath = Path.Combine(SearchInfo.UserRoot, (string)TheListView.SelectedItems[0].Tag);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Sorry, that file does not exist", "My Media Search");
                    return;
                }

                var fileMetadata = SearchInfo.GetFileMetadata(filePath);
                if (fileMetadata == null || fileMetadata.Count == 0)
                {
                    MessageBox.Show("Sorry, no information found about the file", "My Media Search");
                    return;
                }

                var sortedNames = new List<string>(fileMetadata.Keys);
                sortedNames.Sort();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(filePath);
                foreach (var key in sortedNames)
                    sb.AppendLine($"{key}: {fileMetadata[key]}");

                ShowInfoForm infoForm = new ShowInfoForm();
                infoForm.InfoTextBox.Text = sb.ToString();
                infoForm.InfoTextBox.Select(0, 0);
                infoForm.Show();
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenButton_Click(null, null);
        }

        private void SearchResultsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point localPoint = TheListView.PointToClient(e.Location);
                var item = TheListView.GetItemAt(localPoint.X, localPoint.Y);
                if (item != null)
                    item.Selected = true;
            }
        }

        private void showInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInFolderButton_Click(sender, e);
        }

        private void getSearchInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetInfoButton_Click(sender, e);
        }

        private void aboutMyMediaSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var versionInfo = Process.GetCurrentProcess().Modules[0].FileVersionInfo;
            MessageBox.Show
            (
                $"{versionInfo.ProductName} - Powered by metastrings\n" +
                $"Version {versionInfo.ProductVersion}",
                $"{versionInfo.ProductName}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void chooseSearchFoldersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChooseDirsButton_Click(sender, e);
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenButton_Click(null, null);
        }

        private void showInFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowInFolderButton_Click(sender, e);
        }

        private void getSearchInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetInfoButton_Click(sender, e);
        }

        private void updateSearchIndexNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButton_Click(sender, e);
        }

        private void resetSearchIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDbButton_Click(sender, e);
        }

        private void cancelUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelButton_Click(sender, e);
        }

        private void SearchResultsListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                OpenButton_Click(sender, null);
        }

        private void WatcherToUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (m_lastWatcherHit == DateTime.MinValue)
                return;

            if ((DateTime.UtcNow - m_lastWatcherHit).TotalSeconds > 3) // magic number, seconds of quiet before starting the update
            {
                m_lastWatcherHit = DateTime.MinValue;
                UpdateButton_Click(sender, e);
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateView(View.Details);
        }

        private void tilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateView(View.LargeIcon);
        }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            detailsToolStripMenuItem_Click(sender, e);
            detailsToolStripMenuItem1.Checked = true;
            tilesToolStripMenuItem1.Checked = false;
        }

        private void tilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tilesToolStripMenuItem_Click(sender, e);
            detailsToolStripMenuItem1.Checked = false;
            tilesToolStripMenuItem1.Checked = true;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelButton_Click(sender, e);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TheListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenButton_Click(sender, e);
        }

        private void chooseSearchFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseDirsButton_Click(sender, e);
        }

        private void updateIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButton_Click(sender, e);
        }

        private void resetIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDbButton_Click(sender, e);
        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TheListView.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Select a file to Copy Full Path", "My Media Search");
                    return;
                }

                string filePath = Path.Combine(SearchInfo.UserRoot, (string)TheListView.SelectedItems[0].Tag);
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Sorry, that file does not exist", "My Media Search");
                    return;
                }

                Clipboard.SetText(filePath);

                MessageBox.Show($"File full path copied to clipboard:\r\n\r\n{filePath}", "My Media Search");
            }
#if !DEBUG
            catch (Exception exp)
            {
                HandleError(exp);
            }
#endif
            finally
            {
                ResetUi();
            }
        }

        private void copyFullPathToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyFullPathToolStripMenuItem_Click(sender, e);
        }

        private void TheListView_DoubleClick(object sender, EventArgs e)
        {
            OpenButton_Click(sender, e);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("https://metastrings.io");
            psi.UseShellExecute = true;
            Process.Start(psi);
        }
    }
}
