namespace ThiVeMyThuat
{
    partial class FrmDonTuiRand
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sobaithi_theotui = new System.Windows.Forms.TextBox();
            this.btn_tron = new System.Windows.Forms.Button();
            this.txt_tongtuibaithi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.index_page = new System.Windows.Forms.NumericUpDown();
            this.btn_Update_DB = new System.Windows.Forms.Button();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_restore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.index_page)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 56);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(969, 421);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(831, 489);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(681, 489);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 497);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Túi số: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập vào số bài thi / 1 túi: ";
            // 
            // txt_sobaithi_theotui
            // 
            this.txt_sobaithi_theotui.Location = new System.Drawing.Point(198, 11);
            this.txt_sobaithi_theotui.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sobaithi_theotui.Name = "txt_sobaithi_theotui";
            this.txt_sobaithi_theotui.Size = new System.Drawing.Size(148, 26);
            this.txt_sobaithi_theotui.TabIndex = 5;
            this.txt_sobaithi_theotui.Text = "48";
            // 
            // btn_tron
            // 
            this.btn_tron.Location = new System.Drawing.Point(353, 1);
            this.btn_tron.Name = "btn_tron";
            this.btn_tron.Size = new System.Drawing.Size(113, 45);
            this.btn_tron.TabIndex = 6;
            this.btn_tron.Text = "Trộn túi bài thi";
            this.btn_tron.UseVisualStyleBackColor = true;
            this.btn_tron.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_tongtuibaithi
            // 
            this.txt_tongtuibaithi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_tongtuibaithi.Location = new System.Drawing.Point(167, 494);
            this.txt_tongtuibaithi.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongtuibaithi.Name = "txt_tongtuibaithi";
            this.txt_tongtuibaithi.ReadOnly = true;
            this.txt_tongtuibaithi.Size = new System.Drawing.Size(62, 26);
            this.txt_tongtuibaithi.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 497);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "/";
            // 
            // index_page
            // 
            this.index_page.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.index_page.Location = new System.Drawing.Point(79, 494);
            this.index_page.Name = "index_page";
            this.index_page.Size = new System.Drawing.Size(60, 26);
            this.index_page.TabIndex = 7;
            this.index_page.ValueChanged += new System.EventHandler(this.txt_index_page_ValueChanged);
            // 
            // btn_Update_DB
            // 
            this.btn_Update_DB.Enabled = false;
            this.btn_Update_DB.Location = new System.Drawing.Point(472, 1);
            this.btn_Update_DB.Name = "btn_Update_DB";
            this.btn_Update_DB.Size = new System.Drawing.Size(155, 45);
            this.btn_Update_DB.TabIndex = 6;
            this.btn_Update_DB.Text = "Cập nhật vào CSDL";
            this.btn_Update_DB.UseVisualStyleBackColor = true;
            this.btn_Update_DB.Click += new System.EventHandler(this.btn_Update_DB_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Location = new System.Drawing.Point(633, 1);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(155, 45);
            this.btn_backup.TabIndex = 6;
            this.btn_backup.Text = "Tạo bản sao dữ liệu";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(794, 1);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(132, 45);
            this.btn_restore.TabIndex = 6;
            this.btn_restore.Text = "Khôi phục dữ liệu";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // FrmDonTuiRand
            // 
            this.AcceptButton = this.btn_Update_DB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 540);
            this.Controls.Add(this.index_page);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_Update_DB);
            this.Controls.Add(this.btn_tron);
            this.Controls.Add(this.txt_sobaithi_theotui);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_tongtuibaithi);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDonTuiRand";
            this.Text = "FrmDonTuiRand";
            this.Load += new System.EventHandler(this.FrmDonTuiRand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.index_page)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sobaithi_theotui;
        private System.Windows.Forms.Button btn_tron;
        private System.Windows.Forms.TextBox txt_tongtuibaithi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown index_page;
        private System.Windows.Forms.Button btn_Update_DB;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_restore;
    }
}