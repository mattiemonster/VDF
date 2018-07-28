using System;
using System.Collections.Generic;
using System.Windows.Forms;

using VDFExplorer.Util;
using VDFLib;
using VDFLib.Items;

namespace VDFExplorer.Forms
{
    public partial class Editor : Form
    {
        public MenuForm menuForm;
        public VDF vdf;
        public string savePath;
        public static int inputBoxWidth = 350;
        public Dictionary<VDFCatagory, TreeNode> catagories;
        public Dictionary<TreeNode, VDFCatagory> catagoryViaNode;
        public Dictionary<VDFItem, TreeNode> items;
        public Dictionary<TreeNode, VDFItem> itemViaNode;
        public Dictionary<TreeNode, string> nodeType;
        public List<TreeNode> catagoryNodes;
        public List<TreeNode> itemNodes;

        public RecentItems recentItems;

        public Editor(MenuForm menu, RecentItems newRecentItems)
        {
            InitializeComponent();
            menuForm = menu;
            Log.LogInfo("Opening editor");
            menuForm.Hide();

            catagories = new Dictionary<VDFCatagory, TreeNode>();
            catagoryViaNode = new Dictionary<TreeNode, VDFCatagory>();
            items = new Dictionary<VDFItem, TreeNode>();
            nodeType = new Dictionary<TreeNode, string>();
            catagoryNodes = new List<TreeNode>();
            itemNodes = new List<TreeNode>();
            itemViaNode = new Dictionary<TreeNode, VDFItem>();
            treeView1.Nodes.Clear();

            recentItems = newRecentItems;
        }

        public void OpenVDF(string path)
        {
            vdf = VDFReader.LoadVDF(path);
            savePath = path;

            // GeneralUtil.Info("VDF Name: " + vdf.name);
            vdfNameText.Text = "VDF Name: " + vdf.name;

            LoadVDF();
        }

        public void OpenVDF(VDF vdf)
        {
            this.vdf = vdf;
            savePath = vdf.savePath;

            // GeneralUtil.Info("VDF Name: " + vdf.name);
            vdfNameText.Text = "VDF Name: " + vdf.name;

            LoadVDF();
        }

        public void LoadVDF()
        {
            treeView1.Nodes.Clear();
            catagories.Clear();
            items.Clear();

            // Catagories
            foreach (VDFCatagory cat in vdf.catagories)
            {
                TreeNode node = new TreeNode(cat.name);
                nodeType.Add(node, "Catagory");
                catagories.Add(cat, node);
                foreach (VDFItem item in cat.items)
                {
                    TreeNode itemNode = new TreeNode(item.name);
                    node.Nodes.Add(itemNode);
                    itemNodes.Add(itemNode);
                    items.Add(item, itemNode);
                    itemViaNode.Add(itemNode, item);
                    nodeType.Add(itemNode, "Item");
                }
                catagoryViaNode.Add(node, cat);
                catagoryNodes.Add(node);
                treeView1.Nodes.Add(node);
            }

            // Items
            foreach (VDFItem item in vdf.items)
            {
                TreeNode node = new TreeNode(item.name);
                items.Add(item, node);
                itemNodes.Add(node);
                treeView1.Nodes.Add(node);
                nodeType.Add(node, "Item");
                itemViaNode.Add(node, item);
            }

            SetStatus("Loaded VDF: " + vdf.name);

        }

        public void LoadCatagory(VDFCatagory cat)
        {

            
            //if (cat.catagories.Count != 0)
            //{
            //    foreach (VDFCatagory cata in cat.catagories)
            //    {
            //        LoadCatagory(cata, cat);
            //    }
            //}

            //if (parent != null)
            //{
            //    TreeNode parentNode = catagories[parent];
            //    catagories.Remove(parent);
            //    parentNode.Nodes.Add(node);
            //    // treeView1.Nodes.Add(parentNode);
            //    catagories.Add(parent, parentNode);
            //}

        }

        public void SetPath(string newPath)
        {
            savePath = newPath;
        }

        private void exitEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Editor closing", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Log.LogInfo("Closing editor");
                menuForm.Show();
                Close();
            }
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Program closing", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Log.LogInfo("Closing program");
                menuForm.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Editor closing", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                NewVDF newVDF = new NewVDF(menuForm, recentItems);
                newVDF.Show();
                Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vdf.Save(savePath);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            Log.LogInfo("Browsing for VDF to open");
            if (result == DialogResult.OK)
            {
                OpenVDF(openFileDialog1.FileName);
                recentItems.AddItem(openFileDialog1.FileName);
                recentItems.Save();
                menuForm.RefreshRecentItems();
            } else
            {
                Log.LogInfo("Browse cancelled");
                return;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VDF Explorer. Utility program for creating, viewing and editing VDF files.", "About");
        }

