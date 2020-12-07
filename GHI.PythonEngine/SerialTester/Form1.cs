using SerialTester.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialTester
{
    public partial class Form1 : Form
    {
        CommunicationsBus bus;
        public bool IsConnect { get; set; } = false;
        public Form1()
        {
            InitializeComponent();
            Setup();
        }
        private bool PopulateComPorts()
        {
            var ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
                return false;

            this.CmbPort.Items.Add("Select a port");

            foreach (string port in ports)
                this.CmbPort.Items.Add(port);

            this.CmbPort.SelectedIndex = 0;

            return true;
        }

        void Setup()
        {
            PopulateComPorts();
            BtnDisconnect.Click += (a, b) => {
                if (IsConnect)
                {
                    if (bus != null)
                    {
                        bus.Dispose();
                    }
                    IsConnect = false;
                    TxtStatus.Text = "Disconnected";
                   
                }
            };
            BtnConnect.Click += (a, b) => {

                try
                {
                    if (bus != null)
                    {
                        
                        bus.Dispose();
                    }
                    if (CmbPort.SelectedIndex > 0 && int.TryParse(TxtBaudRate.Text, out var baud))
                    {
                        bus = new CommunicationsBus(CmbPort.Text, baud);
                        bus.DataReceived += Bus_DataReceived;
                        TxtStatus.Text = "Connected";
                        IsConnect = true;
                    }
                    else
                    {
                        IsConnect = false;
                    }
                }
                catch(Exception ex)
                {
                    IsConnect = false;
                    MessageBox.Show("Error happen :" + ex.ToString());
                }
            };
            BtnClear.Click += (a, b) => {
                TxtResponse.Clear();
            };
            BtnSend.Click += (a, b) =>
            {
                if (!IsConnect)
                {
                    TxtStatus.Text = "Please connect to device first";
                    return;
                }
                Console.WriteLine("write:"+TxtMessage.Text);
                if (TxtMessage.Lines.Count() > 0)
                {
                    Task BatchTask = new Task(() =>
                    {
                        var lines = TxtMessage.Lines.ToList();
                        foreach (var line in lines)
                        {
                            bus.WriteLine(line);
                            Thread.Sleep(1000);
                        }
                    });
                    BatchTask.Start();

                }
                else
                    bus.WriteLine(TxtMessage.Text);
                //Thread.Sleep(100);
                /*
                var resp = bus.ReadExisting();
                if (!string.IsNullOrEmpty(resp))
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(() => TxtResponse.AppendText(resp + Environment.NewLine)));
                    }
                    else
                    {
                        TxtResponse.AppendText(resp + Environment.NewLine);
                    }
                }*/
            };

        }
      

        private void Bus_DataReceived(object sender, string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => TxtResponse.AppendText(value)));
            }
            else
            {
                TxtResponse.AppendText(value);
            }

        }
    }
}
