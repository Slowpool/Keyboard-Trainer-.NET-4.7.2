using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    public partial class AdminMenu : Form
    {
        private readonly DataUploader dataUploader;
        
        internal AdminMenu(DataBase dataBase)
        {
            InitializeComponent();
            comboBoxTypeOfData.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            comboBoxAction.SelectedIndex = 0;
            dataUploader = new DataUploader(dataBase);
        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            string action = comboBoxAction.Text;
            TypesOfData typeOfData = comboBoxTypeOfData.Text.ToTypeOfData();
            Languages language = comboBoxLanguage.Text.ToLanguage();
            dataUploader.Act(action, typeOfData, language);
        }

        private void comboBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAction.Text)
            {
                case "Delete":
                    buttonExecute.Text = "Execute";
                    break;

                case "Upload":
                case "Re-Upload":
                    buttonExecute.Text = "Choose " + FileOrDirectory() + " and execute";
                    break;
            }
        }

        private string FileOrDirectory()
        {
            switch (comboBoxTypeOfData.Text)
            {
                case "words":
                    dataUploader.TypeOfParsingData = TypesOfParsingData.File;
                    return "file";

                case "texts":
                case "songs":
                    dataUploader.TypeOfParsingData = TypesOfParsingData.Directory;
                    return "directory";

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}