        private void addCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string catagoryName = "Catagory";
            ShowInputDialog(ref catagoryName, "Catagory name");

            if (string.IsNullOrEmpty(catagoryName))
            {
                GeneralUtil.Error("The catagory name must not be empty.");
                return;
            }

            VDFCatagory catagory = new VDFCatagory(catagoryName);
            vdf.AddCatagory(catagory);

            LoadVDF();
        }

        private static DialogResult ShowInputDialog(ref string input, string title)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private static DialogResult ShowItemTypeBox(ref VDFItemType type, string title)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            ComboBox comboBox = new ComboBox();
            comboBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            comboBox.Location = new System.Drawing.Point(5, 5);
            comboBox.Items.Clear();
            comboBox.Items.Add("String");
            comboBox.Items.Add("Int");
            comboBox.Items.Add("Float");
            comboBox.Items.Add("Boolean");
            comboBox.Items.Add("Double");
            comboBox.Items.Add("Long");
            inputBox.Controls.Add(comboBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            if (comboBox.SelectedIndex == 0)
                type = VDFItemType.String;
            else if (comboBox.SelectedIndex == 1)
                type = VDFItemType.Int;
            else if (comboBox.SelectedIndex == 2)
                type = VDFItemType.Float;
            else if (comboBox.SelectedIndex == 3)
                type = VDFItemType.Boolean;
            else if (comboBox.SelectedIndex == 4)
                type = VDFItemType.Double;
            else if (comboBox.SelectedIndex == 5)
                type = VDFItemType.Long;
            return result;
        }

        private static DialogResult ShowBoolBox(ref bool value, string title)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            
            CheckBox checkBox = new CheckBox();
            checkBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            checkBox.Location = new System.Drawing.Point(5, 5);
            checkBox.Text = "Enabled";
            inputBox.Controls.Add(checkBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            if (checkBox.Checked)
                value = true;
            else
                value = false;
            return result;
        }

        private static DialogResult ShowIntBox(ref int input, string title, decimal maxValue)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Size = new System.Drawing.Size(size.Width - 10, 23);
            numericUpDown.Location = new System.Drawing.Point(5, 5);
            numericUpDown.Maximum = maxValue;
            inputBox.Controls.Add(numericUpDown);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = (int)numericUpDown.Value;
            return result;
        }

        private static DialogResult ShowDoubleBox(ref double input, string title, double maxValue)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Size = new System.Drawing.Size(size.Width - 10, 23);
            numericUpDown.Location = new System.Drawing.Point(5, 5);
            numericUpDown.Maximum = (decimal)maxValue;
            inputBox.Controls.Add(numericUpDown);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = (int)numericUpDown.Value;
            return result;
        }
        
        private static DialogResult ShowLongBox(ref long input, string title, long maxValue)
        {
            System.Drawing.Size size = new System.Drawing.Size(inputBoxWidth, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Size = new System.Drawing.Size(size.Width - 10, 23);
            numericUpDown.Location = new System.Drawing.Point(5, 5);
            numericUpDown.Maximum = (decimal)maxValue;
            inputBox.Controls.Add(numericUpDown);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = (int)numericUpDown.Value;
            return result;
        }

        private void addItemToRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VDFItemType type = VDFItemType.String;
            ShowItemTypeBox(ref type, "Item type");

            string itemName = "Item";
            ShowInputDialog(ref itemName, "Item name");

            VDFItem item;

            switch(type)
            {
                case VDFItemType.String:
                    string input = "String";
                    ShowInputDialog(ref input, "Set string");
                    item = new VDFStringItem(itemName, input);
                    break;
                case VDFItemType.Boolean:
                    bool boolInput = false;
                    ShowBoolBox(ref boolInput, "Set bool");
                    item = new VDFBoolItem(itemName, boolInput);
                    break;
                case VDFItemType.Int:
                    int intInput = 0;
                    ShowIntBox(ref intInput, "Set int", int.MaxValue);
                    item = new VDFIntItem(itemName, intInput);
                    break;
                case VDFItemType.Double:
                    double doubleInput = 0;
                    ShowDoubleBox(ref doubleInput, "Set double", double.MaxValue);
                    item = new VDFDoubleItem(itemName, doubleInput);
                    break;
                case VDFItemType.Long:
                    long longInput = 0;
                    ShowLongBox(ref longInput, "Set long", long.MaxValue);
                    item = new VDFLongItem(itemName, longInput);
                    break;
                case VDFItemType.Float:
                    GeneralUtil.NotImplementedError("Float setting unavailable");
                    item = new VDFFloatItem(itemName, 0.0f);
                    break;
                default:
                    return;
            }

            SetStatus("Created item: " + item.name);
            vdf.items.Add(item);

            LoadVDF();
        }

        void SetStatus(string msg)
        {
            statusStrip1.Items[0].Text = msg;
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuForm.Show();
        }

        void Rename()
        {
            string newName = vdf.name;
            ShowInputDialog(ref newName, "Rename VDF");
            vdf.name = newName;
            vdfNameText.Text = "VDF Name: " + vdf.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void renameVDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void addCatagoryToSelectedCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!catagoryNodes.Contains(treeView1.SelectedNode))
            //{
            //    GeneralUtil.Error("Selected object is not a catagory.");
            //    return;
            //}

            //string catagoryName = "Catagory";
            //ShowInputDialog(ref catagoryName, "Catagory name");

            //if (string.IsNullOrEmpty(catagoryName))
            //{
            //    GeneralUtil.Error("The catagory name must not be empty.");
            //    return;
            //}

            //VDFCatagory catagory = new VDFCatagory(catagoryName);
            //// catagoryNodes[treeView1.SelectedNode.Index].Text = "HI!";
            //vdf.catagories[treeView1.SelectedNode.Index].AddCatagory(catagory);

            //LoadVDF();
            GeneralUtil.NotImplementedError();
        }

        private void addItemToSelectedCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VDFItemType type = VDFItemType.String;
            if (ShowItemTypeBox(ref type, "Item type") == DialogResult.Cancel)
                return;

            string itemName = "Item";
            if (ShowInputDialog(ref itemName, "Item name") == DialogResult.Cancel)
                return;

            VDFCatagory cat = catagoryViaNode[treeView1.SelectedNode];
            VDFItem item;

            switch (type)
            {
                case VDFItemType.String:
                    string input = "String";
                    ShowInputDialog(ref input, "Set string");
                    item = new VDFStringItem(itemName, input);
                    break;
                case VDFItemType.Boolean:
                    bool boolInput = false;
                    ShowBoolBox(ref boolInput, "Set bool");
                    item = new VDFBoolItem(itemName, boolInput);
                    break;
                case VDFItemType.Int:
                    int intInput = 0;
                    ShowIntBox(ref intInput, "Set int", int.MaxValue);
                    item = new VDFIntItem(itemName, intInput);
                    break;
                case VDFItemType.Double:
                    double doubleInput = 0;
                    ShowDoubleBox(ref doubleInput, "Set double", double.MaxValue);
                    item = new VDFDoubleItem(itemName, doubleInput);
                    break;
                case VDFItemType.Long:
                    long longInput = 0;
                    ShowLongBox(ref longInput, "Set long", long.MaxValue);
                    item = new VDFLongItem(itemName, longInput);
                    break;
                case VDFItemType.Float:
                    GeneralUtil.NotImplementedError("Float setting unavailable");
                    item = new VDFFloatItem(itemName, 0.0f);
                    break;
                default:
                    return;
            }

            cat.AddItem(item);
            SetStatus("Created item: '" + item.name + "' in catagory: '" + cat.name + "'");

            LoadVDF();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int type = 0;

            if (nodeType[e.Node] == "Catagory")
            {
                typeLabel.Text = "Catagory";
                type = 0;
            }
            else if (nodeType[e.Node] == "Item")
            {
                typeLabel.Text = "Item";
                type = 1;
            }
            else
            {
                typeLabel.Text = "No item or catagory selected";
                return;
            }

            if (type == 0)
            {
                nameLabel.Text = catagoryViaNode[e.Node].name;
                valueTitleLabel.Text = "Item Count";
                valueLabel.Text = catagoryViaNode[e.Node].items.Count.ToString();
                changeValueButton.Enabled = false;
                changeNameButton.Enabled = true;
            } else if (type == 1)
            {
                nameLabel.Text = itemViaNode[e.Node].name;
                valueTitleLabel.Text = "Value";
                valueLabel.Text = itemViaNode[e.Node].value.ToString();
                changeValueButton.Enabled = true;
                changeNameButton.Enabled = true;
            }
        }
    }
}
