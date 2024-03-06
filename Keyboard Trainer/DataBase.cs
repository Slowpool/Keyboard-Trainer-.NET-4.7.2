using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class DataBase
    {
        private readonly MySqlConnection connection;
        private readonly Random rnd;
        private readonly Dictionary<Languages, int> WordsAmount;
        private readonly Dictionary<Languages, int> TextsAmount;
        private readonly Dictionary<string, Dictionary<Languages, int>> KindsOfData;
        private MySqlCommand Command;

        private const string CountRowsCommandPattern = "SELECT COUNT(*) FROM {0}_{1};";
        private const string RandomRowCommandPattern = "SELECT {0} FROM {1}_{0} WHERE id = {2};";

        private const string insertIntoPattern = "INSERT INTO {0} VALUES ";
        private const string insertedValuePattern = "(NULL, '{0}')";

        private const string deleteFromPattern = "DELETE FROM {0}_{1};";

        internal DataBase(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
            rnd = new Random();
            WordsAmount = new Dictionary<Languages, int>();
            TextsAmount = new Dictionary<Languages, int>();
            KindsOfData = new Dictionary<string, Dictionary<Languages, int>>
            {
                { "word", WordsAmount },
                { "text", TextsAmount },
            };
            FillLanguages();
            CountWordsAndTexts();
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

        internal string GetRandomWord(Languages language)
        {
            return GetRandomRow("word", language);
        }

        internal string GetRandomText(Languages language)
        {
            return GetRandomRow("text", language);
        }

        internal string GetRandomSong(Languages language)
        {
            return GetRandomRow("song", language);
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
                MessageBox.Show(caption: "The command wasn't executed",
                                text: "Failed to extracting random word from db",
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return row;
        }

        internal void Delete(TypesOfData typeOfData, Languages language)
        {
//#error there's error somewhere here
            string command = string.Format(deleteFromPattern, language.NewToString(), typeOfData.NewToString());
            TryExecuteAndDisplayInCaseOfError(command, "Deleting error");
        }

        private void TryExecuteAndDisplayInCaseOfError(string command, string error)
        {
            Command = new MySqlCommand(command, connection);
            try
            {
                connection.Open();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(caption: "The command wasn't executed",
                                text: error + "\r\nIn details: " + e.Message,
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        internal void InsertRow(string text, string table_name)
        {
            string command = string.Format(insertIntoPattern, table_name);
            command += string.Format(insertedValuePattern, text) + ";";
            TryExecuteAndDisplayInCaseOfError(command, "inserting error");
        }

        private void RefreshAutoIncrement(string table_name)
        {
            string command = $"ALTER TABLE {table_name} AUTO_INCREMENT = 0;";
            TryExecuteAndDisplayInCaseOfError(command, "AUTO_INCREMENT property setting error");
        }

    }
}