using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard_Trainer
{
    public class LineBuilder
    {
#warning should i initialize these properties or not?
        private Modes Mode { get; set; }
        private Languages Language { get; set; }

        private string BuiltLine {get; set;}

        private readonly int MaxLengthOfLine;

        private readonly DataBase dataBase;

        private readonly Text text;

        private readonly StringBuilder line;

        // TODO i should encapsulate each of these properties in one class e.g. digits builder
        private Random rnd;
        private const int MAX_LENGTH_OF_NUMBER_IN_DIGITS_MODE = 6;

        public LineBuilder(DataBase dataBase, Text text, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.text = text;
            this.MaxLengthOfLine = MaxLengthOfLine;
            line = new StringBuilder(MaxLengthOfLine);
            rnd = new Random();
        }

        public void ChangeMode(Modes Mode)
        {
            this.Mode = Mode;
            if (Mode == Modes.Text)
            {
                text.UploadNewText();
            }
        }

        public void ChangeLanguage(Languages Language)
        {
            this.Language = Language;
            text.Language = Language;
        }

        public string GetNextLine()
        {
            switch(Mode)
            {
                case Modes.RepetitiveWord:
                    BuildRepetitiveWord();
                    break;
                case Modes.SetOfWords:
                    BuildSetOfWords();
                    break;
#warning need in rework
                case Modes.OneWordThreeTimes:
                    OneWordThreeTimesMode();
                    break;
#warning in processing
                case Modes.Text:
                    TextMode();
                    break;
                case Modes.Digits:
                    BuildDigits();
                    break;
#warning need in rework
                case Modes.OwnText:
                    OwnTextMode();
                    break;
            }
            return BuiltLine;
        }

        private void BuildRepetitiveWord()
        {
            string word = dataBase.GetRandomWord(Language) + " ";
            int wordsAmount = MaxLengthOfLine / word.Length;
            line.Clear();
            for(int i = 0; i < wordsAmount; i++)
            {
                line.Append(word);
            }
            BuiltLine = line.ToString();
        }

        private void BuildSetOfWords()
        {
            string word;
            line.Clear();
            while(true)
            {
                word = dataBase.GetRandomWord(Language) + " ";
                // TODO dude you can redo that later (remove .ToString + word in cond
                if ((line.ToString() + word).Length > MaxLengthOfLine)
                {
                    break;
                }
                else
                {
                    line.Append(word);
                }
            }
            BuiltLine = line.ToString();
        }

        private void OneWordThreeTimesMode()
        {
            throw new NotImplementedException();
        }

        private void TextMode()
        {
            line.Clear();
            BuiltLine = text.GetNextLine();
        }

        private void BuildDigits()
        {
            string number;
            int MaxNumber;
            int CurrentMaxLengthOfNumber;
            line.Clear();
            while (true)
            {
                CurrentMaxLengthOfNumber = rnd.Next(MAX_LENGTH_OF_NUMBER_IN_DIGITS_MODE) + 1;
                MaxNumber = (int)Math.Pow(10, CurrentMaxLengthOfNumber);
                number = rnd.Next(MaxNumber).ToString() + " ";
                if ((line.ToString() + number).Length > MaxLengthOfLine)
                {
                    break;
                }
                else
                {
                    line.Append(number);
                }
            }
            BuiltLine = line.ToString();
        }

        private void OwnTextMode()
        {
            throw new NotImplementedException();
        }
    }
}