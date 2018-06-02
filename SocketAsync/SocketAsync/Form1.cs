using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void btnAcceptIncomingAsync_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
