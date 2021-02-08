using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Change
    {
        public Change()
        {

        }
        public int[] MakeChange(decimal currentMoney)
        {
            int[] changeOutput = new int[3];
            int change = Convert.ToInt32(currentMoney * 100);

            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            if (change >= 25 && change % 25 == 0)
            {
                quarters = change / 25;
            }
            else if (change >= 25 && (change % 25) % 10 == 0)
            {
                quarters = change / 25;
                dimes = (change % 25) / 10;
            }
            else if (change >= 25 && ((change % 25) % 10) % 5 == 0)
            {
                quarters = change / 25;
                dimes = (change % 25) / 10;
                nickels = ((change % 25) % 10) / 5;
            }
            else if (change >= 10 && change % 10 == 0)
            {
                dimes = change / 10;
            }
            else if (change >= 10 && (change % 10) % 5 == 0)
            {
                dimes = change / 10;
                nickels = (change % 10) / 5;
            }
            else if (change >= 5 && change % 5 == 0)
            {
                nickels = change / 5;
            }

            changeOutput[0] = quarters;
            changeOutput[1] = dimes;
            changeOutput[2] = nickels;

            return changeOutput;
        }
    }
}
