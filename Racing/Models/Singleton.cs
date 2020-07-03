using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
    public sealed class RandomGenerator
    {
        //To generate random speed for tortoise and punter
        private static readonly Lazy<RandomGenerator> lazy = new Lazy<RandomGenerator>(() => new RandomGenerator());
        public static RandomGenerator Instance { get { return lazy.Value; } }

        private Random _random;
        public Random Seed { get { return _random; } }
        private RandomGenerator()
        {
            _random = new Random(System.DateTime.Now.Millisecond);
        }

        //Generate a random sequence according to input parameter
        public IEnumerable<Enum> GetRandomSequence(CommonClass.Game_Parameter_Type type)
        {
            switch (type)
            {
                //Return random tortoise type
                case CommonClass.Game_Parameter_Type.Racer_Type:
                    return Enum.GetValues(typeof(CommonClass.Racer_Type)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                //Return  speed of racer
                case CommonClass.Game_Parameter_Type.Speed:
                    return Enum.GetValues(typeof(CommonClass.Speed)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                //Return random Punter type
                case CommonClass.Game_Parameter_Type.Punter_Type:
                    return Enum.GetValues(typeof(CommonClass.Punter_Type)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                default: throw new NotImplementedException();
            }
        }
    }
}
    