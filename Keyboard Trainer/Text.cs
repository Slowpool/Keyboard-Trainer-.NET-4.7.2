using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard_Trainer
{
    public class Text
    {
        private readonly StringBuilder FullText;
        private bool TextIsEmpty => FullText.Length == 0;
        private bool TextIsEnoughShort => FullText.Length <= MaxLengthOfLine;

        private readonly DataBase dataBase;

        private readonly int MaxLengthOfLine;

        public Text(DataBase dataBase, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.MaxLengthOfLine = MaxLengthOfLine;

            FullText = new StringBuilder();
        }

        public Languages Language { get; set; }

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

            int LengthOfLine = GetIndexOfLastAcceptableSpace() + 1;
            line = FullText.ToString().Substring(0, LengthOfLine);
            RemoveLineFromFullText();
        }

        public void UploadNewText()
        {
            string newText = dataBase.GetRandomText(Language) + ' ';
            FullText.Clear();
            FullText.Append(newText);
        }

        public void UploadNewText(string ownText)
        {
            FullText.Clear();
            FullText.Append(ownText + ' ');
        }

        private int GetIndexOfLastAcceptableSpace()
        {
            string lineOfMaxLength = FullText.ToString().Substring(0, MaxLengthOfLine);
            return lineOfMaxLength.LastIndexOf(' ');
        }

        private void RemoveLineFromFullText()
        {
            FullText.Remove(0, line.Length);
        }

        public string GetNextLine()
        {
            // this cycle should be endless
            foreach(string line in Lines)
            {
                return line;
            }
            // unreachable code as i think
            throw new Exception("lines ended");
        }
    }
}