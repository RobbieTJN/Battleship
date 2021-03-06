﻿using System;
using System.Text.RegularExpressions;

namespace BattleshipClassLibrary.Validation
{
    public static class Validator
    {
        public static bool IsValidName(string input)
        {
            bool result = true;
            Regex regex = new Regex("[a-z]", RegexOptions.IgnoreCase);

            if (input.Length > 20)
            {
                result = false;
            }
            if (!regex.IsMatch(input))
            {
                result = false;
            }

            return result;
        }

        public static bool AreNamesConfirmed(string input)
        {
            bool result;
            string toLower = input.ToLower();

            switch (toLower)
            {
                case "y":
                case "yes":
                    result = true;
                    break;
                default:
                    result = false;
                    break;
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

        public static bool IsValidColumn(string input)
        {
            bool result = true;
            Regex regex = new Regex("[a-h]", RegexOptions.IgnoreCase);

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

        public static bool IsValidEndCoordinates (int endRow, int endColumn)
        {
            bool isValid = true;
            if (endRow > ConstantsHandler.BOARD_LENGTH || endColumn > ConstantsHandler.BOARD_LENGTH)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
