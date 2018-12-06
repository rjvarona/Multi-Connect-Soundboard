using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using SBoardClient;

namespace SBoardServer
{
    class Program
    {
        //This is a dictionary of key,value pairs used to store the names and sockets of each client.
        public static Dictionary<string, TcpClient> ClientList = new Dictionary<string, TcpClient>();
        public static List<string> playerList = new List<string>();
        public static int connections = 0;
        /// <summary>
        /// Listens for new connections and handles them.
        /// </summary>
        static void Main()
        {
            var serverSocket = new TcpListener(IPAddress.Any, 1234);
            serverSocket.Start();
            Console.WriteLine("Sound Board server started...");
           string player = "player";
            while (true)
            {
                //This next line of code actually blocks
                var clientSocket = serverSocket.AcceptTcpClient();


                playerList.Add(player);
                playerList[playerList.Count - 1] = playerList[playerList.Count - 1] + (playerList.Count - 1).ToString();
                player = playerList[playerList.Count - 1];



                //Somebody connected and sent us data... and no clientSocket doesn't have a method called ReadString: See TcpClientExtension.cs
                string dataFromClient = clientSocket.ReadString();




                //Add the name and StringSocket to the Dictionary object
                if (connections <= 1)
                {
                    ClientList.Add(player, clientSocket);

                    connections++;
                    //Tell everyone that someone new joined!
                    Broadcast(player + " has joined the Battle!!!", player, false);
                    //Log the fact to the server console
                    Console.WriteLine(player + " has joined the Battle!!!");
                    //Create a new object to Handle all future incoming messages from this client
                    var client = new Manager();
                    //Start that thread running
                    client.InitializeClient(clientSocket, player);
                    
                }
                else
                {
                    Console.WriteLine("Only two players allowed on the servers");

                    Broadcast(player + "Tried to connect but only two people allowed at a time.",player, false);
                }
                
                
            }
        }

        /// <summary>
        /// This broadcasts the message to all the players connected.
        /// </summary>
        public static void Broadcast(string msg, string player, bool flag)
        {
            foreach (var item in ClientList)
            {
                var mesage = "";
                var broadcastSocket = item.Value;
                if(flag == false)
                {
                    mesage = msg;
                }
                else
                {
                    mesage = player + " Playeth: " + msg;
                }
                //var m = flag ? player + " Playeth: " + msg : msg;
                item.Value.WriteString(mesage);
            }
        }
    }
}
