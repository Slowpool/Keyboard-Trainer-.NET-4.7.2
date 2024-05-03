using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_demon_Library;
using System.Text.RegularExpressions;

namespace Keyboard_Trainer
{
    internal static class TextForPringHandler
    {
#warning hardcoding
        internal const int MAX_TEXT_LENGTH = 65535;
        internal const int MAX_WORD_LENGTH = 10;

        internal static bool IsCorrectTextLength(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (text.Length > MAX_TEXT_LENGTH)
            {
                return false;
            }

            return true;
        }

        internal static bool IsCorrectWord(string word)
        {
            if (word is null)
            {
                return false;
            }

            if (word.Length == 0)
            {
                return false;
            }

            if (word.Length > MAX_WORD_LENGTH)
            {
                return false;
            }

            foreach (char character in word)
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }

                if (char.IsUpper(character))
                {
                    return false;
                }

                if (character == 'ё')
                {
                    return false;
                }
            }

            return true;
        }

        internal static string PrepareText(string text, TypesOfData type)
        {
            text = RemoveRedundantCharacters(text, type);
            text = Quote(text);
            return text;
        }

        internal static string RemoveRedundantCharacters(string text, TypesOfData type)
        {
            CharacterChecker charChecker;
            switch (type)
            {
                case TypesOfData.Text:
                    charChecker = IsUsualCharacter;
                    text = text.Replace("\r\n", " ");
                    break;

                case TypesOfData.Song:
                    charChecker = CharCheckerForSong;
                    text = text.Replace("\r\n", "\n");
                    text = RemoveKeywords(text);
                    text = ClearRepeatedChars(text, '\n');
                    text = TruncateNextLines(text);
                    break;

                default:
                    throw new Exception();
            }

            var stringBuilder = new StringBuilder(text.Length);
            foreach (var character in text)
            {
                if (charChecker(character))
                {
                    stringBuilder.Append(character);
                }
            }

            text = stringBuilder.ToString();
            text = ClearRepeatedChars(text, ' ');

            return text;
        }

        internal static string Quote(string text)
        {
            return text.Replace("\'", "\'\'");
        }

        internal static bool CharCheckerForSong(char character)
        {
            return IsUsualCharacter(character) || IsNextLineCharacter(character);
        }

        internal static bool IsNextLineCharacter(char character) => character == 10;

        internal static string RemoveKeywords(string text)
        {
            return Regex.Replace(text, @"\[.*?\]", "");
        }

        internal static string ClearRepeatedChars(string text, char targetCharacter)
        {
            string targetSubstring = new string(targetCharacter, 2);
            while (text.IndexOf(targetSubstring) != -1)
            {
                text = text.Replace(targetSubstring, targetCharacter.ToString());
            }
            return text;
        }

        internal static string TruncateNextLines(string text)
        {
            while (text[0] == '\n')
            {
                text = text.Substring(1);
            }
            return text;
        }

        internal static bool IsUsualCharacter(char character)
        {
            return SetsOfCharacters.WholeCharacters.IndexOf(character) != -1;
        }
    }
}
