using System.Drawing;

namespace Keyboard_Trainer
{
    internal class Controller
    {
        private readonly TypeLine typeLine;

        private readonly RequiredLine requiredLine;

        private readonly LineBuilder lineBuilder;

        public readonly Color UsualColor = Color.FromArgb(255, 255, 255); // white
        public readonly Color MistakeColor = Color.FromArgb(255, 255, 0); // yellow

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

        public Controller(RequiredLine requiredLine, TypeLine typeLine, LineBuilder lineBuilder)
        {
            this.requiredLine = requiredLine;
            this.typeLine = typeLine;
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

        private bool IsCorrectSubstring(string substring)
        {
            return requiredLine.IsCorrectSubstring(substring);
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

        private bool IsFinalLine(string line)
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
    }
}