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
                var input = Console.ReadLine();
                if (input != "")
                {
                    if (input[0] == '$') //To input money, put dollar sign first
                    {
                        if (double.TryParse(input.Substring(1), out var din))
                        {
                            VendingMachine.InsertMoney(din);
                        }
                    }
                    else
                    {
                        input = input.ToUpper();
                        if (input == "R") //DEBUGGING
                        {
                            Console.WriteLine("----- [DEBUG] Trash Report -----");
                            VendingMachine.Trash.Report();
                            Console.WriteLine("--------------------------------");
                        }
                        if (VendingMachine.Shelves.ContainsKey(input))
                        {
                            VendingMachine.SelectItem(input);
                        }
                        else
                        {
                            Console.WriteLine("[DEBUG] Item Key DNE"); //remove if/else if no validation needed
                        }
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
