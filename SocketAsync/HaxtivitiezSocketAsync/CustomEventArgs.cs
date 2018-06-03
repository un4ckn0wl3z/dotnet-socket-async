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
    public class ClientConnectedEventArgs : EventArgs
    {
        public string NewClient { get; set; }

        public ClientConnectedEventArgs(string _newClient)
        {
            NewClient = _newClient;
        }
    }


    public class TextReceivedEventArgs : EventArgs
    {
        public string WhoTheFuckClientSentThisText { get; set; }

        public string TextReceived { get; set; }

        public TextReceivedEventArgs(string _clientWhoTheFuckClientSentThisText,string _textReceived)
        {
            WhoTheFuckClientSentThisText = _clientWhoTheFuckClientSentThisText;
            TextReceived = _textReceived;
        }
    }

    public class ConnectionDisconnectedEventArgs : EventArgs
    {
        public string DisconnectedPeer { get; set; }

        public ConnectionDisconnectedEventArgs(string _disconnectedPeer)
        {
            DisconnectedPeer = _disconnectedPeer;
        }
    }

}