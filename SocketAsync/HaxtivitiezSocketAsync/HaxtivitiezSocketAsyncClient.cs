using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HaxtivitiezSocketAsync
{
    public class HaxtivitiezSocketAsyncClient
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;


        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<ConnectionDisconnectedEventArgs> RaiseServerDisconnected;
        public EventHandler<ConnectionDisconnectedEventArgs> RaiseServerConnected;


        public HaxtivitiezSocketAsyncClient()
        {
            mClient = null;
            mServerPort = -1;
            mServerIPAddress = null;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;
            if (!IPAddress.TryParse(_IPAddressServer,out ipaddr))
            {
                Console.WriteLine("Invalid server IP supplied.");
                return false;
            }
            mServerIPAddress = ipaddr;
            return true;
        }

        public static object ResolveHostNameToIPAddress(string strHostName)
        {
            IPAddress[] retAddr = null;

            try
            {
                retAddr = Dns.GetHostAddresses(strHostName);

                foreach (IPAddress ip in retAddr) {
                    if (ip.AddressFamily == AddressFamily.InterNetwork) {
                        return retAddr;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            if (handler != null)
            {
                handler(this, trea);
            }
        }

        protected virtual void OnRaisePeerDisconnectedEvent(ConnectionDisconnectedEventArgs pdea)
        {
            EventHandler<ConnectionDisconnectedEventArgs> handler = RaiseServerDisconnected;
            if (handler != null)
            {
                handler(this, pdea);
            }
        }

        protected virtual void OnRaisePeerConnectedEvent(ConnectionDisconnectedEventArgs pdea)
        {
            EventHandler<ConnectionDisconnectedEventArgs> handler = RaiseServerConnected;
            if (handler != null)
            {
                handler(this, pdea);
            }
        }


        public bool SetPortNumber(string _ServerPort) {
            int portNumber = 0;
            if (!int.TryParse(_ServerPort.Trim(),out portNumber))
            {
                Console.WriteLine("Invalid server port number supplied.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535) {
                return false;

            }

            mServerPort = portNumber;
            return true;
        }

        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                }
            }
        }

        public async Task SendToServer(string usrInput)
        {

            if (string.IsNullOrEmpty(usrInput)) {
                Console.WriteLine("Empty string supplied to send.");
                return;
            }

            if (mClient != null) {
                if (mClient.Connected) {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;
                    await clientStreamWriter.WriteAsync(usrInput);
                    Console.WriteLine("Data sent...");
                }
            }
        }

        public async Task ConnectToServer()
        {
            if (mClient==null)
            {
                mClient = new TcpClient();
            }

            try
            {
                await mClient.ConnectAsync(mServerIPAddress,mServerPort);
                Console.WriteLine(string.Format("Connected to server IP/Port: {0}:{1}", mServerIPAddress.ToString(),mServerPort));

                RaiseServerConnected(this, new ConnectionDisconnectedEventArgs(mClient.Client.RemoteEndPoint.ToString()));

                ReadDataAsync(mClient);
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }

        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[64];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);
                    if (readByteCount<=0) {
                        OnRaisePeerDisconnectedEvent(new ConnectionDisconnectedEventArgs(mClient.Client.RemoteEndPoint.ToString()));
                        Console.WriteLine("Disconnected from server");
                        mClient.Close();
                        break;

                    }
                    Console.WriteLine(string.Format("Received bytes: {0} - message: {1}",readByteCount,new string(buff)));

                    OnRaiseTextReceivedEvent(new TextReceivedEventArgs(mClient.Client.RemoteEndPoint.ToString(), new string(buff)));

                    Array.Clear(buff,0, buff.Length);
                    //readByteCount = 0;
                }

            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }
    }
}
