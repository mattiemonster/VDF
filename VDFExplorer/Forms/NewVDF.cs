﻿using System;
using System.IO;
using VDFExplorer.Util;
using VDFLib;
using System.Windows.Forms;

namespace VDFExplorer.Forms
{
    public partial class NewVDF : Form
    {
        MenuForm menuForm;
        bool closedByUser = true;
        RecentItems recent;

        public NewVDF(MenuForm menu, RecentItems recentItems)
        {
            InitializeComponent();
            menuForm = menu;
            recent = recentItems;
        }

        private void NewVDF_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called when the browse button is pressed
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Log.LogInfo("Browsing for save location");
            DialogResult result = saveDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                Log.LogInfo("Browse cancelled");
                return;
            } else {
                pathTextBox.Text = saveDialog.FileName;
                Log.LogInfo("Save location selected: " + saveDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                GeneralUtil.Error("You must give your VDF a name");
                return;
            }

            if (String.IsNullOrEmpty(pathTextBox.Text))
            {
                GeneralUtil.Error("You must give a save path for the VDF");
                return;
            }

            if (!Directory.Exists(Path.GetDirectoryName(pathTextBox.Text)))
            {
                GeneralUtil.Error("The directory where you'd like to save the VDF doesn't exist");
                return;
            }

            VDF vdf = new VDF(nameTextBox.Text);
            vdf.Save(pathTextBox.Text);

            Editor editor = new Editor(menuForm, recent);
            editor.OpenVDF(vdf);
            editor.SetPath(pathTextBox.Text);
            recent.AddItem(pathTextBox.Text);
            recent.Save();
            menuForm.RefreshRecentItems();
            editor.Show();
            closedByUser = false;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            menuForm.Show();
            Close();
        }

        private void NewVDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedByUser)
                menuForm.Show();
        }
    }
}
