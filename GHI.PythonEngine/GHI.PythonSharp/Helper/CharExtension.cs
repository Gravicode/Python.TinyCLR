using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace GHI.PythonSharp.Helper
{
    public class CharExtensions

    {
        public static bool IsLetter(char c)
        {
            if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
                return true;
            else
                return false;
        }
        public static bool IsWhiteSpace(char c)
        {
            return c == ' ';
        }
        public static bool IsDigit(char c)
        {
            if (!(c < '0' || c > '9'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsLetterOrDigit(char c)
        {
            return IsLetter(c) || IsDigit(c);
        }
    }
}
