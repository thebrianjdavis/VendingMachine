using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Boolean machineIsOn represents turning the vending machine on
            /// Inventory is created and loaded into a dictionary
            /// </summary>
            
            bool machineIsOn = true;
            VendingMachine vendingmachine = new VendingMachine();
            Inventory inventory = new Inventory();
            Dictionary<string, Item> inventoryDict = inventory.InventoryLoad();

            while (machineIsOn)
            {

                /// <summary>
                /// String variable created and set equal to user input
                /// MainMenuPrint writes the main menu to the console
                /// </summary>

                string mainMenuSelection;
                mainMenuSelection = MenuText.MainMenuPrint();

                /// <summary>
                /// Logic guides the user input to write the inventory
                /// contents to the screen, call upon vending machine
                /// functionality, print a sales report file or turn
                /// the machine off
                /// </summary>

                if (mainMenuSelection == "1")
                {
                    MenuText.ShowInventory(inventoryDict);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (mainMenuSelection == "2")
                {
                    inventoryDict = vendingmachine.RunPurchaseMenu(inventoryDict);
                }
                else if (mainMenuSelection == "3")
                {
                    machineIsOn = false;
                    break;
                }
                else if (mainMenuSelection == "4")
                {
                    SalesReport.LogSales(inventoryDict);
                }
                else
                {
                    MenuText.Invalid();
                }
            }
        }
    }
}
