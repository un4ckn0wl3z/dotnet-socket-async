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
            Console.WriteLine("**** Welcome to Socket Client Starter ****");
            Console.WriteLine("Please Type a Valid Server IP Address and Press ENTER: ");
            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Please Supply a Valid Port Number 0 - 65535 and Press ENTER: ");
            string strPort = Console.ReadLine();

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
    }
}
