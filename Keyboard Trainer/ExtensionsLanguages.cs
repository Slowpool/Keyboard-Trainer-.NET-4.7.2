using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard_Trainer
{
    internal static class ExtensionsLanguages
    {
        internal static string NewToString(this Languages language)
        {
            switch (language)
            {
                case Languages.Russian:
                    return "russian";

                case Languages.English:
                    return "english";

                default:
                    throw new ArgumentException();
            }
        }

        internal static Languages ToLanguage(this string language)
        {
            switch (language.ToLower())
            {
                case "russian":
                    return Languages.Russian;

                case "english":
                    return Languages.English;

                default:
                    throw new ArgumentException();
            }
        }
    }
}
