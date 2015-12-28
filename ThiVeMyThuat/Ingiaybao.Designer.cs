namespace ThiVeMyThuat
{
    partial class InGiayBao
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
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.btnin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(66, 71);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(252, 20);
            this.txtghichu.TabIndex = 0;
            // 
            // btnin
            // 
            this.btnin.Location = new System.Drawing.Point(243, 150);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(75, 23);
            this.btnin.TabIndex = 1;
            this.btnin.Text = "In";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // Ingiaybao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 360);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.txtghichu);
            this.Name = "Ingiaybao";
            this.Text = "Ingiaybao";
            this.Load += new System.EventHandler(this.Ingiaybao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Button btnin;
    }
}