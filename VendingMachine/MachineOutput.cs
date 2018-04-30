using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public static class MachineOutput
    {
        public static void DisplayTotalMoney(double totalMoney)
        {
            Console.WriteLine(OutputStrings.TotalMoney + totalMoney);
        }

        public static void DisplayItemCost(double price)
        {
            Console.WriteLine(OutputStrings.ItemCost, price);
        }

        public static void DisplayInsufficientFundsError(double difference)
        {
            Console.WriteLine(OutputStrings.InsufficientFunds, difference);
        }
    }
}
