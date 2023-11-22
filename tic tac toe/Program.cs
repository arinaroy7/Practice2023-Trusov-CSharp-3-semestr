/* 09.11.2023 Избавление классов от зависимости 
Задание: класс, в котором есть методы, с помощью которых можно в этот класс заглянуть 
нужно реализовать класс крестики и нолики - Будет функция поставить фигуру на какую-либо клетку. 2 .. будет ничья или не ничья  
Игровая функция, получить не получить ячейку*/

using System;

namespace TicTacToeNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();

            while (!game.IsDraw() && !game.CheckWin())
            {
                game.PrintBoard();

                Console.WriteLine($"Ход игрока {game.GetCurrentPlayer()}");
                Console.Write("Введите номер строки: 0, 1 или 2  ");
                Console.WriteLine();
                int row = int.Parse(Console.ReadLine());

                Console.Write("Введите номер столбца: 0, 1 или 2  ");
                Console.WriteLine();
                int col = int.Parse(Console.ReadLine());

                game.PlaceMove(row, col);
            }

            game.PrintBoard();

            if (game.CheckWin())
            {
                Console.WriteLine($"Игрок {game.GetCurrentPlayer()} выиграл");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }
    }
}


