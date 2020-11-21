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
        int ID;
        bool edit;

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
        //public WorkoutEditForm(int id, string day_id, int group_id, string time) : this()
        //{
        //    edit = true;
        //    ID = id;
        //    groupComboBox.Text = group_id.ToString();
        //    dayComboBox.Text = day_id;
        //    timeTextBox.Text = time;

        //}

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
    }
}
