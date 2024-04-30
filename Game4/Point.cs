using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game4
{
    internal struct Point
    {
        public int Number;
        public Letters Letter;
        public static bool[,] visited = new bool[8, 8];
        public Point(int Num, Letters Let)
        {
            Number = Num;
            Letter = Let;
        }
        public static bool isValid(int x, int y)
        {
            if (x > 0 && x < 9)
            {
                if (y < 9 && y > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isVisited(int x, Letters y)
        {
            if (!visited[x, Array.IndexOf(Enum.GetValues(y.GetType()), y)])
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
