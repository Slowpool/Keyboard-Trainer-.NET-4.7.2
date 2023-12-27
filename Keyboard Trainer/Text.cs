using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard_Trainer
{
    internal class Text
    {
        private IEnumerable<string> Lines
        {
            get
            {
                yield return "some";
            }
        }

        private string FullText { get; set; }

        private KeyboardDataBase dataBase { get; };

        private readonly int MaxLengthOfLine;

        public Text(KeyboardDataBase dataBase, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.MaxLengthOfLine = MaxLengthOfLine;
        }

        public string GetNextLine()
        {
            #warning stub
            foreach(string line in Lines)
            {
                return line;
            }
            throw new Exception("lines ended");
        }
    }
}
