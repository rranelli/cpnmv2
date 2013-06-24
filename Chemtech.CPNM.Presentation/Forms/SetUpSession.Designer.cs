namespace Chemtech.CPNM.Presentation.Forms
{
    partial class SetUpSession
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
            this.btnCommitConfig = new System.Windows.Forms.Button();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCommitConfig
            // 
            this.btnCommitConfig.Location = new System.Drawing.Point(160, 69);
            this.btnCommitConfig.Name = "btnCommitConfig";
            this.btnCommitConfig.Size = new System.Drawing.Size(75, 23);
            this.btnCommitConfig.TabIndex = 0;
            this.btnCommitConfig.Text = "OK";
            this.btnCommitConfig.UseVisualStyleBackColor = true;
            this.btnCommitConfig.Click += new System.EventHandler(this.btnCommitConfig_Click);
            // 
            // cmbProjects
            // 
            this.cmbProjects.DisplayMember = "Name";
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(114, 12);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(121, 21);
            this.cmbProjects.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Projeto";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(114, 43);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(121, 20);
            this.txbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome do Usuario";
            // 
            // SetUpSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 103);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.btnCommitConfig);
            this.Name = "SetUpSession";
            this.Text = "SetUpSession";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommitConfig;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label2;
    }
}