using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace SerialTester.Helpers
{
    public delegate void OnDataReceivedEvent(object sender, string value);
    public class CommunicationsBus : IDisposable
    {
        private CommunicationsProtocal protocal;
        private StreamReader commandFile;
        private SerialPort serialPort;
        private bool disposed;
        public event OnDataReceivedEvent DataReceived;
        protected virtual void OnDataReceived(object sender, ref string Text)
        {
            if (DataReceived != null)
                DataReceived(sender, Text);
        }
        public enum CommunicationsProtocal
        {
            Uart,
            Spi,
            I2C
        }
        Thread readTask;
        public CommunicationsBus(string portName, int BaudRate=9600)
        {
            //readTask = new Thread(new ThreadStart(ReadLoop));
            this.disposed = false;
            this.commandFile = null;
            this.protocal = CommunicationsProtocal.Uart;

            this.serialPort = new SerialPort();
            this.serialPort.PortName = portName;
            this.serialPort.BaudRate = BaudRate;// 115200;
            this.serialPort.Parity = Parity.None;
            this.serialPort.DataBits = 8;
            this.serialPort.StopBits = System.IO.Ports.StopBits.One;
            this.serialPort.Handshake = Handshake.None;
            this.serialPort.ReadTimeout = 4000; // some of the mount commands take a while, so waiting for result can take a while
            this.serialPort.DataReceived += SerialPort_DataReceived;
            this.serialPort.Open();
            //this.serialPort.DtrEnable = true;
            Thread.Sleep(250);

            this.serialPort.DiscardInBuffer();
            //readTask.Start();
        }

        void ReadLoop()
        {
            while (!this.disposed)
            {
                var readstr = this.serialPort.ReadLine();
                if (!string.IsNullOrEmpty(readstr))
                {
                    OnDataReceived(this, ref readstr);
                }
                Thread.Sleep(100);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
            OnDataReceived(this, ref indata);

        }

        public CommunicationsBus(string portName, StreamReader commandFile) : this(portName)
        {
            this.commandFile = commandFile;
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                if (this.commandFile != null)
                {
                    this.commandFile.Close();
                    this.commandFile.Dispose();
                    this.commandFile = null;
                }

                if (this.serialPort != null)
                {
                    this.serialPort.Close();
                    this.serialPort.Dispose();
                    this.serialPort = null;
                }
            }

            this.disposed = true;
        }

        ~CommunicationsBus()
        {
            this.Dispose(false);
        }

        public void Write(string data)
        {
            data = data.Trim();

            switch (this.protocal)
            {
                case CommunicationsProtocal.I2C:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Spi:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Uart:
                    var buffer = Encoding.UTF8.GetBytes(data);
                    this.serialPort.Write(buffer, 0, buffer.Length);

                    break;
            }
        }

        public void Write(byte[] data)
        {
            switch (this.protocal)
            {
                case CommunicationsProtocal.I2C:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Spi:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Uart:
                    // normally would check the busy pin on ALFAT to 
                    // control data flow, can't do that on eval board
                    // so chunk the data and pause.
                    if (data.Length > 8 * 1024)
                    {
                        Console.WriteLine("data.length: " + data.Length);
                        int block_write_count = data.Length / (4 * 1024);
                        int remainder = data.Length % (4 * 1024);
                        byte[] block = new byte[4 * 1024];
                        int bytecount = 0;
                        Console.WriteLine("Writing: " + block_write_count + " blocks and remainder: " + remainder);
                        for (int ic = 0; ic < block_write_count; ic++)
                        {
                            Buffer.BlockCopy(data, ic * 4 * 1024, block, 0, 4 * 1024);
                            this.serialPort.Write(block, 0, 4 * 1024);
                            this.serialPort.BaseStream.Flush();
                            if (ic % 100 == 0)
                                Console.WriteLine("block: " + ic);
                            bytecount += (4 * 1024);
                            // System.Threading.Thread.Sleep(10);
                        }
                        Console.WriteLine("bytes written: " + bytecount);
                        if (remainder != 0)
                        {
                            this.serialPort.Write(data, block_write_count * 4 * 1024, remainder);
                            this.serialPort.BaseStream.Flush();
                        }
                        Console.WriteLine("Copy to device complete, enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        this.serialPort.Write(data, 0, data.Length);
                    }

                    break;
            }
        }

        public void WriteLine(string line)
        {
            line = line.Trim();

            switch (this.protocal)
            {
                case CommunicationsProtocal.I2C:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Spi:
                    throw new NotImplementedException();

                case CommunicationsProtocal.Uart:
                    this.serialPort.WriteLine(line);

                    break;
            }
        }

        public bool ProcessCommandFromFile()
        {
            if (this.commandFile == null) throw new InvalidOperationException("This object was not initialized for a command file.");

            var line = this.commandFile.ReadLine(); //Possible make this non-blocking
            if (line == null)
                return false;

            this.WriteLine(line);

            return true;
        }

        public string ReadLine()
        {
            if (this.serialPort != null)
            {
                if (serialPort.BytesToRead > 0)
                {
                    return this.serialPort.ReadLine();
                }
                return "";
            }
            else if (this.commandFile != null)
            {
                return this.commandFile.ReadLine(); //Handle end of file
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public string ReadExisting()
        {
            if (this.serialPort != null)
            {
                if (serialPort.BytesToRead > 0)
                {

                    return this.serialPort.ReadExisting();
                }
                return "";
            }
            else if (this.commandFile != null)
            {
                return this.commandFile.ReadLine(); //Handle end of file
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void Read(byte[] data)
        {
            if (this.serialPort != null)
            {
                this.serialPort.Read(data, 0, data.Length);
            }
            else if (this.commandFile != null)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
