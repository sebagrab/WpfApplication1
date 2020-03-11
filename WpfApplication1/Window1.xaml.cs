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
        public Window1()
        {
          //  wbSample.Navigate(@"c:\opis\");
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




            string path = (@"c:\opis\" + comboBox1.Text + ".txt");

            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder(path);

                StreamReader sr = new StreamReader(path);



                while (sg != "end")// ;
                {
                    sg = sr.ReadLine();

                    sb.AppendLine(sg);
                    if (sg != "end")
                    {
                        if (zda != "")
                            zda = (zda + "\r\n" + sg);

                        if (zda == "")
                            zda = (sg);

                    }
                } //while (sg != "end");
                for (int i = 0; i < 50; i++)
                {
                    sg = sr.ReadLine();
                    nove = (nove + "\r\n" + sg);

                }
                sr.Close();
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(zda);

                sw.WriteLine(textBox1.Text);

                sw.WriteLine("end");

                sw.WriteLine(nove);
                sw.Close();
                MessageBox.Show("Zapisano");

                Close();

            }
            else
            {
                string plik = @"c:\opis\" + comboBox1.Text + ".txt";
                File.WriteAllText(plik, "end");
                opisy();

            }

           

               // MessageBox.Show("Nie wybrano numeru fixtury");
            //  string path = (@"c:\opis\" + comboBox1.Text + ".txt");


            //   StreamWriter sw = new StreamWriter(path);
            //  sw.Write("Ala");
            // sw.WriteLine(zda);
            //      sw.WriteLine(" ma kota");
            //    sw.WriteLine("i tak dalej!");
            //    sw.WriteLine("end");
            //    sw.Close();

        }
    

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            opisy();



        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {


            Close();



        }
    }
}
