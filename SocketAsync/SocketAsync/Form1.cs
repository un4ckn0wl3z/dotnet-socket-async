using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HaxtivitiezSocketAsync;

namespace SocketAsync
{
    public partial class Form1 : Form
    {
        HaxtivitiezSocketServer mServer;
        public Form1()
        {
            InitializeComponent();
            mServer = new HaxtivitiezSocketServer();
            mServer.RaiseClientConnectedEvent += HandleClientConnected;
            mServer.RaiseTextReceivedEvent += HandleTextReceived;
            mServer.RaiseClientDisconnectedEvent += HandleClientDisconnected;
        }

        private void btnAcceptIncomingAsync_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
            MessageBox.Show("Started Server");
        }

        private void btnSendMessageToClient_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(txtMessageToClient.Text.Trim()+"\r\n");
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mServer.StopServer();
        }


        void HandleClientConnected(Object sender, ClientConnectedEventArgs ccea)
        {
            txtConsole.AppendText(string.Format("{0} - New Client connected {1}{2}",DateTime.Now,ccea.NewClient,Environment.NewLine));
        }

        void HandleTextReceived(Object sender, TextReceivedEventArgs trea) {
            txtConsole.AppendText(string.Format("{0} - Received from {1}: {2}{3}", DateTime.Now, trea.WhoTheFuckClientSentThisText.Trim(), trea.TextReceived.Trim(), Environment.NewLine));

        }


        void HandleClientDisconnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            if (!txtConsole.IsDisposed)
            {
                txtConsole.AppendText(string.Format("{0} - Client Disconnected: {1}\r\n",
                    DateTime.Now, cdea.DisconnectedPeer));
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
