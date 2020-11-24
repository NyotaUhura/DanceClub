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
    public partial class StudentsInStylesQueryForm : Form
    {
        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";

        public StudentsInStylesQueryForm()
        {
            InitializeComponent();
        }

        private void GroupsInStylesQueryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.styles' table. You can move, or remove it, as needed.
            this.stylesTableAdapter.Fill(this.danceclubdbDataSet.styles);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            query =
                "SELECT COUNT(students.student_id) as Number FROM students, classes, styles, student_group " +
                "WHERE styles.style_id = '" + comboBox1.SelectedValue + "' " +
                "AND classes.style_id = styles.style_id AND student_group.group_id = classes.group_id " +
                "AND student_group.student_id = students.student_id;";


            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();
        }
    }
}
