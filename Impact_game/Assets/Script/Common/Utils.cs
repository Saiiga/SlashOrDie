using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Utils
{
    public static string QwertyToAzerty(string text)
    {
        string returnValue = text;
        switch (text)
        {
            case "Z":
                return "W";
            case "A":
                return "Q";
            case "Q":
                return "A";
            case "W":
                return "Z";
            case ":":
                return "M";
        }

        return returnValue;
    }
}

