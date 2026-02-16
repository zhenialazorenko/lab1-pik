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
            comboBox1.Items.Add("New");
            comboBox1.Items.Add("Open");
            comboBox1.Items.Add("Save");
            comboBox1.Items.Add("Exit");
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string action = comboBox1.SelectedItem?.ToString();

            if (action == "New")
            {
                textBox1.Clear();
                currentFile = "";
            }
            else if (action == "Open")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = File.ReadAllText(ofd.FileName);
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

                File.WriteAllText(currentFile, textBox1.Text);
            }
            else if (action == "Exit")
            {
                Application.Exit();
            }
        }

    }
}
