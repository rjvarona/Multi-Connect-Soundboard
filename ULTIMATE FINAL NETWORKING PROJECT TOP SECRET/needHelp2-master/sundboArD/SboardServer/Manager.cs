using SBoardClient;
using System;
using System.Net.Sockets;
using System.Threading;

namespace SBoardServer

{
   /// <summary>
   /// to recieve and send to all 
   /// </summary>
    public class Manager
    {
       //socket and player which is my client
        private TcpClient _socket;
      
        private string _player;

        /// <summary>
        /// Do Memes is a thread that reads and writes the data messages being sent from client to server and back.
        /// </summary>
        private void DoMemes()
        {
            while (true)
            {
                try
                {
                    string dataFromClient = _socket.ReadString();
                    Program.Broadcast(dataFromClient, _player, true);
                    Console.WriteLine(_player + " has played " + dataFromClient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        /// <summary>
        /// initializes the new client the new client
        /// </summary>

        public void InitializeClient(TcpClient newSocket, string newClient)
        {
            _player = newClient;
            _socket = newSocket;
            var thread = new Thread(DoMemes);
            thread.Start();
        }
    }
}
