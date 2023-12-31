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
        public readonly Color UsualBackColor = SystemColors.WindowFrame;
        public readonly Color MistakeBackColor = Color.Red;
        private DataBase dataBase;
        private const int MaxLengthOfLine = 80;
        //private Modes mode;
        public Modes Mode
        { 
            //get => mode;
            set
            {
                //mode = value;
                controller.ClearTypeLine();
                controller.ChangeMode(value);
            }
        }

        #warning it needs a redo
        public Languages Language
        {
            set
            {
                controller.ClearTypeLine();
                controller.ChangeLanguage(value);
            }
        }

        public KeyboardTrainer()
        {
            InitializeComponent();
            InitializeObjects();
            InitializeMode();
            InitializeLanguage();
        }

        private void InitializeObjects()
        {
            InitializeDataBase();
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
            #warning do requiredLine really need in max length of line?
            var requiredLine = new RequiredLine(LabelOfOutputRequiringLine, MaxLengthOfLine);
            var typeLine = new TypeLine(TextBoxForTyping, MaxLengthOfLine);
            var text = new Text(dataBase, MaxLengthOfLine);
            var lineBuilder = new LineBuilder(dataBase, text, MaxLengthOfLine);
            controller = new Controller(requiredLine, typeLine, this, lineBuilder);
        }

        private void InitializeMode()
        {
            ModesComboBox.SelectedIndex = 0;
        }

        private void InitializeLanguage()
        {
            LanguageComboBox.SelectedIndex = 0;
        }

        private void TextBoxForTyping_KeyPress(object sender, KeyPressEventArgs e)
        {
            controller.HandleCharacter(e.KeyChar);
        }

        private void ModesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = (Modes)ModesComboBox.SelectedIndex;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language = (Languages)LanguageComboBox.SelectedIndex;
        }

#warning debug event
        private void DebugButton_Click(object sender, EventArgs e)
        {
            controller.DisplayNextLine();
        }
    }
}