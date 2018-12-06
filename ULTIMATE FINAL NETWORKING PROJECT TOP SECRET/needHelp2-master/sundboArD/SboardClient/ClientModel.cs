using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace SBoardClient
{
    public class ClientModel : INotifyPropertyChanged
    {
        private TcpClient _socket;

        private string _messageBoard;
       
        public string MessageBoard
        {
            get => _messageBoard; set { _messageBoard = value; OnPropertyChanged(); }
        }

        private string _currentMessage;
        
        public string CurrentMessage
        {
            get {  return _currentMessage;}
            set { _currentMessage = value; OnPropertyChanged(); }
        }

        public bool Connected
        {
            get { return _socket != null && _socket.Connected; }
        }


        /// <summary>
        /// testing from China on a different place
        /// CREATING SOUNDS FOR ALL THE OTHER ONESSSSSS
        /// INITIALIZING THE SOUND GET SET AND PROPERTY CHANGING STUFF FOR ALL THE SOUNDS
        /// 
        /// </summary>
        private string _china;
        public string China
        {
            get { return _china; }
            set { _china = value; OnPropertyChanged(); }
        }

        private string _bingBong;
        public string BingBong
        {
            get { return _bingBong; }
            set { _bingBong = value; OnPropertyChanged(); }
        }

        private string _wrong;
        public string Wrong
        {
            get { return _wrong; }
            set { _wrong = value; OnPropertyChanged(); }
        }

        private string _greatWall;
        public string GreatWall
        {
            get { return _greatWall; }
            set { _greatWall = value; OnPropertyChanged(); }
        }

        private string _reallyRich;
        public string ReallyRich
        {
            get { return _reallyRich; }
            set { _reallyRich = value; OnPropertyChanged(); }
        }

        private string _fakeNews;
        public string FakeNews
        {
            get { return _fakeNews; }
            set { _fakeNews = value; OnPropertyChanged(); }
        }

        private string _fired;
        public string Fired
        {
            get { return _fired; }
            set { _fired = value; OnPropertyChanged(); }
        }

        private string _randomNoise;
        public string RandomNoise
        {
            get { return _randomNoise; }
            set { _randomNoise = value; OnPropertyChanged(); }
        }

        private string _havanas;
        public string Havanas
        {
            get { return _havanas; }
            set { _havanas = value; OnPropertyChanged(); }
        }

        private string _buildWalls;
        public string BuildWalls
        {
            get { return _buildWalls; }
            set { _buildWalls = value; OnPropertyChanged(); }
        }




        /// <summary>
        /// this is what connects the players together
        /// and herer it initializes the board to be able to function
        /// this is it connectttt
        /// </summary>

        public void Connect()
        {

            _socket = new TcpClient("127.0.0.1", 1234);

            //auto updating players
            
            OnPropertyChanged("Connected");

            //to initialize the board
            InitializeBoard();


            //_currentMessage = player;
            Send(_currentMessage);
            _messageBoard = _currentMessage + " :)";
            China = "help";
            var thread = new Thread(GetMessage);
            thread.Start();
        }


        /// <summary>
        /// this initializes the board once it connects
        /// </summary>
        private void InitializeBoard()
        {

            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            mainWindow.China2.IsEnabled = true;
            mainWindow.BingBong.IsEnabled = true;
            mainWindow.Wrong.IsEnabled = true;
            mainWindow.GreatWall.IsEnabled = true;
            mainWindow.ReallyRich.IsEnabled = true;
            mainWindow.FakeNews.IsEnabled = true;
            mainWindow.BuildWall.IsEnabled = true;
            mainWindow.Havana.IsEnabled = true;
            mainWindow.Fired.IsEnabled = true;
            mainWindow.Random.IsEnabled = true;


            //var converter = new System.Windows.Media.ImageSourceConverter();
            //var brush = (ImageSource)converter.ConvertFromString("./pewdiepie.jpg");
            //mainWindow.pewds.ImageSource = brush;

        }

        /// <summary>
        /// this is to recieve the message from herrre
        /// </summary>
        /// 
        private string  _check = "";
        private void GetMessage()
        {
            while(true)
            {
                string msg = _socket.ReadString();
                WhoEnabled(msg);
                

                MessageBoard += "\r\n" + msg;
            }
        }

        /// <summary>
        /// this is to check which button or which sound is played or enabled....
        /// </summary>
        /// <param name="msg"></param>
        private void WhoEnabled(string msg)
        {
            if (msg != null)
            {
                string[] words = msg.Split(':');
                _check = words[words.Length - 1];
            }
            if (_check == " Bruh")
            {
                China = "Bruh";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " BingBong")
            {
                China = "NotEnabled";
                BingBong = "BingBong";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " AnotherOne")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "AnotherOne";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " Titanic")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "Titanic";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " AirHorn")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "AirHorn";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " FakeNews")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "FakeNews";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " DaWay")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "DaWay";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " ToBeContinued")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "ToBeContinued";
                Havanas = "NotEnabled";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " TakeOnMe")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "TakeOnMe";
                BuildWalls = "NotEnabled";
            }
            else if (_check == " Heyeyeya")
            {
                China = "NotEnabled";
                BingBong = "NotEnabled";
                Wrong = "NotEnabled";
                GreatWall = "NotEnabled";
                ReallyRich = "NotEnabled";
                FakeNews = "NotEnabled";
                Fired = "NotEnabled";
                RandomNoise = "NotEnabled";
                Havanas = "NotEnabled";
                BuildWalls = "Heyeyeya";
            }
        }



        /// <summary>
        /// sending a message of code to the server what the client is asking for.
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            _socket.WriteString(message);
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
