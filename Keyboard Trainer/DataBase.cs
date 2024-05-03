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
#warning hardcoding
        private readonly Dictionary<Languages, int> WordsAmount;
        private readonly Dictionary<Languages, int> TextsAmount;
        private readonly Dictionary<Languages, int> SongsAmount;
        private readonly Dictionary<string, Dictionary<Languages, int>> KindsOfData;

        private MySqlCommand Command;

        private const string CountRowsCommandPattern = "SELECT COUNT(*) FROM {0}_{1};";
        private const string RandomRowCommandPattern = "SELECT {0} FROM {1}_{0} WHERE id = {2};";

        private const string insertIntoPattern = "INSERT INTO {0} VALUES ";
        private const string insertedValuePattern = "(NULL, '{0}')";

        private const string deleteFromPattern = "DELETE FROM {0};";

        internal DataBase(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
            rnd = new Random();
#warning hardcoding
            WordsAmount = new Dictionary<Languages, int>();
            TextsAmount = new Dictionary<Languages, int>();
            SongsAmount = new Dictionary<Languages, int>();
            KindsOfData = new Dictionary<string, Dictionary<Languages, int>>
            {
                #warning hardcoding
                { "word", WordsAmount },
                { "text", TextsAmount },
                { "song", SongsAmount },
            };
            FillLanguages();
            CountRowsForAll();
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

        private void CountRowsForAll()
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
                ErrorsDisplayer.ShowError(caption: "Failed to count rows amount in db",
                                         text: "The command wasn't executed");
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
                ErrorsDisplayer.ShowError(caption: "The command wasn't executed",
                                text: "Failed to extracting random word from db");
            }
            finally
            {
                connection.Close();
            }
            return row;
        }

        internal void Delete(string table_name)
        {
//#error there's error somewhere here
            string command = string.Format(deleteFromPattern, table_name);
            TryExecuteAndDisplayInCaseOfError(command, "Deleting error");
            ResetAutoIncrement(table_name);
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
                ErrorsDisplayer.ShowError(caption: "The command wasn't executed",
                                text: error + "\r\nIn details: " + e.Message);
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

        internal void InsertRows(string[] buffer, string table_name)
        {
            //string command = string.Format(insertIntoPattern, );
        }

        private void ResetAutoIncrement(string table_name)
        {
            string command = $"ALTER TABLE {table_name} AUTO_INCREMENT = 0;";
            TryExecuteAndDisplayInCaseOfError(command, "AUTO_INCREMENT property setting error");
        }
    }
}