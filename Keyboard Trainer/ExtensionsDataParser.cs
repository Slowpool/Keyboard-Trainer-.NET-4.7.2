using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keyboard_Trainer.DataUploader;

namespace Keyboard_Trainer
{
    internal static class ExtensionsDataParser
    {
        internal static void FillBufferWithCorrectWords(this StreamReader reader, string[] buffer)
        {
            if (reader == null)
            {
                return;
            }

            string word = reader.ReadLine();
            int i = 1;
            while (word != null && i < buffer.Length)
            {
                word = reader.ReadLine();
                if (TextForPringHandler.IsCorrectWord(word))
                {
                    buffer[i] = word;
                    i++;
                }
            }
        }

        internal static void Clear(this string[] buffer)
        {
            for(int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = null;
            }
        }
    }
}
