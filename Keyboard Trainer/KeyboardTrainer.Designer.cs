namespace Keyboard_Trainer
{
    partial class KeyboardTrainer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxForTyping = new System.Windows.Forms.TextBox();
            this.LabelOfOutputRequiringLine = new System.Windows.Forms.Label();
            this.ModesComboBox = new System.Windows.Forms.ComboBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxForTyping
            // 
            this.TextBoxForTyping.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxForTyping.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxForTyping.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxForTyping.Location = new System.Drawing.Point(197, 54);
            this.TextBoxForTyping.Margin = new System.Windows.Forms.Padding(5);
            this.TextBoxForTyping.Name = "TextBoxForTyping";
            this.TextBoxForTyping.Size = new System.Drawing.Size(818, 30);
            this.TextBoxForTyping.TabIndex = 0;
            this.TextBoxForTyping.TextChanged += new System.EventHandler(this.TextBoxForTyping_TextChanged);
            // 
            // LabelOfOutputRequiringLine
            // 
            this.LabelOfOutputRequiringLine.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelOfOutputRequiringLine.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelOfOutputRequiringLine.Location = new System.Drawing.Point(196, 88);
            this.LabelOfOutputRequiringLine.Name = "LabelOfOutputRequiringLine";
            this.LabelOfOutputRequiringLine.Size = new System.Drawing.Size(819, 25);
            this.LabelOfOutputRequiringLine.TabIndex = 1;
            // 
            // ModesComboBox
            // 
            this.ModesComboBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ModesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModesComboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ModesComboBox.FormattingEnabled = true;
            this.ModesComboBox.Items.AddRange(new object[] {
            "word word word word word word word word word word word word",
            "bought the leaving sweater to jumping through out leak and ciri you",
            "word word word",
            "\"Hello, dear diary!\" - said Amanda after working out. \"Nice!\"",
            "54773 19387 374 75 387 293 5984 17493 0639 390892 103",
            "Own text",
            "& <~ [@/ -)! `(>@-:;; (.; <, \'{\'>}^/>}, ~<`!|@ {^,& #$% ?`\"/!-}(_@~- "});
            this.ModesComboBox.Location = new System.Drawing.Point(197, 463);
            this.ModesComboBox.Name = "ModesComboBox";
            this.ModesComboBox.Size = new System.Drawing.Size(815, 29);
            this.ModesComboBox.TabIndex = 2;
            this.ModesComboBox.SelectedIndexChanged += new System.EventHandler(this.ModesComboBox_SelectedIndexChanged);
            // 
            // ModeLabel
            // 
            this.ModeLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ModeLabel.Location = new System.Drawing.Point(196, 435);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(201, 25);
            this.ModeLabel.TabIndex = 3;
            this.ModeLabel.Text = "Mode";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.LanguageComboBox.Location = new System.Drawing.Point(197, 354);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(210, 29);
            this.LanguageComboBox.TabIndex = 4;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LanguageLabel.Location = new System.Drawing.Point(196, 326);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(201, 25);
            this.LanguageLabel.TabIndex = 5;
            this.LanguageLabel.Text = "Language";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(506, 346);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(144, 43);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // KeyboardTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1169, 652);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.ModesComboBox);
            this.Controls.Add(this.LabelOfOutputRequiringLine);
            this.Controls.Add(this.TextBoxForTyping);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyboardTrainer";
            this.Text = "Keyboard trainer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxForTyping;
        private System.Windows.Forms.Label LabelOfOutputRequiringLine;
        private System.Windows.Forms.ComboBox ModesComboBox;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Button RefreshButton;
    }
}

