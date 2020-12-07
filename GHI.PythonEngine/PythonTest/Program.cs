using GHI.PythonSharp;
using GHIElectronics.TinyCLR.Pins;
using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace PythonTest
{
    class Program
    {
        static void Main()
        {   //use UART5 on SITCore SC20260

            //basic testing
            var module = new PythonSharpEngine(SC20260.UartPort.Uart5);
            module.Run();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
