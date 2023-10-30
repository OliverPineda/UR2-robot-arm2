using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Has2BeSameNameSpace
{
    public class SerialCom
    {

        SerialPort _serialPort;
        public bool Online { get; private set; }

        public SerialCom() { }

        public SerialCom(String port)
        {
            SetupSerialComms(port);
        }


        public void SetupSerialComms(String port)
        {
            try
            {   //must match microchip studio - data visualizer
                _serialPort = new SerialPort(port);
                _serialPort.BaudRate = 9600;
                _serialPort.DataBits = 8;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One; //leave at One bits
                _serialPort.Open();
                Online = true;
            }
            catch
            {
                Online = false;
            }
        }

        public void Move(int command) //here was SerialCommunication.Move(1); //0 for lead off ERROR it was char not int
        {
            try
            {
                if (Online)
                {
                    byte[] buffer = { Convert.ToByte(command) };
                    _serialPort.Write(buffer, 0, 1);
                }
            }
            catch
            {
                Online = false;
            }
        }

        public void Close()
        {
            _serialPort.Close();
        }

    }
}