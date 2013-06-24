namespace Chemtech.CPNM.Presentation.Forms
{
    partial class SetUpReuse
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
            this.ltbStack = new System.Windows.Forms.ListBox();
            this.ltbCandidateItems = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbExistantCriteria2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCommitReuse = new System.Windows.Forms.Button();
            this.btnAddToStack = new System.Windows.Forms.Button();
            this.btnRemoveFromStack = new System.Windows.Forms.Button();
            this.ckbSelectionOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ltbExistantItems = new System.Windows.Forms.ListBox();
            this.txbSearchCriteria1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltbStack
            // 
            this.ltbStack.FormattingEnabled = true;
            this.ltbStack.Location = new System.Drawing.Point(459, 57);
            this.ltbStack.Name = "ltbStack";
            this.ltbStack.Size = new System.Drawing.Size(146, 225);
            this.ltbStack.TabIndex = 2;
            // 
            // ltbCandidateItems
            // 
            this.ltbCandidateItems.DisplayMember = "Name";
            this.ltbCandidateItems.FormattingEnabled = true;
            this.ltbCandidateItems.Location = new System.Drawing.Point(13, 46);
            this.ltbCandidateItems.Name = "ltbCandidateItems";
            this.ltbCandidateItems.Size = new System.Drawing.Size(146, 303);
            this.ltbCandidateItems.Sorted = true;
            this.ltbCandidateItems.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search";
            // 
            // txbExistantCriteria2
            // 
            this.txbExistantCriteria2.Location = new System.Drawing.Point(59, 20);
            this.txbExistantCriteria2.Name = "txbExistantCriteria2";
            this.txbExistantCriteria2.Size = new System.Drawing.Size(100, 20);
            this.txbExistantCriteria2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modificações na pilha";
            // 
            // btnCommitReuse
            // 
            this.btnCommitReuse.Location = new System.Drawing.Point(458, 329);
            this.btnCommitReuse.Name = "btnCommitReuse";
            this.btnCommitReuse.Size = new System.Drawing.Size(146, 44);
            this.btnCommitReuse.TabIndex = 13;
            this.btnCommitReuse.Text = "Aplicar Alterações";
            this.btnCommitReuse.UseVisualStyleBackColor = true;
            this.btnCommitReuse.Click += new System.EventHandler(this.btnCommitReuse_Click);
            // 
            // btnAddToStack
            // 
            this.btnAddToStack.Location = new System.Drawing.Point(370, 101);
            this.btnAddToStack.Name = "btnAddToStack";
            this.btnAddToStack.Size = new System.Drawing.Size(75, 28);
            this.btnAddToStack.TabIndex = 14;
            this.btnAddToStack.Text = "Adicionar ->";
            this.btnAddToStack.UseVisualStyleBackColor = true;
            this.btnAddToStack.Click += new System.EventHandler(this.btnAddToStack_Click);
            // 
            // btnRemoveFromStack
            // 
            this.btnRemoveFromStack.Location = new System.Drawing.Point(370, 195);
            this.btnRemoveFromStack.Name = "btnRemoveFromStack";
            this.btnRemoveFromStack.Size = new System.Drawing.Size(75, 28);
            this.btnRemoveFromStack.TabIndex = 15;
            this.btnRemoveFromStack.Text = "<- Remover";
            this.btnRemoveFromStack.UseVisualStyleBackColor = true;
            this.btnRemoveFromStack.Click += new System.EventHandler(this.btnRemoveFromStack_Click);
            // 
            // ckbSelectionOnly
            // 
            this.ckbSelectionOnly.AutoSize = true;
            this.ckbSelectionOnly.Location = new System.Drawing.Point(459, 297);
            this.ckbSelectionOnly.Name = "ckbSelectionOnly";
            this.ckbSelectionOnly.Size = new System.Drawing.Size(127, 17);
            this.ckbSelectionOnly.TabIndex = 16;
            this.ckbSelectionOnly.Text = "Restringir à Seleção?";
            this.ckbSelectionOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ltbExistantItems);
            this.groupBox1.Controls.Add(this.txbSearchCriteria1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 361);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search";
            // 
            // ltbExistantItems
            // 
            this.ltbExistantItems.DisplayMember = "Name";
            this.ltbExistantItems.FormattingEnabled = true;
            this.ltbExistantItems.Location = new System.Drawing.Point(12, 46);
            this.ltbExistantItems.Name = "ltbExistantItems";
            this.ltbExistantItems.Size = new System.Drawing.Size(146, 303);
            this.ltbExistantItems.Sorted = true;
            this.ltbExistantItems.TabIndex = 1;
            // 
            // txbSearchCriteria1
            // 
            this.txbSearchCriteria1.Location = new System.Drawing.Point(58, 20);
            this.txbSearchCriteria1.Name = "txbSearchCriteria1";
            this.txbSearchCriteria1.Size = new System.Drawing.Size(100, 20);
            this.txbSearchCriteria1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ltbCandidateItems);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txbExistantCriteria2);
            this.groupBox2.Location = new System.Drawing.Point(189, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 361);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item Destino";
            // 
            // SetUpReuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 389);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbSelectionOnly);
            this.Controls.Add(this.btnRemoveFromStack);
            this.Controls.Add(this.btnAddToStack);
            this.Controls.Add(this.btnCommitReuse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ltbStack);
            this.Name = "SetUpReuse";
            this.Text = "SetUpReuse";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbStack;
        private System.Windows.Forms.ListBox ltbCandidateItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbExistantCriteria2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCommitReuse;
        private System.Windows.Forms.Button btnAddToStack;
        private System.Windows.Forms.Button btnRemoveFromStack;
        private System.Windows.Forms.CheckBox ckbSelectionOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ltbExistantItems;
        private System.Windows.Forms.TextBox txbSearchCriteria1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}