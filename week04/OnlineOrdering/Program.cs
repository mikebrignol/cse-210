using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Brooklyn", "NY", "USA");
        Customer customer1 = new Customer("Jessica Germaine", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Smartphone", "SM90", 1200, 1));
        order1.AddProduct(new Product("Phone Case", "PH01", 120, 1));

        Address address2 = new Address("1189 Buckingham St", "Manchester", "England", "UK");
        Customer customer2 = new Customer("Arthur Morgan", address2);

        Order order2 = new Order(customer1);
        order2.AddProduct(new Product("12v 100Ah LiFePo4 Battery", "BT05", 350, 4));
        order2.AddProduct(new Product("350w Solar Panel", "SP09", 59, 4));
        order2.AddProduct(new Product("Power Inverter", "PI41", 20, 1));

        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalCost());
        Console.WriteLine();

        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalCost());
    }
}