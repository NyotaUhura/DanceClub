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
    public partial class GroupsInTeachersQueryForm : Form
    {
        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";

        public GroupsInTeachersQueryForm()
        {
            InitializeComponent();
        }

        private void GroupsInTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.danceclubdbDataSet.teachers);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            query = "SELECT group_name FROM classes WHERE teacher_id = " +
                    Convert.ToInt32(comboBox1.SelectedValue) + "; ";


            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();
        }
    }
}
