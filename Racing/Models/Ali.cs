using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
    public class Ali:Punter
    {
        //Initialize the Ali Punter
        public Ali()
        {
            ClassName = "Ali";
            Money = 50;
            Type = CommonClass.Punter_Type.Ali;
        }
        //Reset Money back to initial value
        public override void Reset()
        {
            Money = 50;
        }
        //Retrive money in hand 
        public int GetMoney()
        {
            return Money;
        }


    }
}
