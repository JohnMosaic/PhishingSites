using System;

namespace PhishingSites
{
    public class Usage
    {
        public void ShowUsage()
        {
            Console.ResetColor();
            Console.WriteLine("+-----------------------------------------------------------------+");
            Console.WriteLine("|       Generate phishing domains from a custom dictionary.       |");
            Console.WriteLine("+------+------------+---------------+-----------------------------+");
            Console.WriteLine("|      |            | [-f <mode_1>] | [domain list file <string>] |");
            Console.WriteLine("| args | [this app] +---------------+-----------------------------+");
            Console.WriteLine("|      |            | [-s <mode_2>] |      [domain <string>]      |");
            Console.WriteLine("+------+------------+---------------+-----------------------------+");
            Console.WriteLine("|      | PhishingSites.exe -f D:\\alexa-top-700k-sites-crawled.csv |");
            Console.WriteLine("| e.g. +----------------------------------------------------------+");
            Console.WriteLine("|      | PhishingSites.exe -s microsoft.com                       |");
            Console.WriteLine("+------+----------------------------------------------------------+");
        }

        public void PrintMsg(string msg, string type)
        {
            if (type == "[INFO]") Console.ForegroundColor = ConsoleColor.Green;
            else if (type == "[WARN]") Console.ForegroundColor = ConsoleColor.Yellow;
            else if (type == "[ERRO]") Console.ForegroundColor = ConsoleColor.Red;
            else Console.ResetColor();
            Console.WriteLine(msg);
        }
    }
}
