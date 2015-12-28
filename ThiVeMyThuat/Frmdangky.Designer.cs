namespace ThiVeMyThuat
{
    partial class FrmDangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangKy));
            this.dgv_thisinh = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btndanhsach = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thisinh)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_thisinh
            // 
            this.dgv_thisinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thisinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thisinh.Location = new System.Drawing.Point(12, 12);
            this.dgv_thisinh.Name = "dgv_thisinh";
            this.dgv_thisinh.Size = new System.Drawing.Size(1340, 636);
            this.dgv_thisinh.TabIndex = 0;
            this.dgv_thisinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thisinh_CellContentClick);
            this.dgv_thisinh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_thisinh_CellDoubleClick_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 654);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Chọn tìm kiếm",
            "Số hồ sơ",
            "Họ tên",
            "Năm tốt nghiệp",
            "Hộ khẩu thường trú",
            "Nơi sinh",
            "Chứng minh nhân dân"});
            this.comboBox1.Location = new System.Drawing.Point(16, 654);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // btndanhsach
            // 
            this.btndanhsach.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btndanhsach.BackgroundImage = global::ThiVeMyThuat.Properties.Resources._1450392238_printer;
            this.btndanhsach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btndanhsach.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btndanhsach.Location = new System.Drawing.Point(1197, 654);
            this.btndanhsach.Name = "btndanhsach";
            this.btndanhsach.Size = new System.Drawing.Size(123, 44);
            this.btndanhsach.TabIndex = 6;
            this.btndanhsach.UseVisualStyleBackColor = false;
            this.btndanhsach.Click += new System.EventHandler(this.btndanhsach_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnxoa.BackgroundImage = global::ThiVeMyThuat.Properties.Resources._1450392188_editor_trash_delete_recycle_bin_glyph;
            this.btnxoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnxoa.Location = new System.Drawing.Point(1022, 654);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(127, 44);
            this.btnxoa.TabIndex = 5;
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnsua.BackgroundImage = global::ThiVeMyThuat.Properties.Resources._1450392136_edit_user;
            this.btnsua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnsua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnsua.Location = new System.Drawing.Point(836, 654);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(152, 44);
            this.btnsua.TabIndex = 4;
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnthem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnthem.Image = global::ThiVeMyThuat.Properties.Resources._1450392485_delete;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnthem.Location = new System.Drawing.Point(654, 654);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(143, 44);
            this.btnthem.TabIndex = 3;
            this.btnthem.Text = "Thêm thí sinh";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImage = global::ThiVeMyThuat.Properties.Resources._1450392390_system_search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(472, 654);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frmdangky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1354, 710);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btndanhsach);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_thisinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmdangky";
            this.Text = "Danh sách thí sinh đăng ký dự thi";
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