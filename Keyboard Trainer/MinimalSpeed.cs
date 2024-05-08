using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class MinimalSpeed
    {
        private readonly TextBox TextBoxForTyping;
        private readonly Timer timer;

        private const double CHARACTERS_IN_WORD = 5.2;
        private const int MILLISECONDS_IN_MINUTE = 60000;

        internal MinimalSpeed(TextBox textBoxForTyping)
        {
            this.TextBoxForTyping = textBoxForTyping;
            timer = new Timer();
            timer.Tick += (sender, args) =>
            {
                TextBoxForTyping.Clear();
                timer.Stop();
            };
        }

        internal void SetSpeed(int MinimalWordsPerMin)
        {
            timer.Interval = (int)(MILLISECONDS_IN_MINUTE / (MinimalWordsPerMin * CHARACTERS_IN_WORD - 1));
        }

        internal void HandleCharacter(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
