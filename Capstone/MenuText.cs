using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MenuText
    {

        /// <summary>
        /// Writes the Main Menu to the console and returns
        /// value of user selection
        /// </summary>

        public static string MainMenuPrint()
        {
            Console.WriteLine("Vending Machine 2.0\n");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("\nPlease make your selection and press RETURN");
            string mainMenuSelection = Console.ReadLine();
            Console.Clear();
            return mainMenuSelection;
        }

        /// <summary>
        /// Loops through Dictionary of items and writes
        /// relevant information to the console
        /// </summary>

        public static void ShowInventory(Dictionary<string, Item> inventoryDict)
        {
            Console.WriteLine($"Code  Price   In Stock   Item Name");
            foreach (KeyValuePair<string, Item> product in inventoryDict)
            {
                decimal i = product.Value.ItemPrice;
                int invCount = product.Value.InventoryCount;
                string n = product.Value.ItemName;
                if (invCount == 0)
                {
                    Console.WriteLine($"{product.Key}    ----    SOLD OUT");
                }
                else
                {
                    
                    Console.WriteLine($"{product.Key}    {i}       {invCount}       {n}");
                }
            }
        }

        /// <summary>
        /// Writes the Purchase Menu to the console and
        /// returns value of user selection
        /// </summary>

        public static string PurchaseMenuDisplay(decimal currentMoney)
        {
            Console.WriteLine("(1) Feed money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"\nCurrent money provided: {currentMoney:C2}");
            string purchaseSelection = Console.ReadLine();
            Console.Clear();
            return purchaseSelection;
        }

        /// <summary>
        /// Writes the Menu Options to load money to the
        /// console and returns user selection
        /// </summary>

        public static string LoadMoneyMenu()
        {
            Console.WriteLine("Please enter bills:");
            Console.WriteLine("(1) - $1.00");
            Console.WriteLine("(2) - $2.00");
            Console.WriteLine("(5) - $5.00");
            Console.WriteLine("(10) - $10.00");
            string billSelect = Console.ReadLine();
            Console.Clear();
            return billSelect;
        }

        /// <summary>
        /// Writes message while dispensing item
        /// </summary>

        public static void Dispense(string name, decimal price, decimal balance)
        {
            Console.WriteLine("Dispensing item...");
            Console.WriteLine($"\n{name} {price} and you have {balance:C2} remaining");
        }

        /// <summary>
        /// Writes message for an invalid selection to the console
        /// </summary>

        public static void Invalid()
        {
            Console.Clear();
            Console.WriteLine("Invalid selection, please try again");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Writes message when current credit balance is not
        /// sufficient to complete the selected transaction to
        /// the console
        /// </summary>

        public static void InsufficientFunds()
        {
            Console.Clear();
            Console.WriteLine("Insufficient money tendered!");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Writes message when inventory is not sufficient
        /// to complete the selected transaction to the console
        /// </summary>

        public static void OutOfStock()
        {
            Console.Clear();
            Console.WriteLine("Product selected is out of stock");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Writes change given to the console
        /// </summary>
        
        public static void PrintChange(decimal currentMoney, int[] changeOutput)
        {
            Console.WriteLine($"Your change is {currentMoney:C2}\n");
            Console.WriteLine($"{changeOutput[0]} Quarter(s) dispensed");
            Console.WriteLine($"{changeOutput[1]} Dime(s) dispensed");
            Console.WriteLine($"{changeOutput[2]} Nickel(s) dispensed");
            Console.ReadLine();
            Console.Clear();
        }
        
    }
}
