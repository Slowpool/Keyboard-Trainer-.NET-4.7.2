using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard_Trainer
{
    internal static class ExtensionsTypesOfData
    {
        internal static string NewToString(this TypesOfData typeOfData)
        {
            switch (typeOfData)
            {
                case TypesOfData.Word:
                    return "word";

                case TypesOfData.Text:
                    return "text";

                case TypesOfData.Song:
                    return "song";

                default:
                    throw new ArgumentException();
            }
        }

        internal static TypesOfData ToTypeOfData(this string typeOfData)
        {
            switch(typeOfData.ToLower())
            {
                case "words":
                    return TypesOfData.Word;

                case "texts":
                    return TypesOfData.Text;

                case "songs":
                    return TypesOfData.Song;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
