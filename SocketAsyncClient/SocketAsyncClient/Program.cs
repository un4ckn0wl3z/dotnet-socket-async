using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaxtivitiezSocketAsync;


namespace SocketAsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HaxtivitiezSocketAsyncClient client = new HaxtivitiezSocketAsyncClient();
            client.RaiseTextReceivedEvent += HandleTextReceived;
            client.RaiseServerDisconnected += HandleServerDisconnected;
            client.RaiseServerConnected += HandleServerConnected;
            Console.WriteLine("**** Welcome to Socket Client Starter ****");
            Console.WriteLine("Please Type a Valid Server IP Address and Press ENTER: ");
            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Please Supply a Valid Port Number 0 - 65535 and Press ENTER: ");
            string strPort = Console.ReadLine();


            if (strIPAddress.StartsWith("<HOST>"))
            {
                strIPAddress = strIPAddress.Replace("<HOST>",string.Empty);
                strIPAddress = Convert.ToString(HaxtivitiezSocketAsyncClient.ResolveHostNameToIPAddress(strIPAddress));
            }

            if (string.IsNullOrEmpty(strIPAddress)) {
                Console.WriteLine("No IP Address Supplied...");
                Environment.Exit(0);
            }

            if (!client.SetServerIPAddress(strIPAddress) || !client.SetPortNumber(strPort))
            {
                Console.WriteLine(string.Format("Wrong IP Address or port number supplied - {0}:{1} \n Press any key to exit...", strIPAddress, strPort));
                Console.ReadKey();
                return;
            }

            client.ConnectToServer();

            string usrInput = null;

            do
            {
                usrInput = Console.ReadLine();

                if (usrInput.Trim() != "<EXIT>") {
                    client.SendToServer(usrInput);
                }
                else if (usrInput.Equals("<EXIT>")) {
                    client.CloseAndDisconnect();
                }


            } while (usrInput != "<EXIT>");


        }

        private static void HandleTextReceived(Object sender, TextReceivedEventArgs trea)
        {
            Console.WriteLine(string.Format("{0} - Received: {1}{2}",DateTime.Now,trea.TextReceived,Environment.NewLine));
        }

        private static void HandleServerDisconnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Disconnected from server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));
            System.Console.ReadLine();
            Environment.Exit(1);
        }

        private static void HandleServerConnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Connected to server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));
        }
    }
}
