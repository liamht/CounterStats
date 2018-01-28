using System;
using System.IO;
using System.Windows.Forms;

namespace CounterStrats.Installer.CfgFileAdder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }


        private void ConfirmFileLocation_Click(object sender, EventArgs e)
        {
            if (CheckFolderIsValidCounterStrikeFolder(folderBrowserDialog1.SelectedPath))
            {
                AddConfigFileToSelectedPath(folderBrowserDialog1.SelectedPath);
                Application.Exit();
            }
            else
            {
                ErrorMessage.Text = @"The folder you specified does not contain your csgo.exe file. Please select the correct folder.";
            }
        }

        private void AddConfigFileToSelectedPath(string selectedPath)
        {
                var cfgLocation = selectedPath + "\\csgo\\cfg\\gamestate_integration_counterstrats.cfg";
                File.Copy("gamestate_integration_counterstrats.cfg", cfgLocation, true);
        }

        private bool CheckFolderIsValidCounterStrikeFolder(string selectedPath)
        {
            return File.Exists(selectedPath + "\\csgo.exe");
        }
        
    }
}
