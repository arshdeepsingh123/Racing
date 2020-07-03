using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
   public abstract class Racer:IData
    {
        public Racer()
        {
            ClassName = "Tortoise";
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public Enum Type { get; set; }
        //Check Type of racer according to racer input type
        public bool CheckType(Enum type)
        {
            return (CommonClass.Racer_Type)Type == (CommonClass.Racer_Type)type;
        }
    }
}
