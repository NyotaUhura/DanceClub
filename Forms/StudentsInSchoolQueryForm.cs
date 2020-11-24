using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceClub.Forms
{
    public partial class StudentsInSchoolQueryForm : Form
    {
        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";

        public StudentsInSchoolQueryForm()
        {
            InitializeComponent();
        }

        private void StudentsInSchoolQueryForm_Load(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            query = "SELECT COUNT(student_id) as Number, AVG(YEAR(NOW())-YEAR(birth_date)) as Average_age FROM students;";


            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();

        }
    }
}
