using System;
using System.Configuration;

namespace VendingMachine
{
    public class Stocker
    {
        private VendingMachine _vendingMachine;
        private string[] _flavors = ConfigurationManager.AppSettings["Flavors"].Split(',');
        private string[] _wrapperColors = ConfigurationManager.AppSettings["WrapperColors"].Split(',');
        private int _queueSize = Convert.ToInt32(ConfigurationManager.AppSettings["QueueSize"]);

        public void StockVendingMachine()
        {
            char[] selectionCode = {'A', '1'};
            foreach(var flavor in _flavors)
            {
                selectionCode[1] = '1';
                foreach (var wrapperColor in _wrapperColors)
                {
                    var queue = new string(selectionCode);
                    _vendingMachine.ItemQueues.Add(queue, new ItemQueue(1.5));
                    for (var k = 0; k < _queueSize; k++)
                    {
                        _vendingMachine.ItemQueues[queue].QueueItem(new Item(flavor + "_" + wrapperColor, flavor, wrapperColor));
                    }
                    selectionCode[1]++;
                }
                selectionCode[0]++;
            }
        }
        
        public Stocker(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }
    }
}
