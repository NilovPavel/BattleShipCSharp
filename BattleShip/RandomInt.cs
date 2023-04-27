using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip
{
    public class RandomInt
    {
        public static int GetRandom(int maxValue)
        {
            int value = (int) (DateTime.Now.Ticks % (long)maxValue);
            return value;
        }
    }
}
