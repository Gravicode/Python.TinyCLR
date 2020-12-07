﻿namespace GHI.PythonSharp.Utilities
{
    using System;
    
    using System.IO;
    
    using System.Text;
    using GHI.PythonSharp.Commands;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Language;

    public static class ModuleUtilities
    {
        private static IDictionary<string, Module> modules = new Dictionary<string, Module>();

        public static string ModuleFileName(string name)
        {
            string dirname = name.Replace('.', '/');
            string filename = dirname + ".py";
            string initfilename = dirname + "/__init__.py";

            string fullfilename = Path.Combine(".", filename);
            string fullinitfilename = Path.Combine(".", initfilename);

            if (File.Exists(fullfilename))
                return (new FileInfo(fullfilename)).FullName;

            if (File.Exists(fullinitfilename))
                return (new FileInfo(fullinitfilename)).FullName;

            string location = (new FileInfo(System.Reflection.Assembly.GetAssembly(typeof(ModuleUtilities)).Location)).DirectoryName;
            string lib = Path.Combine(location, "Lib");

            fullfilename = Path.Combine(lib, filename);
            fullinitfilename = Path.Combine(lib, initfilename);

            if (File.Exists(fullfilename))
                return (new FileInfo(fullfilename)).FullName;

            if (File.Exists(fullinitfilename))
                return (new FileInfo(fullinitfilename)).FullName;

            location = (new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location)).DirectoryName;
            lib = Path.Combine(location, "Lib");

            fullfilename = Path.Combine(lib, filename);
            fullinitfilename = Path.Combine(lib, initfilename);

            if (File.Exists(fullfilename))
                return (new FileInfo(fullfilename)).FullName;

            if (File.Exists(fullinitfilename))
                return (new FileInfo(fullinitfilename)).FullName;

            return null;
        }

        public static Module LoadModule(string name, IContext context)
        {
            Module module = null;

            if (TypeUtilities.IsNamespace(name))
            {
                var types = TypeUtilities.GetTypesByNamespace(name);

                module = new Module(context.GlobalContext);

                foreach (var type in types)
                    module.SetValue(type.Name, type);
            }
            else
            {
                string filename = ModuleUtilities.ModuleFileName(name);

                if (filename == null)
                    throw new ImportError(string.Format("No module named {0}", name));

                if (modules.ContainsKey(filename) && modules[filename].GlobalContext == context.GlobalContext)
                    return modules[filename];

                Parser parser = new Parser(new StreamReader(filename));
                ICommand command = parser.CompileCommandList();

                module = new Module(context.GlobalContext);
                string doc = CommandUtilities.GetDocString(command);

                command.Execute(module);
                module.SetValue("__doc__", doc);

                modules[filename] = module;
            }

            return module;
        }
    }
}
