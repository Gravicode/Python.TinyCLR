namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class PrintFunction : IFunction
    {
        private Machine machine;

        public PrintFunction(Machine machine)
        {
            this.machine = machine;
        }

        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            string separator = (namedArguments != null && namedArguments.Contains("sep")) ? (string)namedArguments["sep"] : " ";
            string end = (namedArguments != null && namedArguments.Contains("end")) ? (string)namedArguments["end"] : null;

            if (arguments != null)
            {
                int narg = 0;
                foreach (var argument in arguments)
                {
                    if (narg != 0)
                        this.machine.Output.Write(separator);
                    this.machine.Output.Write(ValueUtilities.AsPrintString(argument));
                    narg++;
                }
            }

            if (end != null)
                this.machine.Output.Write(end);
            else
                this.machine.Output.WriteLine();

            return null;
        }
    }
}
