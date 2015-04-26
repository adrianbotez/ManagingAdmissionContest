using System;

namespace ManagingAdmissionContest
{
    public class Applicant
    {
        private string notaBac;
        private string notaInfo;
        private string notaMate;

        public string Cnp { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public double TestGrade { get; set; }
        public double BacGrade { get; set; }
        public double InfoGrade { get; set; }
        public double MathGrade { get; set; }

        public Applicant()
        {
            this.Cnp = null;
            this.Surname = null;
            this.Name = null;
            this.TestGrade = 0.0;
            this.BacGrade = 0.0;
            this.InfoGrade = 0.0;
            this.MathGrade = 0.0;
        }

        public Applicant(string cnp, string surname, string name, double testGrade, double bacGrade, double infoGrade, double mathGrade)
        {
            this.Cnp = cnp;
            this.Surname = surname;
            this.Name = name;
            this.TestGrade = testGrade;
            this.BacGrade = bacGrade;
            this.InfoGrade = infoGrade;
            this.MathGrade = mathGrade;
        }

        public Applicant(String applicatData)
        {
            string[] fields = applicatData.Split(',');

            this.Cnp = fields[0];
            this.Surname = fields[1];
            this.Name = fields[2];
            this.TestGrade = Convert.ToDouble(fields[3]);
            this.BacGrade = Convert.ToDouble(fields[4]);
            this.InfoGrade = Convert.ToDouble(fields[5]);
            this.MathGrade = Convert.ToDouble(fields[6]);
        }

        public Applicant(string cnp, string surname, string name, string notaBac, string notaInfo, string notaMate)
        {
            // TODO: Complete member initialization
            this.Cnp = cnp;
            this.Surname = surname;
            this.Name = name;
            this.notaBac = notaBac;
            this.notaInfo = notaInfo;
            this.notaMate = notaMate;
        }

        public override string ToString()
        {
            string s = Cnp + "," + Surname + "," + Name + "," + TestGrade + "," + BacGrade + "," + InfoGrade + "," + MathGrade;
            return s;
        }
        public override bool Equals(Object obj)
        {
            Applicant applicant = obj as Applicant;
            if (applicant == null)
                return false;
            else
                return Cnp.Equals(applicant.Cnp);
        }

        public override int GetHashCode()
        {
            return Int32.Parse(Cnp);
        }
    }
}
