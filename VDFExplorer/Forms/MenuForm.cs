using System;
using System.IO;
using System.Windows.Forms;
using VDFExplorer.Util;

namespace VDFExplorer.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            Log.Init();
            Log.LogInfo("Initialised");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log.LogInfo("Exiting...");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewVDF newVDF = new NewVDF(this);
            newVDF.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Log.LogInfo("Opening VDF file");
            DialogResult result = openDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Log.LogInfo("Opening: " + openDialog.FileName);

                if (!File.Exists(openDialog.FileName))
                {
                    GeneralUtil.Error("File not found.");
                    return;
                }

                Editor editor = new Editor(this);
                editor.OpenVDF(openDialog.FileName);
                editor.Show();
                Hide();
            } else
            {
                Log.LogInfo("VDF Opening cancelled");
            }
        }
    }
}
