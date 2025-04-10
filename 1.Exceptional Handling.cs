using System;
using System.Collections.Generic;

public class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message) { }
}

public class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class InventorySystem
{
    private Dictionary<string, Product> inventory = new Dictionary<string, Product>();

    public InventorySystem()
    {
        inventory["Laptop"] = new Product { Name = "Laptop", Quantity = 5 };
        inventory["Mouse"] = new Product { Name = "Mouse", Quantity = 10 };
    }

    public void DisplayInventory()
    {
        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"Product: {item.Key}, Quantity: {item.Value.Quantity}");
        }
    }

    public void SellProduct(string productName, int qty)
    {
        try
        {
            Console.WriteLine("\nProcessing sale...");
            try
            {
                if (!inventory.ContainsKey(productName))
                    throw new ArgumentException("Product not found in inventory.");

                Product product = inventory[productName];

                if (qty <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                if (product.Quantity < qty)
                    throw new OutOfStockException($"Only {product.Quantity} items left in stock.");

                product.Quantity -= qty;
                Console.WriteLine($"Sold {qty} {productName}(s). Remaining: {product.Quantity}");
            }
            catch (OutOfStockException ex) when (qty > 10)
            {
                Console.WriteLine($"[Filter] Large order warning: {ex.Message}");
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine($"[Stock Issue] {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Input Error] {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[General Error] {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        InventorySystem system = new InventorySystem();

        while (true)
        {
            system.DisplayInventory();
            Console.Write("\nEnter product name to sell (or type 'exit' to quit): ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit") break;

            try
            {
                Console.Write("Enter quantity to sell: ");
                int qty = int.Parse(Console.ReadLine());

                system.SellProduct(name, qty);
            }
            catch (FormatException)
            {
                Console.WriteLine("[Format Error] Please enter a valid numeric quantity.");
            }
        }

        Console.WriteLine("Program ended.");
    }
}