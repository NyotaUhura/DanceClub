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
    public partial class GroupEditForm : Form
    {
        int ID;
        bool edit;
        private bool isChecked = false;

        public GroupEditForm()
        {
            InitializeComponent();
            classesTableAdapter.Fill(danceclubdbDataSet.classes);
            edit = false;
        }

        public GroupEditForm(int id, int style_id, string name, int teacher_id, int cost, int age_id) : this()
        {
            edit = true;
            ID = id;
            nameTextBox.Text = name;
            costTextBox.Text = cost.ToString();
            ageComboBox.Text = age_id.ToString();
            styleComboBox.Text = style_id.ToString();
            teacherComboBox.Text = teacher_id.ToString();
        }

        private void GroupEditForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceclubdbDataSet.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.danceclubdbDataSet.classes);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.age_categories' table. You can move, or remove it, as needed.
            this.age_categoriesTableAdapter.Fill(this.danceclubdbDataSet.age_categories);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.danceclubdbDataSet.teachers);
            // TODO: This line of code loads data into the 'danceclubdbDataSet.styles' table. You can move, or remove it, as needed.
            this.stylesTableAdapter.Fill(this.danceclubdbDataSet.styles);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAll();
            if (isChecked)
            {
                if (!edit)
                {
                    classesTableAdapter.InsertQuery(nameTextBox.Text, Convert.ToInt32(costTextBox.Text),
                        Convert.ToInt32(teacherComboBox.SelectedValue), Convert.ToInt32(ageComboBox.SelectedValue),
                        Convert.ToInt32(styleComboBox.SelectedValue));
                }
                else
                {
                    classesTableAdapter.UpdateQuery(nameTextBox.Text, Convert.ToInt32(costTextBox.Text),
                        Convert.ToInt32(teacherComboBox.SelectedValue), Convert.ToInt32(ageComboBox.SelectedValue),
                        Convert.ToInt32(styleComboBox.SelectedValue), ID);
                }
                Close();
            }
        }

        //Проверки.
        private bool CheckNotNull()
        {
            if (nameTextBox.Text == "" || costTextBox.Text == "" || ageComboBox.Text == "" ||
                styleComboBox.Text == "" || teacherComboBox.Text == "")
            {
                return false;
            }
            return true;
        }

        private bool CheckPrice()
        {
            string Str = costTextBox.Text.Trim();
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

        private void CheckAll()
        {
            if (!CheckPrice())
            {
                MessageBox.Show("Невірно введено ціну.", "Error", MessageBoxButtons.OKCancel);
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

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.classesTableAdapter.FillBy1(this.danceclubdbDataSet.classes);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
