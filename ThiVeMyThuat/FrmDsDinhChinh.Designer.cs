namespace ThiVeMyThuat
{
    partial class FrmDsDinhChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDsDinhChinh));
            PerpetuumSoft.Reporting.Export.ExtraParameters extraParameters1 = new PerpetuumSoft.Reporting.Export.ExtraParameters();
            this.reportManager1 = new PerpetuumSoft.Reporting.Components.ReportManager(this.components);
            this.dsVeMT1 = new ThiVeMyThuat.DsVeMT();
            this.inlineReportSlot1 = new PerpetuumSoft.Reporting.Components.InlineReportSlot(this.components);
            this.reportViewer1 = new PerpetuumSoft.Reporting.View.ReportViewer();
            this.pdfExportFilter1 = new PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsVeMT1)).BeginInit();
            this.SuspendLayout();
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
            // dsVeMT1
            // 
            this.dsVeMT1.DataSetName = "DsVeMT";
            this.dsVeMT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inlineReportSlot1
            // 
            this.inlineReportSlot1.DocumentStream = resources.GetString("inlineReportSlot1.DocumentStream");
            this.inlineReportSlot1.ReportName = "DsDinhChinh";
            this.inlineReportSlot1.ReportScriptType = typeof(PerpetuumSoft.Reporting.Rendering.ReportScriptBase);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageIndex = 0;
            this.reportViewer1.Size = new System.Drawing.Size(645, 369);
            this.reportViewer1.Source = this.inlineReportSlot1;
            this.reportViewer1.SplashForm = null;
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.ViewMode = PerpetuumSoft.Reporting.View.ViewMode.ContinuedPage;
            // 
            // pdfExportFilter1
            // 
            this.pdfExportFilter1.ChangePermissionsPassword = null;
            this.pdfExportFilter1.Compress = true;
            this.pdfExportFilter1.ExtraParameters = extraParameters1;
            this.pdfExportFilter1.UserPassword = null;
            // 
            // FrmDsDinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 369);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmDsDinhChinh";
            this.Text = "FrmDsDinhChinh";
            this.Load += new System.EventHandler(this.FrmDsDinhChinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsVeMT1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PerpetuumSoft.Reporting.Components.ReportManager reportManager1;
        private DsVeMT dsVeMT1;
        private PerpetuumSoft.Reporting.View.ReportViewer reportViewer1;
        private PerpetuumSoft.Reporting.Components.InlineReportSlot inlineReportSlot1;
        private PerpetuumSoft.Reporting.Export.Pdf.PdfExportFilter pdfExportFilter1;
    }
}