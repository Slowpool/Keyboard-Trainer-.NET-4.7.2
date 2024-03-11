using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keyboard_Trainer
{
    public class Text
    {
        private readonly StringBuilder FullText;
        private bool TextIsEmpty => FullText.Length == 0;
        private bool TextIsEnoughShort => FullText.Length <= MaxLengthOfLine;

        private readonly DataBase dataBase;

        private readonly int MaxLengthOfLine;

        internal Text(DataBase dataBase, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.MaxLengthOfLine = MaxLengthOfLine;

            FullText = new StringBuilder();
        }

        private Languages language;
        internal Languages Language
        {
            get => language;
            set
            {
                language = value;
                UploadNewText();
            }
        }

        private string line;

        private IEnumerable<string> Lines
        {
            get
            {
                while (true)
                {
                    CutNextLineFromFullText();
                    yield return line;
                }
            }
        }

        // I know that this method deceives, but it doesn't matter (it is checking the text for emptiness besides cut line and updates the text)
        private void CutNextLineFromFullText()
        {
            if (TextIsEmpty)
            {
                UploadNewText();
            }

            if (TextIsEnoughShort)
            {
                line = FullText.ToString();
                FullText.Clear();
                return;
            }

            int LengthOfLine = IndexOfNextLineElseLastAcceptableSpace() + 1;
            line = FullText.ToString().Substring(0, LengthOfLine);
            RemoveLineFromFullText();
        }

        internal void UploadNewText()
        {
            UploadNewText(dataBase.GetRandomText(Language));
        }

        internal void UploadNewSong()
        {
            UploadNewText(dataBase.GetRandomSong(Language));
        }

        internal void UploadNewText(string textForUploading)
        {
            FullText.Clear();
            FullText.Append(textForUploading + ' ');
        }

        private int IndexOfNextLineElseLastAcceptableSpace()
        {
            string lineOfMaxLength = FullText.ToString().Substring(0, MaxLengthOfLine);
            int indexOfNextLine = lineOfMaxLength.IndexOf('\n');
            if(indexOfNextLine == -1)
            {
                return lineOfMaxLength.LastIndexOf(' ');
            }
            else
            {
                return indexOfNextLine;
            }
        }

        private void RemoveLineFromFullText()
        {
            FullText.Remove(0, line.Length);
        }

        internal string GetNextLine()
        {
            // this cycle must be endless
            foreach(string line in Lines)
            {
                return line;
            }
            // this code must be unreachable
            throw new Exception("lines ended");
        }
    }
}