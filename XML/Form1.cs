using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TextBox txtAd;
        private MaskedTextBox txtSoyad;
        private DateTimePicker dtpDogumTarihi;
        private ListBox lstBoxOgrenci;
        private OpenFileDialog openFileXml;
        private SaveFileDialog saveFileXml;
        private Button btnEkle;
        private Button btnIceAktar;
        private Button btnDısaAktar;
        private Label label1;
        private Label label2;
        private Label label3;

        //içinde öğrenci classlarından olusan bi listemiz var.
        List<Ogrenci> ListOgrenci = new List<Ogrenci>(); 

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            // ogrenci claasından ogrenci instance oluışturduk.
            Ogrenci ogrenci = new Ogrenci()
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                DogumTarihi = dtpDogumTarihi.Value,

            };

            lstBoxOgrenci.Items.Add(ogrenci.Ad);
            ListOgrenci.Add(ogrenci);
        }

        private void btnIceAktar_Click_1(object sender, EventArgs e)
        {
            List<Ogrenci> okunanOgrenciler = new List<Ogrenci>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ogrenci>));
            if (openFileXml.ShowDialog() == DialogResult.OK)
            {
                TextReader reader = new StreamReader(openFileXml.FileName);
                okunanOgrenciler = (List<Ogrenci>)serializer.Deserialize(reader);
                ListOgrenci.AddRange(okunanOgrenciler);
                ListeyiDoldur(ListOgrenci);
                reader.Close();
            }
        }

        private void ListeyiDoldur(List<Ogrenci> OgrenciList)
        {
            lstBoxOgrenci.Items.Clear();
            for (int i = 0; i <= OgrenciList.Count - 1; i++)
            {
                lstBoxOgrenci.Items.Add(OgrenciList[i]);
            }
        }

        private void btnDısaAktar_Click_1(object sender, EventArgs e)
        {
            saveFileXml.Title = "XML dosyasını kaydet.";
            saveFileXml.Filter = "(*.xml)|*.xml";
            //ilk acıldıgında desktop gelmesini saglar.
            saveFileXml.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ogrenci>));

            if (saveFileXml.ShowDialog() == DialogResult.OK)
            {
                //streamwriter -> veri aktarımı söz konusu ise. dosya yaz demek hangi dosyaya onu belirt.
                TextWriter writer = new StreamWriter(saveFileXml.FileName);
                serializer.Serialize(writer, ListOgrenci);
                writer.Close();
                MessageBox.Show("Dosya kaydedildi");
            }
        }
        private void InitializeComponent()
        {
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.MaskedTextBox();
            this.dtpDogumTarihi = new System.Windows.Forms.DateTimePicker();
            this.lstBoxOgrenci = new System.Windows.Forms.ListBox();
            this.openFileXml = new System.Windows.Forms.OpenFileDialog();
            this.saveFileXml = new System.Windows.Forms.SaveFileDialog();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnIceAktar = new System.Windows.Forms.Button();
            this.btnDısaAktar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(112, 27);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(169, 22);
            this.txtAd.TabIndex = 0;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(112, 71);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(169, 22);
            this.txtSoyad.TabIndex = 1;
            // 
            // dtpDogumTarihi
            // 
            this.dtpDogumTarihi.Location = new System.Drawing.Point(112, 119);
            this.dtpDogumTarihi.Name = "dtpDogumTarihi";
            this.dtpDogumTarihi.Size = new System.Drawing.Size(169, 22);
            this.dtpDogumTarihi.TabIndex = 2;
            // 
            // lstBoxOgrenci
            // 
            this.lstBoxOgrenci.FormattingEnabled = true;
            this.lstBoxOgrenci.ItemHeight = 16;
            this.lstBoxOgrenci.Location = new System.Drawing.Point(350, 27);
            this.lstBoxOgrenci.Name = "lstBoxOgrenci";
            this.lstBoxOgrenci.Size = new System.Drawing.Size(230, 276);
            this.lstBoxOgrenci.TabIndex = 3;
            // 
            // openFileXml
            // 
            this.openFileXml.FileName = "openFileDialog1";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(99, 230);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click_1);
            // 
            // btnIceAktar
            // 
            this.btnIceAktar.Location = new System.Drawing.Point(47, 280);
            this.btnIceAktar.Name = "btnIceAktar";
            this.btnIceAktar.Size = new System.Drawing.Size(75, 23);
            this.btnIceAktar.TabIndex = 4;
            this.btnIceAktar.Text = "ıce aktar";
            this.btnIceAktar.UseVisualStyleBackColor = true;
            this.btnIceAktar.Click += new System.EventHandler(this.btnIceAktar_Click_1);
            // 
            // btnDısaAktar
            // 
            this.btnDısaAktar.Location = new System.Drawing.Point(159, 280);
            this.btnDısaAktar.Name = "btnDısaAktar";
            this.btnDısaAktar.Size = new System.Drawing.Size(75, 23);
            this.btnDısaAktar.TabIndex = 4;
            this.btnDısaAktar.Text = "dısa aktar";
            this.btnDısaAktar.UseVisualStyleBackColor = true;
            this.btnDısaAktar.Click += new System.EventHandler(this.btnDısaAktar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "soyad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "doğum tarihi";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(687, 372);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDısaAktar);
            this.Controls.Add(this.btnIceAktar);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lstBoxOgrenci);
            this.Controls.Add(this.dtpDogumTarihi);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
