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
using System.Diagnostics;
using System.Threading.Tasks;



namespace WpfApplication1
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.String A;
        String l;
        string znaleziono;
        int j;
        int b;
        string kh;
        string numerfix;
        string plkw;
        string fixnumerok;
        string fixtura;
        string soft;
        string hard;
        string[] seba = new string[4];
        string path;
        string[] duplik = new string[20];
        string[] znak;
        string[] znak1;
        string[] znak2;
        string[] znak3;
        string[] znak4;
        string[] fixnumer =new string[20];
        string[] stacjap = new string[20];
        string[] softp = new string[20];
        string[] hardp = new string[20];
        string zda="";
        string fix = "0";
        int linia;
        string znaki;
        string koniec = "";
        string program;
        string sg = "";
        string result9;
        string programkr;
        string result;
        string fvt;
        string fix1;
        string fix2;
        string fix3;
        string fix4;
       public int wiersz;
        public MainWindow()
        {
           
            InitializeComponent();
            label1.Content = " ";
            button5.Visibility = Visibility.Collapsed;

            ////////////////////////////////////////
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = @"cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.Start();

            StreamWriter myStreamWriter = myProcess.StandardInput;

            myStreamWriter.WriteLine("NET USE \\\\plkwim0taxlog57 /User:kwi_tester Poiuytrewq1");


            myStreamWriter.Close();
            myProcess.WaitForExit();

            ////////////////////////////////////////

        }
        
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();

            if (etr == "Return")
            {
                
                button1_Click(this, new RoutedEventArgs());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
                label3.Content = " ";
                label4.Content = " ";
                label5.Content = " ";
                koniec = "";
                linia = 1;
                button5.Visibility = Visibility.Collapsed;
            this.label8.Background = System.Windows.Media.Brushes.White;
            fvt = "";
            label1.Content = "Brak numeru ";
            Image1.Source = new BitmapImage(new Uri(@"/WpfApplication1;component/Images/biały.jpg", UriKind.RelativeOrAbsolute));
            textBox1.SelectAll();
            
           // System.Windows.MessageBox.Show("mnbmbm,bm ");
            // label1.Text = textBox1.Text;                // 
            l = textBox1.SelectionLength.ToString();
            j = Convert.ToInt32(l);

            znak = new string[j];

            if (j > 31)
            {
                textBox1.Text = String.Empty;
                // textBox1.Text = ",,";
                j = 0;

            }
            A = Convert.ToString(textBox1);
           
            if (j > 18)
            {
               
                znaki = "0";
                int i = 0;
                while(Convert.ToString(textBox1.Text[i]) != ",")
                {
                    
                    i++;
                }
                i++;
                while (Convert.ToString(textBox1.Text[i]) != ",")
                {
                    znak[i] = Convert.ToString(textBox1.Text[i]);
                    i++;
                }
               


                result = String.Concat(znak);    //zmienia tablice na string

                
                programkr = result;

                //  label1.Content = Convert.ToString(j);          //długość tablicy

                //dla 5 numerów
                fix = "0";
        

                

                /////////////////////
                ////////////////////////
                ///////////////////////
                // DLA 9 znaków

                ///////////////////////

               // for (int k = 11;k < 18; k++)                                  teraz
               //     znak[k] = Convert.ToString(textBox1.Text[k]);             teraz


                result9 = String.Concat(znak);
               // label3.Text = result9;
                program = result9;


                newfix();
                if (znaleziono == "ok")
                {
                    znaleziono = "nok";
                    
                    if (File.Exists("\\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\" + fixtura + ".jpg"))
                        Image1.Source = new BitmapImage(new Uri("\\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\" + fixtura + ".jpg"));
                    if (File.Exists("\\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\" + fixtura + ".jpg"))
                        Image1.Source = new BitmapImage(new Uri ("\\\\plkwim0taxlog57\\c$\\opis\\zdjecia\\" + fixtura + ".jpg"));
                    fix = fixtura;
                    dupikat();
                   label1.Content = ("Fixtura nr " + fixtura);
                    label3.Content = (" Software :  " + soft);
                    label4.Content = (" Hardware : " + hard);
                    label5.Content = (" Numer programu : " + fixnumerok);
                    
                    
                }
                


            }

            linia = 1;
            stacja();

            ////////   numer stacji
            label7.Content = "";
            string path1 = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix + ".txt");
            if (File.Exists(path1))
            {

                StringBuilder sb = new StringBuilder();

                StreamReader sr = new StreamReader(path1);
                string sg = "";
                for (int i = 0; i < 100; i++)
                {

                    sg = sr.ReadLine();
                    sb.AppendLine(sg);
                    if (sg == "kardex")
                    {

                        sg = sr.ReadLine();
                        sb.AppendLine(sg);
                        label7.Content = "Kardex półka nr: " + sg;
                    }

                }


                sr.Close();
            }

            ///// end nr kardex








        }
        private void komunikat()
        {

            zda = "";
            string kom = "0";
                string path = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix1 + ".txt");
                if (File.Exists(path))
                {
                    kom="1";
                     
                    StringBuilder sb = new StringBuilder();
                    //string path = @"\\plkwim0taxlog57\\c$\x.txt"; ;
                    // string path = (@"\\plkwim0taxlog57\\c$\opis\" + fix);
                    StreamReader sr = new StreamReader(path);
                    string sg = "";

                    // do
                    while (sg != "end")// ;
                    {
                        sg = sr.ReadLine();

                        sb.AppendLine(sg);
                        if (sg != "end")
                            zda = (zda + "\n" + sg);
                    } //while (sg != "end");
                    sr.Close();
                  //  if (zda != "")
                  //  {
                  //      MessageBox.Show(zda);
                  //  }
                  //  zda = "";
                }


            string path2 = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix2 + ".txt");
            if (File.Exists(path2))
            {
                kom = "1";
                
                StringBuilder sb = new StringBuilder();
                //string path = @"\\plkwim0taxlog57\\c$\x.txt"; ;
                // string path = (@"\\plkwim0taxlog57\\c$\opis\" + fix);
                StreamReader sr = new StreamReader(path2);
                string sg = "";

                // do
                while (sg != "end")// ;
                {
                    sg = sr.ReadLine();

                    sb.AppendLine(sg);
                    if (sg != "end")
                        zda = (zda + "\n" + sg);
                } //while (sg != "end");
                
            }

            string path3 = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix3 + ".txt");
            if (File.Exists(path3))
            {
                kom = "1";
               
                StringBuilder sb = new StringBuilder();
                //string path = @"\\plkwim0taxlog57\\c$\x.txt"; ;
                // string path = (@"\\plkwim0taxlog57\\c$\opis\" + fix);
                StreamReader sr = new StreamReader(path3);
                string sg = "";

                // do
                while (sg != "end")// ;
                {
                    sg = sr.ReadLine();

                    sb.AppendLine(sg);
                    if (sg != "end")
                        zda = (zda + "\n" + sg);
                } //while (sg != "end");
                sr.Close();
               
            }

            string path4 = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix4 + ".txt");
            if (File.Exists(path4))
            {
                kom = "1";
                
                StringBuilder sb = new StringBuilder();
                //string path = @"\\plkwim0taxlog57\\c$\x.txt"; ;
                // string path = (@"\\plkwim0taxlog57\\c$\opis\" + fix);
                StreamReader sr = new StreamReader(path4);
                string sg = "";

                // do
                while (sg != "end")// ;
                {
                    sg = sr.ReadLine();

                    sb.AppendLine(sg);
                    if (sg != "end")
                        zda = (zda + "\n" + sg);
                } //while (sg != "end");
                sr.Close();
                
            }
            
            if (kom=="1")
            {
                MessageBox.Show(zda);
            }
            zda = "";
        }
        

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\" + fix);
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                System.Diagnostics.Process.Start(path);
            }

        }

        private void button4_Click(object sender, RoutedEventArgs e) //nowyy 
        {
            ////////   numer stacji------ odczyt opisu stacji
            string path = (@"\\\\plkwim0taxlog57\\c$\opis\\" + fix + ".txt");
            if (File.Exists(path))
            {
                
                StringBuilder sb = new StringBuilder();
                //string path = @"\\plkwim0taxlog57\\c$\x.txt"; ;
                // string path = (@"\\plkwim0taxlog57\\c$\opis\" + fix);
                StreamReader sr = new StreamReader(path);
                string sg = "";
                for (int i = 0; i < 10; i++)
                {
                    //label6.Content = "jesli w for "+ i;
                    sg = sr.ReadLine();
                    sb.AppendLine(sg);
                    if (sg == "dedykowana stacja")
                    {
                        
                        sg = sr.ReadLine();
                        sb.AppendLine(sg);
                        label6.Content = "Dedykowana stacja :"+ sg;
                    }
                    
                }

                
                sr.Close();
            ///// end nr stacji
           

               
            }

        }

        

        public void stacja()
        {
            ////////   numer stacji
            label6.Content = "";
            button5.Visibility = Visibility.Visible;
            string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\numery.txt");
            if (File.Exists(path))
            {
                this.label8.Background = System.Windows.Media.Brushes.White;
                fvt = "";
                znak1 = new string[20];
                znak2 = new string[30];
                znak3 = new string[20];
                znak4 = new string[30];
                string kon = "5";
                StringBuilder sb = new StringBuilder();

                StreamReader sr = new StreamReader(path);
                string sg = "";
                button5.Content = "next";
                for (int l = 0; l < linia; l++)
                {
                    sg = sr.ReadLine();
                    sb.AppendLine(sg);
                }
                kon = String.Concat(sg[1]);
                if (kon == " ")
                
                    koniec = "end";
                   
                    
                
                while (koniec != "end")
                {
                    
                        for (int i = 0; i < 5; i++)                     //zmieniamy pierwsze 7 cyfr na tablice i pozniej na string
                            znak3[i] = Convert.ToString(sg[i]);
                        string numer = String.Concat(znak3);
                    znaki = "1";
                    if (j == 19 )
                        {
                            znaki = "0";
                        }
                    if (j == 20)
                    {
                        znaki = "0";
                    }

                   // System.Windows.MessageBox.Show(Convert.ToString(numer[1])+ "   "+ j);
                    if (Convert.ToString(numer[0])!= "1")
                        {
                        
                        if (programkr == numer  )
                            {
                                if (znaki == "0" )
                                {
                                    koniec = "end";

                                    for (int i = 6; i < 21; i++)                     //zmieniamy pierwsze 7 cyfr na tablice i pozniej na string
                                        znak4[i] = Convert.ToString(sg[i]);
                                    string numer1 = String.Concat(znak4);
                                plkw = numer1;
                                FVT();


                                    label6.Content = "Działa na :  " + numer1;
                                    label8.Content = fvt;
                                   button5.Visibility = Visibility.Visible;
                                }
                            }
                        }
                    
                        for (int i = 0; i < 7; i++)                     //zmieniamy pierwsze 7 cyfr na tablice i pozniej na string
                            znak1[i] = Convert.ToString(sg[i]);
                        string nume = String.Concat(znak1);
                       
                            if (program == nume)
                        {
                            koniec = "end";

                            for (int i = 8; i < 23; i++)                     //zmieniamy pierwsze 7 cyfr na tablice i pozniej na string
                                znak2[i] = Convert.ToString(sg[i]);
                            string numer2 = String.Concat(znak2);
                        plkw = numer2;
                        FVT();
                            label6.Content = "Działa na :  " + numer2;
                        label8.Content = fvt;
                        button5.Visibility = Visibility.Visible;
                        }
                    
                    linia++;
                    sg = sr.ReadLine();
                    sb.AppendLine(sg);
                    numer = "";
                    nume = "";
                    kon = String.Concat(sg[1]);
                    if (kon == " ")
                    {
                        koniec = "end";
                        linia =1;
                        button5.Content = "<";
                            // button5.Visibility = Visibility.Collapsed;
                    }
                    

                }


                sr.Close();
            }

            ///// end nr stacji
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        { 
            koniec = "";

           
            stacja();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Window2 dod = new Window2();
            dod.Show();

        }


        public void newfix()
        {  string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\fix.txt");
        if (File.Exists(path))
        {
            string tx;
            
            StringBuilder sb = new StringBuilder(path);

            StreamReader sr = new StreamReader(path);
                    
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);
                    
                    while ("end" != Convert.ToString(tx) && znaleziono != "ok")
                    {
                    b = 0;
                    int c = 0;
                    string[] fixnumer = new string[20];
                    string[] stacjap = new string[20];
                    string[] softp = new string[20];
                    string[] hardp = new string[20];
                   
                    while (Convert.ToString(tx[b]) != "," )
                        
                        {
                            fixnumer[b] = Convert.ToString(tx[b]);
                                b++;
                        }
                            
                       

                       
                           numerfix = String.Concat(fixnumer);
                    
                    if ((numerfix == result && numerfix.Length==5)|| numerfix == result9)
                          {
                        
                        fixnumerok = numerfix;
                               znaleziono = "ok";
                               b++;
                               while (Convert.ToString(tx[b]) != ",")
                               {
                                   softp[c] = Convert.ToString(tx[b]);
                                   b++;
                                   c++;
                               }

                               soft = String.Concat(softp);

                               b++;
                               c = 0;
                               while (Convert.ToString(tx[b]) != ",")
                               {
                                   hardp[c] = Convert.ToString(tx[b]);
                                   b++;
                                   c++;
                               }

                               hard = String.Concat(hardp);
                               c = 0;
                               b++;
                               while (Convert.ToString(tx[b]) != ";")
                               {
                                   stacjap[c] = Convert.ToString(tx[b]);
                                   b++;
                                   c++;
                               }

                               fixtura = String.Concat(stacjap);

                        
                               
                           }


                           numerfix = "";
                           c = 0;
                           b = 0;
                        tx = sr.ReadLine();
                        sb.AppendLine(tx);
                    
                    }


                sr.Close();
            }
            


        }

        public void dupikat()
        {
            string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\duplikat.txt");
            if (File.Exists(path))
            {    wiersz= 0;
                int c = 0;
                string dupilkat="";
                string dupilkat1 = "";
                string dupilkat2 = "";
                string dupilkat3 = "";
                string tx;
                string jest = "nok";
                StringBuilder sb = new StringBuilder(path);

                StreamReader sr = new StreamReader(path);

                tx = sr.ReadLine();
                sb.AppendLine(tx);
                wiersz++;
                while ("end" != Convert.ToString(tx))
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


                    if(jest=="ok")
                    {
                        fix1 = dupilkat;    //numery fikstur do tego samego programu 
                        fix2 = dupilkat1;
                        fix3 = dupilkat2;
                        fix4 = dupilkat3;
                        fixtura = dupilkat + " , " + dupilkat1;
                        if(dupilkat2 != "")
                            fixtura= fixtura + " , " + dupilkat2;
                        if (dupilkat3 != "")
                            fixtura = fixtura + " , " + dupilkat3;
                        jest = "nok";
                         }
                    if(jest!="ok")
                    {
                        wiersz++;
                    }
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);
                    c = 0;
                }
                sr.Close();
            }


        }



        public void FVT()
        {
            this.label8.Background = System.Windows.Media.Brushes.White;
            fvt = "";
            int c = 0;
            string tx = "";
            string plk = "";
            string path = (@"\\\\plkwim0taxlog57\\c$\\opis\\FVT.txt");
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();

                StreamReader sr = new StreamReader(path);
                tx = sr.ReadLine();
                sb.AppendLine(tx);
                while ("end" != Convert.ToString(tx))
                {
                    string[] fvt1 = new string[30];
                    string[] fvt2 = new string[30];
                    while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                    {
                        fvt1[c] = Convert.ToString(tx[c]);
                        c++;

                    }

                    plk = String.Concat(fvt1);
                    c++;
                    if (plk == plkw)
                    {
                        while (Convert.ToString(tx[c]) != "," && Convert.ToString(tx[c]) != ";")
                        {
                            fvt2[c] = Convert.ToString(tx[c]);
                            c++;

                        }

                        fvt=( " ("+String.Concat(fvt2)+")");
                        this.label8.Background = System.Windows.Media.Brushes.Blue;
                        this.label8.Foreground= System.Windows.Media.Brushes.White;
                    }
                    tx = sr.ReadLine();
                    sb.AppendLine(tx);
                    c = 0;
                }


            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btinfo_Click(object sender, RoutedEventArgs e)
        {
            Window1 fix = new Window1();
            fix.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            /////////////// Mapowanie dysku i otworzenie plików pythona
            Process myProcess = new Process();

            myProcess.StartInfo.FileName = @"cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.Start();

            StreamWriter myStreamWriter = myProcess.StandardInput;

            myStreamWriter.WriteLine("NET USE \\\\plkwim0taxlog57 /User:kwi_tester Poiuytrewq1");
            
             
            myStreamWriter.Close();
            myProcess.WaitForExit();
            
             ///////////

        }

        private void DodajZdjecie(object sender, RoutedEventArgs e)
        {

            Window3 dodajZdjecie = new Window3();
           dodajZdjecie.Show();
        }


        private void Szukaj_TE(object sender, RoutedEventArgs e)
        {
            
              Window4 szukajTE = new Window4();
             szukajTE.Show();
        }

    }
}
