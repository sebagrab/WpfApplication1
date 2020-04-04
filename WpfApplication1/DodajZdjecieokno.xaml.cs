using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WpfApplication1
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string plik="nie";
        string z_kat;


        public Window3()
        {
            InitializeComponent();

            for (int x = 1; x <= 120; x++)
            {

                comboBox.Items.Add(x.ToString());
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            plik = "tak";
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                plik = "tak";
                z_kat = openFileDlg.FileName;
                label_sciezka.Content = z_kat;

            }
        }

        private void bt_zapisz_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox.Text!=""&&plik=="tak")
            {
                string plik = @"\\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\" + comboBox.Text + ".jpg";

                System.IO.File.Copy(z_kat, plik, true);
            }
        }


        private void bt_info_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = @"cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.Start();
            StreamWriter myStreamWriter = myProcess.StandardInput;
            myStreamWriter.WriteLine("\\\\plkwim0taxlog57\\c$\\Users\\kwi_tester\\AppData\\Local\\Programs\\Python\\Python38-32\\python.exe \\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\brak_zdjec.py");
            myStreamWriter.Close();
            myProcess.WaitForExit();

            string path = (@"\\\\plkwim0taxlog57\\c$\opis\\zdjecia\\brak_zdjęć.txt");
            //string path = (@"c:\\opis\\zdjecia\\brak_zdjęć.txt");
            StreamReader sr = new StreamReader(path);
            string sg = "";
            sg = sr.ReadToEnd();
           
            textblock.Text = sg;


        }


    }
}
