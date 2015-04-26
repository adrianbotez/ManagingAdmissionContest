using System;

namespace ManagingAdmissionContest
{
    /// <summary>
    /// Manages a single applicant.
    /// </summary>
    public class Applicant
    {
        /// <summary>
        /// The id of the applicant
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The surname of the applicant
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The name of the applicant
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The test grade of the applicant
        /// </summary>
        public double TestGrade { get; set; }

        /// <summary>
        /// The bacalaureat grade of the applicant
        /// </summary>
        public double BacGrade { get; set; }

        /// <summary>
        /// The informatics grade of the applicant
        /// </summary>
        public double InfoGrade { get; set; }

        /// <summary>
        /// The mathematics grade of the applicant
        /// </summary>
        public double MathGrade { get; set; }

        /// <summary>
        /// The admission grade of the applicant
        /// </summary>
        public double AdmissionGrade { get; set; }

        /// <summary>
        /// Creates an applicant object with default values.
        /// </summary>
        public Applicant()
        {
            Id = null;
            Surname = null;
            Name = null;
            TestGrade = 0.0;
            BacGrade = 0.0;
            InfoGrade = 0.0;
            MathGrade = 0.0;
            AdmissionGrade = 0.0;
        }

        /// <summary>
        /// Creates an applicant object with given values for each property.
        /// </summary>
        /// <param name="id">The id of the applicant</param>
        /// <param name="surname">The surname of the applicant</param>
        /// <param name="name">The name of the applicant</param>
        /// <param name="testGrade">The written test grade of the applicant</param>
        /// <param name="bacGrade">The bacalaureat grade of the applicant</param>
        /// <param name="infoGrade">The bacalaureat:informatics grade of the applicant</param>
        /// <param name="mathGrade">The bacalaureat:mathematics grade of the applicant</param>
        /// <param name="admissionGrade">The admission contest grade of the applicant</param>
        public Applicant(string id, string surname, string name, double testGrade, double bacGrade, double infoGrade, double mathGrade, double admissionGrade)
        {
            Id = id;
            Surname = surname;
            Name = name;
            TestGrade = testGrade;
            BacGrade = bacGrade;
            InfoGrade = infoGrade;
            MathGrade = mathGrade;
            AdmissionGrade = admissionGrade;
        }

        /// <summary>
        /// Creates an applicant object from a single string.
        /// </summary>
        /// <param name="applicatData">A string with the data of the applicant</param>
        public Applicant(String applicatData)
        {
            string[] fields = applicatData.Split(',');

            Id = fields[0];
            Surname = fields[1];
            Name = fields[2];
            TestGrade = Convert.ToDouble(fields[3]);
            BacGrade = Convert.ToDouble(fields[4]);
            InfoGrade = Convert.ToDouble(fields[5]);
            MathGrade = Convert.ToDouble(fields[6]);
            AdmissionGrade = Convert.ToDouble(fields[7]);
        }

        public override string ToString()
        {
            string s = Id + "," + Surname + "," + Name + "," + TestGrade + "," + BacGrade + "," + InfoGrade + "," + MathGrade + "," + AdmissionGrade;
            return s;
        }
        public override bool Equals(Object obj)
        {
            Applicant applicant = obj as Applicant;
            if (applicant == null)
                return false;
            else
                return Id.Equals(applicant.Id);
        }

        public override int GetHashCode()
        {
            return Int32.Parse(Id);
        }
    }
}
