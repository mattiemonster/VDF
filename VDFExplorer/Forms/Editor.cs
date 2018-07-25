using System;
using System.Windows.Forms;

using VDFExplorer.Util;
using VDFLib;

namespace VDFExplorer.Forms
{
    public partial class Editor : Form
    {
        public MenuForm menuForm;

        public Editor(MenuForm menu)
        {
            InitializeComponent();
            menuForm = menu;
            Log.LogInfo("Opening editor");
            menuForm.Hide();
        }

        public void OpenVDF(string path)
        {
            GeneralUtil.NotImplementedError();
        }

        public void OpenVDF(VDF vdf)
        {
            GeneralUtil.NotImplementedError();
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
            GeneralUtil.NotImplementedError();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralUtil.NotImplementedError();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VDF Explorer. Utility program for viewing and editing VDF files.", "About");
        }
    }
}
