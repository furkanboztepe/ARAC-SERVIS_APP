using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form2 frm2;
        public Form3 frm3;
        public Form4 frm4;
        public Form5 frm5;

        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
            frm3 = new Form3();
            frm4 = new Form4();
            frm5 = new Form5();
            frm2.frm1 = this;
            frm3.frm1 = this;
            frm4.frm1 = this;
            frm5.frm1 = this;
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=data.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();

        public void musara()
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From musbil", bag);
            if (frm2.textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from musbil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "musbil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From musbil" +
                 " where(MüsteriNo like '%" + frm2.textBox1.Text + "%' )";
            dtst.Clear();
            adtr.Fill(dtst, "musbil");
            bag.Close();
        }

        public void randevuara()
        {
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From randevubil", bag);
            if (frm3.textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from randevubil";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "randevubil");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From randevubil" +
                 " where(Plaka like '%" + frm3.textBox1.Text + "%' )";
            dtst.Clear();
            adtr.Fill(dtst, "randevubil");
            bag.Close();
        }

        public void muslistele()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From musbil", bag);
            adtr.Fill(dtst, "musbil");
            frm2.dataGridView1.DataMember = "musbil";
            frm2.dataGridView1.DataSource = dtst;
            adtr.Dispose();
            bag.Close();
        }

        public void randevulistele()
        {
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From randevubil", bag);
            adtr.Fill(dtst, "randevubil");
            frm3.dataGridView1.DataMember = "randevubil";
            frm3.dataGridView1.DataSource = dtst;
            adtr.Dispose();
            bag.Close();
        }

        public void combo()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musbil";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                frm5.comboBox2.Items.Add(oku[2].ToString());
                frm5.comboBox3.Items.Add(oku[3].ToString());
            }
            bag.Close();
            oku.Dispose();
            frm5.comboBox1.Sorted = true;
            frm5.comboBox2.Sorted = true;
            frm5.comboBox3.Sorted = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm3.ShowDialog();
        }
    }
}
