using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Racing.Models
{
    class PunterModel
    {
        public Image Image { get; private set; }

        private Punter _Punter;
        public string Name { get => _Punter.Name; set { _Punter.Name = value; } }
        public int Money { get => _Punter.Money; private set { _Punter.Money = value; } }
        public const int NOT_BETTING = 0;
        public const int NO_RACER_SELECTED = -1;
        public int RacerID = NO_RACER_SELECTED;
        public int Bet = NOT_BETTING;
        public PunterModel(CommonClass.Punter_Type type, Image image)
        {
            _Punter = GeneratePunter.FactoryMethod(type);
            Image = image;
        }
        public bool Busted { get => (Money > 0 ? true : false); }

        //When Punter win the game add bet money to punter money 
        public void WinGame()
        {
            Money += Bet;
            ResetBet();
        }
        //When Pnter loose the game deduct bet money from Punter money
        public void LoseGame()
        {
            Money -= Bet;
            ResetBet();
        }
        //Reset Bet
        public void ResetBet()
        {
            Bet = NOT_BETTING;
        }
        // Reset Punter
        public void Reset()
        {
            _Punter.Reset();
        }
    }
}
