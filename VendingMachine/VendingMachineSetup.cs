using System;
using System.Configuration;

namespace VendingMachine
{
    class VendingMachineSetup
    {
        private static VendingMachine VendingMachine { get; set; }
        private static Stocker Stock { get; set; }

        private static int _numShelves = Convert.ToInt32(ConfigurationManager.AppSettings["NumShelves"]);
        private static int _shelfSize = Convert.ToInt32(ConfigurationManager.AppSettings["ShelfSize"]);

        public static void SetUpQueues(VendingMachine vendingMachine)
        {
            char[] selectionCode = { 'A', '1' };
            for (int i = 0; i < _numShelves; i++)
            {
                selectionCode[1] = '1';
                for (int j = 0; j < _shelfSize; j++)
                {
                    var queue = new string(selectionCode);
                    vendingMachine.ItemQueues.Add(queue, new ItemQueue(1.5));
                    selectionCode[1]++;
                }
                selectionCode[0]++;
            }
        }

        static void Main(string[] args)
        {
            VendingMachine = new VendingMachine();
            SetUpQueues(VendingMachine);
            Stock = new Stocker(VendingMachine);
            Stock.StockVendingMachine();
            VendingMachine.ReadInput();
        }
    }
}
