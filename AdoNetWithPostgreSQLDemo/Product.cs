using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetWithPostgreSQLDemo
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public decimal unit_price { get; set; }
        public int stock_amount { get; set; }
    }
}
