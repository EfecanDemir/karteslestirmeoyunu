using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace kartesletirmeoyunu
{
    public partial class puantablo : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=127.0.0.1;Database=kartoyunu;user=root;Pwd=admin;SslMode=none");
        MySqlCommand komut;
        MySqlDataReader dr;

        public puantablo()
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

        void dataDoldur()
        {
            baglantiKontrol();

            komut = new MySqlCommand("select oyuncuad,denemesayi,kartboyut,temakart,sure,puan,oynaniszaman from oyuncular", baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds, "oyuncular");
            dataGridView1.DataSource = ds.Tables["oyuncular"];
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns[0].HeaderText = "Kullanıcı Adı";
            this.dataGridView1.Columns[1].HeaderText = "Deneme Sayısı";
            this.dataGridView1.Columns[2].HeaderText = "Kart Boyut";
            this.dataGridView1.Columns[3].HeaderText = "Tema";
            this.dataGridView1.Columns[4].HeaderText = "Kalan Süre";
            this.dataGridView1.Columns[5].HeaderText = "Puan";
            this.dataGridView1.Columns[6].HeaderText = "Oynama Zamanı";


            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Sienna;

            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.Khaki;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.Khaki;
            dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.Khaki;
            dataGridView1.Columns[6].DefaultCellStyle.BackColor = Color.CornflowerBlue;
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oyun ekranına dönüşü onaylıyor musunuz? ", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
            else
            {

            }
        }

        private void puantablo_Load(object sender, EventArgs e)
        {
            dataDoldur();

            //tüm oynayan kişileri txt ye çekme
            TextWriter writer = new StreamWriter(@"Tüm Yarışmacılar.txt");

            writer.Write("\t" + "KİŞİ SAYISI" + "\t" + "|");
            writer.Write("\t" + "KULLANICI ADI" + "\t" + "|");
            writer.Write( "DENEME SAYISI" +  "|");
            writer.Write( "KART BOYUTU" + "\t"+"|");
            writer.Write("\t" + "KART TEMA" + "\t" + "|");
            writer.Write("\t" + "KALAN SÜRE" + "\t" + "|");
            writer.Write("\t" + "PUAN" + "\t" + "|");
            writer.Write("\t" + "OYNANIŞ ZAMANI" + "\t" + "|");
            writer.WriteLine("\n" + "------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            int z = 1;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                writer.Write("\t" + z + "\t" + "\t" + "|");
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                }
                writer.WriteLine("");
                writer.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                z++;
            }
            writer.Close();


        }
    }
}
