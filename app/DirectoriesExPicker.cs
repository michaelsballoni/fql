using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace fql
{
    public partial class DirectoriesExPicker : Form
    {
        public DirectoriesExPicker(SettingsFile settingsFile)
        {
            InitializeComponent();

            m_settingsFile = settingsFile;
            m_excludeDirPaths = new List<string>(m_settingsFile.Settings.ExcludeDirs);
        }

        private SettingsFile m_settingsFile;
        private List<string> m_excludeDirPaths;

        private void AddRootToTree(Environment.SpecialFolder folder)
        {
            string dirPath = Environment.GetFolderPath(folder);
            var rootNode = MediaFoldersTree.Nodes.Add(dirPath.Substring(SearchInfo.UserRoot.Length).Trim('\\'));
            rootNode.Tag = dirPath;
            foreach (var subDirPath in Directory.EnumerateDirectories(dirPath, "*", SearchOption.TopDirectoryOnly))
            {
                TreeNode leafNode = rootNode.Nodes.Add(subDirPath.Substring(dirPath.Length).Trim('\\'));
                leafNode.Tag = subDirPath;
            }
        }

        private void AddDirToListbox(string dirPath, ListBox listBox)
        {
            listBox.Items.Add(dirPath.Substring(SearchInfo.UserRoot.Length));
        }

        private void DirectoriesPicker_Load(object sender, EventArgs e)
        {
            AddRootToTree(Environment.SpecialFolder.MyPictures);
            AddRootToTree(Environment.SpecialFolder.MyMusic);
            AddRootToTree(Environment.SpecialFolder.MyVideos);

            foreach (string dirPath in m_excludeDirPaths)
                AddDirToListbox(dirPath, FoldersToExcludeListbox);
        }

        private void AddExcludeFolderButton_Click(object sender, EventArgs e)
        {
            if (MediaFoldersTree.SelectedNode == null)
            {
                MessageBox.Show("Select a directory in the list of media folders to the left");
                return;
            }

            string dirPath = MediaFoldersTree.SelectedNode.Tag.ToString();
            if (m_excludeDirPaths.Contains(dirPath))
                return;

            m_excludeDirPaths.Add(dirPath);

            AddDirToListbox(dirPath, FoldersToExcludeListbox);
        }

        private void RemoveExcludeFolderButton_Click(object sender, EventArgs e)
        {
            var selectedItems = FoldersToExcludeListbox.SelectedItems;
            if (selectedItems == null || selectedItems.Count == 0)
                return;

            var selectedItemValues = new List<string>();
            foreach (var selelctedItem in selectedItems)
                selectedItemValues.Add(selelctedItem.ToString());

            foreach (var selelctedItem in selectedItemValues)
            {
                string subDirPath = selelctedItem.ToString();
                string dirPath = Path.Combine(SearchInfo.UserRoot, subDirPath);

                m_excludeDirPaths.Remove(dirPath);
                FoldersToExcludeListbox.Items.Remove(subDirPath);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_settingsFile.Settings.ExcludeDirs = m_excludeDirPaths;
            m_settingsFile.SaveSettings();
        }
    }
}
