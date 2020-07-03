using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Racing.Models
{
  public class RacerModel
    {
        public int Lane { get; set; }
        public Image Image { get; private set; }
        public string Name { get => _Racer.Name; set { _Racer.Name = value; } }
        private Racer _Racer;
        public CommonClass.Speed Speed { get; set; }
        //Set speed of racer according to level
        public int Pace
        {
            get
            {
                switch (Speed)
                {
                    case CommonClass.Speed.Level_1: return 4;
                    case CommonClass.Speed.Level_2: return 6;
                    case CommonClass.Speed.Level_3: return 8;
                    case CommonClass.Speed.Level_4: return 10;
                    default: throw new NotImplementedException();
                }
            }
        }
        //Initialize the Racer type and image
        public RacerModel(CommonClass.Racer_Type racer_type, Image image)
        {
            _Racer = GenerateTortoise.FactoryMethod(racer_type);
            //_Type = racer_type;
            Image = image;
        }
        public bool CheckIsSame(Enum type)
        {
            return _Racer.CheckType(type);
        }

    }
}
