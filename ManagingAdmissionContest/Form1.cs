using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagingAdmissionContest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            Label surnameL = new Label();
            surnameL.Text = "Prenume: " + surname;
            string name = textBox2.Text;
            Label nameL = new Label();
            nameL.Text ="Nume: " +name;
            string cnp = textBox3.Text;
            Label cnpL = new Label();
            cnpL.Text = "CNP: " + cnp;
            string notaBac = textBox4.Text;
            Label notaBacL = new Label();
            notaBacL.Text = "Nota Bac: " + notaBac;
            string notaInfo = textBox5.Text;
            Label notaInfoL = new Label();
            notaInfoL.Text = "Nota informatica: " + notaInfo;
            string notaMate = textBox6.Text;
            Label notaMateL = new Label();
            notaMateL.Text = "Nota matematica: " + notaMate;
            this.Hide();
            Form2 f = new Form2();
            f.Show();
            f.Controls.Add(surnameL);
            f.Controls.Add(nameL);
            f.Controls.Add(cnpL);
            f.Controls.Add(notaBacL);
            f.Controls.Add(notaInfoL);
            f.Controls.Add(notaMateL);
            surnameL.Location = new Point(48, 48);
            nameL.Location = new Point(48, 28);
            cnpL.Location=new Point(48, 70);
            notaBacL.Location = new Point(48, 92);
            notaInfoL.Location = new Point(48, 112);
            notaMateL.Location = new Point(48, 132);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
