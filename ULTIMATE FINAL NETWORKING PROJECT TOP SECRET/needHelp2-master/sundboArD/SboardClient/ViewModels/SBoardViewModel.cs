using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace SBoardClient.ViewModels
{

    class SBoardViewModel : INotifyPropertyChanged
    {

 
        private SoundPlayer _soundPlayer2;
        private MainWindow _mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        #region Properties
        //Elements bound to by the view
        public string Message
        {
            get { return _clientModel.CurrentMessage; }
            set { _clientModel.CurrentMessage = value; NotifyPropertyChanged(); }
        }
       



        /// <summary>
        /// this is where the sounds are being made connected to the view
        /// </summary>
        public string MessageBoard
        {

            get
            {
               
                return _clientModel.MessageBoard;

            }


            set { _clientModel.MessageBoard = value; NotifyPropertyChanged(); }

        }
        //-----------------------------------------------CREATING SOUNDS-------------------------------------

        public string China
        {
            get { 

                if( _clientModel.China == "Bruh")
                {
             
                    _soundPlayer2 = new SoundPlayer(@"./Bruh.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set {  _clientModel.China = value; NotifyPropertyChanged(); }
        }

        public string BingBong
        {
            get
            {

                if (_clientModel.BingBong == "BingBong")
                {

                    _soundPlayer2 = new SoundPlayer(@"./BingBong.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.BingBong = value; NotifyPropertyChanged(); }
        }
        public string Wrong
        {
            get
            {

                if (_clientModel.Wrong == "AnotherOne")
                {

                    _soundPlayer2 = new SoundPlayer(@"./AnotherOne.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.Wrong = value; NotifyPropertyChanged(); }
        }

        public string GreatWall
        {
            get
            {

                if (_clientModel.GreatWall == "Titanic")
                {

                    _soundPlayer2 = new SoundPlayer(@"./Titanic.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.GreatWall = value; NotifyPropertyChanged(); }
        }

        public string ReallyRich
        {
            get
            {

                if (_clientModel.ReallyRich == "AirHorn")
                {

                    _soundPlayer2 = new SoundPlayer(@"./AirHorn.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.ReallyRich = value; NotifyPropertyChanged(); }
        }

        public string FakeNews
        {
            get
            {

                if (_clientModel.FakeNews == "FakeNews")
                {

                    _soundPlayer2 = new SoundPlayer(@"./FakeNews.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.FakeNews = value; NotifyPropertyChanged(); }
        }

        public string Fired
        {
            get
            {

                if (_clientModel.Fired == "DaWay")
                {

                    _soundPlayer2 = new SoundPlayer(@"./DaWay.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.Fired = value; NotifyPropertyChanged(); }
        }

        public string RandomNoise
        {
            get
            {

                if (_clientModel.RandomNoise == "ToBeContinued")
                {

                    _soundPlayer2 = new SoundPlayer(@"./ToBeContinued.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.RandomNoise = value; NotifyPropertyChanged(); }
        }

        public string Havanas
        {
            get
            {

                if (_clientModel.Havanas == "TakeOnMe")
                {

                    _soundPlayer2 = new SoundPlayer(@"./takeonme.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.Havanas = value; NotifyPropertyChanged(); }
        }

        public string BuildWalls
        {
            get
            {

                if (_clientModel.BuildWalls == "Heyeyeya")
                {

                    _soundPlayer2 = new SoundPlayer(@"./Heyeyeya.wav");
                    _soundPlayer2.Play();
                    return "Green";
                }
                return "White";

            }
            set { _clientModel.BuildWalls = value; NotifyPropertyChanged(); }
        }





        /// <summary>
        /// initializing all the commands
        /// 
        /// </summary>
        public DelegateCommand ConnectCommand { get; set; }
        public DelegateCommand SendCommand { get; set; }
        public DelegateCommand China2 { get; set; }
        public DelegateCommand BingBong2 { get; set; }
        public DelegateCommand Wrong2 { get; set; }
        public DelegateCommand GreatWall2 { get; set; }
        public DelegateCommand ReallyRich2 { get; set; }
        public DelegateCommand FakeNews2 { get; set; }
        public DelegateCommand BuildWall { get; set; }
        public DelegateCommand Fired2 { get; set; }
        public DelegateCommand Havana { get; set; }
        public DelegateCommand Random { get; set; }


        #endregion 

        #region Private and Internal Vars/Props
        private readonly ClientModel _clientModel;
        #endregion 

        /// <summary>
        /// Constructor creates the Model!
        /// </summary>
        public SBoardViewModel()
        {
            //Create ourselves a model
            _clientModel = new ClientModel();
            //Subscribe to the Model's PropertyChanged event
            _clientModel.PropertyChanged += ClientModelChanged;
            //Create our two Command objects
            ConnectCommand = new DelegateCommand(
                a => _clientModel.Connect(),
                b => !_clientModel.Connected
            );
            SendCommand = new DelegateCommand(
                a => _clientModel.Send("PressF"),
                b => _clientModel.Connected
            );
            China2 = new DelegateCommand(
                a => _clientModel.Send("Bruh"),
                b => _clientModel.Connected
                );
            BingBong2 = new DelegateCommand(
                a => _clientModel.Send("BingBong"),
                b => _clientModel.Connected
                );
            GreatWall2 = new DelegateCommand(
               a => _clientModel.Send("Titanic"),
               b => _clientModel.Connected
               );
            ReallyRich2 = new DelegateCommand(
               a => _clientModel.Send("AirHorn"),
               b => _clientModel.Connected
               );
            FakeNews2 = new DelegateCommand(
               a => _clientModel.Send("FakeNews"),
               b => _clientModel.Connected
               );
           Wrong2  = new DelegateCommand(
               a => _clientModel.Send("AnotherOne"),
               b => _clientModel.Connected
                );
            BuildWall = new DelegateCommand(
                a => _clientModel.Send("Heyeyeya"),
                b => _clientModel.Connected
                );
            Havana = new DelegateCommand(
                a => _clientModel.Send("TakeOnMe"),
                b => _clientModel.Connected
                );
            Fired2 = new DelegateCommand(
              a => _clientModel.Send("DaWay"),
              b => _clientModel.Connected
              );
            Random = new DelegateCommand(
             a => _clientModel.Send("ToBeContinued"),
             b => _clientModel.Connected
             );


        }

        #region Event Listeners
        private void ClientModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Connected"))
            {
                NotifyPropertyChanged("Connected");
                ConnectCommand.RaiseCanExecuteChanged();
                SendCommand.RaiseCanExecuteChanged();
                China2.RaiseCanExecuteChanged();
                BingBong2.RaiseCanExecuteChanged();
                Wrong2.RaiseCanExecuteChanged();
                GreatWall2.RaiseCanExecuteChanged();
                ReallyRich2.RaiseCanExecuteChanged();
                FakeNews2.RaiseCanExecuteChanged();
                BuildWall.RaiseCanExecuteChanged();
                Fired2.RaiseCanExecuteChanged();
                Havana.RaiseCanExecuteChanged();
                Random.RaiseCanExecuteChanged();
            }
            else if (e.PropertyName.Equals("MessageBoard"))
            {
                NotifyPropertyChanged("MessageBoard");
            }
            else if(e.PropertyName.Equals("China"))
            {
                NotifyPropertyChanged("China");
            }
            else if (e.PropertyName.Equals("BingBong"))
            {
                NotifyPropertyChanged("BingBong");
            }
            else if (e.PropertyName.Equals("Wrong"))
            {
                NotifyPropertyChanged("Wrong");
            }
            else if (e.PropertyName.Equals("GreatWall"))
            {
                NotifyPropertyChanged("GreatWall");
            }
            else if (e.PropertyName.Equals("ReallyRich"))
            {
                NotifyPropertyChanged("ReallyRich");
            }
            else if (e.PropertyName.Equals("FakeNews"))
            {
                NotifyPropertyChanged("FakeNews");
            }
            else if (e.PropertyName.Equals("Fired"))
            {
                NotifyPropertyChanged("Fired");
            }
            else if (e.PropertyName.Equals("RandomNoise"))
            {
                NotifyPropertyChanged("RandomNoise");
            }
            else if (e.PropertyName.Equals("Havanas"))
            {
                NotifyPropertyChanged("Havanas");
            }
            else if (e.PropertyName.Equals("BuildWalls"))
            {
                NotifyPropertyChanged("BuildWalls");
            }
        }
        #endregion

        #region INPC Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion NPC Implementation
    }
}
