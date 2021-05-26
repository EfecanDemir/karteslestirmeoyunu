using Bunifu.Framework.UI;
using BunifuAnimatorNS;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace kartesletirmeoyunu
{
    public partial class anasayfa : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=127.0.0.1;Database=kartoyunu;user=root;Pwd=admin;SslMode=none");
        MySqlCommand komut;
        MySqlDataReader dr;

        public string kullaniciAdi { get; set; }
        public string kartboyut { get; set; }
        public string karttema { get; set; }
        
        int boyut,puan;
        int saniye = 60;
        int dakika = 0;

        Image[] hayvan = {
            Properties.Resources.ayı,
            Properties.Resources.balik,
            Properties.Resources.kaplan,
            Properties.Resources.kaplumbag,
            Properties.Resources.kus,
            Properties.Resources.maymun,
            Properties.Resources.penguen,
            Properties.Resources.yılan,
            Properties.Resources.iguana,
            Properties.Resources.geyik,
        };

        Image[] meslek = {
            Properties.Resources.berber,
            Properties.Resources.ciftci,
            Properties.Resources.copcu,
            Properties.Resources.disci,
            Properties.Resources.hemsire,
            Properties.Resources.itfaiyeci,
            Properties.Resources.öğretmen,
            Properties.Resources.tesisatci,
            Properties.Resources.mekanist,
            Properties.Resources.saglikci,
        };

        Image[] nesne = {
            Properties.Resources.agac,
            Properties.Resources.kekadam,
            Properties.Resources.kutu,
            Properties.Resources.kokteyl,
            Properties.Resources.papyon,
            Properties.Resources.zil,
            Properties.Resources.noel,
            Properties.Resources.seker,
            Properties.Resources.mum,
            Properties.Resources.kek,
        };
        Image[] renk = {
            Properties.Resources.sari,
            Properties.Resources.kahve,
            Properties.Resources.lacivert,
            Properties.Resources.acikyesil,
            Properties.Resources.acikmavi,
            Properties.Resources.gri,
            Properties.Resources.koyuyesil,
            Properties.Resources.koyusari,
            Properties.Resources.toprak,
            Properties.Resources.pembe,
        };

        Image[] emoji = {
            Properties.Resources.acikgoz,
            Properties.Resources.agizemoji,
            Properties.Resources.dilemoji,
            Properties.Resources.elemoji,
            Properties.Resources.gozlukemoji,
            Properties.Resources.gunesemoji,
            Properties.Resources.kalpgoz,
            Properties.Resources.kapaligoz,
            Properties.Resources.paragozemoji,
            Properties.Resources.kapaligoz,
        };


        int[] indeksler ={ 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        int[] indeksler1 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        int[] indeksler2 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
        int[] indeksler3 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};
        int[] indeksler4 = { 0, 0, 1, 1, 2, 2, 3, 3 };

        PictureBox ilkkutu;
        int ilkindeks,bulunan,deneme;
        public anasayfa()
        {
            InitializeComponent();
        }

        void baglantiKontrol()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

            }

        }
        private void anasayfa_Load(object sender, EventArgs e)
        {                     
            kullaniciAdiLbl.Text = kullaniciAdi;
            boyutkart.Text=kartboyut;
            temakart.Text = karttema;

            if (boyutkart.Text == "4x5")
            {
                boyut = 10;
            }
            if (boyutkart.Text == "4x4")
            {
                sonucPnl.Size = new Size(510, 462);

                gorsel20.Visible = false;
                gorsel19.Visible = false;
                gorsel18.Visible = false;
                gorsel17.Visible = false;

                boyut = 8;
            }
            if (boyutkart.Text == "2x5")
            {
                sonucPnl.Size = new Size(645, 215);
                gorsel18.Visible = false;
                gorsel17.Visible = false;
                gorsel19.Visible = false;
                gorsel20.Visible = false;
                gorsel16.Visible = false;
                gorsel15.Visible = false;
                gorsel14.Visible = false;
                gorsel13.Visible = false;
                gorsel12.Visible = false;
                gorsel11.Visible = false;

                gorsel9.Location = new Point(570, 24);
                gorsel10.Location= new Point(570, 143);

                boyut = 5;
            }
            if (boyutkart.Text == "3x4")
            {
                sonucPnl.Size = new Size(510, 340);

                gorsel20.Visible = false;
                gorsel19.Visible = false;
                gorsel18.Visible = false;
                gorsel17.Visible = false;
                gorsel16.Visible = false;
                gorsel15.Visible = false;
                gorsel14.Visible = false;
                gorsel13.Visible = false;

                boyut = 6;
            }
            if (boyutkart.Text == "2x4")
            {
                
                sonucPnl.Size = new Size(510, 215);
                gorsel20.Visible = false;
                gorsel19.Visible = false;
                gorsel18.Visible = false;
                gorsel17.Visible = false;
                gorsel18.Visible = false;
                gorsel17.Visible = false;              
                gorsel16.Visible = false;
                gorsel15.Visible = false;
                gorsel14.Visible = false;
                gorsel13.Visible = false;
                gorsel12.Visible = false;
                gorsel11.Visible = false;
                gorsel10.Visible = false;
                gorsel9.Visible = false;

                boyut = 4;
            }


            resimkar();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // 1 saniye
            saniye = saniye - 1;
            saniyeLbl.Text = saniye.ToString();
            dakikaLbl.Text = (dakika - 1).ToString();
            if (dakikaLbl.Text == "0" && saniyeLbl.Text == "1")
            {
                System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                
                timer1.Stop();
                saniyeLbl.Text = "00";

                baglantiKontrol();
                string kayit2 = "insert into oyuncular(oyuncuad,denemesayi,kartboyut,temakart,sure,puan,oynaniszaman) values(@oyuncuad,@denemesayi,@kartboyut,@temakart,@sure,@puan,@oynaniszaman)";
                MySqlCommand komut = new MySqlCommand(kayit2, baglanti);
                komut.Parameters.AddWithValue("@oyuncuad", kullaniciAdiLbl.Text);
                komut.Parameters.AddWithValue("@oynaniszaman", DateTime.Now.ToString());
                komut.Parameters.AddWithValue("@puan", puanLbl.Text);
                komut.Parameters.AddWithValue("@denemesayi", deneme);
                komut.Parameters.AddWithValue("@kartboyut", boyutkart.Text);
                komut.Parameters.AddWithValue("@temakart", temakart.Text);
                komut.Parameters.AddWithValue("@sure", dakikaLbl.Text + label2.Text + saniyeLbl.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();


                sonucPnl.BackColor = Color.Transparent;
                dakika = Convert.ToInt32("3");
                saniye = Convert.ToInt32("60");

                ses.SoundLocation = "C:\\Users\\MONSTER\\Desktop\\3.1dönem\\Yazılım Geliştirme Laboratuvarı II\\finalgörsel\\kaybetme.wav";
                ses.Play();

                MessageBox.Show("Zamanın doldu " + kullaniciAdiLbl.Text + " \n" + deneme + " denemede buldunuz." + "\nBoyut: " + boyutkart.Text + "\nTema: " + temakart.Text + "\nSüre: " + dakikaLbl.Text + label2.Text + saniyeLbl.Text + "\nPuan: " + puanLbl.Text, "ZAMAN BİTTİ");

                puan = 0;
                bulunan = 0;
                deneme = 0;
                baslaBtn.Enabled = true;
                puanLbl.Text = "0";
                dakikaLbl.Text = "3";
                saniyeLbl.Text = "00";
                denemeLbl.Text = "0";

                gorsel1.Enabled = false;
                gorsel2.Enabled = false;
                gorsel3.Enabled = false;
                gorsel4.Enabled = false;
                gorsel5.Enabled = false;
                gorsel6.Enabled = false;
                gorsel7.Enabled = false;
                gorsel8.Enabled = false;
                gorsel9.Enabled = false;
                gorsel10.Enabled = false;
                gorsel11.Enabled = false;
                gorsel12.Enabled = false;
                gorsel13.Enabled = false;
                gorsel14.Enabled = false;
                gorsel15.Enabled = false;
                gorsel16.Enabled = false;
                gorsel17.Enabled = false;
                gorsel18.Enabled = false;
                gorsel19.Enabled = false;
                gorsel20.Enabled = false;






                foreach (Control kontrol in Controls)
                {
                    if (boyutkart.Text == "4x4")
                    {
                        kontrol.Visible = true;

                        gorsel20.Visible = false;
                        gorsel19.Visible = false;
                        gorsel18.Visible = false;
                        gorsel17.Visible = false;
                    }
                    if (boyutkart.Text == "4x5")
                    {
                        kontrol.Visible = true;
                    }
                    if (boyutkart.Text == "3x4")
                    {
                        kontrol.Visible = true;


                        gorsel20.Visible = false;
                        gorsel19.Visible = false;
                        gorsel18.Visible = false;
                        gorsel17.Visible = false;
                        gorsel16.Visible = false;
                        gorsel15.Visible = false;
                        gorsel14.Visible = false;
                        gorsel13.Visible = false;
                    }
                    if (boyutkart.Text == "2x5")
                    {
                        kontrol.Visible = true;

                        gorsel18.Visible = false;
                        gorsel17.Visible = false;
                        gorsel19.Visible = false;
                        gorsel20.Visible = false;
                        gorsel16.Visible = false;
                        gorsel15.Visible = false;
                        gorsel14.Visible = false;
                        gorsel13.Visible = false;
                        gorsel12.Visible = false;
                        gorsel11.Visible = false;

                        gorsel9.Location = new Point(570, 24);
                        gorsel10.Location = new Point(570, 143);

                    }
                    if (boyutkart.Text == "2x4")
                    {
                        kontrol.Visible = true;

                        gorsel20.Visible = false;
                        gorsel19.Visible = false;
                        gorsel18.Visible = false;
                        gorsel17.Visible = false;
                        gorsel18.Visible = false;
                        gorsel17.Visible = false;
                        gorsel16.Visible = false;
                        gorsel15.Visible = false;
                        gorsel14.Visible = false;
                        gorsel13.Visible = false;
                        gorsel12.Visible = false;
                        gorsel11.Visible = false;
                        gorsel10.Visible = false;
                        gorsel9.Visible = false;
                    }

                }
                resimkar();
            
        }
            if (saniye == 0)
            {
                dakika = dakika - 1;
                dakikaLbl.Text = dakika.ToString();
                saniye = 60;
            }
            if (dakikaLbl.Text == "-1")
            {
                timer1.Stop();
                dakikaLbl.Text = "0";
                saniyeLbl.Text = "00";
            }
        }
              
        private void btnGeri_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Giriş ekranına dönüşü onaylıyor musunuz? \n(Oyun sonlandırılacaktır.)", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                baglantiKontrol();
                string kayit2 = "insert into oyuncular(oyuncuad,denemesayi,kartboyut,temakart,sure,puan,oynaniszaman) values(@oyuncuad,@denemesayi,@kartboyut,@temakart,@sure,@puan,@oynaniszaman)";
                MySqlCommand komut = new MySqlCommand(kayit2, baglanti);
                komut.Parameters.AddWithValue("@oyuncuad", kullaniciAdiLbl.Text);
                komut.Parameters.AddWithValue("@oynaniszaman", DateTime.Now.ToString());
                komut.Parameters.AddWithValue("@puan", puanLbl.Text);
                komut.Parameters.AddWithValue("@denemesayi", deneme);
                komut.Parameters.AddWithValue("@kartboyut", boyutkart.Text);
                komut.Parameters.AddWithValue("@temakart", temakart.Text);
                komut.Parameters.AddWithValue("@sure", dakikaLbl.Text + label2.Text + saniyeLbl.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();


                Close();
            }
            else
            {

            }

            
        }

        private void btnSkor_Click(object sender, EventArgs e)
        {

            puantablo p1 = new puantablo();
            p1.Show();
        }

        private void baslaBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            dakika = Convert.ToInt32("3");

            gorsel1.Enabled = true;
            gorsel2.Enabled = true;
            gorsel3.Enabled = true;
            gorsel4.Enabled = true;
            gorsel5.Enabled = true;
            gorsel6.Enabled = true;
            gorsel7.Enabled = true;
            gorsel8.Enabled = true;
            gorsel9.Enabled = true;
            gorsel10.Enabled = true;
            gorsel11.Enabled = true;
            gorsel12.Enabled = true;
            gorsel13.Enabled = true;
            gorsel14.Enabled = true;
            gorsel15.Enabled = true;
            gorsel16.Enabled = true;
            gorsel17.Enabled = true;
            gorsel18.Enabled = true;
            gorsel19.Enabled = true;
            gorsel20.Enabled = true;


            baslaBtn.Enabled = false;

        }

        private void resimkar()
        {
            
            Random rnd = new Random();

            if (boyutkart.Text == "4x5")
            {
                for (int i = 0; i < 20; i++)
                {
                    int sayi = rnd.Next(20);

                    int gecici = indeksler[i];
                    indeksler[i] = indeksler[sayi];
                    indeksler[sayi] = gecici;
                }
            }
            if (boyutkart.Text == "4x4")
            {
                for (int i = 0; i < 16; i++)
                {
                    int sayi = rnd.Next(16);

                    int gecici = indeksler1[i];
                    indeksler1[i] = indeksler1[sayi];
                    indeksler1[sayi] = gecici;
                }
            }
            if (boyutkart.Text == "2x5")
            {
                for (int i = 0; i < 10; i++)
                {
                    int sayi = rnd.Next(10);

                    int gecici = indeksler3[i];
                    indeksler3[i] = indeksler3[sayi];
                    indeksler3[sayi] = gecici;
                }
            }

            if (boyutkart.Text == "3x4")
            {
                for (int i = 0; i < 12; i++)
                {
                    int sayi = rnd.Next(12);

                    int gecici = indeksler2[i];
                    indeksler2[i] = indeksler2[sayi];
                    indeksler2[sayi] = gecici;
                }
            }
            if (boyutkart.Text == "2x4")
            {
                for (int i = 0; i < 8; i++)
                {
                    int sayi = rnd.Next(8);

                    int gecici = indeksler4[i];
                    indeksler4[i] = indeksler4[sayi];
                    indeksler4[sayi] = gecici;
                }
            }

        }
       
        private void gorsel16_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
            PictureBox gorsel = (PictureBox)sender;
            BunifuTransition transition = new BunifuTransition();


            bunifuTransition2.HideSync(gorsel);

            int gorselnumara = int.Parse(gorsel.Name.Substring(6));
            int indeksnumara = indeksler[gorselnumara - 1];


            if (boyutkart.Text == "4x4")
            {
                indeksnumara = indeksler1[gorselnumara - 1];
            }
            if (boyutkart.Text == "4x5")
            {
                indeksnumara = indeksler[gorselnumara - 1];
            }
            if (boyutkart.Text == "3x4")
            {
                indeksnumara = indeksler2[gorselnumara - 1];
            }
            if (boyutkart.Text == "2x5")
            {
                indeksnumara = indeksler3[gorselnumara - 1];
            }
            if (boyutkart.Text == "2x4")
            {
                indeksnumara = indeksler4[gorselnumara - 1];
            }

            //tema seçimi
            if (temakart.Text=="Hayvanlar")
            {
                gorsel.Image = hayvan[indeksnumara];
            }
            if (temakart.Text == "Meslekler")
            {
                gorsel.Image = meslek[indeksnumara];
            }
            if (temakart.Text == "Nesneler")
            {
                gorsel.Image = nesne[indeksnumara];
            }
            if (temakart.Text == "Renkler")
            {
                gorsel.Image = renk[indeksnumara];
            }
            if (temakart.Text == "Emojiler")
            {
                gorsel.Image = emoji[indeksnumara];
            }

            gorsel.Refresh();

            bunifuTransition2.ShowSync(gorsel);

            sonucPnl.BackColor = Color.Transparent;

            if (ilkkutu == null)
            {
                ilkkutu = gorsel;
                ilkindeks = indeksnumara;
                deneme++;
                denemeLbl.Text = deneme.ToString();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                gorsel.Image = null;

                

                if (ilkindeks==indeksnumara)
                {
                    puan = puan + 100;
                    puanLbl.Text = puan.ToString();

                    sonucPnl.BackColor = Color.Green;
                    System.Media.SoundPlayer sesdogru = new System.Media.SoundPlayer();
                    sesdogru.SoundLocation = "C:\\Users\\MONSTER\\Desktop\\3.1dönem\\Yazılım Geliştirme Laboratuvarı II\\finalgörsel\\dogrucevap.wav";
                    sesdogru.Play();

                    bulunan++;
                    bunifuTransition1.HideSync(gorsel);
                    bunifuTransition1.HideSync(ilkkutu);
                    //    transition.HideSync(gorsel, false,
                    //BunifuAnimatorNS.Animation.Mosaic);
                    //    transition.HideSync(ilkkutu, false,
                    //BunifuAnimatorNS.Animation.Mosaic);

                    ilkkutu.Visible = false;
                    gorsel.Visible = false;


                   

                    if (bulunan==boyut)
                    {
                        timer1.Stop();

                        baglantiKontrol();
                        string kayit2 = "insert into oyuncular(oyuncuad,denemesayi,kartboyut,temakart,sure,puan,oynaniszaman) values(@oyuncuad,@denemesayi,@kartboyut,@temakart,@sure,@puan,@oynaniszaman)";
                        MySqlCommand komut = new MySqlCommand(kayit2, baglanti);
                        komut.Parameters.AddWithValue("@oyuncuad", kullaniciAdiLbl.Text);
                        komut.Parameters.AddWithValue("@oynaniszaman", DateTime.Now.ToString());
                        komut.Parameters.AddWithValue("@puan", puanLbl.Text);
                        komut.Parameters.AddWithValue("@denemesayi", deneme);
                        komut.Parameters.AddWithValue("@kartboyut", boyutkart.Text);
                        komut.Parameters.AddWithValue("@temakart", temakart.Text);
                        komut.Parameters.AddWithValue("@sure", dakikaLbl.Text + label2.Text + saniyeLbl.Text);

                        komut.ExecuteNonQuery();
                        baglanti.Close();






                        sonucPnl.BackColor = Color.Transparent;
                        dakika = Convert.ToInt32("3");
                        saniye = Convert.ToInt32("60");

                        ses.SoundLocation = "C:\\Users\\MONSTER\\Desktop\\3.1dönem\\Yazılım Geliştirme Laboratuvarı II\\finalgörsel\\kazanma.wav";
                        ses.Play();

                        MessageBox.Show("Tebrikler "+kullaniciAdiLbl.Text +" \n"+deneme+" denemede buldunuz." + "\nBoyut: "+ boyutkart.Text +"\nTema: "+temakart.Text+"\nSüre: "+ dakikaLbl.Text+label2.Text+saniyeLbl.Text+"\nPuan: " + puanLbl.Text, "TEBRİKLER");
                        
                        puan = 0;
                        bulunan = 0;
                        deneme = 0;
                        baslaBtn.Enabled = true;
                        puanLbl.Text = "0";
                        dakikaLbl.Text="3";
                        saniyeLbl.Text = "00";
                        denemeLbl.Text = "0";

                        gorsel1.Enabled = false;
                        gorsel2.Enabled = false;
                        gorsel3.Enabled = false;
                        gorsel4.Enabled = false;
                        gorsel5.Enabled = false;
                        gorsel6.Enabled = false;
                        gorsel7.Enabled = false;
                        gorsel8.Enabled = false;
                        gorsel9.Enabled = false;
                        gorsel10.Enabled = false;
                        gorsel11.Enabled = false;
                        gorsel12.Enabled = false;
                        gorsel13.Enabled = false;
                        gorsel14.Enabled = false;
                        gorsel15.Enabled = false;
                        gorsel16.Enabled = false;
                        gorsel17.Enabled = false;
                        gorsel18.Enabled = false;
                        gorsel19.Enabled = false;
                        gorsel20.Enabled = false;


                       

                        

                        foreach (Control kontrol in Controls)
                        {
                            if (boyutkart.Text == "4x4")
                            {
                                kontrol.Visible = true;
                                
                                gorsel20.Visible = false;
                                gorsel19.Visible = false;
                                gorsel18.Visible = false;
                                gorsel17.Visible = false;
                            }
                            if (boyutkart.Text == "4x5")
                            {
                                kontrol.Visible = true;
                            }
                            if (boyutkart.Text == "3x4")
                            {
                                kontrol.Visible = true;


                                gorsel20.Visible = false;
                                gorsel19.Visible = false;
                                gorsel18.Visible = false;
                                gorsel17.Visible = false;
                                gorsel16.Visible = false;
                                gorsel15.Visible = false;
                                gorsel14.Visible = false;
                                gorsel13.Visible = false;
                            }
                            if (boyutkart.Text == "2x5")
                            {
                                kontrol.Visible = true;

                                gorsel18.Visible = false;
                                gorsel17.Visible = false;
                                gorsel19.Visible = false;
                                gorsel20.Visible = false;
                                gorsel16.Visible = false;
                                gorsel15.Visible = false;
                                gorsel14.Visible = false;
                                gorsel13.Visible = false;
                                gorsel12.Visible = false;
                                gorsel11.Visible = false;

                                gorsel9.Location = new Point(570, 24);
                                gorsel10.Location = new Point(570, 143);

                            }
                            if (boyutkart.Text == "2x4")
                            {
                                kontrol.Visible = true;

                                gorsel20.Visible = false;
                                gorsel19.Visible = false;
                                gorsel18.Visible = false;
                                gorsel17.Visible = false;
                                gorsel18.Visible = false;
                                gorsel17.Visible = false;
                                gorsel16.Visible = false;
                                gorsel15.Visible = false;
                                gorsel14.Visible = false;
                                gorsel13.Visible = false;
                                gorsel12.Visible = false;
                                gorsel11.Visible = false;
                                gorsel10.Visible = false;
                                gorsel9.Visible = false;
                            }
                           
                        }
                        resimkar();
                    }

                }

                ilkkutu = null;

                if (ilkindeks != indeksnumara)
                {
                    sonucPnl.BackColor = Color.DarkRed;

                    ses.SoundLocation = "C:\\Users\\MONSTER\\Desktop\\3.1dönem\\Yazılım Geliştirme Laboratuvarı II\\finalgörsel\\yanliscevap.wav";
                    ses.Play();
                }

            }

        }
    }  
}
