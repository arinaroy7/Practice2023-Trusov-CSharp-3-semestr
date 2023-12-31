

namespace TicTacToeNamespace {
    public class TicTacToe
    {
        private char[,] board; //Массив игрового поля
        private char currentPlayer; //Текущий игрок (X или O)
        public TicTacToe()
        {
            board = new char[3, 3];
            SetBoard();
            currentPlayer = 'X'; 
        }

        private void SetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void PlaceMove(int row, int col)
        {
            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                SwitchPlayer();
            }
            else
            {
                Console.WriteLine("Клетка занята. Попробуйте другую.");
            }
        }

        private void SwitchPlayer() 
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
        public bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true;

                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true; 
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;

            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true; 

            return false; 
        }

        public void PrintBoard()
        {
            Console.WriteLine("  0   1   2  ");
            Console.WriteLine("---------------");
            for (int i = 0; i < 3; i++)
        {
            Console.Write($" {i} |");
            for (int j = 0; j < 3; j++)
            {
                char symbol = board[i, j] == ' ' ? '-' : board[i, j];
                Console.Write($" {symbol} |");
            }
        Console.WriteLine("\n-------------");
    }
}


        public char GetCurrentPlayer()

        {
            return currentPlayer;
        }

    }
}
/*
23.11.23 Функцию "рисовать" вынести из класса. Научиться правильно писать классы. 
*/
