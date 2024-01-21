using Fidan_sMarket;
using System.Collections.Generic;

Market market = new Market(50);
string opt;

do
{
    ShowMainMenu();
    Console.Write("Select an option: ");
    opt = Console.ReadLine();
    switch (opt)
    {
        case "1":
            AddProductMenu(market);
            break;

        case "2":
            if (MarketIsEmpty(market))
            {
                Console.WriteLine("There are no products to sell. Add products first.");
            }
            else
            {
                SellProductMenu(market);
            }
            break;

        case "3":
            if (MarketIsEmpty(market))
            {
                Console.WriteLine("There are no products to show. Add products first.");
            }
            else
            {
                market.ShowAllProducts();
            }
            break;
        case "4":
            Console.WriteLine("Exiting market.Bye,thank u for choosing us!");
            break;
        default:
            Console.WriteLine("Wrong option!");
            break;


    }
}
    while (opt != "4") ;

static void ShowMainMenu()
{
    Console.WriteLine("==={Welcome to Fidan's Market}===");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Sell Product");
    Console.WriteLine("3. View All Products");
    Console.WriteLine("4. Exit");

   
}
static void AddProductMenu(Market market)
{
    string name;
    do
    {
        Console.Write("Enter product name: ");
        name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid product name. Please enter a valid name.");
        }

    } while (string.IsNullOrWhiteSpace(name));

    decimal price;
    do
    {
        Console.Write("Enter product price: ");
        if (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.WriteLine("Invalid product price. Please enter a valid product price.");
        }

    } while (price < 0);

    Console.Write("Enter product count: ");
    int count;
    while (!int.TryParse(Console.ReadLine(), out count) || count < 0)
    {
        Console.WriteLine("Invalid product count. Please enter a valid product count.");
        Console.Write("Enter product count: ");
    }

    Product newProduct = new Product { Name = name, Price = price, Count = count };
    market.AddProduct(newProduct);
}
static void SellProductMenu(Market market)
{
    string sellProductName;
    do
    {
        Console.Write("Enter product name to sell: ");
        sellProductName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(sellProductName))
        {
            Console.WriteLine("Invalid product name. Please enter a valid name.");
        }

    } while (string.IsNullOrWhiteSpace(sellProductName));

    market.SellProduct(sellProductName);
}
static bool MarketIsEmpty(Market market)
{
    return market.ProductsCount == 0;
}
