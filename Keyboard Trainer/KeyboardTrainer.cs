using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    public partial class KeyboardTrainer : Form
    {
        private Controller controller;
        
        private DataBase dataBase;
        private const int MaxLengthOfLine = 80;
        private FullScreen fullScreen;

        private Modes mode;
        public Modes Mode
        {
            get => mode;
            set
            {
                controller.ChangeMode(value);
                mode = value;
            }
        }

        public Languages Language
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

        public KeyboardTrainer()
        {
            InitializeComponent();
            DisableMnemonicForRequiringLine();
            InitializeObjects();
            InitializeMode();
            InitializeLanguage();
            ToCenter();
        }

        private void DisableMnemonicForRequiringLine()
        {
            LabelOfOutputRequiringLine.UseMnemonic = false;
        }

        private void InitializeObjects()
        {
            InitializeFullScreen();
            InitializeDataBase();
            InitializeControllerAndHisComponents();
        }

        private void InitializeFullScreen()
        {
            fullScreen = new FullScreen(this);
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
            #warning do requiredLine really need in max length of line?
            var requiredLine = new RequiredLine(LabelOfOutputRequiringLine, MaxLengthOfLine);
            var typeLine = new TypeLine(TextBoxForTyping, MaxLengthOfLine);
            var text = new Text(dataBase, MaxLengthOfLine);
            var lineBuilder = new LineBuilder(dataBase, text, MaxLengthOfLine);
            controller = new Controller(requiredLine, typeLine, this, lineBuilder);
        }

        private void InitializeMode()
        {
            ModeComboBox.SelectedIndex = 0;
        }

        private void InitializeLanguage()
        {
            LanguageComboBox.SelectedIndex = 0;
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
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Mode = Mode;
        }

        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            #warning finish it
            if (fullScreen.IsFullScreenNow)
            {
                fullScreen.Disable();
            }
            else
            {
                fullScreen.Enable();
            }
            ToCenter();
        }

        private void ToCenter()
        {
            PanelWithAllComponents.Location = new Point(
                (ClientSize.Width - PanelWithAllComponents.Width) / 2,
                (ClientSize.Height - PanelWithAllComponents.Height) / 2);
        }
    }
}