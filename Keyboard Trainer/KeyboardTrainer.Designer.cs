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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxForTyping
            // 
            this.TextBoxForTyping.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxForTyping.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxForTyping.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxForTyping.Location = new System.Drawing.Point(14, 14);
            this.TextBoxForTyping.Margin = new System.Windows.Forms.Padding(5);
            this.TextBoxForTyping.Name = "TextBoxForTyping";
            this.TextBoxForTyping.Size = new System.Drawing.Size(818, 30);
            this.TextBoxForTyping.TabIndex = 0;
            this.TextBoxForTyping.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxForTyping_KeyPress);
            // 
            // LabelOfOutputRequiringLine
            // 
            this.LabelOfOutputRequiringLine.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelOfOutputRequiringLine.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LabelOfOutputRequiringLine.Location = new System.Drawing.Point(13, 48);
            this.LabelOfOutputRequiringLine.Name = "LabelOfOutputRequiringLine";
            this.LabelOfOutputRequiringLine.Size = new System.Drawing.Size(819, 25);
            this.LabelOfOutputRequiringLine.TabIndex = 1;
            this.LabelOfOutputRequiringLine.Text = "zdarova mir kak tvoi DELAA OO";
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
            "Own text"});
            this.ModesComboBox.Location = new System.Drawing.Point(17, 242);
            this.ModesComboBox.Name = "ModesComboBox";
            this.ModesComboBox.Size = new System.Drawing.Size(815, 29);
            this.ModesComboBox.TabIndex = 2;
            this.ModesComboBox.SelectedIndexChanged += new System.EventHandler(this.ModesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mode";
            // 
            // KeyboardTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(846, 426);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
    }
}

