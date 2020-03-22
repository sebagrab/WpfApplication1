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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int b = 1;
        string a;
        string zda;
        string nove;
        string myString;
        string sg;
        string plik="nie";
        string z_kat = "";
        string fvt;
        string fix1;
        string fix2;
        string fix3;
        string fix4;
        int fix11;
        int fix22;
        int fix33;
        int fix44;
        public int wiersz;
        string fixtura;
        string duplikat_fix;
        string jest="nok";
        int []tablica =new int [20];
        public Window1()
        {
          //  wbSample.Navigate(@"\\plkwim0taxlog57\\c$\opis\");
          //  textBox2.Text = (zda);
        //     a = Convert.ToString(b);
            InitializeComponent();
         //   textBox1.Text =
          //  textBox1.Text = "1       Ultra Pan" + "\n" + "2       Ultra Pan" + "\n" + "3       Ultra Pan" + "\n" + "4       Ultra Pan" + "\n" + "5       Ultra Pan" + "\n" + "6       Ultra Pan" + "\n" + "7       Ultra Pan" + "\n" + "8       Ultra Pan" + "\n" + "9       Ultra Pan" + "\n" + "10       Ultra Pan" + "\n" + "11       Ultra Pan" + "\n" + "12       Ultra Pan" + "\n" + "13       Ultra Pan" + "\n" + "14       Ultra Pan" + "\n" + "15       Ultra Pan" + "\n" + "16       Ultra Pan" + "\n" + "17       Ultra Pan" + "\n" + "18       Ultra Pan" + "\n" + "19       Ultra Pan" + "\n" + "20       Ultra Pan" + "\n" + "21       Ultra Pan" + "\n" + "22       Ultra Pan" + "\n" + "23       Ultra Pan" + "\n" + "24       Ultra Pan" + "\n" + "25       Ultra Pan" + "\n" + "26       Ultra Pan" + "\n" + "27       Ultra Pan" + "\n" + "28       Ultra Pan" + "\n" + "29       Ultra Pan" + "\n" + "30       Ultra Pan" + "\n" + "31       Ultra Pan" + "\n" + "32       Ultra Pan" + "\n" + "33       Ultra Pan" + "\n" + "34       Ultra Pan" + "\n" + "35       Ultra Pan" + "\n" + "36        Ultra Pan" + "\n" + "37       Ultra Pan" + "\n" + "\n" + "38       Ultra Pan" + "\n" + "\n" + "39       Ultra Pan" + "\n" + "\n" + "40       Ultra Pan" + "\n" + "\n" + "41       Ultra Pan" + "\n" + "\n" + "42       Ultra Pan" + "\n" + "\n" + "43       Ultra Pan" + "\n" + "\n" + "44       Ultra Pan" + "\n" + "\n" + "45       Ultra Pan" + "\n" + "\n" + "46       Ultra Pan" + "\n" + "\n" + "47       Ultra Pan" + "\n" + "\n" + "48       Ultra Pan" + "\n" + "\n" + "49       Ultra Pan" + "\n" + "\n" + "50       Ultra Pan" + "\n" + "51       Ultra Pan" + "\n" +  "52       Ultra Pan" + "\n" +  "53       Ultra Pan" + "\n";



            for (int x = 1; x <= 120; x++)
            {
               
                comboBox1.Items.Add(x.ToString());
            }

        
          
            

        }

        public void opisy()
        {
            zda = "";
            fixtura = comboBox1.Text;
            dupikat();
            
            if (jest != "ok")
                duplikat_fix = comboBox1.Text;

            jest = "nok";

            
            string plik = @"\\\\plkwim0taxlog57\\c$\\opis\\info\\" + duplikat_fix +"\\"+txb_tytul.Text+".txt";
            
            File.WriteAllText(plik, textBox1.Text);
            MessageBox.Show("zapisano");

            

           

               

        }
    

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (txb_tytul.Text != "" && textBox1.Text != "" && comboBox1.Text!="")
            {
                opisy();
            }
            if (txb_tytul.Text != "" && plik== "tak" && comboBox1.Text != "")
            {
                fixtura = comboBox1.Text;
                dupikat();
                if (jest != "ok")
                    duplikat_fix = comboBox1.Text;
                jest = "nok";
                string destFile = @"\\\\plkwim0taxlog57\\c$\\opis\\info\\" + duplikat_fix + "\\" + txb_tytul.Text + ".pdf";
                System.IO.File.Copy(z_kat, destFile, true);
                
                MessageBox.Show("Zapisano");
            }
            if (comboBox1.Text == "")
                MessageBox.Show("Brak numeru fikstury");
            if (txb_tytul.Text == "")
                MessageBox.Show("Brak tytułu");
            if (plik != "tak" || textBox1.Text == "")
                //MessageBox.Show("Brak opisu lub nie wybrano pliku");
            
            plik = "";

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {


            Close();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                labelsciezka.Content = z_kat;

            }
        }

        public void dupikat()
        {
            string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\duplikat.txt");
            if (File.Exists(path))
            {
                
                int c = 0;
                string dupilkat = "";
                string dupilkat1 = "";
                string dupilkat2 = "";
                string dupilkat3 = "";
                string tx;
                jest = "nok";
                StringBuilder sb = new StringBuilder(path);

                StreamReader sr = new StreamReader(path);

                tx = sr.ReadLine();
                sb.AppendLine(tx);
                
                while ("end" != Convert.ToString(tx) && "ok"!=jest)
                {
                    string[] duplik = new string[20];
                    string[] duplik1 = new string[20];
                    string[] duplik2 = new string[20];
                    string[] duplik3 = new string[20];
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                    {
                        duplik[c] = Convert.ToString(tx[c]);
                        c++;

                    }

                    dupilkat = String.Concat(duplik);

                    if (dupilkat == fixtura)
                        jest = "ok";
                    if (Convert.ToString(tx[c]) != ";")
                        c++;
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                    {
                        duplik1[c] = Convert.ToString(tx[c]);
                        c++;

                    }

                    dupilkat1 = String.Concat(duplik1);
                    if (dupilkat1 == fixtura)
                        jest = "ok";
                    if (Convert.ToString(tx[c]) != ";")
                        c++;
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                    {
                        duplik2[c] = Convert.ToString(tx[c]);
                        c++;

                    }

                    dupilkat2 = String.Concat(duplik2);
                    if (dupilkat2 == fixtura)
                        jest = "ok";
                    if (Convert.ToString(tx[c]) != ";")
                        c++;
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                    {
                        duplik3[c] = Convert.ToString(tx[c]);
                        c++;

                    }

                    dupilkat3 = String.Concat(duplik3);
                    if (dupilkat3 == fixtura)
                        jest = "ok";


                    if (jest == "ok")
                    {   
                        fix1 = dupilkat;    //numery fikstur do tego samego programu 
                        fix2 = dupilkat1;
                        if (dupilkat2 == "")
                            dupilkat2 = "999";
                        fix3 = dupilkat2;
                        if (dupilkat3 == "")
                            dupilkat3 = "999";
                        fix4 = dupilkat3;
                        int fix11 = Int32.Parse(fix1);
                        int fix22 = Int32.Parse(fix2);
                        int fix33 = Int32.Parse(fix3);
                        int fix44 = Int32.Parse(fix4);
                        int[] tablica = { fix11, fix22, fix33, fix44};
                        Array.Sort(tablica);
                        
                        duplikat_fix = tablica[0].ToString();
                       



                    }
                    
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);
                    c = 0;
                }
                sr.Close();
            }


        }


    }
}
