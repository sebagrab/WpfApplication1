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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string soft;
        string hardwer;
        string fikstura;
        string program;
        string skladnia;
        string path;
        string[] nrstacji = new string[30];
        string ostatninr;
        string TE;
        string ok;
        private object wiersz;
        private string duplikat1;

        public Window2()
        {
            InitializeComponent();
            
        }

        private void txtBarcode1_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.Key == Key.Return)
            {
                
                button2_Click(this, new RoutedEventArgs());
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ok = "ok";
            stacja();
            
            fikstura = textBox2.Text;
            Nowafikstura();
            if (ok == "ok" && fikstura!="")
            {
                zapis();
                System.Windows.MessageBox.Show("Zapisano");
            }
        }

        public void czekaj()
        {
            ok = "nok";
        }
    
        public void stacja()
        {
            string softok = "1";
            if ((bool)checkBox1.IsChecked == false && (bool)checkBox2.IsChecked == false)
            {
                System.Windows.MessageBox.Show("Nie wybrano software");
                czekaj();
                softok = "0";
            }

            if ((bool)checkBox1.IsChecked == true && (bool)checkBox2.IsChecked == true)
            {
                czekaj();
                System.Windows.MessageBox.Show("Zaznaczono 2 software");
                softok = "0";
            }

            if ((bool)checkBox1.IsChecked == true && softok == "1")
            { soft = "Manufacturing"; }

            if ((bool)checkBox2.IsChecked == true && softok == "1")
            { soft = "Spider Client"; }


            string hardwok = "1";
            if ((bool)checkBox3.IsChecked == false && (bool)checkBox4.IsChecked == false)
            {
                czekaj();
                System.Windows.MessageBox.Show("Nie wybrano hardware");
                hardwok = "0";
            }

            if ((bool)checkBox3.IsChecked == true && (bool)checkBox4.IsChecked == true)
            {
                czekaj();
                System.Windows.MessageBox.Show("Zaznaczono 2 hardware");
                hardwok = "0";
            }

            if ((bool)checkBox3.IsChecked == true && hardwok == "1")
            { hardwer = "Manufacturing"; }

            if ((bool)checkBox4.IsChecked == true && hardwok == "1")
            { hardwer = "Spider Client"; }
        
            
        }

        public void zapis()
        {
            string zda = "";
            string path = (@"c:\opis\fix.txt");
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(path);
                string sg = "";
                
                // do
                while (sg != "end")// ;
                {
                    sg = sr.ReadLine();

                    sb.AppendLine(sg);
                    if (sg != "end")
                    {
                        if (zda != "")
                            zda = (zda + "\r\n" + sg);
                        if (zda == "")
                            zda = sg ;

                    }
                } //while (sg != "end");
                sr.Close();

                StreamWriter sw = new StreamWriter(path);

                
                
                skladnia = program + "," + soft + "," + hardwer + "," + fikstura+";";
               // sw.WriteLine(skladnia + zda + "\r\n" + "end" );
                sw.WriteLine(zda + "\r\n" + skladnia + "\r\n" + "end");
                sw.Close();
                Close();
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            NumerTE.Visibility = Visibility.Visible;
            tbnumerte.Visibility = Visibility.Visible;
        }

        public void Nowafikstura()
        {
            if ((bool)checkboxn.IsChecked == true)
                {
                string tx = "";
               
                string path = (@"c:\opis\numeryTE.txt");
                if (File.Exists(path))
                {
                    StringBuilder sb = new StringBuilder();

                    StreamReader sr = new StreamReader(path);
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);
                    while ("end" != Convert.ToString(tx))
                    {
                        int c = 0;
                        string[] nrstacji = new string[30];
                        while (Convert.ToString(tx[c]) != ",")
                        {
                            nrstacji[c] = Convert.ToString(tx[c]);
                            c++;
                           
                        }
                        tx = sr.ReadLine();
                        sb.AppendLine(tx);
                        ostatninr = string.Concat(nrstacji);
                    }
                    int a = Convert.ToInt32(ostatninr);
                    a++;
                    sr.Close();
                    
                    ostatninr = Convert.ToString(a);
                   // System.Windows.MessageBox.Show(ostatninr);     //odczyt ostatniego numeru w piku numery TE

                    StringBuilder sb1 = new StringBuilder();

                    StreamReader sr1 = new StreamReader(path);

                    string sg = "";
                    sg = sr1.ReadLine();
                    sb1.AppendLine(sg);
                   
                    string zda = sg;
                    // do
                    while (sg != "end")// ;
                    {
                        sg = sr1.ReadLine();

                        sb1.AppendLine(sg);
                        if (sg != "end")
                        {
                            zda = (zda + "\r\n" + sg);
                       
                        }
                    } //while (sg != "end");
                    sr1.Close();
                   
                    

                    TE = tbnumerte.Text;
                    fikstura = ostatninr;
                    if (TE == "")
                    {
                        czekaj();
                        System.Windows.MessageBox.Show("Brak numeru TE");
                    }
                    if (ok=="ok")
                    {
                        StreamWriter sw = new StreamWriter(path);
                        skladnia = ostatninr + "," + TE + ";";
                        sw.WriteLine(zda + "\r\n" + skladnia + "\r\n" + "end");
                        sw.Close();

                    }
                   
                }
                if (ok=="ok")
                {
                    System.Windows.MessageBox.Show("Oklej fiksture  " + TE + "\r\n" + "Numerem :   " + ostatninr);
                }
            } 
        }

        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string[] progra;

            
            progra = new string[30];
            string barkod = textBox5.Text;
            
            
            program = "";

            //////
           
            int i = 0;
            while (Convert.ToString(barkod[i]) != ",")
            {

                i++;
            }
            i++;
            while (Convert.ToString(barkod[i]) != ",")
            {
                progra[i] = Convert.ToString(barkod[i]);
                i++;
            }

            program = String.Concat(progra);
            label5.Content = program;


            ///


            
            
        }

        

       

        




    }

}
