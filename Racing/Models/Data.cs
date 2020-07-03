using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Models
{
    //Interface for Punter and Racer class 
    interface IData
    {
        int ID { get; set; }
        
        string Name { get; set; }
        //Class name of IData object
        string ClassName { get; set; }
        Enum Type { get; set; }
        //It will check type of input enum type
        bool CheckType(Enum type);
    }
}
