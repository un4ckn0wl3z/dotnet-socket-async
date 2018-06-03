using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HaxtivitiezSocketAsync
{
    public class HaxtivitiezSocketServer
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTcpListener;

        public List<TcpClient> mClients;
        public EventHandler<ClientConnectedEventArgs> RaiseClientConnectedEvent;
        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<ConnectionDisconnectedEventArgs> RaiseClientDisconnectedEvent;

        public bool KeepRunning
        {
            get;
            set;
        }

        public HaxtivitiezSocketServer()
        {
            mClients = new List<TcpClient>();
        }

        public virtual void OnRaiseClientConnectedEvent(ClientConnectedEventArgs e)
        {
            EventHandler<ClientConnectedEventArgs> handler = RaiseClientConnectedEvent;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        public virtual void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            if (handler != null)
            {
                handler(this, trea);
            }

        }

        public virtual void OnRaiseClientDisconnectedEvent(ConnectionDisconnectedEventArgs cdea)
        {
            EventHandler<ConnectionDisconnectedEventArgs> handler = RaiseClientDisconnectedEvent;

            if (handler != null)
            {
                handler(this, cdea);
            }
        }

        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }

            if (port <= 0)
            {
                port = 23000;
            }

            mIP = ipaddr;
            mPort = port;

            Debug.WriteLine(string.Format("IP Address: {0} - Port: {1}", mIP.ToString(), mPort));

            mTcpListener = new TcpListener(mIP, mPort);

            try
            {
                mTcpListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var returnByAccept = await mTcpListener.AcceptTcpClientAsync();

                    mClients.Add(returnByAccept);

                    Debug.WriteLine(string.Format("Client connected successfully, count {0} - {1}", mClients.Count, returnByAccept.Client.RemoteEndPoint));

                    HandleClientConnection handleConnection = new HandleClientConnection(socketServer: this, paramClient: returnByAccept);
                    handleConnection.TakeCareOfClientListen();

                    ClientConnectedEventArgs eaClientConnected;
                    eaClientConnected = new ClientConnectedEventArgs(returnByAccept.Client.RemoteEndPoint.ToString());
                    OnRaiseClientConnectedEvent(eaClientConnected);
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }



        }

        public void StopServer()
        {
            try
            {
                if (mTcpListener != null)
                {
                    mTcpListener.Stop();
                }

                foreach (TcpClient c in mClients)
                {
                    c.Dispose();
                }

                mClients.Clear();



            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }

        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {
                string message = leMessage.Trim();
                OnRaiseTextReceivedEvent(new TextReceivedEventArgs("Administrtor", message));
                byte[] buffMessage = Encoding.ASCII.GetBytes(message);
                foreach (TcpClient c in mClients)
                {
                    await c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                    Debug.WriteLine("BROASCAT TO : " + c.Client.RemoteEndPoint);
                }

            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
        }

        public void RemoveClient(TcpClient paramClient)
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
                Debug.WriteLine(string.Format("Client removed, count {0}", mClients.Count));

            }
        }
    }

    public class HandleClientConnection
    {
        private readonly TcpClient paramClient;
        private readonly HaxtivitiezSocketServer socketServer;
        public HandleClientConnection(HaxtivitiezSocketServer socketServer, TcpClient paramClient)
        {
            this.socketServer = socketServer;
            this.paramClient = paramClient;
        }
        public async void TakeCareOfClientListen()
        {
            NetworkStream stream = null;
            StreamReader reader = null;
            string clientEndPoint = paramClient.Client.RemoteEndPoint.ToString();

            try
            {
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];
                while (socketServer.KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read");
                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);
                    Debug.WriteLine("RETURNED: " + nRet);

                    if (nRet == 0)
                    {
                        socketServer.OnRaiseClientDisconnectedEvent(new ConnectionDisconnectedEventArgs(clientEndPoint));
                        socketServer.RemoveClient(paramClient);
                        Debug.WriteLine("Socket disconnected");
                        break;
                    }

                    string recvText = new string(buff);
                    Debug.WriteLine("*** RECEIVED: " + recvText.Trim());

                    socketServer.OnRaiseTextReceivedEvent(new TextReceivedEventArgs(
                        paramClient.Client.RemoteEndPoint.ToString(),
                        recvText.Trim()
                        ));

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception exp)
            {
                socketServer.OnRaiseClientDisconnectedEvent(new ConnectionDisconnectedEventArgs(clientEndPoint));
                socketServer.RemoveClient(paramClient);
                Debug.WriteLine(exp.ToString());
            }


        }
    }
}
