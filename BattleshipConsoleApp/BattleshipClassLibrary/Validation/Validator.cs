using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BattleshipClassLibrary.Validation
{
    public static class Validator
    {
        public static bool AreNamesConfirmed(string input)
        {
            bool result;
            string toLower = input.ToLower();

            switch (toLower)
            {
                case "y":
                case "yes":
                case "yeah":
                case "ok":
                case "okay":
                case "sure":
                case "absolutely":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        public static bool IsValidColumn(string input)
        {
            bool result = true;
            Regex regex = new Regex("[a-hA-H]", RegexOptions.IgnoreCase);

            if (input.Length > 1)
            {
                result = false;
            }
            if (!regex.IsMatch(input))
            {
                result = false;
            }

            return result;
        }

        public static bool IsValidRow(string input)
        {
            bool result = true;
            try
            {
                int tryParse = int.Parse(input);

                if (tryParse > ConstantsHandler.BOARD_LENGTH)
                {
                    result = false;
                }
                if (tryParse == 0)
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool IsValidInitialCoordinates(int startColumn, int startRow)
        {
            bool isValid = true;
            if (startColumn > ConstantsHandler.BOARD_LENGTH || startRow > ConstantsHandler.BOARD_LENGTH)
            {
                isValid = false;
            }
            return isValid;
        }

        public static bool IsValidEndCoordinates (int endColumn, int endRow)
        {
            bool isValid = true;
            if (endColumn > ConstantsHandler.BOARD_LENGTH || endRow > ConstantsHandler.BOARD_LENGTH)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
