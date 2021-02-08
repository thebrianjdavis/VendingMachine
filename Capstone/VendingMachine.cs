using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {

        /// <summary>
        /// Properties created to store set "true" value 
        /// to loop purchasing menu functionality and
        /// hold the current credit balance
        /// </summary>
        
        public decimal CurrentMoney { get; private set; }
        private bool isPurchasing { get; set; }

        /// <summary>
        /// RunPurchaseMenu loops through logic to load money
        /// into the machine, display current inventory/
        /// purchase items and return current credit
        /// balance/exit to main menu
        /// </summary>
        
        public Dictionary<string, Item> RunPurchaseMenu(Dictionary<string, Item> inventoryDict)
        {
            isPurchasing = true;
            while (isPurchasing)
            {
                string purchaseSelection;
                purchaseSelection = MenuText.PurchaseMenuDisplay(CurrentMoney);
                
                if (purchaseSelection == "1")
                {
                    string bill = MenuText.LoadMoneyMenu();
                    AddMoney(bill);
                }
                else if (purchaseSelection == "2")
                {
                    MenuText.ShowInventory(inventoryDict);
                    string itemSelect = Console.ReadLine().ToUpper();
                    Console.Clear();
                    ItemBuy(itemSelect, inventoryDict);
                }
                else if (purchaseSelection == "3")
                {
                    Change change = new Change();
                    int[] changeOutput = change.MakeChange(CurrentMoney);
                    MenuText.PrintChange(CurrentMoney, changeOutput);
                    VendLog.Log("GIVE CHANGE", CurrentMoney, 0);
                    CurrentMoney = 0;
                    isPurchasing = false;
                }
            }
            return inventoryDict;
        }

        /// <summary>
        /// AddMoney functionality increments current credit
        /// balance by bills input
        /// Money fed into machine is written to log
        /// </summary>
        
        public void AddMoney(string billSelect)
        {
            string feed = "FEED MONEY";
            if (billSelect == "1")
            {
                CurrentMoney++;
                VendLog.Log(feed, 1, CurrentMoney);
            }
            else if (billSelect == "2")
            {
                CurrentMoney += 2;
                VendLog.Log(feed, 2, CurrentMoney);
            }
            else if (billSelect == "5")
            {
                CurrentMoney += 5;
                VendLog.Log(feed, 5, CurrentMoney);
            }
            else if (billSelect == "10")
            {
                CurrentMoney += 10;
                VendLog.Log(feed, 10, CurrentMoney);
            }
            else
            {
                MenuText.Invalid();
            }
        }

        /// <summary>
        /// Dictionary of items is passed in
        /// ItemPrice subtracted from current credit balance
        /// InventoryCount property is decremented
        /// ItemSold property is incremented
        /// Purchase info/fun message written to console
        /// Sale is written to log
        /// Updated dictionary returned
        /// </summary>

        public Dictionary<string, Item> ItemBuy(string itemSelect, Dictionary<string, Item> inventoryDict)
        {
            bool hasEntry = inventoryDict.ContainsKey(itemSelect);
            Item iSct = new Chip(null, 0, null, 0);

            if (hasEntry)
            {
                iSct = inventoryDict[itemSelect];
            }

            if (hasEntry && iSct.InventoryCount > 0 && CurrentMoney >= iSct.ItemPrice)
            {
                CurrentMoney -= iSct.ItemPrice;
                iSct.InventoryCount--;
                iSct.ItemSold++;
                MenuText.Dispense(iSct.ItemName, iSct.ItemPrice, CurrentMoney);
                iSct.FunMessage();
                Console.ReadLine();
                Console.Clear();
                string purchaseCode = iSct.ItemName + " " + itemSelect.ToUpper();
                VendLog.Log(purchaseCode, iSct.ItemPrice, CurrentMoney);
            }
            else if (hasEntry && iSct.InventoryCount > 0)
            {
                MenuText.InsufficientFunds();
            }
            else if (hasEntry)
            {
                MenuText.OutOfStock();
            }
            else
            {
                MenuText.Invalid();
            }
            return inventoryDict;
        }
    }
}
