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
    public partial class formEmployee : Form
    {
        private static string host = "127.0.0.1";
        private static string database = "sweng";
        private static string user = "root";
        private static string password = "";
        protected static string connectionString = "Data source=" + host + ";Database=" + database + ";username=" + user + ";password=;";
        MySqlConnection cnn;

        public formEmployee()
        {
            InitializeComponent();
        }

        //form load
        private void formEmployee_Load(object sender, EventArgs e)
        {
            loadDefault();
            DisplayInGrid();
        }

        //button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            getAndInsertValues(txtName.Text, txtPosition.Text, txtLeadNum.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update("employee", txtName.Text, txtPosition.Text, txtLeadNum.Text, txtNumber.Text);
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
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvEmp.Rows[e.RowIndex];

                txtNumber.Text = row.Cells["Number"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPosition.Text = row.Cells["Position"].Value.ToString();
                txtLeadNum.Text = row.Cells["TeamLeadNumber"].Value.ToString();

                btnUpdate.Enabled = true;
                btnCancel.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                btnClear.Enabled = false;
            }
        } //ok

        //form functions
        private void clearInput()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtPosition.Text = "";
            txtLeadNum.Text = "";
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
            this.dgvEmp.DataSource = null;
            this.dgvEmp.Rows.Clear();

            connectionString = "Data Source=" + host
                + ";Database=" + database
                + ";User ID=" + user
                + ";Password=" + password
                + ";Convert Zero Datetime = True";

            cnn = new MySqlConnection(connectionString);
            String query = "select * from sweng.employee;";
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
                dgvEmp.DataSource = bSource;
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
                delete("employee", txtNumber.Text);
            }
        }

        //sql functions
        private void insert(params string[] args) //format: table, name, position, leadNum
        {
            string query = "INSERT INTO employee (Name ,Position ,TeamLeadNumber) VALUES (@Name, @Position, @LeadNum)";
            
            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", args[1]);
                myCommand.Parameters.AddWithValue("@Position", args[2]);
                int leadNum = Convert.ToInt32(args[3]);
                myCommand.Parameters.AddWithValue("@LeadNum", leadNum);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Added to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());
            }
        } //ok

        private void getAndInsertValues(string name, string position, string leadNum)
        {
            if (name == "" || position == "" || leadNum == "")
            {
                MessageBox.Show("Please Fill in all the requirements!", "WTF!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    insert("employee", name, position, leadNum);
                    clearInput();
                    DisplayInGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } //ok

        private void update(params string[] args) //format: table, name, position, leadNum, number
        {
            string query = "UPDATE employee set Name = @Name, Position = @Position, TeamLeadNumber = @LeadNum where Number = @Number;";

            using (MySqlConnection myCon = new MySqlConnection(connectionString))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Name", args[1]);
                myCommand.Parameters.AddWithValue("@Position", args[2]);
                int leadNum = Convert.ToInt32(args[3]);
                myCommand.Parameters.AddWithValue("@LeadNum", leadNum);
                myCommand.Parameters.AddWithValue("@Number", args[4]);
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
            string query = "DELETE FROM  employee WHERE Number = @Number;";
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

        //event funtions
        public void onlyNum(object sender, KeyPressEventArgs e, Boolean isDecimal)
        {
            //accepts decimal
            if (isDecimal)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
                {
                    e.Handled = true;
                }
            }
            //only accepts unsigned int
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        } //ok

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

        } //ignore this

        private void txtPosition_TextChanged(object sender, EventArgs e)
        {

        } //ignore this

        private void txtLeadNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNum(sender, e, false);
        } //ok

        
    }
}
