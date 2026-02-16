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
            Editor.IsEnabled = true; // дозволяємо вводити текст
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string action = (ActionBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(action))
            {
                MessageBox.Show("Будь ласка, виберіть дію.");
                return;
            }

            if (action == "New")
            {
                Editor.Clear();
                currentFile = "";
            }
            else if (action == "Open")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Files (*.txt)|*.txt";
                if (ofd.ShowDialog() == true)
                {
                    Editor.Text = File.ReadAllText(ofd.FileName);
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

                File.WriteAllText(currentFile, Editor.Text);
            }
            else if (action == "Exit")
            {
                this.Close(); // закриваємо вікно
            }
        }
    }
}
