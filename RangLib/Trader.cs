using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangLib
{
    public class Trader
    {
        private List<Client> clients;

        public List<Client> Clients   
        { 
            get => clients; 
            set => clients = value; 
        }

        public Client this[string id] // indexator
        {
            get  
            {
                if (!clients.Exists(client => client.ID.Equals(id))) 
                {
                    return null;
                }
                return clients.First(client => client.ID.Equals(id));
            }
            set 
            {
                Client client = this[id];
                clients.Remove(client);
                clients.Add(value);
            }
        }

        public Trader(List<Client> clients)
        {
            this.clients = clients;
        }

        public void SellProducts()  //generator za prodajbi 
        {
            Random rnd = new Random();

            
            foreach (Client client in clients)
            {
                List<decimal> purchases = new List<decimal>();

                for (int i = 0; i < rnd.Next(10, 31); i++)
                {
                    purchases.Add(rnd.Next(1000, 10001) / 100m);
                }

                client.Purchases = purchases;
            }
        }

        public override string ToString()
        {
            string result = "Trader [";

            foreach (Client client in clients)
            {
                result += "\n" + client.ToString();
            }

            result += " ]\n";

            return result;
        }
    }
}
