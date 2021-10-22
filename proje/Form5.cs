using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proje
{
    public partial class Form5 : Form
    {
        public Form1 frm1;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            frm1.combo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                try
                {

                    frm1.bag.Open();
                    frm1.kmt.Connection = frm1.bag;
                    frm1.kmt.CommandText = "INSERT INTO randevubil(RandevuTarihi,RandevuSaati,AltRanTarihi,AltRanSaati,Plaka,MüsteriAd,MüsteriSoyad,AracTipi,AracSasiNo,KilometreDurumu,ModelYili) VALUES ('" + dateTimePicker1.Text + "','" + textBox1.Text + "','" + dateTimePicker2.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker3.Text + "') ";
                    frm1.kmt.ExecuteNonQuery();
                    frm1.kmt.Dispose();
                    frm1.bag.Close();
                    for (int i = 0; i < this.Controls.Count - 1; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                        if (this.Controls[i] is ComboBox) this.Controls[i].Text = "";
                    }

                    MessageBox.Show("Kayıt işlemi tamamlandı ! ");
                    frm1.dtst.Clear();
                    frm1.randevulistele();
                }
                catch
                {
                    ;
                }
            }
        }
    }
}
