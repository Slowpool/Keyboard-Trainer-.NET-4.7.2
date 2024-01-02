using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
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

        public Color ForeColor
        {
            get => DisplayLabel.ForeColor;
            set
            {
                DisplayLabel.ForeColor = value;
            }
        }

        private int LengthOfString => RequiredString.Length;

        private int currentPosition = 0;

        public RequiredLine(Label DisplayLabel, int MaxLength) : base(MaxLength)
        {
            this.DisplayLabel = DisplayLabel;
        }

        public void SetNextRequiredLine(string RequiredString)
        {
            this.RequiredString = RequiredString;
        }

        public bool IsCorrectSubstring(string substring)
        {
            return RequiredString.StartsWith(substring);
        }

        public bool IsFinalLine(string @string)
        {
            bool LengthsAreSame = @string.Length == RequiredString.Length;
            return LengthsAreSame;
        }
    }
}