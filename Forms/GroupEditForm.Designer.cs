namespace DanceClub.Forms
{
    partial class GroupEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.stylesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.danceclubdbDataSet = new DanceClub.danceclubdbDataSet();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.teachersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lable1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ageComboBox = new System.Windows.Forms.ComboBox();
            this.agecategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stylesTableAdapter = new DanceClub.danceclubdbDataSetTableAdapters.stylesTableAdapter();
            this.teachersTableAdapter = new DanceClub.danceclubdbDataSetTableAdapters.teachersTableAdapter();
            this.age_categoriesTableAdapter = new DanceClub.danceclubdbDataSetTableAdapters.age_categoriesTableAdapter();
            this.classesTableAdapter = new DanceClub.danceclubdbDataSetTableAdapters.classesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.stylesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danceclubdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agecategoriesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // styleComboBox
            // 
            this.styleComboBox.DataSource = this.stylesBindingSource;
            this.styleComboBox.DisplayMember = "style_name";
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(222, 142);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(121, 24);
            this.styleComboBox.TabIndex = 0;
            this.styleComboBox.ValueMember = "style_id";
            // 
            // stylesBindingSource
            // 
            this.stylesBindingSource.DataMember = "styles";
            this.stylesBindingSource.DataSource = this.bindingSource1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.danceclubdbDataSet;
            this.bindingSource1.Position = 0;
            // 
            // danceclubdbDataSet
            // 
            this.danceclubdbDataSet.DataSetName = "danceclubdbDataSet";
            this.danceclubdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.DataSource = this.teachersBindingSource;
            this.teacherComboBox.DisplayMember = "second_name";
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(222, 265);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(121, 24);
            this.teacherComboBox.TabIndex = 1;
            this.teacherComboBox.ValueMember = "teacher_id";
            // 
            // teachersBindingSource
            // 
            this.teachersBindingSource.DataMember = "teachers";
            this.teachersBindingSource.DataSource = this.bindingSource1;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lable1.Location = new System.Drawing.Point(128, 88);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(61, 20);
            this.lable1.TabIndex = 2;
            this.lable1.Text = "Назва";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(222, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 22);
            this.nameTextBox.TabIndex = 3;
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(222, 207);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(121, 22);
            this.costTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(128, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Стиль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(143, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ціна";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(97, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Викладач";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(39, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вікова категорія";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(159, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "Група";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(222, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 32);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ageComboBox
            // 
            this.ageComboBox.DataSource = this.agecategoriesBindingSource;
            this.ageComboBox.DisplayMember = "age_name";
            this.ageComboBox.FormattingEnabled = true;
            this.ageComboBox.Location = new System.Drawing.Point(222, 327);
            this.ageComboBox.Name = "ageComboBox";
            this.ageComboBox.Size = new System.Drawing.Size(121, 24);
            this.ageComboBox.TabIndex = 13;
            this.ageComboBox.ValueMember = "age_id";
            // 
            // agecategoriesBindingSource
            // 
            this.agecategoriesBindingSource.DataMember = "age_categories";
            this.agecategoriesBindingSource.DataSource = this.bindingSource1;
            // 
            // stylesTableAdapter
            // 
            this.stylesTableAdapter.ClearBeforeFill = true;
            // 
            // teachersTableAdapter
            // 
            this.teachersTableAdapter.ClearBeforeFill = true;
            // 
            // age_categoriesTableAdapter
            // 
            this.age_categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // classesTableAdapter
            // 
            this.classesTableAdapter.ClearBeforeFill = true;
            // 
            // GroupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 451);
            this.Controls.Add(this.ageComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.teacherComboBox);
            this.Controls.Add(this.styleComboBox);
            this.Name = "GroupEditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.GroupEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stylesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danceclubdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teachersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agecategoriesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ageComboBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private danceclubdbDataSet danceclubdbDataSet;
        private System.Windows.Forms.BindingSource stylesBindingSource;
        private danceclubdbDataSetTableAdapters.stylesTableAdapter stylesTableAdapter;
        private System.Windows.Forms.BindingSource teachersBindingSource;
        private danceclubdbDataSetTableAdapters.teachersTableAdapter teachersTableAdapter;
        private System.Windows.Forms.BindingSource agecategoriesBindingSource;
        private danceclubdbDataSetTableAdapters.age_categoriesTableAdapter age_categoriesTableAdapter;
        private danceclubdbDataSetTableAdapters.classesTableAdapter classesTableAdapter;
    }
}