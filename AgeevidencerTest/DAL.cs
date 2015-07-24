using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AgeevidencerTest
{
    public class DAL
    {

        //Variables
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DAL()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "aedbtest";
            uid = "root";
            password = "123123123.123123123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public string getFirstName()
        {
            string xml = "<USER>";
            if (OpenConnection())
            {
                string query = "SELECT * FROM user";

                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Read results
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    xml += "<ID>" + dataReader["ID"] + "</ID>";
                    xml += "<NAME>" + dataReader["Name"] + "</NAME>";
                    xml += "<AGEMONTH>" + dataReader["AgeMonth"] + "</AGEMONTH>";
                    xml += "<GENDER>" + dataReader["Gender"] + "</GENDER>";
                    xml += "<WORLD>" + dataReader["World"] + "</WORLD>";
                    xml += "<ACTIVE>" + dataReader["Active"] + "</ACTIVE>";
                    xml += "<EMAIL>" + dataReader["Email"] + "</EMAIL>";
                    xml += "<SCORE>" + dataReader["Score"] + "</SCORE>";
                    xml += "<AGEYEAR>" + dataReader["AgeYear"] + "</AGEYEAR>";
                    xml += "<PASSWORD>" + dataReader["Password"] + "</PASSWORD>";
                }

                //close Data Reader
                dataReader.Close();

                //close connection
                this.CloseConnection();

                xml += "</USER>";

                return xml;
            }
            else
            {
                xml = "DENIED</USER>";
                return xml;
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                
                return false;
            }
        }

        public void InsertUser(string instr, string inwhere)
        {
            string query = "INSERT INTO user ("+inwhere+") VALUES("+instr+")";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public void getPhotos()
        {
            //Check in test...
        }


    }
}