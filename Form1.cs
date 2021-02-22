using DanceClub.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;

namespace DanceClub
{
    public partial class Form1 : Form
    {
        private string connectionString =
            "server=localhost;user id=root;password=1969yearofspace;persistsecurityinfo=True;database=danceclubdb";
        


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
            dateTimePicker1.MinDate = DateTime.Today.AddYears(-80);
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-3);
            dateTimePicker2.MinDate = DateTime.Today.AddYears(-80);
            dateTimePicker2.MaxDate = DateTime.Today.AddYears(-3);
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void учніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentsBindingSource;
            tableNameLable.Text = "Учні";
            label1.Visible = true;
            label2.Visible = true;
            filterButton.Visible = true;
            label3.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label4.Visible = true;
            comboBox1.Visible = true;

            label1.Text = "Мінімальна дата народження";
            label2.Text = "Максимальна дата народження";

            //Сортировка.
            comboBox2.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Ім'я";
            radioButton2.Text = "Прізвище";
            radioButton3.Text = "По-батькові";
        }

        private void групиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = classesBindingSource;
            tableNameLable.Text = "Групи";
            label1.Visible = true;
            label2.Visible = true;
            filterButton.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;

            label1.Text = "Мінімальна ціна";
            label2.Text = "Максимальна ціна";

            ////
            comboBox2.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton3.Text = "Ціна";
        }

        private void заняттяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = workoutsBindingSource;
            tableNameLable.Text = "Заняття";
            label1.Visible = true;
            label2.Visible = true;
            filterButton.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;

            label1.Text = "Мінімальний час";
            label2.Text = "Максимальний час";


            ////
            comboBox1.Visible = false;
            sortLabel.Visible = true;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton3.Text = "Час початку";
        }

        private void викладачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = teachersBindingSource;
            tableNameLable.Text = "Викладачі";
            label1.Visible = false;
            label2.Visible = false;
            filterButton.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;

            ////
            comboBox2.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Ім'я";
            radioButton2.Text = "Прізвище";
            radioButton3.Text = "По-батькові";
        }

        private void студентгрупаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentgroupBindingSource;
            tableNameLable.Text = "Студент-група";
            label1.Visible = true;
            label2.Visible = true;
            filterButton.Visible = true;
            label3.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label4.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Мінімальна дата початку";
            label2.Text = "Максимальна дата початку";

            ////
            comboBox2.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton3.Text = "Дата початку";
        }

        private void стиліТанцюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = stylesBindingSource;
            tableNameLable.Text = "Стилі танцю";
            label1.Visible = false;
            label2.Visible = false;
            filterButton.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;

            ////
            comboBox1.Visible = false;
            sortLabel.Visible = false;
            comboBox2.Visible = false;
            label5.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            sortButton.Visible = false;
        }

        private void віковіКатегоріїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = agecategoriesBindingSource;
            tableNameLable.Text = "Вікові категорії";
            label1.Visible = true;
            label2.Visible = false;
            filterButton.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Вік";

            ////
            comboBox2.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = false;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton2.Text = "Мінімальний вік";
            radioButton3.Text = "Максимальний вік";
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

        
        //Добавление.
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
                case "Викладачі":
                    {
                        TeacherEditForm sef = new TeacherEditForm();
                        sef.ShowDialog();
                        teachersTableAdapter.Fill(danceclubdbDataSet.teachers);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Студент-група":
                    {
                        StudentGroupEditForm sef = new StudentGroupEditForm();
                        sef.ShowDialog();
                        student_groupTableAdapter.Fill(danceclubdbDataSet.student_group);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Стилі танцю":
                    {
                        StyleEditForm sef = new StyleEditForm();
                        sef.ShowDialog();
                        stylesTableAdapter.Fill(danceclubdbDataSet.styles);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Вікові категорії":
                    {
                        AgeEditForm aef = new AgeEditForm();
                        aef.ShowDialog();
                        age_categoriesTableAdapter.Fill(danceclubdbDataSet.age_categories);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                default:
                    break;
            }
        }

        //Удаление.
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($"Видалити?", "Сonfirmation", MessageBoxButtons.YesNo);
            switch (res)
            {
                case DialogResult.Yes:
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
                        case "Викладачі":
                            {
                                teachersTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                                teachersTableAdapter.Fill(danceclubdbDataSet.teachers);
                                danceclubdbDataSet.AcceptChanges();
                                break;
                            }
                        case "Студент-група":
                            {
                                student_groupTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                                student_groupTableAdapter.Fill(danceclubdbDataSet.student_group);
                                danceclubdbDataSet.AcceptChanges();
                                break;
                            }
                        case "Стилі танцю":
                            {
                                stylesTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                                stylesTableAdapter.Fill(danceclubdbDataSet.styles);
                                danceclubdbDataSet.AcceptChanges();
                                break;
                            }
                        case "Вікові категорії":
                            {
                                age_categoriesTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                                age_categoriesTableAdapter.Fill(danceclubdbDataSet.age_categories);
                                danceclubdbDataSet.AcceptChanges();
                                break;
                            }
                        default:
                            break;
                    }
                    break;
                case DialogResult.No:
                    break;

            }
           
        }

        //Редактирование.
        private void редагуватиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (tableNameLable.Text)
            {
                case "Групи":
                    {
                        var cdt = new danceclubdbDataSet.classesDataTable();
                        classesTableAdapter.FillBy(cdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        var row = cdt.Rows[0].ItemArray;
                        var ed = new GroupEditForm(Convert.ToInt32(row[0]), Convert.ToInt32(row[5]), row[1].ToString(),
                            Convert.ToInt32(row[3]), Convert.ToInt32(row[2]), Convert.ToInt32(row[4]));
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
                        var ed = new WorkoutEditForm(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]),
                            TimeSpan.Parse(Convert.ToString(row[3])));
                        ed.ShowDialog();
                        workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Викладачі":
                    {
                        var tdt = new danceclubdbDataSet.teachersDataTable();
                        teachersTableAdapter.FillBy(tdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        var row = tdt.Rows[0].ItemArray;

                        var ed = new TeacherEditForm(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(),
                            row[3].ToString(), row[4].ToString());
                        ed.ShowDialog();
                        teachersTableAdapter.Fill(danceclubdbDataSet.teachers);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Студент-група":
                    {
                        MessageBox.Show("Неможливо редагувати.");
                        //var sgdt = new danceclubdbDataSet.student_groupDataTable();
                        //student_groupTableAdapter.FillBy(sgdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        //var row = sgdt.Rows[0].ItemArray;
                        //var ed = new StudentGroupEditForm(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]),
                        //    Convert.ToDateTime(row[3]));
                        //ed.ShowDialog();
                        //student_groupTableAdapter.Fill(danceclubdbDataSet.student_group);
                        //danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Стилі танцю":
                    {
                        var sdt = new danceclubdbDataSet.stylesDataTable();
                        stylesTableAdapter.FillBy(sdt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        var row = sdt.Rows[0].ItemArray;

                        var ed = new StyleEditForm(Convert.ToInt32(row[0]), row[1].ToString());
                        ed.ShowDialog();
                        stylesTableAdapter.Fill(danceclubdbDataSet.styles);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                case "Вікові категорії":
                    {
                        var adt = new danceclubdbDataSet.age_categoriesDataTable();
                        age_categoriesTableAdapter.FillBy(adt, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        var row = adt.Rows[0].ItemArray;

                        var ed = new AgeEditForm(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
                        ed.ShowDialog();
                        age_categoriesTableAdapter.Fill(danceclubdbDataSet.age_categories);
                        danceclubdbDataSet.AcceptChanges();
                        break;
                    }
                default:
                    break;
            }
        }

        //Сортировка.
        private void sortButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            ///////////////////////
            if (tableNameLable.Text == "Учні")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY first_name ASC; ";
                    }
                    else if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY second_name ASC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY third_name ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM students; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY first_name DESC; ";
                    }
                    else if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY second_name DESC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM students ORDER BY third_name DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM students; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM students; ";
                }
            }

            //////////////////////////
            else if (tableNameLable.Text == "Групи")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM classes ORDER BY cost ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM classes; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM classes ORDER BY cost DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM classes; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM classes; ";
                }
            }

            ////////////////////
            else if (tableNameLable.Text == "Заняття")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM workouts ORDER BY start_time ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM workouts; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM workouts ORDER BY start_time DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM workouts; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM workouts; ";
                }
            }

            /////////////
            else if (tableNameLable.Text == "Викладачі")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY first_name ASC; ";
                    }
                    else if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY second_name ASC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY third_name ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM teachers; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY first_name DESC; ";
                    }
                    else if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY second_name DESC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM teachers ORDER BY third_name DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM teachers; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM teachers; ";
                }
            }


            //////////////////////////
            else if (tableNameLable.Text == "Студент-група")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM student_group ORDER BY start_date ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM student_group; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM student_group ORDER BY start_date DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM student_group; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM student_group; ";
                }
            }

            ////////////////////////
            else if (tableNameLable.Text == "Стилі танцю")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM styles ORDER BY style_name ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM styles; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM styles ORDER BY style_name DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM styles; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM styles; ";
                }
            }

            //////////////////////////////////
            else if (tableNameLable.Text == "Вікові категорії")
            {
                if (comboBox2.Text == "за зростанням")
                {
                    if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY min_age ASC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY max_age ASC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM age_categories; ";
                    }
                }
                else if (comboBox2.Text == "за спаданням")
                {
                    if (radioButton2.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY min_age DESC; ";
                    }
                    else if (radioButton3.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY max_age DESC; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM age_categories; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM age_categories; ";
                }
            }

            else
            {
                query =
                    "SELECT * FROM students; ";
            }


            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();
        }

        //Поиск.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            if (tableNameLable.Text == "Учні")
            {
                query = "SELECT * FROM students WHERE first_name LIKE '%" +
                        textBox1.Text + "%' OR second_name LIKE '%" + textBox1.Text + "%' OR third_name LIKE '%"
                        + textBox1.Text + "%' OR phone LIKE '%" + textBox1.Text + "%';";
            }
            else if (tableNameLable.Text == "Групи")
            {
                query = "SELECT * FROM classes WHERE group_name LIKE '%" +
                        textBox1.Text + "%';";
            }
            else if (tableNameLable.Text == "Заняття")
            {
                query = "SELECT * FROM workouts WHERE day_short_name LIKE '%" +
                        textBox1.Text + "%';";
            }
            else if (tableNameLable.Text == "Викладачі")
            {
                query = "SELECT * FROM teachers WHERE first_name LIKE '%" +
                        textBox1.Text + "%' OR second_name LIKE '%" + textBox1.Text + "%' OR third_name LIKE '%" +
                        textBox1.Text + "%' OR phone LIKE '%" + textBox1.Text + "%';";

            }
            else if (tableNameLable.Text == "Студент-група")
            {
                query = "SELECT * FROM student_group;";
            }
            else if (tableNameLable.Text == "Стилі танцю")
            {
                query = "SELECT * FROM styles WHERE style_name LIKE '%" +
                        textBox1.Text + "%';";
            }
            else if (tableNameLable.Text == "Вікові категорії")
            {
                query = "SELECT * FROM age_categories WHERE age_name LIKE '%" +
                        textBox1.Text + "%';";
            }
            else
            {
                query = "SELECT * FROM students WHERE first_name LIKE '%" +
                        textBox1.Text + "%' OR second_name LIKE '%" + textBox1.Text + "%' OR third_name LIKE '%"
                        + textBox1.Text + "%';";
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();
        }


        //Фильтрация.
        private void filterButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            ///////////////////////////////////////
            if (tableNameLable.Text == "Учні")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox1.Text == "ч")
                    {
                        query =
                            "SELECT * FROM students WHERE birth_date >= '"
                            + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND birth_date <= '"
                            + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND gender = 'ч' ; ";
                    }
                    else if (comboBox1.Text == "ж")
                    {
                        query =
                            "SELECT * FROM students WHERE birth_date >= '"
                            + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND birth_date <= '"
                            + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND gender = 'ж' ; ";
                    }
                    else
                    {
                        query =
                            "SELECT * FROM students WHERE birth_date BETWEEN '"
                            + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '"
                            + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'; ";
                    }
                }
                else
                {
                    query =
                        "SELECT * FROM students WHERE birth_date BETWEEN '"
                        + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '"
                        + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'; ";
                }
            }

            ////////////////////////////////////////
            else if (tableNameLable.Text == "Групи")
            {
                if (textBox2.Text != "")
                {
                    if (isNumber(textBox2.Text))
                    {
                        if (textBox3.Text != "")
                        {
                            if (isNumber(textBox3.Text))
                            {
                                query = "SELECT * FROM classes WHERE cost >= " +
                                        textBox2.Text + " AND cost <= " + textBox3.Text + "; ";
                            }
                            else
                            {
                                query = "SELECT * FROM classes;";
                            }
                        }
                        else
                        {
                            query = "SELECT * FROM classes WHERE cost >= " +
                                    textBox2.Text + ";";
                        }
                    }
                    else
                    {
                        query = "SELECT * FROM classes;";
                    }
                }
                else
                {
                    if (textBox3.Text != "")
                    {
                        query = "SELECT * FROM classes WHERE cost <= " +
                                textBox3.Text + ";";
                    }
                    else
                    {
                        query = "SELECT * FROM classes;";
                    }
                }
            }

            ///////////////////////////////////////
            else if (tableNameLable.Text == "Заняття")
            {
                if (textBox2.Text != "")
                {
                    if (isDate(textBox2.Text))
                    {
                        if (textBox3.Text != "")
                        {
                            if (isDate(textBox3.Text))
                            {
                                query = "SELECT * FROM workouts WHERE start_time BETWEEN '"
                                        + textBox2.Text + ":00' AND '"
                                        + textBox3.Text + ":00'; ";
                            }
                            else
                            {
                                query = "SELECT * FROM workouts;";
                            }
                        }
                        else
                        {
                            query = "SELECT * FROM workouts WHERE start_time >= '"
                                    + textBox2.Text + ":00'; ";
                        }
                    }
                    else
                    {
                        query = "SELECT * FROM workouts;";
                    }
                }
                else
                {
                    if (textBox3.Text != "")
                    {
                        query = "SELECT * FROM workouts WHERE start_time <= '"
                                + textBox3.Text + ":00'; ";
                    }
                    else
                    {
                        query = "SELECT * FROM workouts;";
                    }
                }
            }

            ///////////////////////////////////////
            else if (tableNameLable.Text == "Викладачі")
            {
                query = "SELECT * FROM teachers;";
            }

            ///////////////////////////////////////
            else if (tableNameLable.Text == "Студент-група")
            {
                query = "SELECT * FROM student_group WHERE start_date BETWEEN '"
                        + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '"
                        + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'; ";
            }

            ///////////////////////////////////////
            else if (tableNameLable.Text == "Стилі танцю")
            {
                query = "SELECT * FROM styles; ";
            }

            ///////////////////////////////////////
            else if (tableNameLable.Text == "Вікові категорії")
            {
                if (textBox2.Text != "")
                {
                    if (isNumber(textBox2.Text))
                    {
                        query = "SELECT * FROM age_categories WHERE min_age <= " +
                                textBox2.Text + " AND max_age >= " + textBox2.Text + "; ";
                    }
                    else
                    {
                        query = "SELECT * FROM age_categories;";
                    }
                }
                else
                {
                    query = "SELECT * FROM age_categories;";
                }
            }

            ///////////////////////////////////////
            else
            {
                query = "SELECT * FROM students;";
            }


            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            dataGridView1.DataSource = dt.DefaultView;

            connection.Close();

        }
        private bool isDate(string str)
        {
            TimeSpan scheduleDate;
            if (TimeSpan.TryParse(str, out scheduleDate))
            {
                return true;
            }
            return false;
        }

        private bool isNumber(string str)
        {
            int Num;
            bool isNum = int.TryParse(str.Trim(), out Num);
            if (isNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isTime(string str)
        {
            if (str.Length >= 5 || str.Length <= 3) return false;
            if (str[2] == ':')
            {
                string[] words = str.Split(new char[] { ':' });
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

        //Запросы.
        private void кількістьУчнівУШколіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsInSchoolQueryForm siqf = new StudentsInSchoolQueryForm();
            siqf.ShowDialog();
        }

        private void групиЗаДнямиТижняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupsByDayQueryForm gbdqf = new GroupsByDayQueryForm();
            gbdqf.ShowDialog();
        }

        private void групиУВикладачівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupsInTeachersQueryForm gitf = new GroupsInTeachersQueryForm();
            gitf.ShowDialog();
        }

        private void групиЗаСтилямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsInStylesQueryForm gisqf = new StudentsInStylesQueryForm();
            gisqf.ShowDialog();
        }


        //Задача автоматизации.
        private void новийУченьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStudentForm nsf = new NewStudentForm();
            nsf.ShowDialog();
            studentsTableAdapter.Fill(danceclubdbDataSet.students);
            
            student_groupTableAdapter.Fill(danceclubdbDataSet.student_group);
            danceclubdbDataSet.AcceptChanges();
        }



        //Отчеты. 

        private void проРоботуКлубаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var styleColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Стиль"
            };
            var benefitColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Прибуток"
            };
            var studentsNumColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Кількість учнів"
            };

            DataGridView dataGridView2 = new DataGridView();
            dataGridView2.Columns.AddRange(
                styleColomn, benefitColomn, studentsNumColomn
                );

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            query = "SELECT Styles.style_name, SUM(Classes.cost * (SELECT COUNT(student_id) FROM student_group WHERE group_id = classes.group_id)), "
                + " (SELECT COUNT(student_id) FROM student_group WHERE student_group.group_id IN(SELECT group_id FROM Classes WHERE classes.style_id = styles.style_id))"
                + " FROM Styles NATURAL JOIN Classes"
                + " Group by style_name; ";

            MySqlCommand command = new MySqlCommand(query, connection);
            var srt = command.ExecuteReader();
            var list = new List<List<string>>();
            while (srt.Read())
            {
                var lst = new List<string>();
                for (var i = 0; i < srt.FieldCount; i++)
                {
                    lst.Add(srt[i].ToString());
                }
                list.Add(lst);
            }

            connection.Close();
            foreach (var t in list)
            {
                dataGridView2.Rows.Add(t[0], t[1], t[2]);
            }

            /////////////////////////
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Звіт 'Про стилі'.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Ошибка1." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                        var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase("Звіт 'Про стилі'", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(DateTime.Now.ToString(), font));

                            pdfTable.CompleteRow();
                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                        pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();

                            }

                            MessageBox.Show("Звіт успішно сформовано", "Info");
                            System.Diagnostics.Process.Start("Звіт 'Про стилі'.pdf");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка2 :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка3", "Info");
            }
        }

        private void проГрупуToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            var groupNameColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Назва групи"
            };
            var styleColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Стиль"
            };
            var teacherColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Викладач"
            };
            var benefitColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Прибуток"
            };
            var studentsNumColomn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Кількість учнів"
            };

            DataGridView dataGridView2 = new DataGridView();
            dataGridView2.Columns.AddRange(
                groupNameColomn, styleColomn, teacherColomn, benefitColomn, studentsNumColomn
                );

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query;

            query = "SELECT Classes.group_name, Styles.style_name, CONCAT(Teachers.second_name, ' ', Teachers.first_name, ' ', Teachers.third_name) As Teacher,"
                + " (Classes.cost * (SELECT COUNT(student_id) FROM student_group WHERE group_id = classes.group_id)) As Benefit,"
                + " (SELECT COUNT(student_id) FROM student_group WHERE group_id = classes.group_id) As StudentNum"
                + " FROM Classes NATURAL JOIN Styles NATURAL JOIN Teachers"
                + " GROUP BY group_name, style_name, second_name, first_name, third_name"
                + " ORDER BY group_name ASC; ";

            MySqlCommand command = new MySqlCommand(query, connection);
            var srt = command.ExecuteReader();
            var list = new List<List<string>>();
            while (srt.Read())
            {
                var lst = new List<string>();
                for(var i = 0; i < srt.FieldCount; i++)
                {
                    lst.Add(srt[i].ToString());
                }
                 list.Add(lst);
            }

            connection.Close();
            foreach(var t in list)
            {
                dataGridView2.Rows.Add(t[0], t[1], t[2], t[3], t[4]);
            }

            /////////////////////////
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Звіт 'Про групи'.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Ошибка1." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                        var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView2.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase("Звіт 'Про групи'", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(" ", font));
                            pdfTable.AddCell(new Phrase(DateTime.Now.ToString(), font));

                            pdfTable.CompleteRow();
                            foreach (DataGridViewColumn column in dataGridView2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                        pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();

                            }
                            
                            MessageBox.Show("Звіт успішно сформовано", "Info");
                            System.Diagnostics.Process.Start("Звіт 'Про групи'.pdf");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка2 :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка3", "Info");
            }
        }
    }

}
