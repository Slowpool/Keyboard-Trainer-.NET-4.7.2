using System.Drawing;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class RequiredLine
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
        
        #warning one word three times
        public int WordsRemained { get; set; }

        public Color ForeColor
        {
            get => DisplayLabel.ForeColor;
            set
            {
                DisplayLabel.ForeColor = value;
            }
        }


        public RequiredLine(Label DisplayLabel)
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