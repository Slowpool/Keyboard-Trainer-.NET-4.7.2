using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Keyboard_Trainer
{
    internal class Controller
    {
        private TypeLine typeLine { get; set; }
        private RequiredLine requiredLine { get; set; }
        private KeyboardTrainer mainForm { get; set; }
        private Text text { get; set; }
        private Color FormBackColor { get; set; }
        public Controller(RequiredLine requiredLine, TypeLine typeLine, KeyboardTrainer mainForm, Text text)
        {
            this.requiredLine = requiredLine;
            this.typeLine = typeLine;
            this.mainForm = mainForm;
            this.text = text;
#warning delete it in further
            requiredLine.SetReuiredString("hehe");
        }

        public bool IsCorrectCharacter(char character)
        {
            return character == requiredLine.ExpectedCharacter;
        }

        public void SetMistakeState()
        {
            mainForm.BackColor = mainForm.MistakeBackColor;
        }

        public void SetUsualState()
        {
            mainForm.BackColor = mainForm.UsualBackColor;
        }

        public void NextCharacter()
        {
            requiredLine.NextCharacter();
        }

        public void PrevCharacter()
        {
            requiredLine.PrevCharacter();
        }

        public void DisplayNextLine()
        {
#warning rework
            string nextLine = text.GetNextLine();
            requiredLine.SetReuiredString(nextLine);
        }

        public void ChangeMode(Modes Mode)
        {
            switch(Mode)
            {
                case Modes.RepetitiveWord:
                    RepetitiveWordMode();
                    return;
                case Modes.SetOfWords:
                    SetOfWordsMode();
                    return;
                case Modes.OneWordThreeTimes:
                    OneWordThreeTimesMode();
                    return;
                case Modes.Text:
                    TextMode();
                    return;
                case Modes.OwnText:
                    OwnTextMode();
                    return;
                case Modes.Digits:
                    DigitsMode();
                    return;
            }
        }

        private void RepetitiveWordMode()
        {
#warning stub
            DisplayNextLine();
        }

        private void SetOfWordsMode()
        {
#warning stub
            DisplayNextLine();
        }

        private void OneWordThreeTimesMode()
        {
            throw new NotImplementedException();
        }

        private void TextMode()
        {
            throw new NotImplementedException();
        }

        private void OwnTextMode()
        {
            throw new NotImplementedException();
        }

        private void DigitsMode()
        {
            throw new NotImplementedException();
        }

        public void ClearTypeLine()
        {
            typeLine.Clear();
        }

        public void HandleCharacter(char character)
        {
            // BackSpace.
            if (character == 8)
            {
                PrevCharacter();
            }
            // Ctrl + Backspace
            else if (character == 127)
            {
                EraseTheLastWord();
            }

            // Other characters.
            else if (IsCorrectCharacter(character))
            {
#warning need in rework
                NextCharacter();
                SetUsualState();
            }
            else
            {
                SetMistakeState();
            }
        }

        private void EraseTheLastWord()
        {
#warning not fully implemented
            typeLine.EraseTheLastWord();
            //requiredLine.MoveToLastSpace();
        }
    }
}