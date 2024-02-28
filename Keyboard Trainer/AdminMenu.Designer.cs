namespace Keyboard_Trainer
{
    partial class AdminMenu
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
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonUploadAll = new System.Windows.Forms.Button();
            this.buttonReUploadAll = new System.Windows.Forms.Button();
            this.comboBoxTypeOfData = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(12, 12);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(338, 46);
            this.buttonDeleteAll.TabIndex = 0;
            this.buttonDeleteAll.Text = "Delete all";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            // 
            // buttonUploadAll
            // 
            this.buttonUploadAll.Location = new System.Drawing.Point(356, 12);
            this.buttonUploadAll.Name = "buttonUploadAll";
            this.buttonUploadAll.Size = new System.Drawing.Size(288, 46);
            this.buttonUploadAll.TabIndex = 1;
            this.buttonUploadAll.Text = "Upload all";
            this.buttonUploadAll.UseVisualStyleBackColor = true;
            // 
            // buttonReUploadAll
            // 
            this.buttonReUploadAll.Location = new System.Drawing.Point(650, 12);
            this.buttonReUploadAll.Name = "buttonReUploadAll";
            this.buttonReUploadAll.Size = new System.Drawing.Size(292, 46);
            this.buttonReUploadAll.TabIndex = 2;
            this.buttonReUploadAll.Text = "Re-upload all";
            this.buttonReUploadAll.UseVisualStyleBackColor = true;
            // 
            // comboBoxTypeOfData
            // 
            this.comboBoxTypeOfData.FormattingEnabled = true;
            this.comboBoxTypeOfData.Items.AddRange(new object[] {
            "texts",
            "words",
            "songs"});
            this.comboBoxTypeOfData.Location = new System.Drawing.Point(437, 45);
            this.comboBoxTypeOfData.Name = "comboBoxTypeOfData";
            this.comboBoxTypeOfData.Size = new System.Drawing.Size(211, 36);
            this.comboBoxTypeOfData.TabIndex = 5;
            this.comboBoxTypeOfData.SelectedIndexChanged += new System.EventHandler(this.comboBoxAction_SelectedIndexChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "english",
            "russian"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(698, 45);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(198, 36);
            this.comboBoxLanguage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(198, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "data with type of";
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Items.AddRange(new object[] {
            "Delete",
            "Upload",
            "Re-upload"});
            this.comboBoxAction.Location = new System.Drawing.Point(29, 45);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(163, 36);
            this.comboBoxAction.TabIndex = 9;
            this.comboBoxAction.SelectedIndexChanged += new System.EventHandler(this.comboBoxAction_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(654, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "on";
            // 
            // buttonExecute
            // 
            this.buttonExecute.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonExecute.Location = new System.Drawing.Point(203, 128);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(496, 46);
            this.buttonExecute.TabIndex = 11;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxAction);
            this.groupBox1.Controls.Add(this.buttonExecute);
            this.groupBox1.Controls.Add(this.comboBoxTypeOfData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxLanguage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 200);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom action";
            // 
            // AdminMenu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(963, 308);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReUploadAll);
            this.Controls.Add(this.buttonUploadAll);
            this.Controls.Add(this.buttonDeleteAll);
            this.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AdminMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMenu_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUploadAll;
        private System.Windows.Forms.Button buttonReUploadAll;
        private System.Windows.Forms.ComboBox comboBoxTypeOfData;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}