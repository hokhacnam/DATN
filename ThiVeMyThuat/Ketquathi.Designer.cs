namespace ThiVeMyThuat
{
    partial class KetQuaThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KetQuaThi));
            this.dsVeMT1 = new ThiVeMyThuat.DsVeMT();
            this.reportManager1 = new PerpetuumSoft.Reporting.Components.ReportManager(this.components);
            this.inlineReportSlot1 = new PerpetuumSoft.Reporting.Components.InlineReportSlot(this.components);
            this.reportViewer1 = new PerpetuumSoft.Reporting.View.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsVeMT1)).BeginInit();
            this.SuspendLayout();
            // 
            // dsVeMT1
            // 
            this.dsVeMT1.DataSetName = "DsVeMT";
            this.dsVeMT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportManager1
            // 
            this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[] {
            "VeMT"}, new object[] {
            ((object)(this.dsVeMT1.vemt))});
            this.reportManager1.OwnerForm = this;
            this.reportManager1.Reports.AddRange(new PerpetuumSoft.Reporting.Components.ReportSlot[] {
            this.inlineReportSlot1});
            // 
            // inlineReportSlot1
            // 
            this.inlineReportSlot1.DocumentStream = resources.GetString("inlineReportSlot1.DocumentStream");
            this.inlineReportSlot1.ReportName = "ketquathi";
            this.inlineReportSlot1.ReportScriptType = typeof(PerpetuumSoft.Reporting.Rendering.ReportScriptBase);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.Location = new System.Drawing.Point(1, 276);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageIndex = 0;
            this.reportViewer1.Size = new System.Drawing.Size(648, 18);
            this.reportViewer1.Source = this.inlineReportSlot1;
            this.reportViewer1.SplashForm = null;
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ViewMode = PerpetuumSoft.Reporting.View.ViewMode.ContinuedPage;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "In kết quả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(466, 175);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ghi chú :";
            // 
            // Ketquathi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Ketquathi";
            this.Text = "Ketquathi";
            this.Load += new System.EventHandler(this.Ketquathi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsVeMT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DsVeMT dsVeMT1;
        private PerpetuumSoft.Reporting.Components.ReportManager reportManager1;
        private PerpetuumSoft.Reporting.Components.InlineReportSlot inlineReportSlot1;
        private PerpetuumSoft.Reporting.View.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}