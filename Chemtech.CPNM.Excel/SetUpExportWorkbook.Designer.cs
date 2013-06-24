namespace Chemtech.CPNM.AppExcel.Forms
{
    partial class SetUpExportWorkbook
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
            this.btnRedefWorksheet = new System.Windows.Forms.Button();
            this.clbProperties = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbItemTypeGroup = new System.Windows.Forms.ComboBox();
            this.ltbItemType = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPropGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSubArea = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnRedefWorksheet
            // 
            this.btnRedefWorksheet.Location = new System.Drawing.Point(202, 464);
            this.btnRedefWorksheet.Name = "btnRedefWorksheet";
            this.btnRedefWorksheet.Size = new System.Drawing.Size(164, 39);
            this.btnRedefWorksheet.TabIndex = 0;
            this.btnRedefWorksheet.Text = "Redefinir Planilha";
            this.btnRedefWorksheet.UseVisualStyleBackColor = true;
            // 
            // clbProperties
            // 
            this.clbProperties.DisplayMember = "Name";
            this.clbProperties.FormattingEnabled = true;
            this.clbProperties.Location = new System.Drawing.Point(201, 80);
            this.clbProperties.Name = "clbProperties";
            this.clbProperties.Size = new System.Drawing.Size(164, 364);
            this.clbProperties.Sorted = true;
            this.clbProperties.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tipo de Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Agrupamento de Tipos de Items";
            // 
            // cmbItemTypeGroup
            // 
            this.cmbItemTypeGroup.DisplayMember = "Name";
            this.cmbItemTypeGroup.FormattingEnabled = true;
            this.cmbItemTypeGroup.Location = new System.Drawing.Point(12, 28);
            this.cmbItemTypeGroup.Name = "cmbItemTypeGroup";
            this.cmbItemTypeGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbItemTypeGroup.Sorted = true;
            this.cmbItemTypeGroup.TabIndex = 14;
            this.cmbItemTypeGroup.SelectedIndexChanged += new System.EventHandler(this.cmbItemTypeGroup_SelectedIndexChanged);
            // 
            // ltbItemType
            // 
            this.ltbItemType.DisplayMember = "Name";
            this.ltbItemType.Location = new System.Drawing.Point(12, 80);
            this.ltbItemType.Name = "ltbItemType";
            this.ltbItemType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ltbItemType.Size = new System.Drawing.Size(166, 368);
            this.ltbItemType.Sorted = true;
            this.ltbItemType.TabIndex = 13;
            this.ltbItemType.SelectedIndexChanged += new System.EventHandler(this.ltbItemType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Propriedades Desejadas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Agrupamento de Propriedades";
            // 
            // cmbPropGroup
            // 
            this.cmbPropGroup.DisplayMember = "Name";
            this.cmbPropGroup.FormattingEnabled = true;
            this.cmbPropGroup.Location = new System.Drawing.Point(201, 28);
            this.cmbPropGroup.Name = "cmbPropGroup";
            this.cmbPropGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbPropGroup.Sorted = true;
            this.cmbPropGroup.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Filtrar Items por SubArea";
            // 
            // cmbSubArea
            // 
            this.cmbSubArea.DisplayMember = "Name";
            this.cmbSubArea.FormattingEnabled = true;
            this.cmbSubArea.Location = new System.Drawing.Point(12, 482);
            this.cmbSubArea.Name = "cmbSubArea";
            this.cmbSubArea.Size = new System.Drawing.Size(165, 21);
            this.cmbSubArea.Sorted = true;
            this.cmbSubArea.TabIndex = 26;
            // 
            // SetUpExportWorkbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 521);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSubArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPropGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbItemTypeGroup);
            this.Controls.Add(this.ltbItemType);
            this.Controls.Add(this.clbProperties);
            this.Controls.Add(this.btnRedefWorksheet);
            this.Name = "SetUpExportWorkbook";
            this.Text = "SetUpExportWorkbook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedefWorksheet;
        private System.Windows.Forms.CheckedListBox clbProperties;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbItemTypeGroup;
        private System.Windows.Forms.ListBox ltbItemType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPropGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubArea;
    }
}