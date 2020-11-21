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
            if (!edit)
            {
                classesTableAdapter.InsertQuery(nameTextBox.Text, Convert.ToInt32(costTextBox.Text),
                    Convert.ToInt32(teacherComboBox.SelectedValue), Convert.ToInt32(ageComboBox.SelectedValue), 
                    Convert.ToInt32(styleComboBox.SelectedValue));
            }
            else
            {
                classesTableAdapter.UpdateQuery(nameTextBox.Text, Convert.ToInt32(costTextBox.Text),
                    Convert.ToInt32(teacherComboBox.SelectedValue),Convert.ToInt32(ageComboBox.SelectedValue), 
                    Convert.ToInt32(styleComboBox.SelectedValue), ID);
            }

            Close();
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
