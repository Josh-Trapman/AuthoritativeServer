using Network;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Program
    {
        public static void Main()
        {
            BaseUDP? udp = JoinOrHost();

            if (udp is Host)
            {
                udp = (Host)udp;
            }
            else if (udp is Client)
            {
                udp = (Client)udp;
            }

            while (true)
            {
                if (udp == null) return;

                udp.Update();


            }            
        }

        private static BaseUDP? JoinOrHost()
        {
            Console.WriteLine("\n1: Host\n2: Join\n\nEnter (1-3): ");
            string input = Console.ReadLine();

            if (input == "1") return new Host();
            else if (input == "2") return new Client();
            else return null;
        }
    }
}
