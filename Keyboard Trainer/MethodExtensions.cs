
namespace Keyboard_Trainer
{
#warning useless file
    internal static class MethodExtensions
    {
        public static string ToString(this Languages Language)
        {
            switch (Language)
            {
                case Languages.Russian:
                    return "russian";
                case Languages.English:
                    return "english";
                default:
                    throw new System.Exception("unknown language");
            }
        }
    }
}