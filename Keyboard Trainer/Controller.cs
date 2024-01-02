using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Keyboard_Trainer
{
    internal class Controller
    {
        private readonly TypeLine typeLine;

        private readonly RequiredLine requiredLine;

        private readonly KeyboardTrainer mainForm;

        private readonly LineBuilder lineBuilder;

        private Color FormBackColor
        {
            get => mainForm.BackColor;
            set
            {
                mainForm.BackColor = value;
            }
        }

        public Controller(RequiredLine requiredLine, TypeLine typeLine, KeyboardTrainer mainForm, LineBuilder lineBuilder)
        {
            this.requiredLine = requiredLine;
            this.typeLine = typeLine;
            this.mainForm = mainForm;
            this.lineBuilder = lineBuilder;
        }

        public void ChangeMode(Modes Mode)
        {
            lineBuilder.ChangeMode(Mode);
            RefreshLines();
        }

        public void ChangeLanguage(Languages Language)
        {
            lineBuilder.ChangeLanguage(Language);
            RefreshLines();
        }

        private void RefreshLines()
        {
            ClearTypeLine();
            DisplayNextLine();
        }

        public void DisplayNextLine()
        {
            string nextLine = lineBuilder.GetNextLine();
            requiredLine.SetNextRequiredLine(nextLine);
        }

        public void ClearTypeLine()
        {
            typeLine.Clear();
        }

        public void HandleCharacter(char character)
        {
            string currentString = typeLine.TypingString + character;
            if (requiredLine.IsCorrectSubstring(currentString))
            {
                SetUsualState();
            }
            else
            {
                SetMistakeState();
            }
        }

        private void SetUsualState()
        {
            mainForm.BackColor = mainForm.UsualBackColor;
        }

        public void SetMistakeState()
        {
            mainForm.BackColor = mainForm.MistakeBackColor;
        }
    }
}