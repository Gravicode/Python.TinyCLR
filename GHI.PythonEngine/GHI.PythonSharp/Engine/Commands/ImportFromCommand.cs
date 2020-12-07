namespace GHI.PythonSharp.Commands
{
    
    using System.IO;
    
    using System.Text;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class ImportFromCommand : ICommand
    {
        private string modname;
        private IList<string> names;

        public ImportFromCommand(string name)
            : this(name, null)
        {
        }

        public ImportFromCommand(string name, IList<string> names)
        {
            this.modname = name;
            this.names = names;
        }

        public string ModuleName { get { return this.modname; } }

        public ICollection<string> Names { get { return this.names; } }

        public void Execute(IContext context)
        {
            Module module = ModuleUtilities.LoadModule(this.modname, context);

            if (this.names != null)
                foreach (string name in this.names)
                    context.SetValue(name, module.GetValue(name));
            else
                foreach (string name in module.GetNames())
                    context.SetValue(name, module.GetValue(name));
        }
    }
}
