using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CollegeSystem
{
    public partial class formDepartment : Form
    {
        private static string host = "127.0.0.1";
        private static string database = "sweng";
        private static string user = "root";
        private static string password = "";
        protected static string connectionString = "Data source=" + host + ";Database=" + database + ";username=" + user + ";password=;";
        MySqlConnection cnn;

        public formDepartment()
        {
            InitializeComponent();
        }

        private void formDepartment_Load(object sender, EventArgs e)
        {
            loadDefault();
            DisplayInGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            getAndInsertValues(txtName.Text, txtDesc.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update("Department", txtName.Text, txtDesc.Text, txtNumber.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            showDeleteDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearInput();
        } //ok

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInput();
            loadDefault();
        } //ok

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main form = new Main();
            form.Show();
            this.Hide();
        } //ok

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are about to exit, confirm?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        } //ok

        private void dgvDep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDep.Rows[e.RowIndex];

                txtNumber.Text = row.Cells["Number"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtDesc.Text = row.Cells["Description"].Value.ToString();

                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        //form functions
        private void clearInput()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtDesc.Text = "";
        } //ok

        private void loadDefault()
        {
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
        } //ok

        private void DisplayInGrid()
        {
            this.dgvDep.DataSource = null;
            this.dgvDep.Rows.Clear();

            connectionString = "Data Source=" + host
                + ";Database=" + database
                + ";User ID=" + user
                + ";Password=" + password
                + ";Convert Zero Datetime = True";

            cnn = new MySqlConnection(connectionString);
            String query = "select * from sweng.department;";
            MySqlConnection conDB = new MySqlConnection(connectionString);
            MySqlCommand cmdDB = new MySqlCommand(query, conDB);

            try
            {
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmdDB;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dTable;
                dgvDep.DataSource = bSource;
                MyAdapter.Update(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//ok

        private void updelChanges()
        {
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnClear.Enabled = true;
            clearInput();
        } //ok

        private void showDeleteDialog()
        {
            DialogResult dialogResult = MessageBox.Show("You are about to delete, confirm?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                delete("department", txtNumber.Text);
            }
        } //ok

        //sql functions
        private void insert(params string[] args) //format: table, name, description
        {
            string query = "INSERT INTO department (Name ,Description) VALUES (@Name, @Description)";

            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", args[1]);
                myCommand.Parameters.AddWithValue("@Description", args[2]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Added to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());
            }
        } //ok

        private void getAndInsertValues(string name, string description)
        {
            if (name == "" || description == "")
            {
                MessageBox.Show("Please Fill in all the requirements!", "WTF!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    insert("department", name, description);
                    clearInput();
                    DisplayInGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } //ok

        private void update(params string[] args) //format: table, name, description, number
        {
            string query = "UPDATE department set Name = @Name, Description = @Description where Number = @Number;";

            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", args[1]);
                myCommand.Parameters.AddWithValue("@Description", args[2]);
                myCommand.Parameters.AddWithValue("@Number", args[3]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());

                clearInput();
                DisplayInGrid();
                updelChanges();
            }
        } //ok

        private void delete(params string[] args) //format: table, number
        {
            string query = "DELETE FROM  department WHERE Number = @Number;";
            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Number", args[1]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());

                clearInput();
                DisplayInGrid();
                updelChanges();
            }
        } //ok
    }
}
