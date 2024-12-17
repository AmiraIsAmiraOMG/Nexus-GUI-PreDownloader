using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

string INPUTA;
string INPUTB;
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(" ███▄    █ ▓█████ ▒██   ██▒ █    ██   ██████      ▄████  █    ██  ██▓\r\n ██ ▀█   █ ▓█   ▀ ▒▒ █ █ ▒░ ██  ▓██▒▒██    ▒     ██▒ ▀█▒ ██  ▓██▒▓██▒\r\n▓██  ▀█ ██▒▒███   ░░  █   ░▓██  ▒██░░ ▓██▄      ▒██░▄▄▄░▓██  ▒██░▒██▒\r\n▓██▒  ▐▌██▒▒▓█  ▄  ░ █ █ ▒ ▓▓█  ░██░  ▒   ██▒   ░▓█  ██▓▓▓█  ░██░░██░\r\n▒██░   ▓██░░▒████▒▒██▒ ▒██▒▒▒█████▓ ▒██████▒▒   ░▒▓███▀▒▒▒█████▓ ░██░\r\n░ ▒░   ▒ ▒ ░░ ▒░ ░▒▒ ░ ░▓ ░░▒▓▒ ▒ ▒ ▒ ▒▓▒ ▒ ░    ░▒   ▒ ░▒▓▒ ▒ ▒ ░▓  \r\n░ ░░   ░ ▒░ ░ ░  ░░░   ░▒ ░░░▒░ ░ ░ ░ ░▒  ░ ░     ░   ░ ░░▒░ ░ ░  ▒ ░\r\n   ░   ░ ░    ░    ░    ░   ░░░ ░ ░ ░  ░  ░     ░ ░   ░  ░░░ ░ ░  ▒ ░\r\n         ░    ░  ░ ░    ░     ░           ░           ░    ░      ░  \r\n                                                                     ");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("CREATED BY AMIRAISAMIRAOMG");
Console.WriteLine("What operation would you like to execute: ");
INPUTA = Console.ReadLine();
if (INPUTA.Equals("install", StringComparison.OrdinalIgnoreCase))
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" ██▓ ███▄    █   ██████ ▄▄▄█████▓ ▄▄▄       ██▓     ██▓    ▓█████  ██▀███  \r\n▓██▒ ██ ▀█   █ ▒██    ▒ ▓  ██▒ ▓▒▒████▄    ▓██▒    ▓██▒    ▓█   ▀ ▓██ ▒ ██▒\r\n▒██▒▓██  ▀█ ██▒░ ▓██▄   ▒ ▓██░ ▒░▒██  ▀█▄  ▒██░    ▒██░    ▒███   ▓██ ░▄█ ▒\r\n░██░▓██▒  ▐▌██▒  ▒   ██▒░ ▓██▓ ░ ░██▄▄▄▄██ ▒██░    ▒██░    ▒▓█  ▄ ▒██▀▀█▄  \r\n░██░▒██░   ▓██░▒██████▒▒  ▒██▒ ░  ▓█   ▓██▒░██████▒░██████▒░▒████▒░██▓ ▒██▒\r\n░▓  ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░  ▒ ░░    ▒▒   ▓▒█░░ ▒░▓  ░░ ▒░▓  ░░░ ▒░ ░░ ▒▓ ░▒▓░\r\n ▒ ░░ ░░   ░ ▒░░ ░▒  ░ ░    ░      ▒   ▒▒ ░░ ░ ▒  ░░ ░ ▒  ░ ░ ░  ░  ░▒ ░ ▒░\r\n ▒ ░   ░   ░ ░ ░  ░  ░    ░        ░   ▒     ░ ░     ░ ░      ░     ░░   ░ \r\n ░           ░       ░                 ░  ░    ░  ░    ░  ░   ░  ░   ░     \r\n                                                                           ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Version To Try Install: ");
    INPUTB = Console.ReadLine();
    if (INPUTB.Equals("Latest", StringComparison.OrdinalIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("DOWNLOADING LATEST");

        using HttpClient client = new HttpClient();
        
    }
    else
    {
        Console.WriteLine("IS NOT A VALID INPUT PLEASE RESTART");
    }
}
else
{
    Console.WriteLine("IS NOT A VALID INPUT PLEASE RESTART");
}