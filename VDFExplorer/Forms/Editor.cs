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
        public Dictionary<VDFCatagory, TreeNode> catagoryNodes;
        public Dictionary<VDFItem, TreeNode> itemNodes;

        public Editor(MenuForm menu)
        {
            InitializeComponent();
            menuForm = menu;
            Log.LogInfo("Opening editor");
            menuForm.Hide();

            catagoryNodes = new Dictionary<VDFCatagory, TreeNode>();
            itemNodes = new Dictionary<VDFItem, TreeNode>();
            treeView1.Nodes.Clear();
        }

        public void OpenVDF(string path)
        {
            vdf = VDFReader.LoadVDF(path);
            savePath = path;

            // GeneralUtil.Info("VDF Name: " + vdf.name);
            vdfNameText.Text = "VDF Name: " + vdf.name;
        }

        public void OpenVDF(VDF vdf)
        {
            this.vdf = vdf;
            savePath = vdf.savePath;

            // GeneralUtil.Info("VDF Name: " + vdf.name);
            vdfNameText.Text = "VDF Name: " + vdf.name;
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
                NewVDF newVDF = new NewVDF(menuForm);
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
            } else
            {
                Log.LogInfo("Browse cancelled");
                return;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VDF Explorer. Utility program for viewing and editing VDF files.", "About");
        }

        private void addCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string catagoryName = "Catagory";
            ShowInputDialog(ref catagoryName, "Catagory name");

            VDFCatagory catagory = new VDFCatagory(catagoryName);
            vdf.AddCatagory(catagory);
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
                default:
                    return;
            }

            vdf.items.Add(item);
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
    }
}
