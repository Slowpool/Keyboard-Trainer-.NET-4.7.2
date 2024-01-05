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
        }

        public void Clear()
        {
            TypingString = string.Empty;
        }
    }
}