using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Sales
    {
        public int saleId { get; private set; }
        public string salesManager {get; private set;}
        public decimal price { get; private set; }
        public string comment { get; private set; }

        public Sales (int id, string _manager, decimal _price, string _comment)
        {
            saleId = id;
            salesManager = _manager;
            price = _price;
            comment = _comment;
        }
    }
}
