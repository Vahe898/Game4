using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;

namespace Game4
{
    internal class Program
    {
        public static void TakingNecessaryPointForRookAndAther(Point ForRook, Point ForKing, ref int[,] arrForRook, int[,] arrForKing)
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arrForKing[i, j] + arrForRook[i, j] > 10)/*ena vor gci vra yngav araji kingy*/
                    {
                        
                        if (ForRook.Number < ForKing.Number && Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) == Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter))/*kingy verevna uxxahayac*/
                        {
                            for (int k = ForKing.Number; k < 8; k++)/*toxer*/
                            {
                                arrForRook[k, j] = 0;
                            }

                        }
                        else if (ForRook.Number > ForKing.Number && Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) == Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter))/*kingy nerqevna uxxahayac*/
                        {
                            for (int k = 0; k <= ForKing.Number; k++)/*toxer*/
                            {
                                arrForRook[k, j] = 0;
                            }
                        }
                        else if (Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) > Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter) && ForRook.Number == ForKing.Number)/*kingy horizonakan depi caxa yngnum*/
                        {
                            for (int k = Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter); k >= 0; k--)/*toxer*/
                            {
                                arrForRook[i, k] = 0;
                            }
                        }
                        else if (Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) < Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter) && ForRook.Number == ForKing.Number)/*kingy horizonakan depi aja yngnum*/
                        {
                            for (int k = Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter); k < 8; k++)/*toxer*/
                            {
                                arrForRook[i, k] = 0;
                            }
                        }
                    }
                }
            }
        }
        public static void TakingNecessaryPointForQueenAndAther(Point ForQueen, Point ForAther, ref int[,] arrForQueen, int[,] arrForAther)
        {

            TakingNecessaryPointForRookAndAther(ForQueen, ForAther, ref arrForQueen, arrForAther);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arrForQueen[i, j] + arrForAther[i, j] > 10)/*ena vor gci vra yngav bayc diaganali*/
                    {
                       
                        if (ForQueen.Number > ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) < Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*diaganalov verev aj queenic*/
                        {
                            for (int k = ForAther.Number; k >= 0; k--)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t < 8; t++)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if ((ForQueen.Number > ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) > Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter)))/*diaganalov depi verev caxa yngnum queenic*/
                        {
                            for (int k = ForAther.Number; k >= 0; k--)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t >= 0; t--)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if (ForQueen.Number < ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) < Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*queenic nerqev aj diaganalov*/
                        {
                            for (int k = ForAther.Number; k < 8; k++)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t < 8; t++)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if (ForQueen.Number < ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) > Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*queenic diaganalov nerqev cax*/
                        {
                            for (int k = ForAther.Number; k < 8; k++)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t >= 0; t--)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                    }

                }
            }
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrForQueen[i, j]);
            //    }
            //    Console.WriteLine();
            //}
        }
        public static void MakeMatric(int inputNumForRedKing, Letters inputLetForRedKing, int inputNumForRedRook, Letters inputLetForRedRook, ref int[,] arrForRedRook, int inputNumForBlueKing, Letters inputLetForBlueKing, int inputNumForRedRook2, Letters inputLetForRedRook2, ref int[,] arrForRedRook2, int inputNumForRedQueen, Letters inputLetForRedQueen, ref int[,] arrForRedQueen)
        {
            King redKing = new King();
            Point PointOfRedKing = new Point(inputNumForRedKing, inputLetForRedKing);
            int[,] arrForRedKing = new int[8, 8];
            redKing.MatricOfKing(PointOfRedKing.Number, PointOfRedKing.Letter, ref arrForRedKing);

            Rook redRook = new Rook();
            Point PointOfRedRook = new Point(inputNumForRedRook, inputLetForRedRook);
            redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);


            King blueKing = new King();
            Point PointOfBlueKing = new Point(inputNumForBlueKing, inputLetForBlueKing);
            int[,] arrForBlueKing = new int[8, 8];
            blueKing.MatricOfKing(PointOfBlueKing.Number, PointOfBlueKing.Letter, ref arrForBlueKing);

            Rook redRook2 = new Rook();
            Point PointOfRedRook2 = new Point(inputNumForRedRook2, inputLetForRedRook2);
            redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);

            Queen redQueen = new Queen();
            Point PointOfRedQueen = new Point(inputNumForRedQueen, inputLetForRedQueen);
            redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);

            
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedKing, ref arrForRedQueen, arrForRedKing);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook, ref arrForRedQueen, arrForRedRook);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook2, ref arrForRedQueen, arrForRedRook2);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfBlueKing, ref arrForRedQueen, arrForBlueKing);
            

            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfRedKing, ref arrForRedRook, arrForRedKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfBlueKing, ref arrForRedRook, arrForBlueKing);
            
            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfRedKing, ref arrForRedRook2, arrForRedKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfBlueKing, ref arrForRedRook2, arrForBlueKing);
            




            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrForRedRook2[i, j]);
            //    }
            //    Console.WriteLine();
            //}

        }

        public static void MakeChessWithMatric(Point PoinntOfRedRook, string inputFigurOfRedRook, Point PointOfRedKing, string inputFigurOfRedKing, Point PoinntOfRedRook2, string inputFigurOfRedRook2, Point PointOfBlueKing, string inputFigurOfBlueKing, Point PointOfRedQueen, string inputFigurOfRedQueen)
        {
            //int[,] arrForRedRook = new int[8, 8];
            //int[,] arrForRedRook2 = new int[8, 8];
            //int[,] arrForRedQueen = new int[8, 8];

            //MakeMatric(PointOfRedKing.Number, PointOfRedKing.Letter, PoinntOfRedRook.Number, PoinntOfRedRook.Letter, ref arrForRedRook, PointOfBlueKing.Number, PointOfBlueKing.Letter, PoinntOfRedRook2.Number, PoinntOfRedRook2.Letter, ref arrForRedRook2, PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);
            //King redKing = new King();
            //int[,] arrForRedKing = new int[8, 8];
            //redKing.MatricOfKing(PointOfRedKing.Number, PointOfRedKing.Letter, ref arrForRedKing);

            //King blueKing = new King();
            //int[,] arrForBlueKing = new int[8, 8];
            //blueKing.MatricOfKing(PointOfBlueKing.Number, PointOfBlueKing.Letter, ref arrForBlueKing);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0 && i < 8)/*tverna tpum*/
                    {
                        Console.Write(i + 1);
                    }
                    else if (i == 8 && j >= 0)/*tareri hamra*/
                    {
                        Console.Write($"  {(Letters)j}");
                    }

                    if ((i + j) % 2 == 0 && i < 8)/*guynenrna*/
                    {

                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    /*karmiri figury*/
                    if (i == PointOfRedKing.Number && (Letters)j == PointOfRedKing.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedKing + "  ");
                    }

                    /*kaputi figury*/
                    else if (i == PoinntOfRedRook.Number && (Letters)j == PoinntOfRedRook.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedRook + "  ");
                    }
                    else if (i == PoinntOfRedRook2.Number && (Letters)j == PoinntOfRedRook2.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedRook2 + "  ");
                    }
                    else if (i == PointOfBlueKing.Number && (Letters)j == PointOfBlueKing.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(inputFigurOfBlueKing + "  ");
                    }
                    else if (i == PointOfRedQueen.Number && (Letters)j == PointOfRedQueen.Letter)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedQueen + "  ");
                    }

                    /*karmiri vandakanishnery*/
                    //else if (i < 8)
                    //{


                    //    if (arrForBlueKing[i, j] + arrForRedKing[i, j] == 2 || arrForBlueKing[i, j] + arrForRedQueen[i, j] == 3 || arrForBlueKing[i, j] + arrForRedRook[i, j] == 3 || arrForBlueKing[i, j] + arrForRedRook2[i, j] == 3)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Green;
                    //        Console.Write(" # ");
                    //    }

                    //    else if (i < 8 && arrForRedRook[i, j] == 2 || arrForRedRook2[i, j] == 2 || arrForRedQueen[i, j] == 2)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Red;
                    //        Console.Write(" # ");
                    //    }
                    //    else if (i < 8 && arrForRedKing[i, j] == 1)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Red;
                    //        Console.Write(" # ");
                    //    }
                    //    else if (i < 8 && arrForBlueKing[i, j] == 1)
                    //    {
                    //        Console.ForegroundColor = ConsoleColor.Blue;
                    //        Console.Write(" # ");
                    //    }

                    else if (i != 8 && j >= 0)
                    {
                        Console.Write("   ");
                    }
                    //}
                }
                Console.ResetColor();
                Console.WriteLine();
            }

        }
        public static void Entering()
        {
            int intOfRedRook;
            Letters LetterOfRedRook = Letters.A;

            int intOfRedRook2;
            Letters LetterOfRedRook2 = Letters.A;

            int intOfRedKing;
            Letters LetterOfRedKing = Letters.A;

            int intOfBlueKing;
            Letters LetterOfBlueKing = Letters.A;

            int intOfRedQueen;
            Letters LetterOfRedQueen = Letters.A;

            Console.WriteLine("Enter number For red Rook");
            if(int.TryParse(Console.ReadLine(),out intOfRedRook))
            {
                if(intOfRedRook<9 && intOfRedRook > 0)
                {
                    Console.WriteLine("Enter letter For red Rook");
                    LetterOfRedRook = (Letters)Enum.Parse(typeof(Letters), Console.ReadLine(), ignoreCase: true);
                }
                else
                {
                    throw new ArgumentException($"Parameter cannot be {intOfRedRook}");
                }
                
                
            }
            Console.WriteLine("Enter number For red Rook2");
            if (int.TryParse(Console.ReadLine(), out intOfRedRook2))
            {
                if (intOfRedRook2 < 9 && intOfRedRook2 > 0)
                {
                    Console.WriteLine("Enter letter For red Rook2");
                    LetterOfRedRook2 = (Letters)Enum.Parse(typeof(Letters), Console.ReadLine(), ignoreCase: true);
                }
                else
                {
                    throw new ArgumentException($"Parameter cannot be {intOfRedRook2}");
                }
            }
            Console.WriteLine("Enter number For red King");
            if (int.TryParse(Console.ReadLine(), out intOfRedKing))
            {
                if (intOfRedKing < 9 && intOfRedKing > 0)
                {
                    Console.WriteLine("Enter letter For red king");
                    LetterOfRedKing = (Letters)Enum.Parse(typeof(Letters), Console.ReadLine(), ignoreCase: true);
                }
                else
                {
                    throw new ArgumentException($"Parameter cannot be {intOfRedKing}");
                }
            }
            Console.WriteLine("Enter number For blue King");
            if (int.TryParse(Console.ReadLine(), out intOfBlueKing))
            {
                if (intOfBlueKing < 9 && intOfBlueKing > 0)
                {
                    Console.WriteLine("Enter letter For blue king");
                    LetterOfBlueKing = (Letters)Enum.Parse(typeof(Letters), Console.ReadLine(), ignoreCase: true);
                }
                else
                {
                    throw new ArgumentException($"Parameter cannot be {intOfBlueKing}");
                }
            }
            Console.WriteLine("Enter number For red Queen");
            if (int.TryParse(Console.ReadLine(), out intOfRedQueen))
            {
                if (intOfRedQueen < 9 && intOfRedQueen > 0)
                {
                    Console.WriteLine("Enter letter For red Queen");
                    LetterOfRedQueen = (Letters)Enum.Parse(typeof(Letters), Console.ReadLine(), ignoreCase: true);
                }
                else
                {
                    throw new ArgumentException($"Parameter cannot be {intOfRedQueen}");
                }
            }
            Point PointOfRedRook2 = new Point(intOfRedRook2-1, LetterOfRedRook2);
            Point PointOfRedKing = new Point(intOfRedKing - 1, LetterOfRedKing);
            Point PointOfRedRook = new Point(intOfRedRook-1, LetterOfRedRook);
            Point PointOfBlueKing = new Point(intOfBlueKing-1, LetterOfBlueKing);
            Point PointOfRedQueen = new Point(intOfRedQueen-1, LetterOfRedQueen);
            int[,] arrForRedRook = new int[8, 8];
            int[,] arrForRedRook2 = new int[8, 8];
            int[,] arrForRedQueen = new int[8, 8];
            DoingMat(ref PointOfRedRook2, ref PointOfRedKing, ref PointOfRedRook, ref PointOfBlueKing, ref PointOfRedQueen, ref arrForRedRook, ref arrForRedRook2,  ref arrForRedQueen);
            MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");
        }
        public static void MatPoints(ref Point PointOfSmth, ref Point PointOfBlueKing, int[,] arrForSmth, int[,] arrForElse, int[,] arrForElse1,int stop,int a)/*a ov asum em kingi vor koxmy*/
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (stop < 1)
                    {
                        if (arrForSmth[i, j] == 2 && j == Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + a )
                        {
                            if (i > PointOfBlueKing.Number + 1 || i < PointOfBlueKing.Number - 1)
                            {
                                if(arrForElse[i, j] != 2 && arrForElse1[i, j] != 2)
                                {
                                    PointOfSmth.Letter = (Letters)j;
                                    PointOfSmth.Number = i;
                                    stop++;
                                }
                                else
                                {
                                    PointOfSmth.Letter = (Letters)j;
                                    PointOfSmth.Number = i;
                                    
                                }
                                
                                
                            }
                        }
                    }
                }
            }
        }
        public static void KeepingFriend(ref Point PointOfDanger,ref Point PointOfKiper,ref Point PointOfKiper2,ref Point PointOfBlueKng,ref int[,] arrOfDanger,ref int[,] arrOfKeeper,ref int[,] arrOfKeeper2 , int[,] arrOfKing)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arrOfKing[i, j] == 1 && arrOfDanger[i, j] == 9)
                    {

                        for (int t = 0; j < 8; t++)
                        {
                            if (arrOfKeeper[i, t] == 2)/*horizionakov enq pahum*/
                            {
                                PointOfKiper.Number = i;
                                PointOfKiper.Letter = (Letters)t;
                                break;
                            }
                            else if (arrOfKeeper2[i, t] == 2)/*horizionakov enq pahum*/
                            {
                                PointOfKiper2.Number = i;
                                PointOfKiper2.Letter = (Letters)t;
                                break;
                            }
                            else if (arrOfKeeper[t, j] == 2)
                            {
                                PointOfKiper.Number = t;
                                PointOfKiper.Letter = (Letters)j;
                                break;
                            }
                            else if (arrOfKeeper2[t, j] == 2)
                            {
                                PointOfKiper2.Number = t;
                                PointOfKiper2.Letter = (Letters)j;
                                break;
                            }
                        }

                    }
                }
            }
        }
        public static void rechPoint(ref Point PointOfSmth,Point PointOfReching,Point PointOfElse, Point PointOfElse2, Point PointOfRedKing,Point PointOfBlueKing, ref int[,] arrOfSmth, int[,] arrOfReching,  int[,] arrOfElse,  int[,] arrOfElse2, int[,] arrOfRedKing, int[,] arrOfBlueKing , ref int count)
        {
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfRedKing, ref arrOfSmth, arrOfRedKing);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfBlueKing, ref arrOfSmth, arrOfBlueKing);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfElse, ref arrOfSmth, arrOfElse);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfElse2, ref arrOfSmth, arrOfElse2);

            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfRedKing, ref arrOfReching, arrOfRedKing);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfBlueKing, ref arrOfReching, arrOfBlueKing);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfElse, ref arrOfReching, arrOfElse);
            TakingNecessaryPointForRookAndAther(PointOfSmth, PointOfElse2, ref arrOfReching, arrOfElse2);
            count = 0;
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (count < 1)
                    {
                        if (arrOfSmth[i, j] == arrOfReching[i, j] && arrOfSmth[i, j] == 2)
                        {
                            PointOfSmth.Number = i;
                            PointOfSmth.Letter = (Letters)j;
                            count++;
                            break;
                        }
                    }
                }
                
            }
        }
        public static void  DoingMat(ref Point PointOfRedRook2,ref  Point PointOfRedKing,ref Point PointOfRedRook, ref Point PointOfBlueKing,ref Point PointOfRedQueen, ref int[,] arrForRedRook, ref int[,] arrForRedRook2, ref int[,] arrForRedQueen)
        {
            King redKing = new King();           
            int[,] arrForRedKing = new int[8, 8];
            redKing.MatricOfKing(PointOfRedKing.Number, PointOfRedKing.Letter, ref arrForRedKing);

            Rook redRook = new Rook();            
            redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);


            King blueKing = new King();          
            int[,] arrForBlueKing = new int[8, 8];
            blueKing.MatricOfKing(PointOfBlueKing.Number, PointOfBlueKing.Letter, ref arrForBlueKing);

            Rook redRook2 = new Rook();           
            redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);

            Queen redQueen = new Queen();          
            redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);

            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedKing, ref arrForRedQueen, arrForRedKing);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook, ref arrForRedQueen, arrForRedRook);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook2, ref arrForRedQueen, arrForRedRook2);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfBlueKing, ref arrForRedQueen, arrForBlueKing);



            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfRedKing, ref arrForRedRook, arrForRedKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfBlueKing, ref arrForRedRook, arrForBlueKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfRedRook2, ref arrForRedRook, arrForRedRook2);
            TakingNecessaryPointForRookAndAther(PointOfRedRook, PointOfRedQueen, ref arrForRedRook, arrForRedQueen);



            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfRedKing, ref arrForRedRook2, arrForRedKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfBlueKing, ref arrForRedRook2, arrForBlueKing);
            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfRedRook2, ref arrForRedRook2, arrForRedRook2);
            TakingNecessaryPointForRookAndAther(PointOfRedRook2, PointOfRedQueen, ref arrForRedRook2, arrForRedQueen);

            int stopQueen = 0;
            int stopRook = 0;
            int stopRook2 = 0;

            
            
            if(PointOfRedRook.Number>= PointOfBlueKing.Number -1 && PointOfRedRook.Number <= PointOfBlueKing.Number + 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) >= Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) -1 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) <= Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
            {
                KeepingFriend(ref PointOfRedRook, ref PointOfRedQueen, ref PointOfRedRook2, ref PointOfBlueKing, ref arrForRedRook, ref arrForRedQueen, ref arrForRedRook2, arrForBlueKing);
                redRook2.CleanMatric(ref arrForRedRook2);
                redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook);
                redQueen.CleanMatric(ref arrForRedQueen);
                redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);

                MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");

            }
            else if (PointOfRedRook2.Number >= PointOfBlueKing.Number - 1 && PointOfRedRook2.Number <= PointOfBlueKing.Number + 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) >= Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) <= Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
            {
                KeepingFriend(ref PointOfRedRook2, ref PointOfRedQueen, ref PointOfRedRook, ref PointOfBlueKing, ref arrForRedRook2, ref arrForRedQueen, ref arrForRedRook, arrForBlueKing);
                redRook.CleanMatric(ref arrForRedRook);
                redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);
                redQueen.CleanMatric(ref arrForRedQueen);
                redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);

                MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");

            }
            /*nayum enq aj koxmy paga te che*/
            else if (Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)+1 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)/*taguhin paguma ajic*/
            {
                for (int i = 0; i < 8; i++)
                {
                    
                    if(arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 2)
                    {
                        MatPoints(ref PointOfRedRook, ref PointOfBlueKing, arrForRedRook, arrForRedQueen, arrForRedRook2, stopQueen,1);
                        redRook.CleanMatric(ref arrForRedRook);
                        redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);
                        break;
                    }
                    else if(arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 2)
                    {
                        MatPoints(ref PointOfRedRook2, ref PointOfBlueKing, arrForRedRook2, arrForRedRook, arrForRedQueen, stopQueen, 1);
                        redRook2.CleanMatric(ref arrForRedRook2);
                        redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);
                        break;
                    }
                    else if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 2)
                    {
                        MatPoints(ref PointOfRedQueen, ref PointOfBlueKing, arrForRedQueen, arrForRedRook, arrForRedRook2, stopQueen, 1);
                        redQueen.CleanMatric(ref arrForRedQueen);
                        redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);
                        break;
                    }
                }
                
                 MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");
            }
            
            
            
            /*nayum enq caxy paga te che*/
            else if (Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) -1 )
            {
                for (int i = 0; i < 8; i++)
                {
                   
                    if(arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
                    {
                        MatPoints(ref PointOfRedRook, ref PointOfBlueKing, arrForRedRook, arrForRedQueen, arrForRedRook2, stopRook,-1);
                        redRook.CleanMatric(ref arrForRedRook);
                        redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);
                        break;
                    }
                    else if(arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
                    {
                        MatPoints(ref PointOfRedRook2, ref PointOfBlueKing, arrForRedRook2, arrForRedRook, arrForRedQueen, stopRook2, -1);
                        redRook2.CleanMatric(ref arrForRedRook2);
                        redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);
                        break;
                    }
                    else if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
                    {
                        MatPoints(ref PointOfRedQueen, ref PointOfBlueKing, arrForRedQueen, arrForRedRook, arrForRedRook2, stopQueen, -1);
                        redQueen.CleanMatric(ref arrForRedQueen);
                        redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);
                        break;
                    }
                }
                MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");

            }
            /*mejtexnenq pagum*/
            else if (Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter))
            {
                int sit = 0;
                for (int i = 0; i < 8; i++)
                {

                    if (arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1)
                    {
                        MatPoints(ref PointOfRedRook, ref PointOfBlueKing, arrForRedRook, arrForRedQueen, arrForRedRook2, stopRook, 0);
                        redRook.CleanMatric(ref arrForRedRook);
                        redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);
                        break;
                    }
                    else if (arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1 && Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1)
                    {
                        MatPoints(ref PointOfRedRook2, ref PointOfBlueKing, arrForRedRook2, arrForRedRook, arrForRedQueen, stopRook2, 0);
                        redRook2.CleanMatric(ref arrForRedRook2);
                        redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);
                        break;
                    }
                    else if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)] == 2 && Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1 && Array.IndexOf(Enum.GetValues(PointOfRedQueen.Letter.GetType()), PointOfRedQueen.Letter) != Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1)
                    {
                        MatPoints(ref PointOfRedQueen, ref PointOfBlueKing, arrForRedQueen, arrForRedRook, arrForRedRook2, stopQueen, 0);
                        redQueen.CleanMatric(ref arrForRedQueen);
                        redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);
                        break;
                    }
                    else if (i ==7)
                    {
                        if (Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) < Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1 || Array.IndexOf(Enum.GetValues(PointOfRedRook.Letter.GetType()), PointOfRedRook.Letter) > Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
                        {

                            for (int j = 0; j < 8; j++)
                            {
                                int count = 0;
                                Point pointOfReching = new Point(i, PointOfBlueKing.Letter);
                                int[,] arr = new int[8, 8];
                                Rook rechingRook = new Rook();
                                rechingRook.MatricOfRook(pointOfReching.Number, pointOfReching.Letter, ref arr);

                                rechPoint(ref PointOfRedRook, pointOfReching, PointOfRedQueen, PointOfRedRook2, PointOfRedKing, PointOfBlueKing, ref arrForRedRook, arr, arrForRedQueen, arrForRedRook2, arrForRedKing, arrForBlueKing, ref count);
                                if (count > 0)
                                {
                                    break;
                                }
                            }

                        }
                        else if (Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) < Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) - 1 || Array.IndexOf(Enum.GetValues(PointOfRedRook2.Letter.GetType()), PointOfRedRook2.Letter) > Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1)
                        {

                            for (int j = 0; j < 8; j++)
                            {
                                int count = 0;
                                Point pointOfReching = new Point(i, PointOfBlueKing.Letter);
                                int[,] arr = new int[8, 8];
                                Rook rechingRook = new Rook();
                                rechingRook.MatricOfRook(pointOfReching.Number, pointOfReching.Letter, ref arr);

                                rechPoint(ref PointOfRedRook2, pointOfReching, PointOfRedQueen, PointOfRedRook, PointOfRedKing, PointOfBlueKing, ref arrForRedRook2, arr, arrForRedQueen, arrForRedRook, arrForRedKing, arrForBlueKing, ref count);
                                if (count > 0)
                                {
                                    break;
                                }
                            }

                        }
                    }
                    
                        
                    

                }
                MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");
            }
            
            //else if()
            int mat = 0;
            for(int i = 0; i < 8; i++)
            {
                if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)]==9 || arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)]==9|| arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)] == 9)
                {
                    mat++;
                }
                if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) -1] == 9 || arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)-1] == 9 || arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter)-1] == 9)
                {
                    mat++;
                }
                if (arrForRedQueen[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 9 || arrForRedRook[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 9 || arrForRedRook2[i, Array.IndexOf(Enum.GetValues(PointOfBlueKing.Letter.GetType()), PointOfBlueKing.Letter) + 1] == 9)
                {
                    mat++;
                }
            }
            if(mat == 3)
            {
                Console.WriteLine(  "mat");
                               
            }
            else
            {
                blueKing.kingIsMoving(ref PointOfBlueKing.Number, ref PointOfBlueKing.Letter);
                blueKing.MatricOfKing(PointOfBlueKing.Number, PointOfBlueKing.Letter, ref arrForBlueKing);
                MakeChessWithMatric(PointOfRedRook, "r", PointOfRedKing, "k", PointOfRedRook2, "r", PointOfBlueKing, "k", PointOfRedQueen, "q");
                DoingMat(ref PointOfRedRook2, ref PointOfRedKing, ref PointOfRedRook, ref PointOfBlueKing, ref PointOfRedQueen, ref arrForRedRook, ref arrForRedRook2, ref arrForRedQueen);

            }
            

        }
        static void Main(string[] args)
        {
            int[,] arr = new int[8, 8];
            int[,] arr2 = new int[8, 8];
            int[,] arr3 = new int[8, 8];
            Point PoinntOfRedRook2 = new Point(1, Letters.E);
            
            Point PoinntOfRedRook = new Point(3, Letters.D);
            
            Point PoinntOfRedQueen = new Point(6, Letters.H);
            Point PointOfRedKing = new Point(5, Letters.C);
            Point PointOfBlueKing = new Point(4, Letters.F);
            ////MakeMatric(PointOfRedKing.Number, PointOfRedKing.Letter, PoinntOfRedRook.Number, PoinntOfRedRook.Letter, ref arr, PointOfBlueKing.Number, PointOfBlueKing.Letter, PoinntOfRedRook2.Number, PoinntOfRedRook2.Letter, ref arr2, PoinntOfRedQueen.Number, PoinntOfRedQueen.Letter, ref arr3);
            MakeChessWithMatric(PoinntOfRedRook, "r", PointOfRedKing, "k", PoinntOfRedRook2, "r", PointOfBlueKing, "k", PoinntOfRedQueen, "q");
            //Entering();
            DoingMat(ref PoinntOfRedRook2, ref PointOfRedKing, ref PoinntOfRedRook, ref PointOfBlueKing, ref PoinntOfRedQueen, ref arr, ref arr2, ref arr3);


           
            //Console.WriteLine(  );
            //Console.WriteLine(  );
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arr2[i, j]);
            //    }
            //    Console.WriteLine();
            //}


        }
    }
}

