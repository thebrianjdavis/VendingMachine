using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Inventory
    {
        public Inventory()
        {
        }
        public Dictionary<string, Item> InventoryLoad()
        {
            /// <summary>
            /// Creates a dictionary to store instances of items and
            /// returns the populated dictionary
            /// </summary>

            Dictionary<string, Item> inventoryDict = new Dictionary<string, Item>();
            try
            {
                string filePath = Directory.GetCurrentDirectory();
                string fileName = @"vendingmachine.csv";
                string fullPath = Path.Combine(filePath, fileName);
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        /// <summary>
                        /// Creates a temporary string array to hold values
                        /// to populate into new item instances
                        /// </summary>

                        string line = sr.ReadLine();
                        string[] temp = line.Split('|');

                        /// <summary>
                        /// Assigns values from the array to a constructor for
                        /// the new item and default the inventory to 5
                        /// </summary>

                        string itemRow = temp[0];
                        string itemName = temp[1];
                        decimal itemPrice = decimal.Parse(temp[2]);
                        string itemType = temp[3];
                        int inventoryCount = 5;

                        /// <summary>
                        /// Logic to create instance of the correct subclass of
                        /// the item and load into dictionary
                        /// </summary>

                        if (itemType == "Gum")
                        {
                            Gum gum = new Gum(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, gum);
                        }
                        else if (itemType == "Drink")
                        {
                            Drink drink = new Drink(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, drink);
                        }
                        else if (itemType == "Chip")
                        {
                            Chip chip = new Chip(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, chip);
                        }
                        else if (itemType == "Candy")
                        {
                            Candy candy = new Candy(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, candy);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return inventoryDict;
        }
    }
}
