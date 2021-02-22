using System;
using System.Windows.Forms;

namespace DanceClub.Forms
{
    public partial class StyleEditForm : Form
    {
        private int ID;
        private bool edit;
        private bool isChecked = false;
        public StyleEditForm()
        {
            InitializeComponent();
            stylesTableAdapter.Fill(danceclubdbDataSet.styles);
            edit = false;
        }

        public StyleEditForm(int id, string style_name) : this()
        {
            edit = true;
            ID = id;
            styleTextBox.Text = style_name;
        }

        private void StyleEditForm_Load(object sender, EventArgs e)
        {
            this.stylesTableAdapter.Fill(this.danceclubdbDataSet.styles);
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
                    stylesTableAdapter.InsertQuery(styleTextBox.Text);
                }
                else
                {
                    stylesTableAdapter.UpdateQuery(styleTextBox.Text, ID);
                }
            }
            Close();
        }

        // Проверки.
        private bool CheckNotNull()
        {
            if (styleTextBox.Text == "")
            {
                return false;
            }
            return true;
        }
        private void CheckAll()
        {
            if (!CheckNotNull())
            {
                MessageBox.Show("Не всі поля заповнені.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                isChecked = true;
            }
        }

        private void StyleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
