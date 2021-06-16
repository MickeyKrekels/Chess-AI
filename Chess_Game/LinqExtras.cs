using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Game
{
    public static class LinqExtras
    {

            public static T IfDefaultGiveMe<T>(this T value, T alternate)
            {
                if (value.Equals(default(T))) return alternate;
                return value;
            }
    }
    
}
