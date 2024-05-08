using Microsoft.VisualBasic;
using System;
using System.Text;
using CharactersGenerator;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    public class LineBuilder
    {
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

        private int CounterForThreeWordsMode { get; set; }

        internal LineBuilder(DataBase dataBase, Text text, int MaxLengthOfLine)
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
            switch (Mode)
            {
                case Modes.Text:
                    text.UploadNewText();
                    break;
                case Modes.OwnText:
                    HandleOwnTextOnce();
                    break;
                case Modes.Song:
                    text.UploadNewSong();
                    break;
            }
        }

        private void HandleOwnTextOnce()
        {
            string ownText = RequestText();
            text.UploadNewText(ownText);
        }

        private string RequestText()
        {
            return Interaction.InputBox("Insert your own text.");
        }

        public void ChangeLanguage(Languages Language)
        {
            this.Language = Language;
            text.Language = Language;
        }

        public string GetNextLine()
        {
            line.Clear();
            switch(Mode)
            {
                case Modes.RepetitiveWord:
                    BuildRepetitiveWord();
                    break;

                case Modes.SetOfWords:
                    BuildSetOfWords();
                    break;

                case Modes.Text:
                    TextMode();
                    break;

                case Modes.Digits:
                    BuildDigits();
                    break;

                case Modes.OwnText:
                    OwnTextMode();
                    break;

                case Modes.Characters:
                    BuildCharacters();
                    break;

                case Modes.Song:
                    BuildSong();
                    break;
                default:
                    throw new Exception("Mode wasn't handled");
            }
            return BuiltLine;
        }

        private void BuildRepetitiveWord()
        {
            string word = dataBase.GetRandomWord(Language) + " ";
            int wordsAmount = MaxLengthOfLine / word.Length;
            for(int i = 0; i < wordsAmount; i++)
            {
                line.Append(word);
            }
            BuiltLine = line.ToString();
        }

        private void BuildSetOfWords()
        {
            string word;
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

            BuiltLine = line.ToString();
        }

        private void RefreshCondition()
        {
            RefreshCounter();
            RefreshWord();
        }

        private void RefreshCounter()
        {
            CounterForThreeWordsMode = 1;
        }

        private void RefreshWord()
        {
            string word = dataBase.GetRandomWord(Language) + " ";
            BuiltLine = word;
        }

        private void TextMode()
        {
            BuiltLine = text.GetNextLine();
        }

        private void BuildDigits()
        {
            string number;
            int MaxNumber;
            int CurrentMaxLengthOfNumber;
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
            TextMode();
        }

        private void BuildCharacters()
        {                                                         // -1 was added for space at the end
            string characters = Generator.GenerateCharactersWithSpace(MaxLengthOfLine - 1);
            characters = GuaranteeSpaceAtTheEnd(characters);
            BuiltLine = characters;
        }

        private void BuildSong()
        {
            BuiltLine = text.GetNextLine().Replace('\n', ' ');
        }

        private string GuaranteeSpaceAtTheEnd(string @string)
        {
            if (@string[@string.Length - 1] == ' ')
            {
                return @string;
            }
            else
            {
                return @string + ' ';
            }
        }
    }
}