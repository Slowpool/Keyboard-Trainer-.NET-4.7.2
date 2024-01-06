using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class TypeLine
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

        public TypeLine(TextBox TypingTextBox)
        {
            this.TypingTextBox = TypingTextBox;
        }

        public void Clear()
        {
            TypingString = string.Empty;
        }
    }
}