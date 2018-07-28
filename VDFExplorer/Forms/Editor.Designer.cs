namespace VDFExplorer.Forms
{
    partial class Editor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Catagory Item");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Catagory", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Item");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatagoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatagoryToSelectedCatagoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToSelectedCatagoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameVDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vdfNameText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.valueTitleLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 55);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "CatagoryItem";
            treeNode1.Text = "Catagory Item";
            treeNode2.Name = "";
            treeNode2.Text = "Catagory";
            treeNode3.Name = "Item";
            treeNode3.Text = "Item";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(314, 484);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vDFToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitEditorToolStripMenuItem,
            this.exitProgramToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // exitEditorToolStripMenuItem
            // 
            this.exitEditorToolStripMenuItem.Name = "exitEditorToolStripMenuItem";
            this.exitEditorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitEditorToolStripMenuItem.Text = "Exit Editor";
            this.exitEditorToolStripMenuItem.Click += new System.EventHandler(this.exitEditorToolStripMenuItem_Click);
            // 
            // exitProgramToolStripMenuItem
            // 
            this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitProgramToolStripMenuItem.Text = "Exit Program";
            this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
            // 
            // vDFToolStripMenuItem
            // 
            this.vDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCatagoryToolStripMenuItem,
            this.addCatagoryToSelectedCatagoryToolStripMenuItem,
            this.addItemToRootToolStripMenuItem,
            this.addItemToSelectedCatagoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.renameVDFToolStripMenuItem});
            this.vDFToolStripMenuItem.Name = "vDFToolStripMenuItem";
            this.vDFToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.vDFToolStripMenuItem.Text = "VDF";
            // 
            // addCatagoryToolStripMenuItem
            // 
            this.addCatagoryToolStripMenuItem.Name = "addCatagoryToolStripMenuItem";
            this.addCatagoryToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addCatagoryToolStripMenuItem.Text = "Add catagory";
            this.addCatagoryToolStripMenuItem.Click += new System.EventHandler(this.addCatagoryToolStripMenuItem_Click);
            // 
            // addCatagoryToSelectedCatagoryToolStripMenuItem
            // 
            this.addCatagoryToSelectedCatagoryToolStripMenuItem.Name = "addCatagoryToSelectedCatagoryToolStripMenuItem";
            this.addCatagoryToSelectedCatagoryToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addCatagoryToSelectedCatagoryToolStripMenuItem.Text = "Add catagory to selected catagory";
            this.addCatagoryToSelectedCatagoryToolStripMenuItem.Click += new System.EventHandler(this.addCatagoryToSelectedCatagoryToolStripMenuItem_Click);
            // 
            // addItemToRootToolStripMenuItem
            // 
            this.addItemToRootToolStripMenuItem.Name = "addItemToRootToolStripMenuItem";
            this.addItemToRootToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addItemToRootToolStripMenuItem.Text = "Add item to root";
            this.addItemToRootToolStripMenuItem.Click += new System.EventHandler(this.addItemToRootToolStripMenuItem_Click);
            // 
            // addItemToSelectedCatagoryToolStripMenuItem
            // 
            this.addItemToSelectedCatagoryToolStripMenuItem.Name = "addItemToSelectedCatagoryToolStripMenuItem";
            this.addItemToSelectedCatagoryToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addItemToSelectedCatagoryToolStripMenuItem.Text = "Add item to selected catagory";
            this.addItemToSelectedCatagoryToolStripMenuItem.Click += new System.EventHandler(this.addItemToSelectedCatagoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // renameVDFToolStripMenuItem
            // 
            this.renameVDFToolStripMenuItem.Name = "renameVDFToolStripMenuItem";
            this.renameVDFToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.renameVDFToolStripMenuItem.Text = "Rename VDF";
            this.renameVDFToolStripMenuItem.Click += new System.EventHandler(this.renameVDFToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "vdf";
            this.openFileDialog1.FileName = "openDialog";
            this.openFileDialog1.Filter = "VDF File|*.vdf";
            this.openFileDialog1.Title = "Open VDF file";
            // 
            // vdfNameText
            // 
            this.vdfNameText.AutoSize = true;
            this.vdfNameText.Location = new System.Drawing.Point(12, 32);
            this.vdfNameText.Name = "vdfNameText";
            this.vdfNameText.Size = new System.Drawing.Size(65, 13);
            this.vdfNameText.TabIndex = 2;
            this.vdfNameText.Text = "VDF Name: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Rename";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // valueTitleLabel
            // 
            this.valueTitleLabel.AutoSize = true;
            this.valueTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueTitleLabel.Location = new System.Drawing.Point(336, 55);
            this.valueTitleLabel.Name = "valueTitleLabel";
            this.valueTitleLabel.Size = new System.Drawing.Size(55, 20);
            this.valueTitleLabel.TabIndex = 4;
            this.valueTitleLabel.Text = "Value";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(77, 17);
            this.statusLabel.Text = "Editor loaded";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.valueTitleLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vdfNameText);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem vDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCatagoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renameVDFToolStripMenuItem;
        private System.Windows.Forms.Label vdfNameText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem addCatagoryToSelectedCatagoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addItemToSelectedCatagoryToolStripMenuItem;
        private System.Windows.Forms.Label valueTitleLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}