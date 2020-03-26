using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FlightSimulator
{
    class TelnetClient
    {
        TcpClient client;
        Socket sender;
        private NetworkStream ns;
        private StreamWriter sw;
        private StreamReader sr;

        public TelnetClient()
        {
            client = null;
            sender = null;
            ns = null;
            sw = null;
            sr = null;
        }

        public void connect(string ip,int port)
        {
            Console.WriteLine("connecting");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client = new TcpClient();
            sender= new Socket(ep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            while (!client.Connected)
            {
                try
                {
                    client.Connect(ep);
                    this.ns = client.GetStream();
                    this.sw = new StreamWriter(ns);
                    this.sr = new StreamReader(ns);
                }
                catch (Exception) { }

            }
            Console.WriteLine("succesful");
            
        }
        public void write(string command)
        {
            if (client != null)
            {
                try
                {
                    sw.WriteLine(command);
                    sw.Flush();

                }
                catch (Exception) { }
            }
        }
        public string read()
        {
            if (client != null)
            {
                try
                {
                    string data = sr.ReadLine();
                    return data;
                }
                catch 
                {
                    throw new Exception("unable to read");
                }
            }
            return "";
        }
        public void disconnect()
        {
            client.Close();
        }
    }
}
