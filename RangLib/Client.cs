using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangLib
{
    public class Client: IUpgradable          //2.
    {
        private List<decimal> purchases = new List<decimal>();

        private const string idPrefix = "U";        //unikalno id
        private static int ID_COUNT = 0;
        private string id;

        public string ID
        {
            get => id;
        }

        public List<decimal> Purchases
        {
            get => purchases;
            set => purchases = value;
        }

        public Client()  
        {
            ++ID_COUNT;

            id = idPrefix + ID_COUNT.ToString("D6");
        }

        public Client(List<decimal> purchases)  //obshto polzvane
        {
            this.purchases = purchases;

            ++ID_COUNT;

            id = idPrefix + ID_COUNT.ToString("D6");
        }

        public Client(Client client)    //kopirane
        {
            purchases = client.purchases;
        }

        public decimal AveragePurchases() //presmqtane na sredna stoinost
        {
            if (purchases.Count() > 0)
            {
                return purchases.Average();
            }

            return 0;
        }

        void IUpgradable.Upgrade(Action<IUpgradable> action)  // priemane na delegat
        {
            action(this);
        }

        public override string ToString()  //predefinirane na ToString
        {
            return String.Format("Enterprise No.:{0}, Average purchase: {1:C2}", ID, AveragePurchases());
        }

        public override bool Equals(object obj)
        {
            Client client = obj as Client;
            return this.ID.Equals(client.ID);
        }
    }
}
