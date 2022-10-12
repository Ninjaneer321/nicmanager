using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NICManager
{
    internal class DatabaseConnection
    {
        Authenticator authenticator = new Authenticator();

        public bool ConfigLoginDb()
        {
            MySqlConnection configConn = new MySqlConnection(Query.configConnect);
            try
            {
                configConn.Open();
                Console.WriteLine("Connection established.");
                configConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed. Error: " + ex);
                return false;
            }
        }
        public MySqlConnection UserLoginDb(string username, string password)
        {
            MySqlCommand userLoginQuery = new MySqlCommand(Query.userConnect);
            userLoginQuery.Parameters.AddWithValue("@username", username);
            userLoginQuery.Parameters.AddWithValue("@password", authenticator.GetHash(password));
            MySqlConnection userConnect = new MySqlConnection(userLoginQuery.ToString());

            try { 
                Int32 match = (Int32) userLoginQuery.ExecuteScalar();
                MessageBox.Show("Connection successful.");
                return userConnect;
            } catch (Exception ex) {
                MessageBox.Show("Connection failed. Error: " + ex);
                return null;
            }
        }
    }
}
