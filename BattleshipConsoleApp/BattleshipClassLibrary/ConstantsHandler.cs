namespace BattleshipClassLibrary
{
    public static class ConstantsHandler
    {
        public static readonly int BOARD_LENGTH = 8;

        public static readonly string HORIZONTAL_LINE = "  ---------------------------------";
        public static readonly string VERTICAL_LINE = " | ";

        public static readonly string ROW = "Row:";
        public static readonly string ROW_ERROR = "Row must be a non-zero positive integer that is less than or equal to " + BOARD_LENGTH + ". Try again.";

        public static readonly string COLUMN = "Column:";
        public static readonly string COLUMN_ERROR = "Column must be a single letter, A-H. Try again.";

        public static readonly string ORIENTATION = "Now enter its orientation: horizontal (h) or vertical (v).";
        public static readonly string ORIENTATION_ERROR = "Invalid orientation, try again.";
        public static readonly string VERTICAL = "vertical";
        public static readonly string HORIZONTAL = "horizontal";
        public static readonly string ORIENTATION_INPUT_ERROR = "Error";

        public static readonly string SHIP_PLACE_SUCCESS = "Successfully placed ship.";
        public static readonly string SHIP_PLACE_INVALID_COORDS = "Invalid ship placement - ship would be partially outside the game board. Try again.";
        public static readonly string SHIP_PLACE_HAS_SHIP = "Invalid ship placement - one or more of the selected panels already contains a ship. Try again.";

        public static readonly string PLAYER_TURN_MESSAGE = "'s turn! Enter the coordinates you wish to fire at!";
        public static readonly string OPPONENT_BOARD = "Opponent's Board:";

        public static readonly string HIT = "Ka-BOOOM! Hit registered!";
        public static readonly string MISS = "Splooosh...Hit missed.";
        public static readonly string ALREADY_HIT = "You already targeted that panel. Enter new coordinates:";
        public static readonly string SANK = "[Sinking ship sounds] ...You sank my ";

        public static readonly string CONTINUE = "Press any key to continue...";

        public static readonly string WINNER_MSG_START = "'s fleet is destroyed! ";
        public static readonly string WINNER_MSG_END = " has won the game!";
    }
}
