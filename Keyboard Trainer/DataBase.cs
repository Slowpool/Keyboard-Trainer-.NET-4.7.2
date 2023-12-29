using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class DataBase
    {
        private MySqlConnection connection;
        private MySqlCommand Command;
        private Random rnd;
        
        private Dictionary<Languages, int> wordsAmount;
        private Dictionary<Languages, int> textsAmount;
        private Dictionary<string, Dictionary<Languages, int>> KindsOfData;

        const string CountRowsCommandPattern = "SELECT COUNT(*) FROM {0}_{1};";
        const string RandomRowCommandPattern = "SELECT {0} FROM {1}_{0} WHERE id = {2};";

        public DataBase(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
            InitializeObjects();
            CountWordsAndTexts();
        }

        private void InitializeObjects()
        {
            rnd = new Random();
            wordsAmount = new Dictionary<Languages, int>();
            textsAmount = new Dictionary<Languages, int>();
            KindsOfData = new Dictionary<string, Dictionary<Languages, int>>
            {
                { "word", wordsAmount },
                { "text", textsAmount },
            };
        }

        private void CountWordsAndTexts()
        {
            foreach (var languageAndKind in KindsOfData)
            {
                CountRows(languageAndKind.Key, languageAndKind.Value);
            }
        }

        private void CountRows(string kindOfData, Dictionary<Languages, int> dict)
        {
            foreach (var language in dict.Keys)
            {
                dict[language] = GetRowsAmount(kindOfData, language);
            }
        }

        private int GetRowsAmount(string kindOfData, Languages language)
        {
            string commandString = string.Format(CountRowsCommandPattern, language, kindOfData);
            Command = new MySqlCommand(commandString, connection);
            int rowsAmount = 0;
            try
            {
                rowsAmount = (int)Command.ExecuteScalar();
            }
            catch
            {
                MessageBox.Show("Failed to count rows amount in db", "The command wasn't executed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rowsAmount;
        }

        public string GetRandomWord(Languages language)
        {
            return GetRandomRow("word", language);
        }

        public string GetRandomText(Languages language)
        {
            return GetRandomRow("text", language);
        }

        private string GetRandomRow(string kindOfData, Languages language)
        {
            int rowsAmount = KindsOfData[kindOfData][language];
            int numberOfRandomWord = rnd.Next(rowsAmount) + 1;
            string commandString = string.Format(
                RandomRowCommandPattern,
                numberOfRandomWord,
                language,
                numberOfRandomWord);
            Command = new MySqlCommand(commandString, connection);

            string row = string.Empty;
            try
            {
                row = (string)Command.ExecuteScalar();
            }
            catch
            {
                MessageBox.Show("Failed to extracting random word from db", "The command wasn't executed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return row;
        }
    }
}