using System;
using System.IO;

namespace ManagingAdmissionContest
{
    /// <summary>
    /// Manages the more general aspects of database connection for the applicant database.
    /// </summary>
    class Database
    {
        /// <summary>
        /// Creates a database.
        /// </summary>
        /// <param name="databaseName">The name of the database</param>
        public static void CreateDatabase(string databaseName)
        {
            Directory.CreateDirectory(databaseName);
        }

        /// <summary>
        /// Creates a table.
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        public static void CreateTable(string tableName)
        {
            try
            {
                FileStream fs = File.Create(tableName);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a database.
        /// </summary>
        /// <param name="databaseName">The name of the database</param>
        public static void DeleteDatabase(string databaseName)
        {
            Directory.Delete(databaseName, true);
        }

        /// <summary>
        /// Deletes a table.
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        public static void DeleteTable(string tableName)
        {
            try
            {
                if (File.Exists(tableName))
                {
                    File.Delete(tableName);
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
        }
    }
}
