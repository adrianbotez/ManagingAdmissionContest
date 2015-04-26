using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace ManagingAdmissionContest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Filter = "txt files (*.txt)|*.txt";
            fdlg.FilterIndex = 2;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(fdlg.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
           // fdlg.Title = "C# Corner Open File Dialog";
           
        }

        private void publishResults_Click(object sender, EventArgs e)
        {
            IApplicantDatabase appDatabase = new ApplicantDatabase();

            TestPopulateDatabase(appDatabase);

            List<Applicant> listApplicants = appDatabase.SelectAllRecords();

            SortedList listApplicantsSortedByGrade = new SortedList();

            for (int iApp = 0; iApp < listApplicants.Count; iApp++)
            {
                Applicant applicant = listApplicants[iApp];

                double avgPonderateGrade = (applicant.BacGrade + applicant.InfoGrade + applicant.MathGrade) / 3;

                listApplicantsSortedByGrade.Add(avgPonderateGrade, applicant);
            }

            WriteResultsToPdfFile(listApplicantsSortedByGrade);
        }

        private void WriteResultsToPdfFile(SortedList listApplicantsSortedByGrade)
        {
            PdfDocument pdf = new PdfDocument();

            PdfPage pdfPage = pdf.AddPage();

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Regular);

            graph.DrawString("Faculty admission contest",
                            fontTitle,
                            XBrushes.Black,
                            new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point),
                            XStringFormats.TopCenter
                            );

            int yPoint = 40;

            XFont fontEntries = new XFont("Verdana", 16, XFontStyle.Regular);

            for (int iApp = listApplicantsSortedByGrade.Count - 1; iApp >= 0  ; iApp--)
            {
                Applicant applicant = listApplicantsSortedByGrade.GetByIndex(iApp) as Applicant;

                double avgGrade = (double)listApplicantsSortedByGrade.GetKey(iApp);

                avgGrade = Math.Round(avgGrade, 2);

                double limitBudget = Convert.ToDouble(budgetFinanced.Text);
                double limitFeePayer = Convert.ToDouble(feePayer.Text);

                string typeCandidate = "";

                XSolidBrush brush;

                if (avgGrade >= limitBudget)
                {
                    typeCandidate = "budget-financed";

                    brush = XBrushes.Green;
                }
                else if (avgGrade < limitBudget && avgGrade >= limitFeePayer)
                {
                    typeCandidate = "fee payer";

                    brush = XBrushes.Black;
                }
                else
                {
                    typeCandidate = "rejected";

                    brush = XBrushes.Red;
                }


                graph.DrawString(applicant.Surname + " " + applicant.Name, fontEntries, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(avgGrade.ToString(), fontEntries, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(typeCandidate, fontEntries, brush, new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                yPoint = yPoint + 40;
            }

            pdf.Save("ResultsPDF.pdf");

            Process.Start("ResultsPDF.pdf");
        }

        private void budgetFinanced_TextChanged(object sender, EventArgs e)
        {
            decimal result = 0;

            if (Decimal.TryParse(budgetFinanced.Text, out result))
            {
                if (result < 5)
                {
                    MessageBox.Show("Inferior limit for rejected applicants!");

                    if (budgetFinanced.Text.Length >= 1)
                    {
                        budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
                else if (result > 10)
                {
                    MessageBox.Show("Grade is to high!");

                    if (budgetFinanced.Text.Length >= 1)
                    {
                        budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter only numbers.");

                if (budgetFinanced.Text.Length >= 1)
                {
                    budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                }
                
            }
        }

        private void feePayer_TextChanged(object sender, EventArgs e)
        {
            decimal result = 0, resultsBudget = 0;

            if (Decimal.TryParse(feePayer.Text, out result))
            {
                if (result < 5)
                {
                    MessageBox.Show("Inferior limit for rejected applicants");

                    if (feePayer.Text.Length >= 1)
                    {
                        feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                    }
                }
                else if (result > 10)
                {
                    MessageBox.Show("Grade is to high!");

                    if (feePayer.Text.Length >= 1)
                    {
                        feePayer.Text = feePayer.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
                else if (Decimal.TryParse(budgetFinanced.Text, out resultsBudget))
                {
                    if (resultsBudget < result)
                    {
                        MessageBox.Show("Limit for fee payer must be lower than budget financed.");

                        if (feePayer.Text.Length >= 1)
                        {
                            feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter only numbers.");

                if (feePayer.Text.Length >= 1)
                {
                    feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                }

            }
        }



        private void TestPopulateDatabase(IApplicantDatabase appDatabase)
        {
            Applicant applicant1 = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75);

            Applicant applicant2 = new Applicant("2342184593201", "Victor", "Rachieru", 7, 4.75, 4, 4.5);

            Applicant applicant3 = new Applicant("1314541890188", "Marius", "Zavincu", 8, 9.75, 10, 6.75);

            appDatabase.InsertRecord(applicant1);
            appDatabase.InsertRecord(applicant2);
            appDatabase.InsertRecord(applicant3);
        }
    }
}
