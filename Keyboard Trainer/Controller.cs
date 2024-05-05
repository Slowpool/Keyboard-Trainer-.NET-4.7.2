using System;
using System.Drawing;

namespace Keyboard_Trainer
{
    internal class Controller
    {
        private readonly TypeLine typeLine;

        private readonly RequiredLine requiredLine;

        private readonly LineBuilder lineBuilder;

        private readonly Walkthrough walkthrough;

        public readonly Color UsualColor = Color.White;
        public readonly Color MistakeColor = Color.Yellow;

        private bool hardcoreMode;
        public bool HardcoreMode
        {
            get => hardcoreMode;
            set
            {
                if (value == true)
                {
                    if (MistakeState)
                    {
                        typeLine.Clear();
                    }
                }
                hardcoreMode = value;
            }
        }

        public bool MistakeState => requiredLine.ForeColor == MistakeColor;

        internal int TargetLinesNumberForWalkthrough
        {
            set
            {
                walkthrough.TargetNumberOfLines = value;
            }
        }

        public Controller(RequiredLine requiredLine, TypeLine typeLine, LineBuilder lineBuilder, Walkthrough walkthrough)
        {
            this.requiredLine = requiredLine;
            this.typeLine = typeLine;
            this.lineBuilder = lineBuilder;
            this.walkthrough = walkthrough;
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
            typeLine.Clear();
            DisplayNextLine();
        }

        public void DisplayNextLine()
        {
            string nextLine = lineBuilder.GetNextLine();
            requiredLine.SetNextRequiredLine(nextLine);
        }

        public void HandleEditedTypingLine()
        {
            if (IsCorrectSubstring(typeLine.TypingString))
            {
                HandleCorrectString(typeLine.TypingString);
            }
            else
            {
                SetMistakeState();
            }
        }

        private bool IsCorrectSubstring(string substring)
        {
            return requiredLine.IsCorrectSubstring(substring);
        }

        private void HandleCorrectString(string @string)
        {
            SetUsualState();
            if (IsCompletedLine(@string))
            {
# warning i didn't finish it
                if (walkthrough.Enabled)
                {
                    walkthrough.PlusLine();
                }
                RefreshLines();
            }
        }

        private void SetUsualState()
        {
            requiredLine.ForeColor = UsualColor;
        }

        private bool IsCompletedLine(string line)
        {
            return requiredLine.IsFinalLine(line);
        }

        public void SetMistakeState()
        {
            if (HardcoreMode)
            {
                typeLine.Clear();
            }
            else
            {
                requiredLine.ForeColor = MistakeColor;
            }
        }

        internal void StopWalkthrough()
        {
            walkthrough.Enabled = false;
        }

        internal void NewWalkthrough(int targetNumberOfLines)
        {
            walkthrough.Create(targetNumberOfLines);
        }
    }
}