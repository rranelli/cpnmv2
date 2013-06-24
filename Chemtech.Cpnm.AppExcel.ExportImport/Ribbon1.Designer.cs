namespace Chemtech.Cpnm.AppExcel.ExportImport
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnConfig = this.Factory.CreateRibbonButton();
            this.btnUploadData = this.Factory.CreateRibbonButton();
            this.btnDownloadData = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "CopyPasteNuncaMais";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnConfig);
            this.group1.Items.Add(this.btnUploadData);
            this.group1.Items.Add(this.btnDownloadData);
            this.group1.Label = "Export & Import";
            this.group1.Name = "group1";
            // 
            // btnConfig
            // 
            this.btnConfig.Label = "Configurar Planilha";
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfig_Click);
            // 
            // btnUploadData
            // 
            this.btnUploadData.Label = "Fazer Upload";
            this.btnUploadData.Name = "btnUploadData";
            this.btnUploadData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUploadData_Click);
            // 
            // btnDownloadData
            // 
            this.btnDownloadData.Label = "Fazer Download";
            this.btnDownloadData.Name = "btnDownloadData";
            this.btnDownloadData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDownloadData_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfig;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUploadData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDownloadData;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
