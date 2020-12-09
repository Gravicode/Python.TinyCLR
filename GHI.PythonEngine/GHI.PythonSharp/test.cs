using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace GHI.PythonSharp
{
    public class ReflectionExample
    {
        private uint FunctionA() => 0x1234;

        private uint FunctionB(uint numPlus) => 0x1234 + numPlus;
    }
    class test
    {
        void test1()
        {
            var r = new ReflectionExample();

            var type = r.GetType();

            var methodA = type.GetMethod("FunctionA", BindingFlags.NonPublic | BindingFlags.Instance);

            var valueA = methodA.Invoke(r, null);

            var methodB = type.GetMethod("FunctionB", BindingFlags.NonPublic | BindingFlags.Instance);

            var valueB = methodB.Invoke(r, new object[] { (uint)1 });

            var obj = type.InvokeMember(null, BindingFlags.CreateInstance, null, null, null);
            var obj2 = typeof(ReflectionExample).InvokeMember(null, BindingFlags.CreateInstance, null, null, null);

            Debug.WriteLine("methodA : " + valueA);
            Debug.WriteLine("methodB : " + valueB);
        }
    }
}
