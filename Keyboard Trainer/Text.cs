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

        private string FullText { get; set; }

        private readonly DataBase dataBase;

        private readonly int MaxLengthOfLine;

        private IEnumerable<string> Lines
        {
            get
            {
                while (true)
                {
                    BuildLine();
                    yield return "some";
                }
            }
        }

        public Text(DataBase dataBase, int MaxLengthOfLine)
        {
            this.dataBase = dataBase;
            this.MaxLengthOfLine = MaxLengthOfLine;
        }

        public string GetNextLine()
        {
            foreach(string line in Lines)
            {
                return line;
            }
            // unreachable code as i think
            throw new Exception("lines ended");
        }
    }
}
