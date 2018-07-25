using System;
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
            GeneralUtil.NotImplementedError();
        }
    }
}
