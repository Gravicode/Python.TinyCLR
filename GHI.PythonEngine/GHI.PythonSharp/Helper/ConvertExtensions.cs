using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace GHI.PythonSharp.Helper
{
    public class ConvertExtensions
    {
        public static bool ToBoolean(string value)
        {
            if (value == null) return false;
            value = value.Trim();
            if (value.ToLower() == "false") return false;
            if (value.ToLower() == "true") return true;
            return false;
        }
    }
}
