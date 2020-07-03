using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using Racing.Models;

namespace Racing
{
   //Game logic
    public partial class MainWindow : Window
    {
        //Set total racer count to 4
        private const int racer_count = 4;
        private List<(double Top, double Left)> _RacerPositionList = new List<(double, double)>();
        private List<RacerModel> _RacerModelList = new List<RacerModel>();
        private List<dynamic> _PunterModelList = new List<dynamic>();
        DispatcherTimer timer;
        //Initialize the Timer,Punter and Racer
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            InitializePunterModel();
            InitializeRacerModel();
            Randomize();

        }
        private void InitializeTimer()
        {
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50)
                
            };
        }
        //Set image of punter and add it to list
        private void InitializePunterModel()
        {
            int i = 0;
            foreach (CommonClass.Punter_Type punter in RandomGenerator.Instance.GetRandomSequence(CommonClass.Game_Parameter_Type.Punter_Type))
            {
                string name = "";
                string imageURL = "";
                //Image image;
                switch (++i)
                {
                    case 1:
                        name = "Bob";
                        imageURL = "image/bob.png";
                        break;
                    case 2:
                        name = "Joe";
                        imageURL = "image/joe.png";
                        break;
                    case 3:
                        name = "Ali";
                        imageURL = "image/ali.png";
                        break;
                    default: throw new NotImplementedException("Punter Class Not Defined !!!");
                }

                //Image image = GetPunterImage(imageURL);
                PunterModel model = new PunterModel(punter, GetPunterImage(imageURL));
                model.Name = name;

                _PunterModelList.Add(new { ImageSource = model.Image.Source, Model = model });
            }
            PunterListView.ItemsSource = _PunterModelList;
        }
        //Retrive Punter Image
        private Image GetPunterImage(string imageURL)
        {
            Image image = new System.Windows.Controls.Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(imageURL, UriKind.Relative);
            bi.DecodePixelHeight = 50;
            bi.DecodePixelWidth = 65;
            bi.EndInit();
            image.Source = bi;
            return image;
        }
        //Set racer image and type
        private void InitializeRacerModel()
        {
            Image image;
            CommonClass.Racer_Type type;
            for (int i = 0; i < racer_count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        image = Tortoise1;
                        type = CommonClass.Racer_Type.Tortoise1;
                        break;
                    case 2:
                        image = Tortoise2;
                        type = CommonClass.Racer_Type.Tortoise2;
                        break;
                    case 3:
                        image = Tortoise3;
                        type = CommonClass.Racer_Type.Tortoise3;
                        break;
                    case 4:
                        image = Tortoise4;
                        type = CommonClass.Racer_Type.Tortoise4;
                        break;
                    default: throw new NotImplementedException("Racer Image on screen Not Implemented");
                }

                //image.MouseDown += (sender, e) => RacerImage_MouseDown(image, e) ;
                _RacerPositionList.Add((Convert.ToInt64(image.GetValue(Canvas.TopProperty)),
                                        Convert.ToInt64(image.GetValue(Canvas.LeftProperty))));

                RacerModel racer = new RacerModel(type, image);
                racer.Image.MouseDown += (sender, e) => RacerImage_MouseDown(racer, e);

                _RacerModelList.Add(racer);

                timer.Tick += (sender, e) => Timer_Tick_Method(racer, e);
            }
        }
        //Check when racer hit the finish line and then check who win the game
        private void Timer_Tick_Method(RacerModel racer, EventArgs e)
        {
            Image image = racer.Image;
            long Left = Convert.ToInt64(image.GetValue(Canvas.LeftProperty));
            int pace = racer.Pace;
            if (Left >= ImageBackground.Width - image.Width)
            {
                timer.Stop();
               
                MessageBox.Show($"{racer.Name} has won!!!");
                //int id = int.Parse(racer.Name.Substring(6));
                CheckForWinner(racer.Lane);
                Randomize();
            }
            else
            {
                Canvas.SetLeft(image, Left + pace);
            }
        }
        //Check Punter winner and add or subtract bet money from their money.
        private void CheckForWinner(int winner_id)
        {
            foreach (dynamic item in _PunterModelList)
            {
                
                PunterModel punter = item.Model;
                
                if (punter.RacerID != PunterModel.NO_RACER_SELECTED)
                {
                   
                    if (punter.RacerID == winner_id)
                    {
                        punter.WinGame();

                       
                        if (punter.Name == "Bob")
                        {
                            BobBet.Content = "Bob has won the race";
                        }
                        if (punter.Name == "Joe")
                        {
                            JoeBet.Content = "Joe has won the race";
                        }
                        if (punter.Name == "Ali")
                        {
                            AliBet.Content = "Ali has won the race";
                        }
                    }
                    else
                    {
                        punter.LoseGame();
                        if(punter.Name=="Bob")
                        {
                            BobBet.Content = "Bob has lost the race"; 
                        }
                        if (punter.Name == "Joe")
                        {
                            JoeBet.Content = "Joe has lost the race";
                        }
                        if (punter.Name == "Ali")
                        {
                            AliBet.Content = "Ali has lost the race";
                        }



                    }
                }
                if(punter.Name=="Bob")
                {
                    if(punter.Money==0)
                    {
                        BobBet.Content = "Bob busted";
                        BobBet.Foreground = Brushes.Red;
                    }
                }
                if (punter.Name == "Joe")
                {
                    if (punter.Money == 0)
                    {
                        JoeBet.Content = "Joe busted";
                                   
                       JoeBet.Foreground = Brushes.Red;
                    }
                }
                if (punter.Name == "Ali")
                {
                    if (punter.Money == 0)
                    {
                        AliBet.Content = "Ali busted";
                        AliBet.Foreground = Brushes.Red;
                    }
                }
            }
        }
        private void Randomize()
        {
            RandomizeRacerPosition();
            RandomizeRacerPace();
        }

        private void RandomizeRacerPosition()
        {
            int i = 0;
            foreach (var type in RandomGenerator.Instance.GetRandomSequence(CommonClass.Game_Parameter_Type.Racer_Type))
            {
                (double Top, double Left) = _RacerPositionList[i];
                foreach (var racer in _RacerModelList)
                {
                    if (racer.CheckIsSame(type))
                    {
                        Canvas.SetTop(racer.Image, Top);
                        Canvas.SetLeft(racer.Image, Left);

                        racer.Lane = ++i;
                        racer.Name = "Racer " + i;
                        break;
                    }
                }
            }
        }
        private void RandomizeRacerPace()
        {
            int i = 0;
            foreach (CommonClass.Speed value in RandomGenerator.Instance.GetRandomSequence(CommonClass.Game_Parameter_Type.Speed))
            {
                _RacerModelList[i++].Speed = value;
            }
        }
        //Show image and name of racer for which punter has bet
        private void RacerImage_MouseDown(RacerModel model, MouseButtonEventArgs e)
        {
            Image image = model.Image;
            SelectedRacer.Source = image.Source;
            SelectedRacerName.Content = "Tortoise " + model.Lane;
        }
        private void PunterListView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (PunterListView.SelectedIndex == -1) return;

            dynamic Content = (sender as ListBoxItem).Content;
            PunterModel model = Content.Model as PunterModel;
            

            if (model.RacerID != PunterModel.NO_RACER_SELECTED)
            {
                RacerModel racer = GetRaceModel(model.RacerID);
                SelectedRacer.Source = racer.Image.Source;
                SelectedRacerName.Content = "Tortoise " + racer.Lane; ;
            }
            else
            {
                SelectedRacer.Source = null;
                SelectedRacerName.Content = string.Empty;
            }
          
         
            BetSlider.Maximum = model.Money;
            
            if (model.Bet > 0)
            {
               
                
                    MoneyLabel.Content = model.Bet;
                    BetSlider.Value = model.Bet;
                
            }
            else
            {
                BetSlider.Value = model.Money;
                MoneyLabel.Content = model.Money;
            }
        }
        //Change the value of bet on slider
        private void BetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MoneyLabel.Content = BetSlider.Value;

        }
        //Exit Game
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Start the game
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            // Clear field
       
            ResetField();
        }
       //Set Betting for punter 
        private void BettingButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRacerName.Content.ToString() != string.Empty)
            {

                if (PunterListView.SelectedIndex > -1)
                {
                    dynamic Content = PunterListView.SelectedItem;
                    PunterModel model = Content.Model as PunterModel;
                    
                    model.Bet = Convert.ToInt32(BetSlider.Value);
                    model.RacerID = int.Parse(SelectedRacerName.Content.ToString().Substring(8));
                    if(PunterListView.SelectedIndex==0)
                    {
                        if (model.Money == 0)
                        {
                            MessageBox.Show("you are busted and cannot bet");
                            BobBet.Content = "You are busted and cannot bet";
                           
                        }
                        else
                        {
                            BobBet.Content = "Bob has placed $" + model.Bet + " on " + SelectedRacerName.Content;
                        }
                    }
                    if (PunterListView.SelectedIndex == 1)
                    {
                        if (model.Money == 0)
                        {
                            MessageBox.Show("you are busted and cannot bet");
                            JoeBet.Content = "You are busted and cannot bet";

                        }
                        else
                        {
                            JoeBet.Content = "Joe has placed $" + model.Bet + " on " + SelectedRacerName.Content;
                        }
                    }
                    if (PunterListView.SelectedIndex == 2)
                    {
                        if (model.Money == 0)
                        {
                            MessageBox.Show("you are busted and cannot bet");
                            AliBet.Content = "You are busted and cannot bet";

                        }
                        else
                        {
                            AliBet.Content = "Ali has placed $" + model.Bet + " on " + SelectedRacerName.Content;
                        }
                    }
                    if (model.Bet == 0)
                    {
                        
                        model.RacerID = PunterModel.NO_RACER_SELECTED;
                    }
                }
            }
            ResetField();
        }
        private void ResetField()
        {
            SelectedRacer.Source = null;
            SelectedRacerName.Content = string.Empty;
            MoneyLabel.Content = string.Empty;
            PunterListView.SelectedIndex = -1;
            BetSlider.Value = 0;
        }
        private RacerModel GetRaceModel(int racerID)
        {
            for (int i = 0; i < racer_count; i++)
            {
                if (_RacerModelList[i].Lane == racerID)
                    return _RacerModelList[i];
            }
            throw new Exception("Error !!!");
        }
        //It will reset the game to original state
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _PunterModelList.Count; i++)
            {
                dynamic punter = _PunterModelList[i];
                punter.Model.Reset();
            }
            BobBet.Content = "Bob has not placed any bet";
            JoeBet.Content = "Joe has not placed any bet";
            AliBet.Content = "Ali has not placed any bet";
            BobBet.Foreground = Brushes.Black;
            JoeBet.Foreground = Brushes.Black;
            AliBet.Foreground = Brushes.Black;

        }


    }
}
