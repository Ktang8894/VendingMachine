using System;

namespace VendingMachine
{
    class Actor
    {
        private static VendingMachine VendingMachine { get; set; }
        private static Stocker Stock { get; set; }
        private static void Input()
        {
            while (true)
            {
                var input = Console.ReadLine().ToUpper();
                if (input != "")
                {
                    if (input[0] == '$' && double.TryParse(input.Substring(1), out var money))
                    {
                        VendingMachine.InsertMoney(money);
                    }
                    else if (input.ToUpper() == "TRASH")
                    {
                        VendingMachine.Trash.Report();
                    }
                    else
                    {
                        VendingMachine.SelectItem(input);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            VendingMachine = new VendingMachine();
            Stock = new Stocker(VendingMachine);
            Stock.StockVendingMachine();
            Input();
        }
    }
}
