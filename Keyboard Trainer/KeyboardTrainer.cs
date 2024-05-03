using System;
using System.Drawing;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal partial class KeyboardTrainer : Form
    {
        private Controller controller;
        private DataBase dataBase;
        private FullScreen fullScreen;
        private AdminMenu adminMenu;

        private const int MAX_LINE_LENGTH = 80;


        private Modes mode;
        internal Modes Mode
        {
            get => mode;
            set
            {
                controller.ChangeMode(value);
                mode = value;
            }
        }

        internal Languages Language
        {
            set
            {
                controller.ChangeLanguage(value);
            }
        }

        private bool DisplayLanguages
        {
            set
            {
                LanguageComboBox.Visible = value;
                LanguageLabel.Visible = value;
            }
        }

        internal KeyboardTrainer()
        {
            InitializeComponent();
            LabelOfOutputRequiringLine.UseMnemonic = false;
            InitializeObjects();
            InitializeMode();
            InitializeLanguage();
            ToCenterTheComponents();
        }

        private void InitializeObjects()
        {
            fullScreen = new FullScreen(this);
            InitializeDataBase();
            adminMenu = new AdminMenu(dataBase);
            InitializeControllerAndHisComponents();
        }

        private void InitializeDataBase()
        {
            string connectionString =
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=password;" +
                "database=keyboardtrainer;";

            dataBase = new DataBase(connectionString);
        }

        private void InitializeControllerAndHisComponents()
        {
            var requiredLine = new RequiredLine(LabelOfOutputRequiringLine);
            var typeLine = new TypeLine(TextBoxForTyping);
            var text = new Text(dataBase, MAX_LINE_LENGTH);
            var lineBuilder = new LineBuilder(dataBase, text, MAX_LINE_LENGTH);
            var walkthrough = new Walkthrough(ModeComboBox);
            controller = new Controller(requiredLine, typeLine, lineBuilder, walkthrough);
        }

        private void InitializeMode()
        {
            ModeComboBox.SelectedIndex = 0;
            checkBoxHardcoreMode.Checked = false;
        }

        private void InitializeLanguage()
        {
            LanguageComboBox.SelectedIndex = 0;
        }

        private void ToCenterTheComponents()
        {
            PanelWithAllComponents.Location = new Point(
                (ClientSize.Width - PanelWithAllComponents.Width) / 2,
                (ClientSize.Height - PanelWithAllComponents.Height) / 2);
        }

        private void TextBoxForTyping_TextChanged(object sender, EventArgs e)
        {
            controller.HandleEditedTypingLine();
        }

        private void ModesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = (Modes)ModeComboBox.SelectedIndex;
            if(ShouldHideLanguages(Mode))
            {
                DisplayLanguages = false;
            }
            else
            {
                DisplayLanguages = true;
            }
            TextBoxForTyping.Focus();
        }

        private bool ShouldHideLanguages(Modes Mode)
        {
            if (Mode == Modes.OwnText)
            {
                return true;
            }

            if (Mode == Modes.Digits)
            {
                return true;
            }

            if (Mode == Modes.Characters)
            {
                return true;
            }

            return false;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language = (Languages)LanguageComboBox.SelectedIndex;
            TextBoxForTyping.Focus();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Mode = Mode;
            TextBoxForTyping.Focus();
        }

        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            if (fullScreen.IsFullScreenNow)
            {
                fullScreen.Disable();
            }
            else
            {
                fullScreen.Enable();
            }
            ToCenterTheComponents();
            TextBoxForTyping.Focus();
        }

        private void checkBoxHardcoreMode_CheckedChanged(object sender, EventArgs e)
        {
            controller.HardcoreMode = checkBoxHardcoreMode.Checked;
            TextBoxForTyping.Focus();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            adminMenu.Show();
        }

        private void checkBoxWalkthrough_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownWalkthroughCounter.Enabled = checkBoxWalkthrough.Enabled;
            controller.ChangeWalkthroughTo(checkBoxWalkthrough.Enabled);
        }
    }
}