using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class OneWordThreeTimes
    {
        internal bool WordWrittenThreeTimes { get; set; }

        private int wordsRemains;
        private int WordsRemains
        {
            get => wordsRemains;
            set
            {
                wordsRemains = value;
                if (WordsRemains == 0)
                {
                    WordWrittenThreeTimes = true;
                }
                else
                {
                    WordWrittenThreeTimes = false;
                    WordsLabel.Text = string.Empty;
                    for (int i = 0; i < WordsRemains; i++)
                    {
                        WordsLabel.Text += Word + '\n';
                    }
                }
            }
        }

        private Label WordsLabel;
        private string Word;
        internal OneWordThreeTimes(Label wordsLabel)
        {
            WordsLabel = wordsLabel;
        }

        internal void Create(string word)
        {
            this.Word = word;
            StartOver();
        }

        internal void StartOver()
        {
            WordsRemains = 3;
        }

        internal void WordSuccessfulyEntered()
        {
            WordsRemains--;
        }


    }
}
