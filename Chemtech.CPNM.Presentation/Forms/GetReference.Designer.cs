namespace Chemtech.CPNM.Presentation.Forms
{
    partial class GetReference
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
            this.ltbItemType = new System.Windows.Forms.ListBox();
            this.cmbItemTypeGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPropGroup = new System.Windows.Forms.ComboBox();
            this.ltbProperty = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSubArea = new System.Windows.Forms.ComboBox();
            this.ltbItem = new System.Windows.Forms.ListBox();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinishSelection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbMetadata = new System.Windows.Forms.RadioButton();
            this.rbValueRef = new System.Windows.Forms.RadioButton();
            this.ltbMeta = new System.Windows.Forms.ListBox();
            this.rbValueOnly = new System.Windows.Forms.RadioButton();
            this.rbValueAndUnit = new System.Windows.Forms.RadioButton();
            this.rbUnitOnly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ltbUnit = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltbItemType
            // 
            this.ltbItemType.DisplayMember = "Name";
            this.ltbItemType.Location = new System.Drawing.Point(8, 81);
            this.ltbItemType.Name = "ltbItemType";
            this.ltbItemType.Size = new System.Drawing.Size(166, 368);
            this.ltbItemType.Sorted = true;
            this.ltbItemType.TabIndex = 0;
            this.ltbItemType.SelectedIndexChanged += new System.EventHandler(this.LtbItemTypeSelectedIndexChanged);
            // 
            // cmbItemTypeGroup
            // 
            this.cmbItemTypeGroup.DisplayMember = "Name";
            this.cmbItemTypeGroup.FormattingEnabled = true;
            this.cmbItemTypeGroup.Location = new System.Drawing.Point(8, 29);
            this.cmbItemTypeGroup.Name = "cmbItemTypeGroup";
            this.cmbItemTypeGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbItemTypeGroup.Sorted = true;
            this.cmbItemTypeGroup.TabIndex = 1;
            this.cmbItemTypeGroup.SelectedIndexChanged += new System.EventHandler(this.CmbItemTypeGroupSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Agrupamento de Tipos de Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo de Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Propriedade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Agrupamento de Propriedades";
            // 
            // cmbPropGroup
            // 
            this.cmbPropGroup.DisplayMember = "Name";
            this.cmbPropGroup.FormattingEnabled = true;
            this.cmbPropGroup.Location = new System.Drawing.Point(377, 29);
            this.cmbPropGroup.Name = "cmbPropGroup";
            this.cmbPropGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbPropGroup.Sorted = true;
            this.cmbPropGroup.TabIndex = 14;
            // 
            // ltbProperty
            // 
            this.ltbProperty.DisplayMember = "Name";
            this.ltbProperty.Location = new System.Drawing.Point(375, 81);
            this.ltbProperty.Name = "ltbProperty";
            this.ltbProperty.Size = new System.Drawing.Size(166, 368);
            this.ltbProperty.Sorted = true;
            this.ltbProperty.TabIndex = 13;
            this.ltbProperty.SelectedIndexChanged += new System.EventHandler(this.LtbPropertySelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "SubArea";
            // 
            // cmbSubArea
            // 
            this.cmbSubArea.DisplayMember = "Name";
            this.cmbSubArea.FormattingEnabled = true;
            this.cmbSubArea.Location = new System.Drawing.Point(191, 29);
            this.cmbSubArea.Name = "cmbSubArea";
            this.cmbSubArea.Size = new System.Drawing.Size(165, 21);
            this.cmbSubArea.Sorted = true;
            this.cmbSubArea.TabIndex = 18;
            // 
            // ltbItem
            // 
            this.ltbItem.CausesValidation = false;
            this.ltbItem.DisplayMember = "Name";
            this.ltbItem.Location = new System.Drawing.Point(191, 81);
            this.ltbItem.Name = "ltbItem";
            this.ltbItem.Size = new System.Drawing.Size(165, 368);
            this.ltbItem.Sorted = true;
            this.ltbItem.TabIndex = 17;
            this.ltbItem.SelectedIndexChanged += new System.EventHandler(this.LtbItemSelectedIndexChanged);
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(566, 368);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(165, 20);
            this.txbValue.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Valor a ser inserido:";
            // 
            // btnFinishSelection
            // 
            this.btnFinishSelection.Location = new System.Drawing.Point(566, 394);
            this.btnFinishSelection.Name = "btnFinishSelection";
            this.btnFinishSelection.Size = new System.Drawing.Size(165, 56);
            this.btnFinishSelection.TabIndex = 23;
            this.btnFinishSelection.Text = "Inserir Referência";
            this.btnFinishSelection.UseVisualStyleBackColor = true;
            this.btnFinishSelection.Click += new System.EventHandler(this.BtnFinishSelectionClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Valor a ser inserido:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbMetadata);
            this.groupBox4.Controls.Add(this.rbValueRef);
            this.groupBox4.Location = new System.Drawing.Point(570, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 65);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo de Propriedade";
            // 
            // rbMetadata
            // 
            this.rbMetadata.AutoSize = true;
            this.rbMetadata.Location = new System.Drawing.Point(6, 42);
            this.rbMetadata.Name = "rbMetadata";
            this.rbMetadata.Size = new System.Drawing.Size(115, 17);
            this.rbMetadata.TabIndex = 22;
            this.rbMetadata.Text = "Valor de Metadado";
            this.rbMetadata.UseVisualStyleBackColor = true;
            this.rbMetadata.CheckedChanged += new System.EventHandler(this.RbMetadataCheckedChanged);
            // 
            // rbValueRef
            // 
            this.rbValueRef.AutoSize = true;
            this.rbValueRef.Checked = true;
            this.rbValueRef.Location = new System.Drawing.Point(6, 19);
            this.rbValueRef.Name = "rbValueRef";
            this.rbValueRef.Size = new System.Drawing.Size(124, 17);
            this.rbValueRef.TabIndex = 21;
            this.rbValueRef.TabStop = true;
            this.rbValueRef.Text = "Valor de Propriedade";
            this.rbValueRef.UseVisualStyleBackColor = true;
            this.rbValueRef.CheckedChanged += new System.EventHandler(this.RbValueRefCheckedChanged);
            // 
            // ltbMeta
            // 
            this.ltbMeta.DisplayMember = "Name";
            this.ltbMeta.Items.AddRange(new object[] {
            "AreaRef",
            "ItemNameRef",
            "ItemTypeNameRef",
            "ProjectRef",
            "SubAreaRef",
            "ValueRef"});
            this.ltbMeta.Location = new System.Drawing.Point(375, 81);
            this.ltbMeta.Name = "ltbMeta";
            this.ltbMeta.Size = new System.Drawing.Size(166, 368);
            this.ltbMeta.Sorted = true;
            this.ltbMeta.TabIndex = 30;
            // 
            // rbValueOnly
            // 
            this.rbValueOnly.AutoSize = true;
            this.rbValueOnly.Location = new System.Drawing.Point(6, 19);
            this.rbValueOnly.Name = "rbValueOnly";
            this.rbValueOnly.Size = new System.Drawing.Size(88, 17);
            this.rbValueOnly.TabIndex = 21;
            this.rbValueOnly.Text = "Apenas Valor";
            this.rbValueOnly.UseVisualStyleBackColor = true;
            this.rbValueOnly.CheckedChanged += new System.EventHandler(this.RbValueOnlyCheckedChanged);
            // 
            // rbValueAndUnit
            // 
            this.rbValueAndUnit.AutoSize = true;
            this.rbValueAndUnit.Checked = true;
            this.rbValueAndUnit.Location = new System.Drawing.Point(6, 42);
            this.rbValueAndUnit.Name = "rbValueAndUnit";
            this.rbValueAndUnit.Size = new System.Drawing.Size(101, 17);
            this.rbValueAndUnit.TabIndex = 22;
            this.rbValueAndUnit.TabStop = true;
            this.rbValueAndUnit.Text = "Valor e Unidade";
            this.rbValueAndUnit.UseVisualStyleBackColor = true;
            this.rbValueAndUnit.CheckedChanged += new System.EventHandler(this.RbValueAndUnitCheckedChanged);
            // 
            // rbUnitOnly
            // 
            this.rbUnitOnly.AutoSize = true;
            this.rbUnitOnly.Location = new System.Drawing.Point(6, 65);
            this.rbUnitOnly.Name = "rbUnitOnly";
            this.rbUnitOnly.Size = new System.Drawing.Size(104, 17);
            this.rbUnitOnly.TabIndex = 23;
            this.rbUnitOnly.Text = "Apenas Unidade";
            this.rbUnitOnly.UseVisualStyleBackColor = true;
            this.rbUnitOnly.CheckedChanged += new System.EventHandler(this.RbUnitOnlyCheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUnitOnly);
            this.groupBox1.Controls.Add(this.rbValueAndUnit);
            this.groupBox1.Controls.Add(this.rbValueOnly);
            this.groupBox1.Location = new System.Drawing.Point(566, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 88);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opção de texto";
            // 
            // ltbUnit
            // 
            this.ltbUnit.DisplayMember = "Name";
            this.ltbUnit.Location = new System.Drawing.Point(566, 102);
            this.ltbUnit.Name = "ltbUnit";
            this.ltbUnit.Size = new System.Drawing.Size(166, 121);
            this.ltbUnit.Sorted = true;
            this.ltbUnit.TabIndex = 26;
            this.ltbUnit.SelectedIndexChanged += new System.EventHandler(this.LtbUnitSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Unidade desejada";
            // 
            // GetReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 457);
            this.Controls.Add(this.ltbMeta);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ltbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFinishSelection);
            this.Controls.Add(this.txbValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSubArea);
            this.Controls.Add(this.ltbItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPropGroup);
            this.Controls.Add(this.ltbProperty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbItemTypeGroup);
            this.Controls.Add(this.ltbItemType);
            this.Name = "GetReference";
            this.Text = "Seleção de referência";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbItemType;
        private System.Windows.Forms.ComboBox cmbItemTypeGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPropGroup;
        private System.Windows.Forms.ListBox ltbProperty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSubArea;
        private System.Windows.Forms.ListBox ltbItem;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinishSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbMetadata;
        private System.Windows.Forms.RadioButton rbValueRef;
        private System.Windows.Forms.ListBox ltbMeta;
        private System.Windows.Forms.RadioButton rbValueOnly;
        private System.Windows.Forms.RadioButton rbValueAndUnit;
        private System.Windows.Forms.RadioButton rbUnitOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ltbUnit;
        private System.Windows.Forms.Label label2;
    }
}

