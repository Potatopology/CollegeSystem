using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CollegeSystem
{
    class MyFunctions
    {
        private static string host = "127.0.0.1";
        private static string database = "sweng";
        private static string user = "root";
        protected static string connectionString = "Data source=" + host + ";Database=" + database + ";username=" + user + ";password=;";

        public static void insertAll(params string[] args) //done: 2B improved
        {
            string query = "";

            switch (args[0])
            {
                case "employee":
                    query = "INSERT INTO employee (Name ,Position ,TeamLeadNumber) VALUES (@Name, @Position, @LeadNum)";
                    break;
                case "team_lead":
                    query = "INSERT INTO team_lead (Name ,DepNum) VALUES (@Name, @DepNum)";
                    break;
                case "department":
                    query = "INSERT INTO department (Name ,Desc) VALUES (@Name, @Desc)";
                    break;
                default:
                    MessageBox.Show(":<");
                    break;
            }

            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                switch (args[0])
                {
                    case "employee":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        myCommand.Parameters.AddWithValue("@Position", args[2]);
                        int leadNum = Convert.ToInt32(args[3]);
                        myCommand.Parameters.AddWithValue("@LeadNum", leadNum);
                        break;
                    case "team_lead":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        int depNum = Convert.ToInt32(args[2]);
                        myCommand.Parameters.AddWithValue("@DepNum", depNum);
                        break;
                    case "department":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        myCommand.Parameters.AddWithValue("@Desc", args[2]);
                        break;
                    default:
                        MessageBox.Show(":<");
                        break;
                }

                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Added to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());
            }
        }

        public static void updateAll(params string[] args) //doing
        {
            string query = "";

            switch (args[0])
            {
                case "employee":
                    query = "UPDATE employee set Name = @Name, Position = @Position, TeamLeadNumber = @LeadNum where Number = @Number;";
                    break;
                case "team_lead":
                    query = "UPDATE @Table set Name = @Name, DepNum = @DepNum where Number = @Number;";
                    break;
                case "department":
                    query = "UPDATE @Table set @Field = @Value where Number = @Number;";
                    break;
                default:
                    MessageBox.Show("madafukin starboy");
                    break;
            }

            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                switch (args[0])
                {
                    case "employee":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        myCommand.Parameters.AddWithValue("@Position", args[2]);
                        int leadNum = Convert.ToInt32(args[3]);
                        myCommand.Parameters.AddWithValue("@LeadNum", leadNum);
                        myCommand.Parameters.AddWithValue("@Number", args[4]);
                        break;
                    case "team_lead":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        int depNum = Convert.ToInt32(args[2]);
                        myCommand.Parameters.AddWithValue("@DepNum", depNum);
                        myCommand.Parameters.AddWithValue("@Number", args[4]);
                        break;
                    case "department":
                        myCommand.Parameters.AddWithValue("@Name", args[1]);
                        myCommand.Parameters.AddWithValue("@Desc", args[2]);
                        myCommand.Parameters.AddWithValue("@Number", args[4]);
                        break;
                    default:
                        MessageBox.Show("madafukin starboy");
                        break;
                }

                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());
            }
        }

        
    }
}
