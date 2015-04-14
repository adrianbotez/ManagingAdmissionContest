using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace ManagingAdmissionContest
{
    class ApplicantDatabase : IApplicantDatabase
    {
        private static ApplicantDatabase _instance;
        private List<Applicant> ApplicantList { get; set; }
        private string FileName { get; set; }

        /// <summary>
        /// Constructor initializes the list of Applicant objects.
        /// </summary>
        private ApplicantDatabase()
        {
            ApplicantList = new List<Applicant>();

        }

        /// <summary>
        /// Initializes the only instance of this class. 
        /// If the file already exists, it loads the data from file, if not, it creates a file.
        /// </summary>
        /// <param name="fileName">Can be the file name ("myfile.txt") 
        /// or the absolute path ("D:\ManagingAdmissionContest-master\myfile.txt").</param>
        /// <returns>Returns the only instance of this class.</returns>
        public static ApplicantDatabase InitializeDatabase(string fileName)
        {
            if (_instance == null)
            {
                _instance = new ApplicantDatabase();
            }

            try
            {
                if (File.Exists(fileName))
                {
                    _instance = LoadFromFile(fileName);
                }
                FileStream fs = File.Create(fileName);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            _instance.FileName = fileName;
            return _instance;
        }

        /// <summary>
        /// If the file exists, it deletes it, if not, it throws a FileNotFoundException.
        /// It sets the only instance to null.
        /// </summary>
        public void DeleteDatabase()
        {
            try
            {
                if (File.Exists(_instance.FileName))
                {
                    File.Delete(_instance.FileName);
                }
                else
                {
                    throw new FileNotFoundException("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            _instance = null;
        }

        /// <summary>
        /// It inserts the applicant, if it's not already in the list.
        /// </summary>
        /// <param name="applicant">The applicant to be inserted.</param>
        public void InsertRecord(Applicant applicant)
        {
            if (this.ApplicantList.IndexOf(applicant) == -1)
            {
                this.ApplicantList.Add(applicant);
            }
            SaveToFile();
        }

        /// <summary>
        /// If the applicant is in the list, it deletes it.
        /// </summary>
        /// <param name="applicant">The applicant to be deleted.</param>
        public void DeleteRecord(Applicant applicant)
        {
            if (this.ApplicantList.IndexOf(applicant) != -1)
            {
                this.ApplicantList.Remove(applicant);
            }
            SaveToFile();
        }

        /// <summary>
        /// It deletes the records that have the specified value for the specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="property">The property to search.</param>
        /// <param name="value">The value to search.</param>
        public void DeleteRecords(string property, string value)
        {
            Type t = typeof(Applicant);
            PropertyInfo p = t.GetProperty(property);
            List<Applicant> applicant_to_remove = new List<Applicant>();
            if (p != null)
            {
                foreach (Applicant a in ApplicantList)
                {
                    if (GetPropValue(a, property).ToString() == value)
                    {
                        applicant_to_remove.Add(a);
                    }
                }
                foreach (Applicant a in applicant_to_remove)
                {
                        ApplicantList.Remove(a);
                }

            }
            else
            {
                throw new ApplicantPropertyNotFoundException("Property " + property + "was not found.");
            }
            SaveToFile();
        }

        /// <summary>
        /// Returns the value of the property.
        /// </summary>
        /// <param name="src">The object that has the property.</param>
        /// <param name="propName">The name of the property.</param>
        /// <returns>The value of the property.</returns>
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        /// <summary>
        /// It sets a value to a property.
        /// </summary>
        /// <param name="src">The object that has the property.</param>
        /// <param name="propName">The name of the property.</param>
        /// <param name="value">The value we want to set.</param>
        public static void SetPropValue(object src, string propName, string value)
        {
            Type t = src.GetType();
            PropertyInfo p = t.GetProperty(propName);
            Type propType = p.PropertyType;
            if (propType.Equals(typeof (double)))
            {
                double doubleValue = Double.Parse(value);
                src.GetType().GetProperty(propName).SetValue(src, doubleValue, null);
            }
            else
            {
                src.GetType().GetProperty(propName).SetValue(src, value, null);
            }
        }

        /// <summary>
        /// It updates the records that have a certain value for a certain property, 
        /// with a specified value for a specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="forProperty">The property to search.</param>
        /// <param name="forValue">The value to search.</param>
        /// <param name="setProperty">The property to update.</param>
        /// <param name="setValue">The new value for the property.</param>
        public void UpdateRecords(string forProperty, string forValue, string setProperty, string setValue)
        {
            Type t = typeof (Applicant);
            PropertyInfo p1 = t.GetProperty(forProperty);
            PropertyInfo p2 = t.GetProperty(forProperty);
            if ((p1 != null) && (p2 != null))
            {
                foreach (Applicant a in ApplicantList)
                {
                    if (GetPropValue(a, forProperty).ToString() == forValue)
                    {
                        SetPropValue(a, setProperty, setValue);
                    }
                }
            }
            else
            {
                throw new ApplicantPropertyNotFoundException("One of the properties was not found.");
            }
            SaveToFile();
        }

        /// <summary>
        /// Returns all the applicant records.
        /// </summary>
        /// <returns>A list of Applicant objects.</returns>
        public List<Applicant> SelectAllRecords()
        {
            return this.ApplicantList;
        }

        /// <summary>
        /// It selects the records that have the specified value for the specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="property">The property to search.</param>
        /// <param name="value">The value to search.</param>
        /// <returns>Returns a list of Applicant objects.</returns>
        public List<Applicant> SelectRecords(string property, string value)
        {
            Type t = typeof(Applicant);
            PropertyInfo p = t.GetProperty(property);
            List<Applicant> applicants_to_return = new List<Applicant>();
            if (p != null)
            {
                foreach (Applicant a in ApplicantList)
                {
                    if (GetPropValue(a, property).ToString() == value)
                    {
                        applicants_to_return.Add(a);
                    }
                }
            }
            else
            {
                throw new ApplicantPropertyNotFoundException("Property " + property + "was not found.");
            }
            return applicants_to_return;
        }

        /// <summary>
        /// It saves the database to file.
        /// </summary>
        public void SaveToFile()
        {
            System.IO.File.WriteAllText(this.FileName, this.ToString());
        }

        /// <summary>
        /// It loads the database from file.
        /// </summary>
        /// <param name="fileName">The file from which to load the database.</param>
        /// <returns>Returns an Applicant Database</returns>
        public static ApplicantDatabase LoadFromFile(string fileName)
        {
            string line;
            Applicant applicant;
            ApplicantDatabase applicantDatabase = new ApplicantDatabase();

            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                applicant = new Applicant(line);
                applicantDatabase.ApplicantList.Add(applicant);
            }

            file.Close();
            return applicantDatabase;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Applicant applicant in ApplicantList)
            {
                sb.Append(applicant.ToString());
                sb.Append("\r\n");
            }
            return sb.ToString();
        }

    }

    public class DatabaseException : Exception
    {
        public DatabaseException():base()
        {
            
        }
        public DatabaseException(string message)
            : base(message)
        {

        }
    }

    public class ApplicantPropertyNotFoundException : DatabaseException
    {
        public ApplicantPropertyNotFoundException()
            : base()
        {

        }
        public ApplicantPropertyNotFoundException(string message)
            : base(message)
        {

        }
    }

    public class FileNotFoundException : DatabaseException
    {
        public FileNotFoundException()
            : base()
        {

        }
        public FileNotFoundException(string message)
            : base(message)
        {

        }
    }
    
}