using DanceClub.danceclubdbDataSetTableAdapters;
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
    public partial class AgeEditForm : Form
    {
        private int ID;
        private bool edit;
        private bool isChecked = false;

        public AgeEditForm()
        {
            InitializeComponent();
            age_categoriesTableAdapter.Fill(danceclubdbDataSet.age_categories);
            edit = false;
        }
        public AgeEditForm(int id, string age_name, int min_age, int max_age) : this()
        {
            edit = true;
            ID = id;
            nameTextBox.Text = age_name.ToString();
            minAgeTextBox.Text = min_age.ToString();
            maxAgeTextBox.Text = max_age.ToString();
        }

        private void AgeEditForm_Load(object sender, EventArgs e)
        {
            this.age_categoriesTableAdapter.Fill(this.danceclubdbDataSet.age_categories);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            if (!isChecked)
            {
                return;
            }
            if (isChecked)
            {
                if (!edit)
                {
                    age_categoriesTableAdapter.InsertQuery(nameTextBox.Text, Convert.ToInt32(minAgeTextBox.Text), Convert.ToInt32(maxAgeTextBox.Text));

                }
                else
                {
                    age_categoriesTableAdapter.UpdateQuery(nameTextBox.Text, Convert.ToInt32(minAgeTextBox.Text), Convert.ToInt32(maxAgeTextBox.Text), ID);
                }
            }
            Close();
        }

        // Проверки.
        private bool CheckNotNull()
        {
            if (nameTextBox.Text == "" || minAgeTextBox.Text == "" || maxAgeTextBox.Text == "")
            {
                return false;
            }
            return true;
        }

        private bool CheckNum1()
        {
            string Str = minAgeTextBox.Text.Trim();
            bool isNum = int.TryParse(Str, out _);
            if (isNum)
            {
                if (Convert.ToInt32(minAgeTextBox.Text) >= 3)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool CheckNum2()
        {
            string Str = maxAgeTextBox.Text.Trim();
            int Num;
            bool isNum = int.TryParse(Str, out Num);
            if (isNum)
            {
                if (Convert.ToInt32(maxAgeTextBox.Text) >= 3)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool IsNum2Bigger()
        {
            if (Convert.ToInt32(minAgeTextBox.Text) <= Convert.ToInt32(maxAgeTextBox.Text))
                return true;
            return false;
        }
        private void CheckAll()
        {
            if (!CheckNotNull())
            {
                MessageBox.Show("Не всі поля заповнені.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckNum1())
            {
                MessageBox.Show("Невірно введено мінімальний вік.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!CheckNum2())
            {
                MessageBox.Show("Невірно введено максимальний вік.", "Error", MessageBoxButtons.OKCancel);
            }
            else if (!IsNum2Bigger())
            {
                MessageBox.Show("Мінімальний вік має бути меншим за максимальний.", "Error", MessageBoxButtons.OKCancel);
            }
            else
            {
                isChecked = true;
            }
        }

        private void AgeEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
