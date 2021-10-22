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
    public partial class Form3 : Form
    {
        public Form1 frm1;
        string ara;
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm1.randevuara();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            frm1.dtst.Clear();
            frm1.randevulistele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell hucre in dataGridView1.SelectedCells)
                {
                    ara = hucre.Value.ToString();

                }
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    frm1.bag.Open();
                    frm1.kmt.Connection = frm1.bag;
                    frm1.kmt.CommandText = "DELETE from randevubil WHERE Plaka='" + ara + "'";
                    frm1.kmt.ExecuteNonQuery();
                    frm1.kmt.Dispose();
                    frm1.bag.Close();
                    frm1.dtst.Clear();
                    frm1.randevulistele();

                }
            }
            catch
            {
                ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm1.dtst.Clear();
            frm1.randevulistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1.frm5.ShowDialog();
        }
    }
}
