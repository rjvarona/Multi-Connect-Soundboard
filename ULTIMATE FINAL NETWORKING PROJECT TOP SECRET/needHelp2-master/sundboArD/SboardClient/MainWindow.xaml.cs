using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;

namespace SBoardClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer _soundPlayer;
        private readonly ClientModel _clientModel;


        public MainWindow()
        {
            _clientModel = new ClientModel();
           
            //pewds.ImageSource = brush;
            InitializeComponent();
        }

        private void China_Click(object sender, RoutedEventArgs e)
        {

            Button obj = sender as Button;

            string _name = obj.Name;

            switch (_name)
            {
                case "China":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\China.wav");
                    _clientModel.Send("China");
                    break;
                case "Wrong":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\Wrong.wav");
                    break;
                case "GreatWall":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\GreatWall.wav");
                    break;
                case "ReallyRich":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\ReallyRich.wav");
                    break;
                case "BingBong":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\BingBong.mp4");


                    break;
                case "FakeNews":
                    _soundPlayer = new SoundPlayer(@"C:\Users\rjvar\Documents\GitHub\needHelp2\soundBBRRDD\wavs\FakeNews.mp3");


                    break;
                default:

                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
