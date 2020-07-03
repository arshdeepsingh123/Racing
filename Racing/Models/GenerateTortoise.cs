using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
    //Generate Racer type at run time accordint to input racer type
  public static  class GenerateTortoise
    {
        public static Racer FactoryMethod(CommonClass.Racer_Type type)
        {
            switch (type)
            {
                case CommonClass.Racer_Type.Tortoise1: return new Tortoise1();
                case CommonClass.Racer_Type.Tortoise2: return new Tortoise2();
                case CommonClass.Racer_Type.Tortoise3: return new Tortoise3();
                case CommonClass.Racer_Type.Tortoise4: return new Tortoise4();
                default: throw new NotImplementedException("Tortoise Class not found !!!");
            }
        }
    }
}
