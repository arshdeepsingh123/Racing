using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
    //Generate Punter type at run time according to input Punter type
   public static class GeneratePunter
    {
       
        public static Punter FactoryMethod(CommonClass.Punter_Type type)
        {
            switch (type)
            {
                case CommonClass.Punter_Type.Joe: return new Joe();
                case CommonClass.Punter_Type.Bob: return new Bob();
                case CommonClass.Punter_Type.Ali: return new Ali();
                default: throw new NotImplementedException("Punter  Not Defined !!!");
            }
        }
    }
}
