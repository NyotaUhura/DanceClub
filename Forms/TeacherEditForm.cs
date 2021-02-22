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
    public partial class TeacherEditForm : Form
    {
        private int ID;
        private bool edit;
        private bool isChecked = false;

        public TeacherEditForm()
        {
            InitializeComponent();
            teachersTableAdapter.Fill(danceclubdbDataSet.teachers);
            edit = false;
        }

        public TeacherEditForm(int id, string first_name, string second_name, string third_name, string phone) : this()
        {
            edit = true;
            ID = id;
            firstNameTextBox.Text = first_name;
            secondNameTextBox.Text = second_name;
            thirdNameTextBox.Text = third_name;
            phoneTextBox.Text = phone;
        }

        private void TeacherEditForm_Load(object sender, EventArgs e)
        {
            this.teachersTableAdapter.Fill(this.danceclubdbDataSet.teachers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            if (!isChecked)
            {
                return;
            }
            else
            {
                if (!edit)
                {
                    teachersTableAdapter.InsertQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                        phoneTextBox.Text);

                }
                else
                {
                    teachersTableAdapter.UpdateQuery(firstNameTextBox.Text, secondNameTextBox.Text, thirdNameTextBox.Text,
                        phoneTextBox.Text, ID);
                }
            }
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
        private bool CheckNotNumber()
        {
            string A = firstNameTextBox.Text + secondNameTextBox.Text + thirdNameTextBox.Text;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= '0' && A[i] <= '9')
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckNotNull()
        {
            if (firstNameTextBox.Text == "" || secondNameTextBox.Text == "" || thirdNameTextBox.Text == "" ||
                phoneTextBox.Text == "")
            {
                return false;
            }
            return true;
        }
        private void CheckAll()
        {
            if (!CheckNotNull())
            {
                MessageBox.Show("Не всі поля заповнені.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckNotNumber())
            {
                MessageBox.Show("ПІБ не має містити цифр.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckPhone())
            {
                MessageBox.Show("Невірно введено номер.", "Error", MessageBoxButtons.OKCancel);
            }
            else
            {
                isChecked = true;
            }
        }

        private void TeacherEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
