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
        private readonly ComboBox ModeComboBox;

        private bool Enabled
        {
            set
            {
                if (value)
                {
                    LineCounter = 0;
                    ModeCounter = 0;

                }
            }
        }

        private int LineCounter { get; set; }
        private int ModeCounter { get; set; }

        internal int TargetNumberOfLines
#warning hardcoding
        private readonly List<int> ModesForWalkthrough = new List<int> { 0, 1,  3, 4,  6 };

        public Walkthrough(ComboBox ModeComboBox)
        {
            this.ModeComboBox = ModeComboBox;
            LineCounter = 0;
            ModeCounter = 0;
        }



    }
}
