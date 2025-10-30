using System;
using Network;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Program
    {
        public static void Main()
        {
            Host host;
            Client client;

            string input = Lobby();

            if (input == "1")
            {
                host = new Host();
            }
            else if (input == "2")
            {
                client = new Client();
            }
        }

        private static string Lobby()
        {
            Console.WriteLine("\n1: Host\n2: Join\n\nEnter 1 or 2: ");
            string input = Console.ReadLine();

            return input;

        }
    }
}
