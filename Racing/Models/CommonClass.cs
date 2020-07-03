using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
  public  static class CommonClass
    {
        //To define parameters of game like Racer type ,Speed and punter type
        public enum Game_Parameter_Type { Racer_Type, Speed, Punter_Type };
       
        //To define the racer type and no
        public enum Racer_Type { Tortoise1, Tortoise2, Tortoise3, Tortoise4 };
        //To fix the speed of the game according to level
        public enum Speed { Level_1, Level_2, Level_3, Level_4 };
        //Define type of Punter who will bet on racer
        public enum Punter_Type { Joe, Bob, Ali };
    }
}
