using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipClassLibrary
{
    public static class ConstantsHandler
    {
        public static int BOARD_LENGTH = 8;

        public static string COLUMN = "Column:";
        public static string COLUMN_ERROR = "Column must be a single letter, A-H. Try again.";

        public static string ROW = "Row:";
        public static string ROW_ERROR = "Row must be a non-zero positive integer that is less than or equal to " + BOARD_LENGTH + ". Try again.";

        public static string ORIENTATION = "Now enter its orientation: horizontal (h) or vertical (v).";
        public static string ORIENTATION_ERROR = "Invalid orientation, try again.";

        public static string PLAYER_TURN_MESSAGE = "'s turn! Enter the coordinates you wish to fire at!";
    }
}
