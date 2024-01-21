using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidan_sMarket
{
    internal class Market : IStore
    {
        private Product[] _products;
        private int _productCount;
        private int _productLimit;
        private decimal _totalIncome;
        private int _marketLimitCount;

        public Product[] Products => _products;
        public int ProductLimit => _productLimit;
        public decimal TotalIncome => _totalIncome;
        public int ProductsCount => _productCount;
        public int ProductCount => _marketLimitCount;
        public Market(int productLimit)
        {
            _productLimit = productLimit; 
            _products = new Product[_productLimit];
            _productCount = 0;
            _totalIncome = 0;
        }
        private bool CheckLimit(int _marketLimitCount)
        {
            return _marketLimitCount > _productLimit;
        }

        public void AddProduct(Product product)
        {

            _marketLimitCount += product.Count;

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                Console.WriteLine("Invalid product name. Please enter a valid name.");
                return;
            }

            if (CheckLimit(_marketLimitCount))
            {
                Console.WriteLine("Product limit reached. Cannot add more products.");
                Console.WriteLine($"Remaining product limit: {_productLimit - _productCount}");
                return;
            }

            for (int i = 0; i < _productCount; i++)
            {
                if (_products[i]?.Name == product.Name)
                {
                    Console.WriteLine($"Product: {product.Name} already exists.");
                    return;
                }
            }

            _products[_productCount] = product;
            _productCount++;
            Console.WriteLine($"Product '{product.Name}' added successfully.");
        }

        public bool SellProduct(string productName)
        {
            for (int i = 0; i < ProductsCount; i++)
            {
                if (_products[i] != null && !string.IsNullOrWhiteSpace(_products[i].Name) && _products[i].Name == productName && _products[i].Count > 0)
                {
                    _totalIncome += _products[i].Price;
                    _products[i].Count--;
                    Console.WriteLine($"{_products[i].Name} sold. Total Income: {_totalIncome}");
                    _marketLimitCount -= _products[i].Count;
                    return true;
                }
            }

            Console.WriteLine($"Invalid product name or product {productName} not found or out of stock.");
            return false;
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("All Products:");

            for (int i = 0; i < _productCount; i++)
            {
                var product = _products[i];
                if (product != null)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Count: {product.Count}");
                }
            }
        }

    }
}