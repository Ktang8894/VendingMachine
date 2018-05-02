using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public static class MachineOutput
    {
        public static void DisplayCurrentBalance(double currentBalance)
        {
            Console.WriteLine(OutputStrings.CurrentBalance + currentBalance);
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

        public static void DisplayInstructions()
        {
            Console.WriteLine(OutputStrings.Instructions);
        }

        public static void ReportTrashStatus(Dictionary<string, int> wrappers)
        {
            Console.WriteLine(OutputStrings.TrashReportHeader);
            foreach (KeyValuePair<string, int> wrapper in wrappers)
            {
                Console.WriteLine(OutputStrings.TrashReport, wrapper.Key, wrapper.Value);
            }
            Console.WriteLine(OutputStrings.TrashReportFooter);
        }

        public static void QueueStatus(string name, string flavor, string wrapperColor, int remaining)
        {
            Console.WriteLine(OutputStrings.QueueStatus, name, flavor, wrapperColor, remaining);
        }
    }
}
