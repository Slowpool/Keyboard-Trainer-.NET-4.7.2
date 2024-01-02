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

        public string TypingString
        {
            get => TypingTextBox.Text;
            set
            {
                TypingTextBox.Text = value;
            }
        }

        public int CharactersAmount { get; private set; }

        public TypingStates TypingState { get; private set; }
        
        public TypeLine(TextBox TypingTextBox, int MaxLength) : base(MaxLength)
        {
            this.TypingTextBox = TypingTextBox;
            CharactersAmount = 0;

            #warning i think that this property useless (MaxLength)
            //SetMaxLengthForTextBox();
        }

        //private void SetMaxLengthForTextBox()
        //{
        //    TypingTextBox.MaxLength = MaxLength; 
        //}

        public void Clear()
        {
            TypingString = string.Empty;
        }
    }
}