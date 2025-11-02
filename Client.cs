using System.Text;
 

namespace Network
{

    public class Client : BaseUDP
    {
        public Client()
        {
            UDP.Client.Bind(_broadcastEP);
        }

        public void DisplayLobbies()
        {
            try
            {
                byte[] msg = _udp.Receive(ref _broadcastEP);
                string lobby = Encoding.ASCII.GetString(msg);

                Console.WriteLine(lobby);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void Update()
        {
            DisplayLobbies();
        }

    }
}