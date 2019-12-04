using BattleshipClassLibrary.Enumerations;
using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;

namespace BattleshipClassLibrary
{
    public class Board
    {
        public List<Panel> Panels { get; set; }
        public Board()
        {
            Panels = new List<Panel>();
            for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
            {
                for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
                {
                    Panels.Add(new Panel(row, column));
                }
            }
        }

        public void DrawEmptyBoard()
        {
            string horizontalLine = "  ---------------------------------";
            string verticalLine = " | ";
            Console.WriteLine();
            Console.Write("    ");
            for (int i = 1; i <= ConstantsHandler.BOARD_LENGTH; i++)
            {
                Console.Write((ColumnHeaderLetters)i + "   ");
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine(horizontalLine);
            for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
            {
                for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
                {
                    if (Panels.At(row, column).Coordinates.Column == 1)
                    {
                        Console.Write(row + verticalLine);
                    }
                    Console.Write(Panels.At(row, column).DisplayStatus + verticalLine);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(horizontalLine);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
