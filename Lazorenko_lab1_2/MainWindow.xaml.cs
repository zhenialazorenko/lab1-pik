using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lazorenko_lab1_2
{
    public partial class MainWindow : Window
    {
        string currentFile = "";

        public MainWindow()
        {
            InitializeComponent();
            txtDocument.IsEnabled = true; // дозволяємо вводити текст
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            string action = (cmbActions.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(action))
            {
                MessageBox.Show("Будь ласка, виберіть дію.");
                return;
            }

            if (action == "New")
            {
                txtDocument.Clear();
                currentFile = "";
            }
            else if (action == "Open")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Files (*.txt)|*.txt";
                if (ofd.ShowDialog() == true)
                {
                    txtDocument.Text = File.ReadAllText(ofd.FileName);
                    currentFile = ofd.FileName;
                }
            }
            else if (action == "Save")
            {
                if (string.IsNullOrEmpty(currentFile))
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Text Files (*.txt)|*.txt";
                    sfd.DefaultExt = "txt";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == true)
                        currentFile = sfd.FileName;
                    else
                        return; // натиснули скасувати
                }

                File.WriteAllText(currentFile, txtDocument.Text);
            }
            else if (action == "Exit")
            {
                this.Close();
            }
        }
    }
}