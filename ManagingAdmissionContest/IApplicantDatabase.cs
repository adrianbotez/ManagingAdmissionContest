using System.Collections.Generic;

namespace ManagingAdmissionContest
{
    public interface IApplicantDatabase
    {
        void DeleteDatabase();
        void InsertRecord(Applicant applicant);
        void DeleteRecord(Applicant applicant);
        void DeleteRecords(string property, string value);
        void UpdateRecords(string forProperty, string forValue, string setProperty, string setValue);
        List<Applicant> SelectAllRecords();
        List<Applicant> SelectRecords(string property, string value);
        void SaveToFile();
        string ToString();
    }
}