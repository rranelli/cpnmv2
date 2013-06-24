﻿namespace Chemtech.CPNM.Presentation
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
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.ltbItem = new System.Windows.Forms.ListBox();
            this.rbValueOnly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUnitOnly = new System.Windows.Forms.RadioButton();
            this.rbValueAndUnit = new System.Windows.Forms.RadioButton();
            this.btnFinishSelection = new System.Windows.Forms.Button();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ltbUnit = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltbItemType
            // 
            this.ltbItemType.DisplayMember = "Name";
            this.ltbItemType.Location = new System.Drawing.Point(12, 90);
            this.ltbItemType.Name = "ltbItemType";
            this.ltbItemType.Size = new System.Drawing.Size(166, 368);
            this.ltbItemType.Sorted = true;
            this.ltbItemType.TabIndex = 0;
            this.ltbItemType.SelectedIndexChanged += new System.EventHandler(this.ltbItemType_SelectedIndexChanged);
            // 
            // cmbItemTypeGroup
            // 
            this.cmbItemTypeGroup.DisplayMember = "Name";
            this.cmbItemTypeGroup.FormattingEnabled = true;
            this.cmbItemTypeGroup.Location = new System.Drawing.Point(12, 38);
            this.cmbItemTypeGroup.Name = "cmbItemTypeGroup";
            this.cmbItemTypeGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbItemTypeGroup.Sorted = true;
            this.cmbItemTypeGroup.TabIndex = 1;
            this.cmbItemTypeGroup.SelectedIndexChanged += new System.EventHandler(this.cmbItemTypeGroup_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Agrupamento de Tipos de Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo de Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Propriedade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Agrupamento de Propriedades";
            // 
            // cmbPropGroup
            // 
            this.cmbPropGroup.DisplayMember = "Name";
            this.cmbPropGroup.FormattingEnabled = true;
            this.cmbPropGroup.Location = new System.Drawing.Point(381, 38);
            this.cmbPropGroup.Name = "cmbPropGroup";
            this.cmbPropGroup.Size = new System.Drawing.Size(165, 21);
            this.cmbPropGroup.Sorted = true;
            this.cmbPropGroup.TabIndex = 14;
            // 
            // ltbProperty
            // 
            this.ltbProperty.DisplayMember = "Name";
            this.ltbProperty.Location = new System.Drawing.Point(379, 90);
            this.ltbProperty.Name = "ltbProperty";
            this.ltbProperty.Size = new System.Drawing.Size(166, 368);
            this.ltbProperty.Sorted = true;
            this.ltbProperty.TabIndex = 13;
            this.ltbProperty.SelectedIndexChanged += new System.EventHandler(this.ltbProperty_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Filtro Item";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(195, 38);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(165, 21);
            this.comboBox3.Sorted = true;
            this.comboBox3.TabIndex = 18;
            // 
            // ltbItem
            // 
            this.ltbItem.CausesValidation = false;
            this.ltbItem.DisplayMember = "Name";
            this.ltbItem.Location = new System.Drawing.Point(195, 90);
            this.ltbItem.Name = "ltbItem";
            this.ltbItem.Size = new System.Drawing.Size(165, 368);
            this.ltbItem.Sorted = true;
            this.ltbItem.TabIndex = 17;
            this.ltbItem.SelectedIndexChanged += new System.EventHandler(this.ltbItem_SelectedIndexChanged);
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
            this.rbValueOnly.CheckedChanged += new System.EventHandler(this.rbValueOnly_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbUnitOnly);
            this.groupBox1.Controls.Add(this.rbValueAndUnit);
            this.groupBox1.Controls.Add(this.rbValueOnly);
            this.groupBox1.Location = new System.Drawing.Point(568, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 88);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opção de texto";
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
            this.rbUnitOnly.CheckedChanged += new System.EventHandler(this.rbUnitOnly_CheckedChanged);
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
            this.rbValueAndUnit.CheckedChanged += new System.EventHandler(this.rbValueAndUnit_CheckedChanged);
            // 
            // btnFinishSelection
            // 
            this.btnFinishSelection.Location = new System.Drawing.Point(574, 411);
            this.btnFinishSelection.Name = "btnFinishSelection";
            this.btnFinishSelection.Size = new System.Drawing.Size(134, 56);
            this.btnFinishSelection.TabIndex = 23;
            this.btnFinishSelection.Text = "Inserir Referência";
            this.btnFinishSelection.UseVisualStyleBackColor = true;
            this.btnFinishSelection.Click += new System.EventHandler(this.btnFinishSelection_Click);
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(568, 373);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(165, 20);
            this.txbValue.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(570, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Valor a ser inserido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Unidade desejada";
            // 
            // ltbUnit
            // 
            this.ltbUnit.DisplayMember = "Name";
            this.ltbUnit.Location = new System.Drawing.Point(567, 90);
            this.ltbUnit.Name = "ltbUnit";
            this.ltbUnit.Size = new System.Drawing.Size(166, 147);
            this.ltbUnit.Sorted = true;
            this.ltbUnit.TabIndex = 26;
            this.ltbUnit.SelectedIndexChanged += new System.EventHandler(this.ltbUnit_SelectedIndexChanged);
            // 
            // GetReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ltbUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbValue);
            this.Controls.Add(this.btnFinishSelection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox3);
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
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ListBox ltbItem;
        private System.Windows.Forms.RadioButton rbValueOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUnitOnly;
        private System.Windows.Forms.RadioButton rbValueAndUnit;
        private System.Windows.Forms.Button btnFinishSelection;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ltbUnit;
    }
}
