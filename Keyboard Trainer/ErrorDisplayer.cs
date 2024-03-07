using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Trainer
{
    internal static class ErrorDisplayer
    {
        internal static void ShowError(string caption, string text)
        {
            MessageBox.Show(caption: caption,
                                text: text,
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error);
        }
    }
}
