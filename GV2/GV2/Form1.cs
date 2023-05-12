using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GV2
{
    public partial class Form1 : Form
    {
        string path = "ödevdb.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\ödevdb.db"; //database creat debug folder

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public Form1()
        {
            InitializeComponent();
            SQLiteConnection bag = new SQLiteConnection("Data Source=C:\\Users\\serka\\Desktop\\simar\\ödevdb\\ödev.db"); 
            SQLiteConnection yeni = new SQLiteConnection(bag);
            yeni.Open(); // Bağlantıyı Açtık

            if (yeni.State == ConnectionState.Open)
            {
                MessageBox.Show("Veritabanına Bağlanıldı"); // Bağlantı Açılırsa Uyarı Versin
            }

            else
            {
                MessageBox.Show("Bağlantı Başarısız"); // Başarısız ise uyarı Versin
            }
            yeni.Close(); //Bağlantıyı Sonlandırdık
        }

        string ad, soyad;
        int koltukno, sayac = 0, boskoltuk = 35, dolukoltuk = 0;

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (textisim.Text == "" || txtsoyisim.Text == "" || txtkoltukno.Text == "") MessageBox.Show("Lütfen Boş alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!(rderkek.Checked || rdkadin.Checked)) MessageBox.Show("Lütfen cinsiyet seçimi yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                try
                {

                    ad = textisim.Text;
                    soyad = txtsoyisim.Text;
                    koltukno = Convert.ToInt32(txtkoltukno.Text);

                    if (koltukno < 1 || koltukno > 35)
                    {
                        MessageBox.Show("Lütfen geçerli bir koltuk numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtkoltukno.Text = "";
                    }
                    else
                    {

                        if (Array.IndexOf(dolukoltukdizi, koltukno) == -1)
                        {

                            Label koltukara = this.Controls.Find("koltuk" + koltukno.ToString(), true).FirstOrDefault() as Label;

                            if (koltukara != null)
                            {
                                koltukara.Text += "\r" + ad + " " + soyad;
                                koltukara.BackColor = Color.Red;
                                dolukoltuk++;
                                boskoltuk--;

                                Array.Resize(ref dolukoltukdizi, dolukoltukdizi.Length + 1);
                                dolukoltukdizi[sayac] = koltukno;
                                sayac++;

                                lbldolu.Text = dolukoltuk.ToString();
                                lblbos.Text = boskoltuk.ToString();

                                textisim.Text = "";
                                txtsoyisim.Text = "";
                                txtkoltukno.Text = "";


                                Image erkek = Image.FromFile("İconlar/E.png");
                                Image kadin = Image.FromFile("İconlar/K.png");
                                if (rdkadin.Checked)
                                {
                                    koltukara.Image = kadin;
                                }
                                else
                                {
                                    koltukara.Image = erkek;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Girmiş olduğunuz koltuk numarasına ait koltuk dolu", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtkoltukno.Text = "";
                        }
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("İşlem Başarılı Şekilde Kaydedildi :))", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtkoltukno.Text = "";
                }
            }
        }

        private void btniptalet_Click(object sender, EventArgs e)
        {
            try
            {
                koltukno = Convert.ToInt32(txtiptalkoltukno.Text);

                if (koltukno < 1 || koltukno > 35)
                {
                    MessageBox.Show("Lütfen geçerli bir koltuk numarası giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtiptalkoltukno.Text = "";
                }

                else
                {
                    if (Array.IndexOf(dolukoltukdizi, koltukno) != -1)
                    {

                        Label koltukara = this.Controls.Find("koltuk" + koltukno.ToString(), true).FirstOrDefault() as Label;
                        if (koltukara != null)
                        {
                            koltukara.Text = koltukno + ".koltuk";
                            koltukara.BackColor = Color.FloralWhite;
                            dolukoltuk--;
                            boskoltuk++;

                            int sirano = Array.IndexOf(dolukoltukdizi, koltukno);
                            Array.Clear(dolukoltukdizi, sirano, 1);

                            lbldolu.Text = dolukoltuk.ToString();
                            lblbos.Text = boskoltuk.ToString();
                            txtiptalkoltukno.Text = "";

                            Image bos_koltuk = Image.FromFile("İconlar/VarsayılanKoltuk.png");
                            koltukara.Image = bos_koltuk;
                        }
                    }
                    else
                    {
                        MessageBox.Show("İptal edilmek istenen koltuk zaten boş!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtiptalkoltukno.Text = "";
                    }
                }

            }

            catch (Exception)
            {
                MessageBox.Show("Seçilen Koltuk İptal Edilmiştir!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtiptalkoltukno.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbldolu.Text = dolukoltuk.ToString();
            lblbos.Text = boskoltuk.ToString();
        }

        int[] dolukoltukdizi = new int[0];
        private void salonEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalonEkleme g = new SalonEkleme();
            g.MdiParent = this.ParentForm;
            g.Show();
        }

        private void filmEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilmEkle g = new FilmEkle();
            g.MdiParent = this.ParentForm;
            g.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapılıyor!!!", "Mesaj Çıktısı");
            this.Close();
            //close ile sistem tamamen kapanırken hide ile winform kapansa bile çalışır halde oluyor.
            //this.Hide();
        }
    }
}
