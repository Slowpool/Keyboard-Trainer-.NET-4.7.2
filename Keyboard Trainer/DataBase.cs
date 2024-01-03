using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    public class DataBase
    {
#warning all properties opened for tests
        public MySqlConnection connection;
        public MySqlCommand Command;
        public Random rnd;
        public Dictionary<Languages, int> WordsAmount;
        public Dictionary<Languages, int> TextsAmount;
        public Dictionary<string, Dictionary<Languages, int>> KindsOfData;

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
            WordsAmount = new Dictionary<Languages, int>();
            TextsAmount = new Dictionary<Languages, int>();
            KindsOfData = new Dictionary<string, Dictionary<Languages, int>>
            {
                { "word", WordsAmount },
                { "text", TextsAmount },
            };
            FillLanguages();
        }

        private void FillLanguages()
        {
            foreach(Languages language in Enum.GetValues(typeof(Languages)))
            {
                foreach(var kindOfData in KindsOfData.Values)
                {
                    kindOfData[language] = 0;
                }
            }
        }

        private void CountWordsAndTexts()
        {
            foreach (var languageAndKind in KindsOfData)
            {
                CountRows(languageAndKind.Key, languageAndKind.Value);
            }
        }

        private void CountRows(string kindOfData, Dictionary<Languages,int> dict)
        {
            foreach (var language in dict.Keys.ToList())
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
                connection.Open();
                rowsAmount = Convert.ToInt32(Command.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show("Failed to count rows amount in db", "The command wasn't executed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
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
                kindOfData,
                language,
                numberOfRandomWord);
            Command = new MySqlCommand(commandString, connection);

            string row = string.Empty;
            try
            {
                connection.Open();
                row = Convert.ToString(Command.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show("Failed to extracting random word from db", "The command wasn't executed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return row;
        }
    }
}