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
    public partial class StudentEditForm : Form
    {
        private int ID;
        private bool edit;
        private bool isChecked = false;
        public StudentEditForm()
        {
            InitializeComponent();
            studentsTableAdapter.Fill(danceclubdbDataSet.students);
            edit = false;
        }

        public StudentEditForm(int id, string first_name, string second_name, string third_name, string gender, DateTime date, string adress, string phone ) : this()
        {
            edit = true;
            ID = id;
            firstNameTextBox.Text = first_name;
            secondNameTextBox.Text = second_name;
            thirdNameTextBox.Text = third_name;
            dateTimePicker1.Value = date;
            genderComboBox.Text = gender;
            adressTextBox.Text = adress;
            phoneTextBox.Text = phone;
        }

        private void StudentEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.danceclubdbDataSet.students);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            if (isChecked)
            {
                if (!edit)
                {
                    studentsTableAdapter.InsertQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                        genderComboBox.Text, dateTimePicker1.Value,
                        adressTextBox.Text, phoneTextBox.Text);

                }
                else
                {
                    studentsTableAdapter.UpdateQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                        genderComboBox.Text, dateTimePicker1.Value,
                        adressTextBox.Text, phoneTextBox.Text, ID);
                }
                Close();
            }
            
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
