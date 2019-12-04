using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipClassLibrary
{
    public static class StringConverters
    {
        public static int StringToInt(string input)
        {
            string toLower = input.ToLower();
            int output = 0;
            switch (toLower)
            {
                case "a":
                    output = 1;
                    break;
                case "b":
                    output = 2;
                    break;
                case "c":
                    output = 3;
                    break;
                case "d":
                    output = 4;
                    break;
                case "e":
                    output = 5;
                    break;
                case "f":
                    output = 6;
                    break;
                case "g":
                    output = 7;
                    break;
                case "h":
                    output = 8;
                    break;
            }
            return output;
        }

        public static string Orientation(string input)
        {
            string toLower = input.ToLower();
            string output;
            switch (toLower)
            {
                case "h":
                case "horizontal":
                    output = "horizontal";
                    break;
                case "v":
                case "vertical":
                    output = "vertical";
                    break;
                default:
                    output = "Error";
                    break;
            }
            return output;
        }
    }
}
