using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    #warning this class must have ctrl+backspace method and some classes must have similar.

    internal class RequiredLine : Line
    {
        private readonly Label DisplayLabel;
        // GODLIKE PROPERTY DEMONSTRATION
        public string RequiredString
        {
            get => DisplayLabel.Text;
            set
            {
                DisplayLabel.Text = value;
            }
        }

        private int LengthOfString => RequiredString.Length;

        private int currentPosition = 0;

        private int CurrentPosition
        {
            get => currentPosition;
            set
            {
                if (value < 0)
                {
                    return;
                }
                else if (value == LengthOfString)
                {
                    return;
                }
                else
                {
                    currentPosition = value;
                }
            }
        }

        public char ExpectedCharacter
        {
            get => RequiredString[CurrentPosition];
        }

        public RequiredLine(Label DisplayLabel, int MaxLength) : base(MaxLength)
        {
            this.DisplayLabel = DisplayLabel;
        }

        public void NextCharacter()
        {
            CurrentPosition++;
        }

        public void PrevCharacter()
        {
            CurrentPosition--;
        }

        public void SetNextRequiredLine(string RequiredString)
        {
            this.RequiredString = RequiredString;
        }
    }
}