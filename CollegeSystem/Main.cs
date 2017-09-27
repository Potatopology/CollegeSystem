using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            formEmployee form = new formEmployee();
            form.Show();
            this.Hide();
        }

        private void btnTeamLead_Click(object sender, EventArgs e)
        {
            formTeamLead form = new formTeamLead();
            form.Show();
            this.Hide();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            formDepartment form = new formDepartment();
            form.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
