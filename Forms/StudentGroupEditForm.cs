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
    public partial class StudentGroupEditForm : Form
    {
        int ID;
        bool edit;
        private bool isChecked = false;

        public StudentGroupEditForm()
        {
            InitializeComponent();
            student_groupTableAdapter.Fill(danceclubdbDataSet.student_group);
            edit = false;
        }

        public StudentGroupEditForm(int id, int student_id, int group_id, DateTime date) : this()
        {
            //edit = true;
            //ID = id;
            //dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells[0].Value.ToString() == student_id.ToString()).Selected = true;
            //comboBox1.Text = group_id.ToString();
            //DateTime dt = DateTime.Today;
            //dt = date;
        }

        private void StudentGroupEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.danceclubdbDataSet.classes);
            this.student_groupTableAdapter.Fill(this.danceclubdbDataSet.student_group);
            this.studentsTableAdapter.Fill(this.danceclubdbDataSet.students);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                student_groupTableAdapter.InsertQuery(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                    Convert.ToInt32(comboBox1.SelectedValue), DateTime.Today.Date);
            }
            else
            {
                student_groupTableAdapter.UpdateQuery(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                    Convert.ToInt32(comboBox1.SelectedValue), DateTime.Today.Date, ID);
            }
            Close();
        }
    }
}
