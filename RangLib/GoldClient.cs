using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangLib
{
    public class GoldClient : Client
    {
        private decimal credit = 0;
        public decimal Credit
        {
            get => credit;
            set => credit = value;
        }

        public GoldClient()
            : base() 
        {

        }

        public GoldClient(List<decimal> purchases, decimal credit)  //obhsto polzwane
            : base(purchases)
        {
            this.credit = credit;
        }

        public GoldClient(GoldClient client) //kopirane
            : base(client.Purchases)
        {
            this.credit = client.credit;
        }

        public override string ToString()  // predefinirane metod ToString
        {
            string result = base.ToString();
            return "VIP " + result + String.Format(", credit:{0:C2}", credit);
        }
    }
}
