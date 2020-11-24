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
        public NewStudentForm(int id, string first_name, string second_name, string third_name, string gender, DateTime date, string adress, string phone, string style) : this()
        {
            ID = id;
            firstNameTextBox.Text = first_name;
            secondNameTextBox.Text = second_name;
            thirdNameTextBox.Text = third_name;
            dateTimePicker1.Value = date;
            genderComboBox.Text = gender;
            adressTextBox.Text = adress;
            phoneTextBox.Text = phone;
            styleComboBox.Text = style;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            studentsTableAdapter.InsertQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                genderComboBox.Text, dateTimePicker1.Value, adressTextBox.Text, phoneTextBox.Text);
            
            //student_group
            Close();
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
                genderComboBox.Text == "" || adressTextBox.Text == "" || phoneTextBox.Text == "")
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
