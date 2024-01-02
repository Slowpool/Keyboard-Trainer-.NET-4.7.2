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

        public readonly Color UsualColor = Color.FromArgb(255, 255, 255); // white
        public readonly Color MistakeColor = Color.FromArgb(255, 255, 0); // yellow

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

        public void HandleEditedTypingLine()
        {
            string @string = typeLine.TypingString;
            if (IsCorrectSubstring(@string))
            {
                HandleCorrectString(@string);
            }
            else
            {
                SetMistakeState();
            }
        }

        private bool IsCorrectSubstring(string @string)
        {
            return requiredLine.IsCorrectSubstring(@string);
        }

        private void HandleCorrectString(string @string)
        {
            SetUsualState();
            if (IsFinalLine(@string))
            {
                RefreshLines();
            }
        }

        private void SetUsualState()
        {
            requiredLine.ForeColor = UsualColor;
        }

        private bool IsFinalLine(string @string)
        {
            return requiredLine.IsFinalLine(@string);
        }

        public void SetMistakeState()
        {
            requiredLine.ForeColor = MistakeColor;
        }
    }
}