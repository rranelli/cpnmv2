namespace Chemtech.CPNM.App.Excel
{
    partial class CPNMRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CPNMRibbon()
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
            this.btnInsertReference = this.Factory.CreateRibbonButton();
            this.btnUpdateReferences = this.Factory.CreateRibbonButton();
            this.btnApplyItemReuse = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnInsertReference);
            this.group1.Items.Add(this.btnUpdateReferences);
            this.group1.Items.Add(this.btnApplyItemReuse);
            this.group1.Label = "CPNM";
            this.group1.Name = "group1";
            // 
            // btnInsertReference
            // 
            this.btnInsertReference.Label = "Inserir Referencia";
            this.btnInsertReference.Name = "btnInsertReference";
            this.btnInsertReference.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnInsertReferenceClick);
            // 
            // btnUpdateReferences
            // 
            this.btnUpdateReferences.Label = "Update Valores";
            this.btnUpdateReferences.Name = "btnUpdateReferences";
            this.btnUpdateReferences.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnUpdateReferencesClick);
            // 
            // btnApplyItemReuse
            // 
            this.btnApplyItemReuse.Label = "Aplicar Reuso";
            this.btnApplyItemReuse.Name = "btnApplyItemReuse";
            this.btnApplyItemReuse.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnApplyItemReuseClick);
            // 
            // CPNMRibbon
            // 
            this.Name = "CPNMRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CPNMRibbonLoad);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnInsertReference;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpdateReferences;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnApplyItemReuse;
    }

    partial class ThisRibbonCollection
    {
        internal CPNMRibbon CPNMRibbon
        {
            get { return this.GetRibbon<CPNMRibbon>(); }
        }
    }
}
