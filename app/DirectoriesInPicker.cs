using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace fql
{
    public partial class DirectoriesInPicker : Form
    {
        public DirectoriesInPicker(SettingsFile settingsFile)
        {
            InitializeComponent();

            m_settingsFile = settingsFile;
            m_includeDirPaths = new List<string>(m_settingsFile.Settings.IncludeDirs);
        }

        private SettingsFile m_settingsFile;
        private List<string> m_includeDirPaths;

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

            foreach (string dirPath in m_includeDirPaths)
                AddDirToListbox(dirPath, FoldersToIncludeListbox);
        }

        private void AddIncludeFolderButton_Click(object sender, EventArgs e)
        {
            if (MediaFoldersTree.SelectedNode == null)
            {
                MessageBox.Show("Select a directory in the list of media folders to the left");
                return;
            }

            string dirPath = MediaFoldersTree.SelectedNode.Tag.ToString();
            if (m_includeDirPaths.Contains(dirPath))
                return;

            m_includeDirPaths.Add(dirPath);

            AddDirToListbox(dirPath, FoldersToIncludeListbox);
        }

        private void RemoveIncludeFolderButton_Click(object sender, EventArgs e)
        {
            var selectedItems = FoldersToIncludeListbox.SelectedItems;
            if (selectedItems == null || selectedItems.Count == 0)
            {
                return;
            }

            var selectedItemValues = new List<string>();
            foreach (var selelctedItem in selectedItems)
                selectedItemValues.Add(selelctedItem.ToString());

            foreach (var selelctedItem in selectedItemValues)
            {
                string subDirPath = selelctedItem.ToString();
                string dirPath = Path.Combine(SearchInfo.UserRoot, subDirPath);

                m_includeDirPaths.Remove(dirPath);
                FoldersToIncludeListbox.Items.Remove(subDirPath);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            m_settingsFile.Settings.IncludeDirs = m_includeDirPaths;
            m_settingsFile.SaveSettings();
        }
    }
}
