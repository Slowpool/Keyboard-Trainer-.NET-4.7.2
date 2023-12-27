using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class TypeLine : Line
    {
        private readonly TextBox TypingTextBox;

        private string TypingString
        {
            get => TypingTextBox.Text;
            set
            {
                TypingTextBox.Text = value;
            }
        }

        public States State { get; private set; }

        public TypeLine(TextBox TypingTextBox, int MaxLength) : base(MaxLength)
        {
            this.TypingTextBox = TypingTextBox;
            SetMaxLengthForTextBox();
        }

        private void SetMaxLengthForTextBox()
        {
            TypingTextBox.MaxLength = MaxLength; 
        }

        public void Clear()
        {
            TypingString = string.Empty;
        }
    }
}