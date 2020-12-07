namespace GHI.PythonSharp.Utilities
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Commands;

    public static class CommandUtilities
    {
        public static string GetDocString(ICommand command)
        {
            var composite = command as CompositeCommand;

            if (composite == null)
                return null;

            return composite.GetDocString();
        }
    }
}
