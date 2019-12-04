using BattleshipClassLibrary.Enumerations;
using BattleshipClassLibrary.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipClassLibrary
{
    public class Board
    {
        public List<Panel> Panels { get; set; }
        public Board()
        {
            Panels = new List<Panel>();
            for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
            {
                for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
                {
                    Panels.Add(new Panel(column, row));
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
            for (int column = 1; column <= ConstantsHandler.BOARD_LENGTH; column++)
            {
                for (int row = 1; row <= ConstantsHandler.BOARD_LENGTH; row++)
                {
                    if (Panels.At(column, row).Coordinates.Row == 1)
                    {
                        Console.Write(column + verticalLine);
                    }
                    Console.Write(Panels.At(column, row).DisplayStatus + verticalLine);
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(horizontalLine);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
