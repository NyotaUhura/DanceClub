using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanceClub.Forms;

namespace DanceClub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.styles' table. You can move, or remove it, as needed.
            this.stylesTableAdapter.Fill(this.danceclubdbDataSet.styles);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.age_categories' table. You can move, or remove it, as needed.
            this.age_categoriesTableAdapter.Fill(this.danceclubdbDataSet.age_categories);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.student_group' table. You can move, or remove it, as needed.
            this.student_groupTableAdapter.Fill(this.danceclubdbDataSet.student_group);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.danceclubdbDataSet.teachers);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.workouts' table. You can move, or remove it, as needed.
            this.workoutsTableAdapter.Fill(this.danceclubdbDataSet.workouts);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.danceclubdbDataSet.classes);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.danceclubdbDataSet.students);
            dataGridView1.AutoGenerateColumns = true;

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void учніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = studentsBindingSource;
            dataGridView1.DataSource = studentsBindingSource;
            tableNameLable.Text = "Учні";
        }

        private void групиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = classesBindingSource;
            dataGridView1.DataSource = classesBindingSource;
            tableNameLable.Text = "Групи";
        }

        private void заняттяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = workoutsBindingSource;
            dataGridView1.DataSource = workoutsBindingSource;
            tableNameLable.Text = "Заняття";
        }

        private void викладачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = teachersBindingSource;
            dataGridView1.DataSource = teachersBindingSource;
            tableNameLable.Text = "Викладачі";
        }

        private void студентгрупаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = studentgroupBindingSource;
            dataGridView1.DataSource = studentgroupBindingSource;
            tableNameLable.Text = "Студент-група";
        }

        private void стиліТанцюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = stylesBindingSource;
            dataGridView1.DataSource = stylesBindingSource;
            tableNameLable.Text = "Стилі танцю";
        }

        private void віковіКатегоріїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = agecategoriesBindingSource;
            dataGridView1.DataSource = agecategoriesBindingSource;
            tableNameLable.Text = "Вікові категорії";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            studentsTableAdapter.Update(danceclubdbDataSet);
            classesTableAdapter.Update(danceclubdbDataSet);
            workoutsTableAdapter.Update(danceclubdbDataSet);
            teachersTableAdapter.Update(danceclubdbDataSet);
            student_groupTableAdapter.Update(danceclubdbDataSet);
            stylesTableAdapter.Update(danceclubdbDataSet);
            age_categoriesTableAdapter.Update(danceclubdbDataSet);
        }


        private void правкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tableNameLable.Text)
            {
                case "Групи":
                {
                    GroupEditForm gef = new GroupEditForm();
                    gef.ShowDialog();
                    classesTableAdapter.Fill(danceclubdbDataSet.classes);
                    danceclubdbDataSet.AcceptChanges();
                        break;
                }
                case "Учні": 
                {
                    StudentEditForm sef = new StudentEditForm();
                    sef.ShowDialog();
                    studentsTableAdapter.Fill(danceclubdbDataSet.students);
                    danceclubdbDataSet.AcceptChanges();
                    break;
                }
                case "Заняття":
                    {
                        WorkoutEditForm sef = new WorkoutEditForm();
                        sef.ShowDialog();
                        workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                default:
                    break;
            }
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tableNameLable.Text)
            {
                case "Групи":
                {
                    classesTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    classesTableAdapter.Fill(danceclubdbDataSet.classes);
                    danceclubdbDataSet.AcceptChanges();
                        break;
                }
                case "Учні":
                {
                    studentsTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    studentsTableAdapter.Fill(danceclubdbDataSet.students);
                    danceclubdbDataSet.AcceptChanges();
                    break;
                }
                case "Заняття":
                {
                    workoutsTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
                    danceclubdbDataSet.AcceptChanges();
                    break;
                }
                default:
                    break;
            }
        }

        private void редагуватиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (tableNameLable.Text)
            {
                case "Групи":
                {
                    var cdt = new danceclubdbDataSet.classesDataTable();
                    classesTableAdapter.FillBy(cdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    var row = cdt.Rows[0].ItemArray;
                    var ed = new GroupEditForm(Convert.ToInt32(row[0]), Convert.ToInt32(row[5]), row[1].ToString(), Convert.ToInt32(row[3]), Convert.ToInt32(row[2]), Convert.ToInt32(row[4]));
                    ed.ShowDialog();
                    classesTableAdapter.Fill(danceclubdbDataSet.classes);
                    danceclubdbDataSet.AcceptChanges();
                        break;
                }
                case "Учні":
                {
                    var sdt = new danceclubdbDataSet.studentsDataTable();
                    studentsTableAdapter.FillBy(sdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    var row = sdt.Rows[0].ItemArray;
                    //var ed = new StudentEditForm(Convert.ToInt32(row[7]), row[0].ToString(), row[1].ToString(),
                    //    row[2].ToString(), row[3].ToString(), 
                    //    new DateTime(Convert.ToInt32((row[4]).ToString().Split('.')[2]), Convert.ToInt32((row[4]).ToString().Split('.')[1]), Convert.ToInt32((row[4]).ToString().Split('.')[0])), 
                    //    row[5].ToString(), row[6].ToString());

                    var ed = new StudentEditForm(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(),
                        row[3].ToString(), row[4].ToString(), Convert.ToDateTime(row[5]),
                        row[6].ToString(), row[7].ToString());
                        ed.ShowDialog();
                    studentsTableAdapter.Fill(danceclubdbDataSet.students);
                    danceclubdbDataSet.AcceptChanges();
                    break;
            }
                case "Заняття":
                    {
                        var wdt = new danceclubdbDataSet.workoutsDataTable();
                        workoutsTableAdapter.FillBy(wdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        var row = wdt.Rows[0].ItemArray;
                        var ed = new WorkoutEditForm(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), TimeSpan.Parse(Convert.ToString(row[3])));
                        ed.ShowDialog();
                        workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
