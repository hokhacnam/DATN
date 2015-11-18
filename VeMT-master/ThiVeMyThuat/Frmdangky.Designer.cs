namespace ThiVeMyThuat
{
    partial class Frmdangky
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
            this.dgv_thisinh = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btndanhsach = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thisinh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_thisinh
            // 
            this.dgv_thisinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thisinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thisinh.Location = new System.Drawing.Point(12, 62);
            this.dgv_thisinh.Name = "dgv_thisinh";
            this.dgv_thisinh.Size = new System.Drawing.Size(1340, 586);
            this.dgv_thisinh.TabIndex = 0;
            this.dgv_thisinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thisinh_CellContentClick);
            this.dgv_thisinh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thisinh_CellDoubleClick_1);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(547, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(330, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(282, 654);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(143, 44);
            this.btnthem.TabIndex = 3;
            this.btnthem.Text = "Thêm hồ sơ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnsua.Location = new System.Drawing.Point(459, 654);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(152, 44);
            this.btnsua.TabIndex = 4;
            this.btnsua.Text = "Sửa hồ sơ";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(640, 654);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(127, 44);
            this.btnxoa.TabIndex = 5;
            this.btnxoa.Text = "Xoá hồ sơ";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btndanhsach
            // 
            this.btndanhsach.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btndanhsach.Location = new System.Drawing.Point(795, 654);
            this.btndanhsach.Name = "btndanhsach";
            this.btndanhsach.Size = new System.Drawing.Size(123, 44);
            this.btndanhsach.TabIndex = 6;
            this.btndanhsach.Text = "In danh sách kiểm dò";
            this.btndanhsach.UseVisualStyleBackColor = true;
            this.btndanhsach.Click += new System.EventHandler(this.btndanhsach_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Chọn tìm kiếm",
            "Số hồ sơ",
            "Họ tên",
            "Năm tốt nghiệp",
            "hktt",
            "noisinh",
            "cmnd"});
            this.comboBox1.Location = new System.Drawing.Point(184, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // Frmdangky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 710);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btndanhsach);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_thisinh);
            this.Name = "Frmdangky";
            this.Text = "Cập nhật thí sinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmdangky_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thisinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_thisinh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btndanhsach;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}