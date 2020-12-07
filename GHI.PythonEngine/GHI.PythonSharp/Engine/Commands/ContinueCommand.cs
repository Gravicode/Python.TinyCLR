namespace GHI.PythonSharp.Commands
{
    using System;
    using System.Text;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class ContinueCommand : ICommand
    {
        public void Execute(IContext context)
        {
            BindingEnvironment environment = (BindingEnvironment)context;
            environment.WasContinue = true;
        }
    }
}
