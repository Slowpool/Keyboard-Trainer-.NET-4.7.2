using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class DataParser
    {
        private readonly DataBase dataBase;
        private readonly StringBuilder stringBuilder;

        internal TypesOfParsingData TypeOfParsingData;
        private readonly FolderBrowserDialog folderBrowserDialog;
        private readonly OpenFileDialog openFileDialog;


#warning hardcoding
        private readonly int MAX_WORD_LENGTH = 10; 

        internal DataParser(DataBase dataBase)
        {
            this.dataBase = dataBase;

            stringBuilder = new StringBuilder();

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files(.txt)|*.txt";

            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Choose directory which has *.txt files with songs/texts.";
        }

        //internal void UploadTo(string typeOfData, string langauge, string filePath)
        //{
        //    using (var wordsReader = new StreamReader("C:/MySqlSource/russian_words.txt", Encoding.GetEncoding(1251)))
        //    {
        //        string word;
        //        string[] buffer = new string[256];
        //        do
        //        {
        //            wordsReader.FillWithCorrectWordsTo(buffer);

        //            InsertIntoTable(buffer);
        //            //try
        //            //{
        //            //}
        //            //catch
        //            //{
        //            //    Console.WriteLine("insert error");
        //            //}
        //        }
        //        while (true);
        //    }
        //}

        //public bool InsertIntoTable(string[] words)
        //{
        //    stringBuilder.Clear();
        //    stringBuilder.Append(insertPattern);

        //    for (int i = 0; i < words.Length - 1; i++)
        //    {
        //        string currentInstruction = string.Format(insertedValuePattern, words[i]);
        //        stringBuilder.Append(currentInstruction);
        //    }
        //    stringBuilder.Append(string.Format(finishedValuePattern, words[words.Length - 1]));
        //    var insert = new MySqlCommand(stringBuilder.ToString(), connection);
        //    var rows = insert.ExecuteNonQuery();
        //    return rows == 1;
        //}

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

        internal void Act(string action, string typeOfData, string language)
        {
            switch (action)
            {
                case "Delete":
                    DialogResult answer = MessageBox.Show(caption: "Deletion confirmation",
                                        text: string.Format("Are you sure you want to delete all {0} on {1} language?", typeOfData + "s", language),
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

                    }
                    catch
                    { }
                    break;

                case "Re-upload":

                    break;
            }
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