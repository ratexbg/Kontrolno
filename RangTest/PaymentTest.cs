using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RangLib;

namespace RangTest
{
    class PaymentTest
    {
        public static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();  // suzdavane na spisuk ot klienti

            for (int i = 0; i < 3; i++)
            {
                clients.Add(new Client());  // suzdavane na klienti
            }

            for (int i = 0; i < 3; i++)
            {
                clients.Add(new GoldClient()); //suzdavane na vip klienti
            }

            Trader trader = new Trader(clients);

            trader.SellProducts();

            Console.WriteLine("Before client upgrade");
            Console.WriteLine(trader);

            for (int i = 0; i < trader.Clients.Count(); i++)    //obhojdane na klienti za upgrade
            {
                IUpgradable client = trader.Clients[i];
                client.Upgrade(trader.UpgradeRules);
            }

            Console.WriteLine("After client upgrade");
            Console.WriteLine(trader);
        }
    }
}
