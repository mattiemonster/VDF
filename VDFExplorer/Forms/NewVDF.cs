using System;
using VDFExplorer.Util;
using System.Windows.Forms;

namespace VDFExplorer.Forms
{
    public partial class NewVDF : Form
    {
        MenuForm menuForm;

        public NewVDF(MenuForm menu)
        {
            InitializeComponent();
            menuForm = menu;
        }

        private void NewVDF_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when the browse button is pressed
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = saveDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            } else {
                pathTextBox.Text = saveDialog.FileName;
                MessageBox.Show(saveDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneralUtil.NotImplementedError("Creating VDF not implemented");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            menuForm.Show();
            Close();
        }

        private void NewVDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuForm.Show();
        }
    }
}
