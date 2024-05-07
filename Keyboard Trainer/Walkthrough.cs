using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal class Walkthrough
    {
        private readonly ComboBox modeComboBox;
        private readonly CheckBox checkBox;
        private WalkthroughCases LastResult { get; set; }

        private bool enabled;
        internal bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                if (!enabled)
                {
                    Reset();
                }
            }
        }

        private int lineCounter;
        internal int LineCounter
        {
            get => lineCounter;
            set
            {
                lineCounter = value;
                if (lineCounter == TargetNumberOfLines)
                {
                    CurrentModeIndex++;
                    lineCounter = 0;
                }
                else
                {
                    LastResult = WalkthroughCases.NextLine;
                }
            }
        }

        private int currentModeIndex;
        private int CurrentModeIndex
        {
            get => currentModeIndex;
            set
            {
                currentModeIndex = value;
                if (ModesForWalkthrough.Count == currentModeIndex)
                {
                    LastResult = WalkthroughCases.End;
                    checkBox.Checked = false;
                }
                else
                {
                    LastResult = WalkthroughCases.NextMode;
                    modeComboBox.SelectedIndex = ModesForWalkthrough[CurrentModeIndex];
                }
            }
        }

        internal int TargetNumberOfLines { get; set; }
#warning hardcoding
        private readonly List<int> ModesForWalkthrough = new List<int> { 0, 1,  3, 4,  6, 7 };

        public Walkthrough(ComboBox modeComboBox, CheckBox checkBox)
        {
            this.modeComboBox = modeComboBox;
            this.checkBox = checkBox;
        }

        internal void Reset()
        {
            LineCounter = 0;
            CurrentModeIndex = 0;
        }

        internal void Create(int targetNumberOfLines)
        {
            Enabled = true;
            TargetNumberOfLines = targetNumberOfLines;
            Reset();
            modeComboBox.SelectedIndex = ModesForWalkthrough[CurrentModeIndex];
        }

        internal WalkthroughCases PlusLine()
        {
            LineCounter++;
            return LastResult;
        }
    }
}
