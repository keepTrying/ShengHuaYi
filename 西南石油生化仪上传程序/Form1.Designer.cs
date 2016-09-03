namespace 西南石油生化仪上传程序
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.button_upload = new System.Windows.Forms.Button();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_query = new System.Windows.Forms.Button();
            this.dataGridView_name = new System.Windows.Forms.DataGridView();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.dataGridView_person = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_person)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "体检编码";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(90, 28);
            this.textBox_code.MaxLength = 15;
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(197, 21);
            this.textBox_code.TabIndex = 1;
            this.textBox_code.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(562, 25);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(75, 23);
            this.button_upload.TabIndex = 3;
            this.button_upload.Text = "上传";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(27, 185);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(104, 21);
            this.dateTimePicker_start.TabIndex = 5;
            this.dateTimePicker_start.Value = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(184, 185);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(103, 21);
            this.dateTimePicker_end.TabIndex = 6;
            this.dateTimePicker_end.Value = new System.DateTime(2016, 8, 29, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "人员信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "结束日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "开始日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "本地数据";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "姓名列表";
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(234, 212);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(53, 23);
            this.button_query.TabIndex = 14;
            this.button_query.Text = "查询";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView_name
            // 
            this.dataGridView_name.AllowUserToAddRows = false;
            this.dataGridView_name.AllowUserToDeleteRows = false;
            this.dataGridView_name.AllowUserToOrderColumns = true;
            this.dataGridView_name.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_name.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_name.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_name.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_name.Location = new System.Drawing.Point(27, 245);
            this.dataGridView_name.MultiSelect = false;
            this.dataGridView_name.Name = "dataGridView_name";
            this.dataGridView_name.ReadOnly = true;
            this.dataGridView_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_name.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_name.RowHeadersVisible = false;
            this.dataGridView_name.RowTemplate.Height = 23;
            this.dataGridView_name.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_name.Size = new System.Drawing.Size(260, 232);
            this.dataGridView_name.TabIndex = 15;
            this.dataGridView_name.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.AllowUserToAddRows = false;
            this.dataGridView_data.AllowUserToDeleteRows = false;
            this.dataGridView_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_data.Location = new System.Drawing.Point(304, 185);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.RowHeadersVisible = false;
            this.dataGridView_data.RowTemplate.Height = 23;
            this.dataGridView_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_data.Size = new System.Drawing.Size(333, 292);
            this.dataGridView_data.TabIndex = 16;
            // 
            // dataGridView_person
            // 
            this.dataGridView_person.AllowUserToAddRows = false;
            this.dataGridView_person.AllowUserToDeleteRows = false;
            this.dataGridView_person.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_person.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_person.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_person.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_person.Location = new System.Drawing.Point(32, 84);
            this.dataGridView_person.MultiSelect = false;
            this.dataGridView_person.Name = "dataGridView_person";
            this.dataGridView_person.ReadOnly = true;
            this.dataGridView_person.RowHeadersVisible = false;
            this.dataGridView_person.RowTemplate.Height = 23;
            this.dataGridView_person.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_person.Size = new System.Drawing.Size(605, 69);
            this.dataGridView_person.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 494);
            this.Controls.Add(this.dataGridView_person);
            this.Controls.Add(this.dataGridView_data);
            this.Controls.Add(this.dataGridView_name);
            this.Controls.Add(this.button_query);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.button_upload);
            this.Controls.Add(this.textBox_code);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "生化仪上传程序";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_person)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.DataGridView dataGridView_name;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.DataGridView dataGridView_person;
    }
}

