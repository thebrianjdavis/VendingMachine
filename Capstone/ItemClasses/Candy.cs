﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : Item
    {
        public Candy(string itemName, decimal itemPrice, string itemType, int inventoryCount) : base(itemName, itemPrice, itemType, inventoryCount)
        {

        }
        public override void FunMessage()
        {
            Console.WriteLine("\nMunch Munch, Yum!");
        }
    }
}
