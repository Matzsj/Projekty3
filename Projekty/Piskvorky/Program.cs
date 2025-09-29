using System;

namespace Piskvorky
{
    internal class programdruhy
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                ResetBoard();
                PlayGame();

                Console.Write("Chceš hrát znovu? (a/n): ");
                if (Console.ReadLine()?.ToLower() != "a")
                    break;
                Console.Clear();
            }
        }

        static void PlayGame()
        {
            while (true)
            {
                printBoard();
                PlayerMove();
                if (CheckWin('X')) { printBoard(); Console.WriteLine("Vyhrál jsi! 🎉"); break; }
                if (IsDraw()) { printBoard(); Console.WriteLine("Remíza!"); break; }

                BotMove();
                if (CheckWin('O')) { printBoard(); Console.WriteLine("Bot vyhrál! 🤖"); break; }
                if (IsDraw()) { printBoard(); Console.WriteLine("Remíza!"); break; }
            }
        }

        static void printBoard()
        {
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine();
        }

        static void PlayerMove()
        {
            while (true)
            {
                Console.Write("Zadej číslo (1–9): ");
                if (int.TryParse(Console.ReadLine(), out int pos) && pos >= 1 && pos <= 9)
                {
                    int i = pos - 1;
                    if (board[i] != 'X' && board[i] != 'O')
                    {
                        board[i] = 'X';
                        break;
                    }
                }
                Console.WriteLine("Neplatný tah, zkus to znovu.");
            }
        }

        static void BotMove()
        {
            int pos;
            do { pos = rnd.Next(0, 9); } while (board[pos] == 'X' || board[pos] == 'O');
            board[pos] = 'O';
        }

        static bool CheckWin(char p)
        {
            int[,] wins =
            {
                {0,1,2}, {3,4,5}, {6,7,8},
                {0,3,6}, {1,4,7}, {2,5,8},
                {0,4,8}, {2,4,6}
            };

            for (int i = 0; i < wins.GetLength(0); i++)
            {
                if (board[wins[i, 0]] == p && board[wins[i, 1]] == p && board[wins[i, 2]] == p)
                    return true;
            }
            return false;
        }

        static bool IsDraw()
        {
            foreach (var c in board)
                if (c != 'X' && c != 'O') return false;
            return true;
        }

        static void ResetBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = (char)('1' + i);
        }
    }
}
