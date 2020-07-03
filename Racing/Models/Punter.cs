using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
  public abstract class Punter:IData
    {
        public Punter()
        {
            ClassName = "Abstract Punter Class";
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public Enum Type { get; set; }
        // Money that punter will have in hand
        public int Money { get; set; }
       
       

        public bool CheckType(Enum type)
        {
            return (CommonClass.Punter_Type)Type == (CommonClass.Punter_Type)type;
        }
        //Reset the punter money to initial amount
        public abstract void Reset();
    }
}
