using System.Collections.Generic;

namespace ManagingAdmissionContest
{
    /// <summary>
    /// Manages the database connection for the applicant database.
    /// </summary>
    public interface IApplicantDatabase
    {
        /// <summary>
        /// Deletes the database.
        /// </summary>
        void DeleteDatabase();
        
        /// <summary>
        /// It inserts the applicant, if it's not already in the list.
        /// </summary>
        /// <param name="applicant">The applicant to be inserted.</param>
        void InsertRecord(Applicant applicant);
        
        /// <summary>
        /// If the applicant is in the list, it deletes it.
        /// </summary>
        /// <param name="applicant">The applicant to be deleted.</param>
        void DeleteRecord(Applicant applicant);
        
        /// <summary>
        /// It deletes the records that have the specified value for the specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="property">The property to search.</param>
        /// <param name="value">The value to search.</param>
        void DeleteRecords(string property, string value);
        
        /// <summary>
        /// It updates the records that have a certain value for a certain property, 
        /// with a specified value for a specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="forProperty">The property to search.</param>
        /// <param name="forValue">The value to search.</param>
        /// <param name="setProperty">The property to update.</param>
        /// <param name="setValue">The new value for the property.</param>
        void UpdateRecords(string forProperty, string forValue, string setProperty, string setValue);
        
        /// <summary>
        /// Returns all the applicant records.
        /// </summary>
        /// <returns>A list of Applicant objects.</returns>
        List<Applicant> SelectAllRecords();
        
        /// <summary>
        /// It selects the records that have the specified value for the specified property.
        /// Throws ApplicantPropertyNotFoundException if the property is not found.
        /// </summary>
        /// <param name="property">The property to search.</param>
        /// <param name="value">The value to search.</param>
        /// <returns>Returns a list of Applicant objects.</returns>
        List<Applicant> SelectRecords(string property, string value);
        
        /// <summary>
        /// It saves the database to file.
        /// </summary>
        void SaveToFile();

        /// <summary>
        /// It converts the applicant database to string.
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}