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
    /// Logika interakcji dla klasy Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();

            for (int x = 1; x <= 120; x++)
            {

                combobox.Items.Add(x.ToString());
            }

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   string tx = "";
            int c = 0;
            label_numerte.Content = "";
            string szukaj = (string)combobox.SelectedItem;
            string numer = "";
            //string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\numeryTE.txt");
            string path = (@"c:\\opis\\numeryTE.txt");
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();

                StreamReader sr = new StreamReader(path);
                tx = sr.ReadLine();
                sb.AppendLine(tx);
                while ("end" != Convert.ToString(tx))
                {
                    string[] numerfix = new string[30];
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                        {
                            numerfix[c] = Convert.ToString(tx[c]);
                            c++;

                        }
                    numer = String.Concat(numerfix);
                    
                    c++;
                    if(numer==szukaj)
                    {
                        
                        string[] numerp = new string[30];
                        int p = 0;
                        while(p<7)
                        {
                            numerp[p] = Convert.ToString(tx[c]);
                            c++;
                            p++;
                            
                        }
                        label_numerte.Content = String.Concat(numerp);
                        
                    }
                    c = 0;
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);

                }
            }
        }
    }
}
