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
    public partial class GroupsByDayQueryForm : Form
    {
        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";

        public GroupsByDayQueryForm()
        {
            InitializeComponent();
        }

        private void GroupsByDayQueryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.weekdays' table. You can move, or remove it, as needed.
            this.weekdaysTableAdapter.Fill(this.danceclubdbDataSet.weekdays);


            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            //Добавить проверки, после некорректных значений ломается. 
            if (comboBox1.Text != "")
            {
                query = "SELECT classes.group_name FROM classes, weekdays, workouts WHERE weekdays.day_short_name = '" +
                        comboBox1.Text + "' AND workouts.day_short_name = weekdays.day_short_name AND workouts.group_id = classes.group_id; ";

            }
            else
            {
                query = "SELECT group_name FROM classes; ";
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();
        }
    }
}
