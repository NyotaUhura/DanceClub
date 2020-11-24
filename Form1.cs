using DanceClub.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;



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
            radioButton1.Visible = true;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Ціна";
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
            comboBox1.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Час початку";
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
            radioButton1.Visible = true;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Дата початку";
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
            comboBox1.Visible = true;
            sortLabel.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            sortButton.Visible = true;

            radioButton1.Text = "Мінімальний вік";
            radioButton1.Text = "Максимальний вік";
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

        //Редактирование.

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
                default:
                    break;
            }
        }

        //Удаление.
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show($"Delete?", "Сonfirmation", MessageBoxButtons.YesNo);
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
                        default:
                            break;
                    }
                    break;
                case DialogResult.No:
                    break;

            }
            //switch (tableNameLable.Text)
            //{
            //    case "Групи":
            //    {
            //        classesTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            //        classesTableAdapter.Fill(danceclubdbDataSet.classes);
            //        danceclubdbDataSet.AcceptChanges();
            //        break;
            //    }
            //    case "Учні":
            //    {
            //        studentsTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            //        studentsTableAdapter.Fill(danceclubdbDataSet.students);
            //        danceclubdbDataSet.AcceptChanges();
            //        break;
            //    }
            //    case "Заняття":
            //    {
            //        workoutsTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            //        workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
            //        danceclubdbDataSet.AcceptChanges();
            //        break;
            //    }
            //    default:
            //        break;
            //}
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
                        var ed = new WorkoutEditForm(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt32(row[2]),
                            TimeSpan.Parse(Convert.ToString(row[3])));
                        ed.ShowDialog();
                        workoutsTableAdapter.Fill(danceclubdbDataSet.workouts);
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY min_age ASC; ";
                    }
                    else if (radioButton1.Checked)
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
                    if (radioButton1.Checked)
                    {
                        query =
                            "SELECT * FROM age_categories ORDER BY min_age DESC; ";
                    }
                    else if (radioButton2.Checked)
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
                        query = "SELECT * FROM workouts WHERE start_time >= '"
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
            ExportToPDF();
        }

        private void ExportToPDF()
        {
            string deviceInfo = "";
            string[] streamIDs;
            Warning[] warnings;

            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "DanceClubReport.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",danceclubdbDataSet.Tables["students"]));
            //viewer.RefreshReport();
            //viewer.ReportRefresh();
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding,
            out extension, out streamIDs, out warnings);

            string fileName = @"C:\Users\Anastasiya\Desktop\NURE\year_2\Course project\DanceClub\Reports\report1.pdf";
            File.WriteAllBytes(fileName, bytes);
            System.Diagnostics.Process.Start(fileName);
        }

        private void ExportToPDF2()
        {
            string deviceInfo = "";
            string[] streamIDs;
            Warning[] warnings;

            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "GroupsReport.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", danceclubdbDataSet.Tables["classes"]));
            //viewer.RefreshReport();
            //viewer.ReportRefresh();
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding,
                out extension, out streamIDs, out warnings);

            string fileName = @"C:\Users\Anastasiya\Desktop\NURE\year_2\Course project\DanceClub\Reports\report2.pdf";
            File.WriteAllBytes(fileName, bytes);
            System.Diagnostics.Process.Start(fileName);
        }

        private void проГрупуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToPDF2();
        }
    }

}
