namespace fql
{
    partial class DirectoriesInPicker
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
            this.MediaFoldersTree = new System.Windows.Forms.TreeView();
            this.FoldersToIncludeListbox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RemoveIncludeFolderButton = new System.Windows.Forms.Button();
            this.AddIncludeFolderButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.FormCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MediaFoldersTree
            // 
            this.MediaFoldersTree.Location = new System.Drawing.Point(11, 32);
            this.MediaFoldersTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MediaFoldersTree.Name = "MediaFoldersTree";
            this.MediaFoldersTree.Size = new System.Drawing.Size(331, 399);
            this.MediaFoldersTree.TabIndex = 0;
            // 
            // FoldersToIncludeListbox
            // 
            this.FoldersToIncludeListbox.FormattingEnabled = true;
            this.FoldersToIncludeListbox.ItemHeight = 25;
            this.FoldersToIncludeListbox.Location = new System.Drawing.Point(7, 29);
            this.FoldersToIncludeListbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FoldersToIncludeListbox.Name = "FoldersToIncludeListbox";
            this.FoldersToIncludeListbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FoldersToIncludeListbox.Size = new System.Drawing.Size(314, 329);
            this.FoldersToIncludeListbox.Sorted = true;
            this.FoldersToIncludeListbox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MediaFoldersTree);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(348, 440);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Media Folders To Choose";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FoldersToIncludeListbox);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(759, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(336, 388);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "The Media Folders To Search In";
            // 
            // RemoveIncludeFolderButton
            // 
            this.RemoveIncludeFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveIncludeFolderButton.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveIncludeFolderButton.Location = new System.Drawing.Point(376, 269);
            this.RemoveIncludeFolderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveIncludeFolderButton.Name = "RemoveIncludeFolderButton";
            this.RemoveIncludeFolderButton.Size = new System.Drawing.Size(377, 45);
            this.RemoveIncludeFolderButton.TabIndex = 7;
            this.RemoveIncludeFolderButton.Text = "<< Remove Folder To Search In <<";
            this.RemoveIncludeFolderButton.UseVisualStyleBackColor = true;
            this.RemoveIncludeFolderButton.Click += new System.EventHandler(this.RemoveIncludeFolderButton_Click);
            // 
            // AddIncludeFolderButton
            // 
            this.AddIncludeFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddIncludeFolderButton.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddIncludeFolderButton.Location = new System.Drawing.Point(376, 216);
            this.AddIncludeFolderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddIncludeFolderButton.Name = "AddIncludeFolderButton";
            this.AddIncludeFolderButton.Size = new System.Drawing.Size(377, 45);
            this.AddIncludeFolderButton.TabIndex = 5;
            this.AddIncludeFolderButton.Text = ">> Add Folder To Search In >>";
            this.AddIncludeFolderButton.UseVisualStyleBackColor = true;
            this.AddIncludeFolderButton.Click += new System.EventHandler(this.AddIncludeFolderButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(759, 474);
            this.OkButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(151, 45);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // FormCancelButton
            // 
            this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.FormCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormCancelButton.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormCancelButton.Location = new System.Drawing.Point(945, 474);
            this.FormCancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FormCancelButton.Name = "FormCancelButton";
            this.FormCancelButton.Size = new System.Drawing.Size(151, 45);
            this.FormCancelButton.TabIndex = 8;
            this.FormCancelButton.Text = "Cancel";
            this.FormCancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "What Folders Do You Want To Search In?";
            // 
            // DirectoriesInPicker
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FormCancelButton;
            this.ClientSize = new System.Drawing.Size(1112, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormCancelButton);
            this.Controls.Add(this.RemoveIncludeFolderButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AddIncludeFolderButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DirectoriesInPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Media Search - Pick Which Media File Folders To Search In";
            this.Load += new System.EventHandler(this.DirectoriesPicker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView MediaFoldersTree;
        private System.Windows.Forms.ListBox FoldersToIncludeListbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddIncludeFolderButton;
        private System.Windows.Forms.Button RemoveIncludeFolderButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button FormCancelButton;
        private System.Windows.Forms.Label label1;
    }
}