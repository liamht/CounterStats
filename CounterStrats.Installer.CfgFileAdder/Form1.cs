using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                File.Copy("gamestate_integration_counterstrats.cfg", cfgLocation);
        }

        private bool CheckFolderIsValidCounterStrikeFolder(string selectedPath)
        {
            return File.Exists(selectedPath + "\\csgo.exe");
        }
        
    }
}
