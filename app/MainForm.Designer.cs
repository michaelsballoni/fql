namespace fql
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.getSearchInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showInFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSearchInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseSearchFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.updateIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMyMediaSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WatcherToUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.TheListView = new System.Windows.Forms.ListView();
            this.StatusStrip.SuspendLayout();
            this.SearchResultsContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusBarLabel,
            this.toolStripStatusLabel1});
            this.StatusStrip.Location = new System.Drawing.Point(0, 425);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 26, 0);
            this.StatusStrip.Size = new System.Drawing.Size(859, 32);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(133, 24);
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(83, 25);
            this.StatusBarLabel.Text = "Ready.";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(266, 25);
            this.toolStripStatusLabel1.Text = "Powered by metastrings";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.ToolTipText = "Click to visit the metastrings web site";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(15, 44);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(829, 32);
            this.SearchBox.TabIndex = 9;
            this.SearchBox.Text = "Enter search terms here, then hit [Enter] or press the Search button";
            this.SearchBox.Click += new System.EventHandler(this.SearchBox_Click);
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // SearchResultsContextMenu
            // 
            this.SearchResultsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SearchResultsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.showInFolderToolStripMenuItem,
            this.copyFullPathToolStripMenuItem1,
            this.getSearchInfoToolStripMenuItem,
            this.toolStripSeparator3,
            this.viewDetailsToolStripMenuItem});
            this.SearchResultsContextMenu.Name = "SearchResultsContextMenu";
            this.SearchResultsContextMenu.Size = new System.Drawing.Size(204, 170);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // showInFolderToolStripMenuItem
            // 
            this.showInFolderToolStripMenuItem.Name = "showInFolderToolStripMenuItem";
            this.showInFolderToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.showInFolderToolStripMenuItem.Text = "&Show In Folder";
            this.showInFolderToolStripMenuItem.Click += new System.EventHandler(this.showInFolderToolStripMenuItem_Click);
            // 
            // copyFullPathToolStripMenuItem1
            // 
            this.copyFullPathToolStripMenuItem1.Name = "copyFullPathToolStripMenuItem1";
            this.copyFullPathToolStripMenuItem1.Size = new System.Drawing.Size(203, 32);
            this.copyFullPathToolStripMenuItem1.Text = "&Copy Full Path";
            this.copyFullPathToolStripMenuItem1.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem1_Click);
            // 
            // getSearchInfoToolStripMenuItem
            // 
            this.getSearchInfoToolStripMenuItem.Name = "getSearchInfoToolStripMenuItem";
            this.getSearchInfoToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.getSearchInfoToolStripMenuItem.Text = "&Get Properties";
            this.getSearchInfoToolStripMenuItem.Click += new System.EventHandler(this.getSearchInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.tilesToolStripMenuItem});
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.viewDetailsToolStripMenuItem.Text = "View";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(167, 34);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(167, 34);
            this.tilesToolStripMenuItem.Text = "Tiles";
            this.tilesToolStripMenuItem.Click += new System.EventHandler(this.tilesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.searchIndexToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(859, 33);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.showInFolderToolStripMenuItem1,
            this.copyFullPathToolStripMenuItem,
            this.getSearchInfoToolStripMenuItem1,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(420, 34);
            this.openToolStripMenuItem1.Text = "&Open Selected Search Result";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // showInFolderToolStripMenuItem1
            // 
            this.showInFolderToolStripMenuItem1.Name = "showInFolderToolStripMenuItem1";
            this.showInFolderToolStripMenuItem1.Size = new System.Drawing.Size(420, 34);
            this.showInFolderToolStripMenuItem1.Text = "&Show In Folder";
            this.showInFolderToolStripMenuItem1.Click += new System.EventHandler(this.showInFolderToolStripMenuItem1_Click);
            // 
            // copyFullPathToolStripMenuItem
            // 
            this.copyFullPathToolStripMenuItem.Name = "copyFullPathToolStripMenuItem";
            this.copyFullPathToolStripMenuItem.Size = new System.Drawing.Size(420, 34);
            this.copyFullPathToolStripMenuItem.Text = "&Copy Full Path";
            this.copyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // getSearchInfoToolStripMenuItem1
            // 
            this.getSearchInfoToolStripMenuItem1.Name = "getSearchInfoToolStripMenuItem1";
            this.getSearchInfoToolStripMenuItem1.Size = new System.Drawing.Size(420, 34);
            this.getSearchInfoToolStripMenuItem1.Text = "&Get Properties";
            this.getSearchInfoToolStripMenuItem1.Click += new System.EventHandler(this.getSearchInfoToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(417, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(420, 34);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem1,
            this.tilesToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // detailsToolStripMenuItem1
            // 
            this.detailsToolStripMenuItem1.Checked = true;
            this.detailsToolStripMenuItem1.CheckOnClick = true;
            this.detailsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Size = new System.Drawing.Size(187, 34);
            this.detailsToolStripMenuItem1.Text = "&Details";
            this.detailsToolStripMenuItem1.Click += new System.EventHandler(this.detailsToolStripMenuItem1_Click);
            // 
            // tilesToolStripMenuItem1
            // 
            this.tilesToolStripMenuItem1.Name = "tilesToolStripMenuItem1";
            this.tilesToolStripMenuItem1.Size = new System.Drawing.Size(187, 34);
            this.tilesToolStripMenuItem1.Text = "&Tiles";
            this.tilesToolStripMenuItem1.Click += new System.EventHandler(this.tilesToolStripMenuItem1_Click);
            // 
            // searchIndexToolStripMenuItem
            // 
            this.searchIndexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseSearchFoldersToolStripMenuItem,
            this.toolStripSeparator2,
            this.resetIndexToolStripMenuItem,
            this.updateIndexToolStripMenuItem});
            this.searchIndexToolStripMenuItem.Name = "searchIndexToolStripMenuItem";
            this.searchIndexToolStripMenuItem.Size = new System.Drawing.Size(167, 29);
            this.searchIndexToolStripMenuItem.Text = "&Search Index";
            // 
            // chooseSearchFoldersToolStripMenuItem
            // 
            this.chooseSearchFoldersToolStripMenuItem.Name = "chooseSearchFoldersToolStripMenuItem";
            this.chooseSearchFoldersToolStripMenuItem.Size = new System.Drawing.Size(355, 34);
            this.chooseSearchFoldersToolStripMenuItem.Text = "&Choose Search Folders";
            this.chooseSearchFoldersToolStripMenuItem.Click += new System.EventHandler(this.chooseSearchFoldersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(352, 6);
            // 
            // updateIndexToolStripMenuItem
            // 
            this.updateIndexToolStripMenuItem.Name = "updateIndexToolStripMenuItem";
            this.updateIndexToolStripMenuItem.Size = new System.Drawing.Size(355, 34);
            this.updateIndexToolStripMenuItem.Text = "&Update Index";
            this.updateIndexToolStripMenuItem.Click += new System.EventHandler(this.updateIndexToolStripMenuItem_Click);
            // 
            // resetIndexToolStripMenuItem
            // 
            this.resetIndexToolStripMenuItem.Name = "resetIndexToolStripMenuItem";
            this.resetIndexToolStripMenuItem.Size = new System.Drawing.Size(355, 34);
            this.resetIndexToolStripMenuItem.Text = "&Reset Index";
            this.resetIndexToolStripMenuItem.Click += new System.EventHandler(this.resetIndexToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.cancelToolStripMenuItem.Text = "&Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMyMediaSearchToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutMyMediaSearchToolStripMenuItem
            // 
            this.aboutMyMediaSearchToolStripMenuItem.Name = "aboutMyMediaSearchToolStripMenuItem";
            this.aboutMyMediaSearchToolStripMenuItem.Size = new System.Drawing.Size(362, 34);
            this.aboutMyMediaSearchToolStripMenuItem.Text = "About My Media Search";
            this.aboutMyMediaSearchToolStripMenuItem.Click += new System.EventHandler(this.aboutMyMediaSearchToolStripMenuItem_Click);
            // 
            // WatcherToUpdateTimer
            // 
            this.WatcherToUpdateTimer.Enabled = true;
            this.WatcherToUpdateTimer.Interval = 1000;
            this.WatcherToUpdateTimer.Tick += new System.EventHandler(this.WatcherToUpdateTimer_Tick);
            // 
            // TheListView
            // 
            this.TheListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TheListView.HideSelection = false;
            this.TheListView.Location = new System.Drawing.Point(15, 80);
            this.TheListView.MultiSelect = false;
            this.TheListView.Name = "TheListView";
            this.TheListView.Size = new System.Drawing.Size(829, 338);
            this.TheListView.TabIndex = 18;
            this.TheListView.UseCompatibleStateImageBehavior = false;
            this.TheListView.DoubleClick += new System.EventHandler(this.TheListView_DoubleClick);
            this.TheListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TheListView_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 457);
            this.Controls.Add(this.TheListView);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MainForm";
            this.Text = "My Media Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.SearchResultsContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ContextMenuStrip SearchResultsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSearchInfoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMyMediaSearchToolStripMenuItem;
        private System.Windows.Forms.Timer WatcherToUpdateTimer;
        private System.Windows.Forms.ListView TheListView;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseSearchFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showInFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem getSearchInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

