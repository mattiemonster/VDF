using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VDFExplorer.Util;

namespace VDFExplorer.Forms
{
    public partial class MenuForm : Form
    {

        public RecentItems recentItems = new RecentItems();

        public MenuForm()
        {
            InitializeComponent();
            Log.Init();
            Log.LogInfo("Initialised");

            // Init recent items
            Log.LogInfo("Initialising recent items");
            recentItems.Init();
            recentItems.Load();
            RefreshRecentItems();
        }

        public void RefreshRecentItems()
        {
            listBox1.Items.Clear();
            foreach (string item in recentItems.recentItems)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log.LogInfo("Exiting...");
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewVDF newVDF = new NewVDF(this, recentItems);
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

                Editor editor = new Editor(this, recentItems);
                editor.OpenVDF(openDialog.FileName);
                recentItems.AddItem(openDialog.FileName);
                recentItems.Save();
                RefreshRecentItems();
                editor.Show();
                Hide();
            } else
            {
                Log.LogInfo("VDF Opening cancelled");
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            recentItems.Close();
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            if (GeneralUtil.AskYesNo("Are you sure you want to remove this item?", "Removing recent item"))
            {
                recentItems.RemoveItemAt(listBox1.SelectedIndex);
                recentItems.Save();
                RefreshRecentItems();
            }
        }

        private void openSelectedButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists((string)listBox1.SelectedItem))
            {
                GeneralUtil.Error("File not found.");
                return;
            }

            Editor editor = new Editor(this, recentItems);
            editor.OpenVDF((string)listBox1.SelectedItem);
            recentItems.AddItem((string)listBox1.SelectedItem);
            recentItems.Save();
            RefreshRecentItems();
            editor.Show();
            Hide();
        }
    }
}
