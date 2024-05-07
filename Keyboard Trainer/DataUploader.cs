using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Keyboard_Trainer
{
    internal class DataUploader
    {
        private readonly DataBase dataBase;

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

        internal DataUploader(DataBase dataBase)
        {
            this.dataBase = dataBase;

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files(.txt)|*.txt";

            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Choose directory which has *.txt files with songs/texts.";
        }

        internal void Act(string action, TypesOfData typeOfData, Languages language)
        {
            string table_name = language.NewToString() + "_" + typeOfData.NewToString();
            switch (action)
            {
                case "Delete":
                    DialogResult answer = MessageBox.Show(caption: "Deletion confirmation",
                                        text: string.Format("Are you sure you want to delete all {0} on {1} language?", typeOfData.NewToString() + "s", language.NewToString()),
                                        buttons: MessageBoxButtons.YesNo,
                                        icon: MessageBoxIcon.Warning);
                    if (answer == DialogResult.Yes)
                    {
                        dataBase.Delete(table_name);
                    }
                    MessageBox.Show("Successfull removing");
                    break;

                case "Upload":
                    try
                    {
                        string pathOfFileOrDirectory = RequestThePath();
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

        private void UploadTxtFile(string pathOfFileOrDirectory, string table_name)
        {
            if (table_name.EndsWith("word"))
            {
                var wordsDeader = new StreamReader(pathOfFileOrDirectory);
                string[] buffer = new string[256];
                wordsDeader.FillBufferWithCorrectWords(buffer);
                do
                {
                    wordsDeader.FillBufferWithCorrectWords(buffer);
#warning does it work?
                    dataBase.InsertRows(buffer, table_name);
                    buffer.Clear();
                    
                }
                while (true);

                wordsDeader.Dispose();
            }
            else
            {
                throw new NotImplementedException();
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
//#error something wrong here
                    throw new Exception("incorrect type of data");
                }
                
                text = TextForPringHandler.PrepareText(text, type);

                if (TextForPringHandler.IsCorrectTextLength(text))
                {
                    dataBase.InsertRow(text, table_name);
                }
                else
                {
                    ErrorsDisplayer.ShowError(caption: "Incorrect text length",
                                            text: $"text in file {file.Name} was too long or empty");
                }
                textReader.Close();
            }
        }
    }
}