using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NICManager
{
    public static class Query
    {
        /* 
         * DATABASE CONFIGURATION SETTINGS
         * These settings allow you to set the database server, database name, and the configuration user information.
         * By default, the configUser is called on the first start of the program so that an administrator can create 
         * a superuser account and use the administrative tools in NICManager. Once the installation and setup has been
         * complete, this user will be deleted from the database and only the superuser (or another administrator) will
         * be able to access the administrative functions.
         */
        public static string dbServer = "localhost";            // Server hostname or IP address
        public static string dbDatabase = "nicdb";              // Database Name
        public static string dbUserDefault = "configUser";             // Default User
        public static string dbPasswordDefault = "configPassword1";    // Default Password

        // Default configuration connection.
        public static string configConnect = "server=" + dbServer +
                                             ";database=" + dbDatabase +
                                             ";uid=" + dbUserDefault +
                                             ";pwd=" + dbPasswordDefault + ";";
        
        // Default defines for table names in database. These values be changed but must also be changed in the database.
        public static Dictionary<string, string> dbTables = new Dictionary<string, string>()
        {
            { "attach", "attachments" },
            { "archiveAttach", "attachments_archive" },
            { "lookupAttachEntries", "attachments_entries" },
            { "entries", "entries" },
            { "archiveEntries", "entries_archive" },
            { "logsEntries", "logs_entries" },
            { "logsMessages", "logs_messages" },
            { "logsUsers", "logs_users" },
            { "users", "users" }
        };

        // Default defines for column names in Attachments and Attachments Archive tables. These values be changed but must also be changed in the database.
        public static Dictionary<string, string> dbFieldsAttach = new Dictionary<string, string>()
        {
            { "id", "id" },
            { "name", "name" },
            { "cat", "category" },
            { "type", "fileType" },
            { "filename", "fileName" },
            { "location", "fileLocation" },
            { "userid", "users_id" }
        };

        // Default defines for column names in Users table. These values be changed but must also be changed in the database.
        public static Dictionary<string, string> dbUsers = new Dictionary<string, string>()
        {
            { "id", "id" },
            { "username", "username" },
            { "created", "created" }
        };

        /*
         * DATABASE PRODUCTION SETTINGS
         * These queries are designed for databases in production mode that have completed the configuration process.
         */

        // Default user connection with parameters.
        public static string userConnect = "server=" + dbServer +
                                           ";database=" + dbDatabase +
                                           ";uid=@username" +
                                           ";pwd=@password" + ";";

        /* 
         * DATABASE CONNECTION OPERATOR QUERIES
         * These queries are used by operators to select and manipulate records.
         */

            // Select a single record found by NIC number
            public static string queryRecordByNIC = "SELECT 1 FROM " + dbTables["entries"] + " WHERE nic=@nic;";
            // Selectm a single record found by case number
            public static string queryRecordByCase = "SELECT 1 FROM " + dbTables["entries"] + " WHERE caseNumber=@caseNumber;";

        /*
         * DATABASE CONNECTION ADMINISTRATOR QUERIES
         * These queries are used by administrators to assert full control over the model.
         */

            // Create a standard user.
            public static string adminCreateUser = "CREATE USER '@username'@'" + dbServer + "' IDENTIFIED WITH mysql_native_password BY '@password';" +
                                                   "GRANT INSERT, UPDATE, SELECT, on *.* TO '@username'@'" + dbServer + "';" +
                                                   "FLUSH PRIVILEGES;";
            // Create an administrator user.
            public static string adminCreateAdmin = "CREATE USER '@username'@'" + dbServer + "' IDENTIFIED WITH mysql_native_password BY '@password';" +
                                                   "GRANT CREATE, ALTER, DROP, INSERT, UPDATE, DELETE, SELECT, REFERENCES, RELOAD on *.* TO '@username'@'" + dbServer + "' WITH GRANT OPTION;" +
                                                   "FLUSH PRIVILEGES;";
    }
}
