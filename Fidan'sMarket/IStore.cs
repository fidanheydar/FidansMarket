using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidan_sMarket
{
    internal interface IStore
    {
        Product[] Products { get; }
        int ProductLimit { get; }
        decimal  TotalIncome { get; }

       public void AddProduct(Product product);
       public bool SellProduct(string productName);
       public void ShowAllProducts();
    }
}
