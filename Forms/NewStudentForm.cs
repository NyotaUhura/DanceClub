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
    public partial class NewStudentForm : Form
    {
        private int ID;
        private bool isChecked = false;

        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";

        public NewStudentForm()
        {
            InitializeComponent();
        }

        private void NewStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.styles' table. You can move, or remove it, as needed.
            this.stylesTableAdapter.Fill(this.danceclubdbDataSet.styles);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.weekdays' table. You can move, or remove it, as needed.
            this.weekdaysTableAdapter.Fill(this.danceclubdbDataSet.weekdays);

        }
        public NewStudentForm(int id, string first_name, string second_name, string third_name, string gender, DateTime date, string adress, string phone, int style_id, int group_id) : this()
        {
            ID = id;
            firstNameTextBox.Text = first_name;
            secondNameTextBox.Text = second_name;
            thirdNameTextBox.Text = third_name;
            dateTimePicker1.Value = date;
            genderComboBox.Text = gender;
            adressTextBox.Text = adress;
            phoneTextBox.Text = phone;
            styleComboBox.Text = style_id.ToString();
            //group_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            studentsTableAdapter.InsertQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                genderComboBox.Text, dateTimePicker1.Value, adressTextBox.Text, phoneTextBox.Text);
            

            if (FindGroup(ref ID) != 0)
            {
                student_groupTableAdapter.InsertQuery(ID, FindGroup(ref ID), DateTime.Today);
                Close();
            }
            else
            {
                MessageBox.Show("Групи, що підходить, немає.", "Error");
                Close();
            }
            
        }

        private int FindGroup(ref int id)
        {
            /////Возраст.
            
            var age = (dateTimePicker1.Value - DateTime.Today).Duration().Days/365;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;
            string query1;

            query = "SELECT group_id FROM classes, students, age_categories, styles WHERE student_id = " + ID +
                    " AND " + age + " >= age_categories.min_age AND " + age + " <= age_categories.max_age " +
                    " AND classes.age_id = age_categories.age_id AND classes.style_id = styles.style_id;";

            query1 = "SELECT student_id FROM students ORDER BY student_id DESC LIMIT 1;";

            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());

            MySqlCommand command1 = new MySqlCommand(query1, connection);
            DataTable dt1 = new DataTable();
            dt1.Load(command1.ExecuteReader());
            id = Convert.ToInt32(dt1.Rows[0].ItemArray[0]);

            if (dt.Rows.Count != 0) return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            connection.Close();
            return 0;
        }

        // Проверки.
        private bool CheckPhone()
        {
            if (phoneTextBox.Text.Length > 10)
            {
                return false;
            }
            else
            {
                string Str = phoneTextBox.Text.Trim();
                int Num;
                bool isNum = int.TryParse(Str, out Num);
                if (isNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool CheckGender()
        {
            if (genderComboBox.Text == "ч" || genderComboBox.Text == "ж")
            {
                return true;
            }
            return false;
        }

        private bool CheckNotNull()
        {
            if (firstNameTextBox.Text == "" || secondNameTextBox.Text == "" || thirdNameTextBox.Text == "" ||
                genderComboBox.Text == "" || adressTextBox.Text == "" || phoneTextBox.Text == "" || styleComboBox.Text == "")
            {
                return false;
            }
            return true;
        }
        private void CheckAll()
        {
            if (!CheckPhone())
            {
                MessageBox.Show("Невірно введено номер.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckGender())
            {
                MessageBox.Show("Стать має бути ч або ж.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckNotNull())
            {
                MessageBox.Show("Не всі поля заповнені.", "Error", MessageBoxButtons.OKCancel);
            }
            else
            {
                isChecked = true;
            }
        }
    }
}
