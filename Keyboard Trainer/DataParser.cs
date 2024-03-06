using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IT_demon_Library;
using System.Text.RegularExpressions;

namespace Keyboard_Trainer
{
    internal class DataParser
    {
        private readonly DataBase dataBase;
        //private readonly StringBuilder stringBuilder;

        private TypesOfParsingData typeOfParsingData;
        internal TypesOfParsingData TypeOfParsingData
        {
            get => typeOfParsingData;
            set
            {
                typeOfParsingData = value;
                if (typeOfParsingData == TypesOfParsingData.File)
                {
                    fileOrFolderDialog = openFileDialog;
                }
                else
                {
                    fileOrFolderDialog = folderBrowserDialog;
                }
            }
        }
        private readonly FolderBrowserDialog folderBrowserDialog;
        private readonly OpenFileDialog openFileDialog;
        private dynamic fileOrFolderDialog;

#warning hardcoding
        private const int MAX_TEXT_LENGTH = 65535; 
        private const int MAX_WORD_LENGTH = 10; 

        internal DataParser(DataBase dataBase)
        {
            this.dataBase = dataBase;

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files(.txt)|*.txt";

            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Choose directory which has *.txt files with songs/texts.";
        }

        //internal static bool IsCorrectWord(string word)
        //{
        //    if (word is null)
        //    {
        //        return false;
        //    }

        //    if (word.Length == 0)
        //    {
        //        return false;
        //    }

        //    if (word.Length > MAX_WORD_LENGTH)
        //    {
        //        return false;
        //    }

        //    foreach (char character in word)
        //    {
        //        if (!char.IsLetter(character))
        //        {
        //            return false;
        //        }

        //        if (char.IsUpper(character))
        //        {
        //            return false;
        //        }

        //        if (character == 'ё')
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        internal void Act(string action, TypesOfData typeOfData, Languages language)
        {
            switch (action)
            {
                case "Delete":
                    DialogResult answer = MessageBox.Show(caption: "Deletion confirmation",
                                        text: string.Format("Are you sure you want to delete all {0} on {1} language?", typeOfData.NewToString() + "s", language.NewToString()),
                                        buttons: MessageBoxButtons.YesNo,
                                        icon: MessageBoxIcon.Warning);
                    if (answer == DialogResult.Yes)
                    {
                        dataBase.Delete(typeOfData, language);
                    }
                    break;

                case "Upload":
                    try
                    {
                        string pathOfFileOrDirectory = RequestThePath();
                        string table_name = language.NewToString() + "_" + typeOfData.NewToString();
                        if (TypeOfParsingData == TypesOfParsingData.File)
                        {
                            UploadTxtFile(pathOfFileOrDirectory, table_name);
                        }
                        else
                        {
                            UploadAllTxtFilesFromDirectory(pathOfFileOrDirectory, table_name);
                        }
                    }
                    catch
                    { }
                    break;

                case "Re-upload":

                    break;
            }
        }

        private void UploadAllTxtFilesFromDirectory(string directoryPath, string table_name)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            var texts = directory.GetFiles().Where(file => file.Extension == ".txt");

            StreamReader textReader;
            string text;
            foreach (FileInfo file in texts)
            {
                textReader = new StreamReader(file.FullName, Encoding.UTF8);
                text = textReader.ReadToEnd();

                TypesOfData type;
                if (table_name.EndsWith("text"))
                {
                    type = TypesOfData.Text;
                }
                else if (table_name.EndsWith("song"))
                {
                    type = TypesOfData.Song;
                }
                else
                {
                    throw new Exception("incorrect type of data");
                }

                text = PrepareText(text, type);

                if (IsCorrectTextLength(text))
                {
                    dataBase.InsertRow(text, table_name);
                }
                else
                {
                    MessageBox.Show("too long text");
                }
                textReader.Close();
            }
        }

        private static string PrepareText(string text, TypesOfData type)
        {
            text = RemoveRedundantCharacters(text, type);
            text = Quote(text);
            return text;
        }

        static bool IsCorrectTextLength(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (text.Length > MAX_TEXT_LENGTH)
            {
                return false;
            }

            return true;
        }

        static string RemoveRedundantCharacters(string text, TypesOfData type)
        {
            CharacterChecker charChecker;
            switch (type)
            {
                case TypesOfData.Text:
                    charChecker = IsUsualCharacter;
                    text = text.Replace("\r\n", " ");
                    break;

                case TypesOfData.Song:
                    charChecker = CharCheckerForSong;
                    text = text.Replace("\r\n", "\n");
                    text = RemoveKeywords(text);
                    text = ClearRepeatedChars(text, '\n');
                    break;

                default:
                    throw new Exception();
            }

            var stringBuilder = new StringBuilder(text.Length);
            foreach (var character in text)
            {
                if (charChecker(character))
                {
                    stringBuilder.Append(character);
                }
            }

            text = stringBuilder.ToString();
            text = ClearRepeatedChars(text, ' ');

            return text;
        }

        private static bool CharCheckerForSong(char character)
        {
            return IsUsualCharacter(character) || IsNextLineCharacter(character);
        }

        private static bool IsNextLineCharacter(char character) => character == 10;

        private static string RemoveKeywords(string text)
        {
            return Regex.Replace(text, @"\[.*?\]", "");
        }

        private static string ClearRepeatedChars(string text, char targetCharacter)
        {
            string targetSubstring = new string(targetCharacter, 2);
            while(text.IndexOf(targetSubstring) != -1)
            {
                text = text.Replace(targetSubstring, targetCharacter.ToString());
            }
            return text;
        }

        private static string Quote(string text)
        {
            return text.Replace("\'", "\'\'");
        }

        private static bool IsUsualCharacter(char character)
        {
            return SetsOfCharacters.WholeCharacters.IndexOf(character) != -1;
        }

        private void UploadTxtFile(string pathOfFileOrDirectory, string table_name)
        {
            throw new NotImplementedException();
        }

        private string RequestThePath()
        {
            if (fileOrFolderDialog.ShowDialog() == DialogResult.OK)
            {
                string path;
                try
                {
                    path = fileOrFolderDialog.FileName;
                }
                catch
                {
                    path = fileOrFolderDialog.SelectedPath;
                }
                return path;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}