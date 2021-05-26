using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kartesletirmeoyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            

            if (kAdiTextbox.Text != "" && kartboyutCmb.Text != "" && temaCmb.Text != "")
            {

                anasayfa a1 = new anasayfa();
                a1.kullaniciAdi = kAdiTextbox.Text;
                a1.kartboyut = kartboyutCmb.Text;
                a1.karttema = temaCmb.Text;
                a1.Show();



            }
            else
            {
                if (kAdiTextbox.Text == "")
                {
                    errorProviderkadi.SetError(kAdiTextbox, "Ad alanı boş bırakılamaz");
                    
                }
                if(kartboyutCmb.Text == "")
                {
                    errorProviderkadi.SetError(kartboyutCmb, "Boyut alanı boş bırakılamaz");
                    
                }
                if(temaCmb.Text == "")
                {
                    errorProviderkadi.SetError(temaCmb, "Tema alanı boş bırakılamaz");
                }
            }
        }

        private void cikisBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
