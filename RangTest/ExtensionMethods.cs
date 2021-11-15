using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RangLib;

namespace RangTest
{
    public static class ExtensionMethods
    {
        public static void UpgradeRules(this Trader trader, IUpgradable client)  //razshirqvasht method 
        {
            if (client.GetType() == typeof(GoldClient))
            {
                GoldClient goldClient = client as GoldClient;
                goldClient.Credit = goldClient.AveragePurchases() * 0.03m;
            }
            else if (client.GetType() == typeof(Client) && (client as Client).AveragePurchases() >= 55m)
            {
                Client upgradeClient = client as Client;
                GoldClient goldClient = new GoldClient(upgradeClient.Purchases, 0);
                trader[upgradeClient.ID] = goldClient;
            }

        }


    }
}
