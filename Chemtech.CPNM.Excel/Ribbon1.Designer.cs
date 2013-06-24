namespace Chemtech.CPNM.Excel
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
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnAddRef = this.Factory.CreateRibbonButton();
            this.btnRefReuse = this.Factory.CreateRibbonButton();
            this.btnFetchAll = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.checkBox1 = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "CopyPasteNuncaMais";
            this.tab1.Name = "tab1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnAddRef);
            this.group2.Items.Add(this.btnRefReuse);
            this.group2.Items.Add(this.btnFetchAll);
            this.group2.Label = "Ações";
            this.group2.Name = "group2";
            // 
            // btnAddRef
            // 
            this.btnAddRef.Label = "Adicionar Referência";
            this.btnAddRef.Name = "btnAddRef";
            this.btnAddRef.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAddRef_Click);
            // 
            // btnRefReuse
            // 
            this.btnRefReuse.Label = "Reuso de Referências";
            this.btnRefReuse.Name = "btnRefReuse";
            // 
            // btnFetchAll
            // 
            this.btnFetchAll.Label = "Carregar do banco";
            this.btnFetchAll.Name = "btnFetchAll";
            // 
            // group3
            // 
            this.group3.Items.Add(this.button6);
            this.group3.Items.Add(this.button3);
            this.group3.Items.Add(this.checkBox1);
            this.group3.Label = "Configuração";
            this.group3.Name = "group3";
            // 
            // button6
            // 
            this.button6.Label = "Aplicar Compartilhamento";
            this.button6.Name = "button6";
            // 
            // button3
            // 
            this.button3.Label = "Configurar Ambiente";
            this.button3.Name = "button3";
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Label = "Ativar Inspeção";
            this.checkBox1.Name = "checkBox1";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddRef;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRefReuse;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFetchAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
