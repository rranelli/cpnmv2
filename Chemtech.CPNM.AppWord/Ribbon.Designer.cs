namespace Chemtech.CPNM.AppWord
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
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
            this.Group1 = this.Factory.CreateRibbonGroup();
            this.btnAddRef = this.Factory.CreateRibbonButton();
            this.btnRefReuse = this.Factory.CreateRibbonButton();
            this.btnFetchAll = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.checkBox1 = this.Factory.CreateRibbonCheckBox();
            this.tab1.SuspendLayout();
            this.Group1.SuspendLayout();
            this.group2.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.Group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "Copy&PasteNuncaMais";
            this.tab1.Name = "tab1";
            // 
            // Group1
            // 
            this.Group1.Items.Add(this.btnAddRef);
            this.Group1.Items.Add(this.btnRefReuse);
            this.Group1.Items.Add(this.btnFetchAll);
            this.Group1.Label = "Ações";
            this.Group1.Name = "Group1";
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
            this.btnRefReuse.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRefReuse_Click);
            // 
            // btnFetchAll
            // 
            this.btnFetchAll.Label = "Carregar do banco";
            this.btnFetchAll.Name = "btnFetchAll";
            this.btnFetchAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFetchAll_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button6);
            this.group2.Items.Add(this.button3);
            this.group2.Items.Add(this.checkBox1);
            this.group2.Label = "Configuração";
            this.group2.Name = "group2";
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
            // 
            // checkBox1
            // 
            this.checkBox1.Label = "Ativar Inspeção";
            this.checkBox1.Name = "checkBox1";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.Group1.ResumeLayout(false);
            this.Group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddRef;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRefReuse;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFetchAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
