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
    public partial class WorkoutEditForm : Form
    {
        private int ID;
        private bool edit;
        private bool isChecked = false;
        public WorkoutEditForm()
        {
            InitializeComponent();
            classesTableAdapter.Fill(danceclubdbDataSet.classes);
            edit = false;

        }

        public WorkoutEditForm(int id, string day_id, int group_id, TimeSpan time) : this()
        {
            edit = true;
            ID = id;
            groupComboBox.Text = group_id.ToString();
            dayComboBox.Text = day_id;
            timeTextBox.Text = time.ToString(); 

        }

        private void WorkoutEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.weekdays' table. You can move, or remove it, as needed.
            this.weekdaysTableAdapter.Fill(this.danceclubdbDataSet.weekdays);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.danceclubdbDataSet.classes);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.workouts' table. You can move, or remove it, as needed.
            this.workoutsTableAdapter.Fill(this.danceclubdbDataSet.workouts);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckTime())
            {
                MessageBox.Show("Час має розділятися знаком ':'.", "Error", MessageBoxButtons.OKCancel);
                //this.Show();
            }
            else
            {
                if (!edit)
                {
                    workoutsTableAdapter.InsertQuery(Convert.ToString(dayComboBox.SelectedValue),
                        Convert.ToInt32(groupComboBox.SelectedValue), TimeSpan.Parse(timeTextBox.Text));
                }
                else
                {
                    workoutsTableAdapter.UpdateQuery(Convert.ToString(dayComboBox.SelectedValue),
                        Convert.ToInt32(groupComboBox.SelectedValue), TimeSpan.Parse(timeTextBox.Text), ID);
                }
            }
            
            

            //if (!edit)
            //{
            //    workoutsTableAdapter.InsertQuery(Convert.ToString(dayComboBox.SelectedValue),
            //        Convert.ToInt32(groupComboBox.SelectedValue), timeTextBox.Text);
            //}
            //else
            //{
            //    workoutsTableAdapter.UpdateQuery(Convert.ToString(dayComboBox.SelectedValue),
            //        Convert.ToInt32(groupComboBox.SelectedValue), timeTextBox.Text, ID);
            //}

            //Close();
        }

        //Проверки.
        private bool CheckTime()
        {
            string str = timeTextBox.Text;
            if (str.Length <= 3) return false;
            if (str[2] == ':')
            {
                string[] words = timeTextBox.Text.Split(new char[] { ':' });
                string Str1 = words[0].Trim();
                string Str2 = words[1].Trim();
                int Num;
                bool isNum1 = int.TryParse(Str1, out Num);
                bool isNum2 = int.TryParse(Str2, out Num);
                if (isNum1 && isNum2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckNotNull()
        {
            if (groupComboBox.Text == "" || dayComboBox.Text == "" || timeTextBox.Text == "")
            {
                return false;
            }
            return true;
        }

        private void CheckAll()
        {
            if (!CheckTime())
            {
                MessageBox.Show("Невірно введено час.", "Error", MessageBoxButtons.OKCancel);
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
