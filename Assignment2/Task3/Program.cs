using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TBCAcademyCsharp.Assignment_02
{
    internal class Task03
    { 
        public void Main(String[] args)
        {
            Run();
        }


        public class Move
        {
            private enum MoveValue
            {
                Rock = 0,
                Paper,
                Scissors
            }
            MoveValue moveValue;


            public Move(int moveValueInt)
            {
                this.moveValue = (MoveValue)moveValueInt;
            }

            public Move(string moveValueStr)
            {
                if (moveValueStr.ToLower() == "rock")
                    this.moveValue = MoveValue.Rock;
                else if (moveValueStr.ToLower() == "paper")
                    this.moveValue = MoveValue.Paper;
                else if (moveValueStr.ToLower() == "scissors")
                {
                    this.moveValue = MoveValue.Scissors;
                }
                else throw new Exception();
            }
            public static bool operator >(Move a, Move b)
            {
                if (a == b)
                    return false;
                if (a.moveValue == MoveValue.Rock)
                {
                    if (b.moveValue == MoveValue.Paper)
                        return false;
                    return true;
                }
                else if (a.moveValue == MoveValue.Paper) //else isn't needed
                {
                    if (b.moveValue == MoveValue.Scissors)
                        return false;
                    return true;
                }
                else if (a.moveValue == MoveValue.Scissors)
                {
                    if (b.moveValue == MoveValue.Rock)
                        return false;
                    return true;
                }
                return false;
            }
            public static bool operator <(Move a, Move b)
            {
                if (a == b)
                    return false;
                return !(a > b);
            }

            public static bool operator ==(Move a, Move b)
            {
                return a.moveValue == b.moveValue;
            }

            public static bool operator !=(Move a, Move b)
            {
                return !(a == b);
            }

            public string ToString()
            {
                return this.moveValue.ToString();
            }


        }
        public static void Run()
        {
            Random rand = new Random();
            while (true)
            {
                try
                {

                    Console.WriteLine("Enter your move \n(q) to quit");
                    string playerMoveStr = Console.ReadLine();
                    if (playerMoveStr.ToLower() == "q")
                        break;
                    Move playerMove = new Move(playerMoveStr);
                    Move cpuMove = new Move(rand.Next(3));

                    Console.WriteLine("Computer played " + cpuMove.ToString());
                    Console.WriteLine("Player played " + playerMove.ToString());

                    if (playerMove == cpuMove)
                    {
                        Console.WriteLine("Draw!");
                    }
                    else if (playerMove > cpuMove)
                    {
                        Console.WriteLine("You win!");
                    }
                    else
                    {
                        Console.WriteLine("You lose!");
                    }
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Enter Rock, Paper, or Scissors!\n");
                }

            }
        }
    }
}
