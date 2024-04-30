using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game4
{
    internal class Queen 
    {
        private int _numberForQueen;
        private Letters _letterForQueen;

        public int NumberForQueen
        {
            get
            {
                return _numberForQueen;
            }
            set
            {
                if (value > 0 && value < 9)
                {
                    _numberForQueen = value;
                }
                else
                {
                    throw new ArgumentException($"{value} is not correct");
                }
            }
        }
        public Letters LetterForQueen
        {
            get
            {
                return _letterForQueen;

            }
            set
            {
                if (Enum.IsDefined(typeof(Letters), value))/*senc nayum em tenam tvacs enumis meja te che*/
                {
                    _letterForQueen = (Letters)Enum.Parse(typeof(Letters), value.ToString().ToUpper());/*tvacs tary vory stringa darcnuma enum*/
                }
                else
                {
                    throw new ArgumentException($"{value} is not correct");
                }
            }
        }
        public void MatricOfQueen(int inputNum, Letters inputLet, ref int[,] arr)
        {
            Point PointOfQueen = new Point(inputNum, inputLet);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((inputNum == i && inputLet == (Letters)(j)))
                    {
                        arr[i, j] = 9;
                    }
                    else if (PointOfQueen.Number == i && Array.IndexOf(Enum.GetValues(PointOfQueen.Letter.GetType()), PointOfQueen.Letter) != Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), (Letters)j))
                    {
                        arr[i, j] = 2;
                    }
                    /*uxxahayaca etum nuyn cev*/
                    else if (NumberForQueen != inputNum && Array.IndexOf(Enum.GetValues(PointOfQueen.Letter.GetType()), PointOfQueen.Letter) == Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), (Letters)j))
                    {
                        arr[i, j] = 2;
                    }
                    else if (Math.Abs(PointOfQueen.Number - i) == Math.Abs(Array.IndexOf(Enum.GetValues(PointOfQueen.Letter.GetType()), PointOfQueen.Letter) - Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), (Letters)j)))
                    {
                        arr[i, j] = 2;
                    }


                }

            }

           
        }
        public void CleanMatric(ref int[,] arr)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arr[i, j] = 0;
                }

            }
        }
    }
}
