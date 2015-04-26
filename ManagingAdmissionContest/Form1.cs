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
            decimal myDec;
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text)
                )
            {
                MessageBox.Show("All fields must be field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox4.Text, out myDec))
            {
                MessageBox.Show("Baccalaureat grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox5.Text, out myDec))
            {
                MessageBox.Show("Computer Science grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox6.Text, out myDec))
            {
                MessageBox.Show("Mathematics grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else
            {
                string surname = textBox1.Text;
                Label surnameL = new Label();
                surnameL.Text = "Firstname: " + surname;
                string name = textBox2.Text;
                Label nameL = new Label();
                nameL.Text = "Lastname: " + name;
                string cnp = textBox3.Text;
                Label cnpL = new Label();
                cnpL.Text = "Badge no.: " + cnp;
                string notaBac = textBox4.Text;
                Label notaBacL = new Label();
                notaBacL.Text = "Baccalaureate grade: " + notaBac;
                string notaInfo = textBox5.Text;
                Label notaInfoL = new Label();
                notaInfoL.Text = "Computer science grade: " + notaInfo;
                string notaMate = textBox6.Text;
                Label notaMateL = new Label();
                notaMateL.Text = "Mathematics grade: " + notaMate;
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
                cnpL.Location = new Point(48, 70);
                notaBacL.Location = new Point(48, 92);
                notaInfoL.Location = new Point(48, 117);
                notaMateL.Location = new Point(48, 137);
            }
            //Applicant applicant = new Applicant(cnp, surname, name, notaBac, notaInfo, notaMate);
            //IApplicantDatabase appDatabase = new ApplicantDatabase();
            //appDatabase.InsertRecord(applicant);


        }

        public string getName
        {
            get { return "Nume: " + textBox2.Text; }
        }
        public string getFirstname
        {
            get { return "Prenume: " + textBox1.Text; }
        }
        public string getNo
        {
            get { return "Nr. legitimatie: " + textBox3.Text; }
        }

        public string getNotaBac
        {
            get { return "Nota Bacalaureat: " + textBox4.Text; }
        }

        public string getNotaMate
        {
            get { return "Nota Matematica: " +textBox6.Text; }
        }

        public string getNotaInfo
        {
            get { return "Nota Informatica " + textBox5.Text; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
