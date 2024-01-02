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

        private DataBase dataBase { get; set; }

        private string BuiltLine {get; set;}

        private readonly int MaxLengthOfLine;

        private Text text { get; set; }

        public LineBuilder(DataBase dataBase, Text text, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.text = text;
            this.MaxLengthOfLine = MaxLengthOfLine;
        }

        public void ChangeMode(Modes Mode)
        {
            this.Mode = Mode;
        }

        public void ChangeLanguage(Languages Language)
        {
            this.Language = Language;
        }

        public string GetNextLine()
        {
            switch(Mode)
            {
                case Modes.RepetitiveWord:
                    BuildRepetitiveWord();
                    break;
#warning need in rework
                case Modes.SetOfWords:
                    BuildSetOfWords();
                    break;
                case Modes.OneWordThreeTimes:
                    OneWordThreeTimesMode();
                    break;
                case Modes.Text:
                    TextMode();
                    break;
                case Modes.OwnText:
                    OwnTextMode();
                    break;
                case Modes.Digits:
                    DigitsMode();
                    break;
            }
            return BuiltLine;
        }

        private void BuildRepetitiveWord()
        {
            string word = dataBase.GetRandomWord(Language) + " ";
            int wordsAmount = MaxLengthOfLine / word.Length;
            StringBuilder line = new StringBuilder(word, MaxLengthOfLine);
            for(int i = 1; i < wordsAmount; i++)
            {
                line.Append(word);
            }
            BuiltLine = line.ToString();
        }

        private void BuildSetOfWords()
        {
            throw new NotImplementedException();
        }

        private void OneWordThreeTimesMode()
        {
            throw new NotImplementedException();
        }

        private void TextMode()
        {
            throw new NotImplementedException();
        }

        private void OwnTextMode()
        {
            throw new NotImplementedException();
        }

        private void DigitsMode()
        {
            throw new NotImplementedException();
        }
    }
}