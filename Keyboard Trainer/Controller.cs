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

        private Color FormBackColor { get; set; }

        public Controller(RequiredLine requiredLine, TypeLine typeLine, KeyboardTrainer mainForm, LineBuilder lineBuilder)
        {
            this.requiredLine = requiredLine;
            this.typeLine = typeLine;
            this.mainForm = mainForm;
            this.lineBuilder = lineBuilder;
#warning delete it in further
            requiredLine.SetNextRequiredLine("hehe");
        }

        public bool IsCorrectCharacter(char character)
        {
            return character == requiredLine.ExpectedCharacter;
        }

        public void SetMistakeState()
        {
            mainForm.BackColor = mainForm.MistakeBackColor;
        }

        public void SetUsualState()
        {
            mainForm.BackColor = mainForm.UsualBackColor;
        }

        public void NextCharacter()
        {
            requiredLine.NextCharacter();
        }

        public void PrevCharacter()
        {
            requiredLine.PrevCharacter();
        }

        public void DisplayNextLine()
        {
            #warning rework
            string nextLine = lineBuilder.GetNextLine();
            requiredLine.SetNextRequiredLine(nextLine);
        }

        public void ChangeMode(Modes Mode)
        {
            lineBuilder.ChangeMode(Mode);
        }

        public void ClearTypeLine()
        {
            typeLine.Clear();
        }

        public void HandleCharacter(char character)
        {
            // BackSpace.
            if (character == 8)
            {
                PrevCharacter();
            }
            // Ctrl + Backspace
            else if (character == 127)
            {

            }

            // Other characters.
            else if (IsCorrectCharacter(character))
            {
#warning need in rework
                NextCharacter();
                SetUsualState();
            }
            else
            {
                SetMistakeState();
            }
        }

        public void ChangeLanguage(Languages Language)
        {
            lineBuilder.ChangeLanguage(Language);
        }
    }
}