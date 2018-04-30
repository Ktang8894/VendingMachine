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

        public static void DisplaySoldOutError()
        {
            Console.WriteLine(OutputStrings.SoldOut);
        }

        //Probably delete this?
        public static void Debug_QueueStatus(string name, string flavor, string wrapperColor, int remaining)
        {
            Console.WriteLine("--- Current Item Queue State ---");
            Console.WriteLine("Dispensing Item: " + name);
            Console.WriteLine("Flavor: " + flavor);
            Console.WriteLine("Wrapper Color: " + wrapperColor);
            Console.WriteLine("Remaining in queue: " + remaining);
            Console.WriteLine("--------------------------------");
        }
    }
}
