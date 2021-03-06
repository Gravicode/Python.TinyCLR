﻿namespace GHI.PythonSharp.Commands
{
    using System.IO;
    using System.Text;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class ImportCommand : ICommand
    {
        private string modname;
        private string[] names;

        public ImportCommand(string modname)
        {
            this.modname = modname;
            this.names = modname.Split('.');
        }

        public string ModuleName { get { return this.modname; } }

        public void Execute(IContext context)
        {
            Module module = ModuleUtilities.LoadModule(this.modname, context);

            IValues values = context;
            int nname = 0;

            foreach (var name in this.names)
            {
                string normname = name.Trim();

                if (nname == this.names.Length - 1)
                    values.SetValue(normname, module);
                else if (!values.HasValue(normname))
                {
                    var mod = new Module(context.GlobalContext);
                    values.SetValue(normname, mod);
                    values = mod;
                }
                else
                    values = (IValues)values.GetValue(normname);

                nname++;
            }
        }
    }
}
