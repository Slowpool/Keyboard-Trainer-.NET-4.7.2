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
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.FullScreenButton = new System.Windows.Forms.Button();
            this.PanelWithAllComponents = new System.Windows.Forms.Panel();
            this.adminButton = new System.Windows.Forms.Button();
            this.checkBoxHardcoreMode = new System.Windows.Forms.CheckBox();
            this.PanelWithAllComponents.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxForTyping
            // 
            this.TextBoxForTyping.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxForTyping.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxForTyping.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxForTyping.Location = new System.Drawing.Point(6, 6);
            this.TextBoxForTyping.Margin = new System.Windows.Forms.Padding(6);
            this.TextBoxForTyping.Name = "TextBoxForTyping";
            this.TextBoxForTyping.Size = new System.Drawing.Size(1062, 36);
            this.TextBoxForTyping.TabIndex = 0;
            this.TextBoxForTyping.TextChanged += new System.EventHandler(this.TextBoxForTyping_TextChanged);
            // 
            // LabelOfOutputRequiringLine
            // 
            this.LabelOfOutputRequiringLine.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelOfOutputRequiringLine.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelOfOutputRequiringLine.Location = new System.Drawing.Point(4, 48);
            this.LabelOfOutputRequiringLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelOfOutputRequiringLine.Name = "LabelOfOutputRequiringLine";
            this.LabelOfOutputRequiringLine.Size = new System.Drawing.Size(1065, 32);
            this.LabelOfOutputRequiringLine.TabIndex = 1;
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeComboBox.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModeComboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Items.AddRange(new object[] {
            "word word word word word word word word word word word word",
            "bought the leaving sweater to jumping through out leak and ciri you",
            "word word word",
            "\"Hello, dear diary!\" - said Amanda after working out. \"Nice!\"",
            "54773 19387 374 75 387 293 5984 17493 0639 390892 103",
            "Own text",
            "& <~ [@/ -)! `(>@-:;; (.; <, \'{\'>}^/>}, ~<`!|@ {^,& #$% ?`\"/!-}(_@~-",
            "Song"});
            this.ModeComboBox.Location = new System.Drawing.Point(8, 376);
            this.ModeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(1058, 36);
            this.ModeComboBox.TabIndex = 2;
            this.ModeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModesComboBox_SelectedIndexChanged);
            // 
            // ModeLabel
            // 
            this.ModeLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModeLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ModeLabel.Location = new System.Drawing.Point(4, 340);
            this.ModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(261, 32);
            this.ModeLabel.TabIndex = 3;
            this.ModeLabel.Text = "Mode";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.LanguageComboBox.Location = new System.Drawing.Point(432, 197);
            this.LanguageComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(272, 36);
            this.LanguageComboBox.TabIndex = 4;
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LanguageLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LanguageLabel.Location = new System.Drawing.Point(427, 161);
            this.LanguageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(261, 32);
            this.LanguageLabel.TabIndex = 5;
            this.LanguageLabel.Text = "Language";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.Location = new System.Drawing.Point(9, 191);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(174, 46);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // FullScreenButton
            // 
            this.FullScreenButton.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullScreenButton.Location = new System.Drawing.Point(894, 191);
            this.FullScreenButton.Name = "FullScreenButton";
            this.FullScreenButton.Size = new System.Drawing.Size(174, 46);
            this.FullScreenButton.TabIndex = 8;
            this.FullScreenButton.Text = "Full screen";
            this.FullScreenButton.UseVisualStyleBackColor = true;
            this.FullScreenButton.Click += new System.EventHandler(this.FullScreenButton_Click);
            // 
            // PanelWithAllComponents
            // 
            this.PanelWithAllComponents.Controls.Add(this.adminButton);
            this.PanelWithAllComponents.Controls.Add(this.checkBoxHardcoreMode);
            this.PanelWithAllComponents.Controls.Add(this.LabelOfOutputRequiringLine);
            this.PanelWithAllComponents.Controls.Add(this.ModeComboBox);
            this.PanelWithAllComponents.Controls.Add(this.ModeLabel);
            this.PanelWithAllComponents.Controls.Add(this.FullScreenButton);
            this.PanelWithAllComponents.Controls.Add(this.TextBoxForTyping);
            this.PanelWithAllComponents.Controls.Add(this.LanguageLabel);
            this.PanelWithAllComponents.Controls.Add(this.RefreshButton);
            this.PanelWithAllComponents.Controls.Add(this.LanguageComboBox);
            this.PanelWithAllComponents.Location = new System.Drawing.Point(12, 12);
            this.PanelWithAllComponents.Name = "PanelWithAllComponents";
            this.PanelWithAllComponents.Size = new System.Drawing.Size(1075, 438);
            this.PanelWithAllComponents.TabIndex = 9;
            // 
            // adminButton
            // 
            this.adminButton.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(894, 272);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(174, 46);
            this.adminButton.TabIndex = 10;
            this.adminButton.Text = "Admin menu";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // checkBoxHardcoreMode
            // 
            this.checkBoxHardcoreMode.AutoSize = true;
            this.checkBoxHardcoreMode.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxHardcoreMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxHardcoreMode.Location = new System.Drawing.Point(432, 286);
            this.checkBoxHardcoreMode.Name = "checkBoxHardcoreMode";
            this.checkBoxHardcoreMode.Size = new System.Drawing.Size(135, 32);
            this.checkBoxHardcoreMode.TabIndex = 9;
            this.checkBoxHardcoreMode.Text = "Hardcore";
            this.checkBoxHardcoreMode.UseVisualStyleBackColor = true;
            this.checkBoxHardcoreMode.CheckedChanged += new System.EventHandler(this.checkBoxHardcoreMode_CheckedChanged);
            // 
            // KeyboardTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1520, 838);
            this.Controls.Add(this.PanelWithAllComponents);
            this.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyboardTrainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard trainer";
            this.PanelWithAllComponents.ResumeLayout(false);
            this.PanelWithAllComponents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxForTyping;
        private System.Windows.Forms.Label LabelOfOutputRequiringLine;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button FullScreenButton;
        private System.Windows.Forms.Panel PanelWithAllComponents;
        private System.Windows.Forms.CheckBox checkBoxHardcoreMode;
        private System.Windows.Forms.Button adminButton;
    }
}

