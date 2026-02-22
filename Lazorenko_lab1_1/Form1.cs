using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lazorenko_lab1_1
{
    public partial class Form1 : Form
    {
        string currentFile = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbActions.Items.Add("New");
            cmbActions.Items.Add("Open");
            cmbActions.Items.Add("Save");
            cmbActions.Items.Add("Exit");
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string action = cmbActions.SelectedItem?.ToString();

            if (action == "New")
            {
                txtDocument.Clear();
                currentFile = "";
            }
            else if (action == "Open")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDocument.Text = File.ReadAllText(ofd.FileName);
                    currentFile = ofd.FileName;
                }
            }
            else if (action == "Save")
            {
                if (currentFile == "")
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Text Files (*.txt)|*.txt";
                    sfd.DefaultExt = "txt";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                        currentFile = sfd.FileName;
                }

                File.WriteAllText(currentFile, txtDocument.Text);
            }
            else if (action == "Exit")
            {
                Application.Exit();
            }
        }
    }
}
