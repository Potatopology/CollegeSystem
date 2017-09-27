using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CollegeSystem
{
    class Employee : MyFunctions
    {
        private string table;
        private int number;
        private string name;
        private string position;
        private int leadNumber;

        private string[] parameterizedFields = { "@Number", "@Name", "@Position", "@LeadNum" };

        public Employee()
        {
            table = "";
            number = 0;
            name = "";
            position = "";
            leadNumber = 0;
        }
        public Employee(string tbl, int num, string n,  string pos, int leadNum)
        {
            table = tbl;
            number = num;
            name = n;
            position = pos;
            leadNumber = leadNum;
        }
        


    }
}
