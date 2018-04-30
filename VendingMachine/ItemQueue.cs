using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ItemQueue
    {
        private Queue<Item> _itemQueue;
        private double _price { get; set; }
        
        //For debugging
        public void Status()
        {
            MachineOutput.Debug_QueueStatus(_itemQueue.Peek().Name, _itemQueue.Peek().Flavor, _itemQueue.Peek().WrapperColor, (_itemQueue.Count - 1));
        }

        public double CheckPrice()
        {
            return _price;
        }

        public void QueueItem(Item item)
        {
            _itemQueue.Enqueue(item);
        }

        public Item DispenseItem()
        {
            //Check for null? Might be good to do so in vendingmachine.cs
            return _itemQueue.Dequeue();
        }

        public bool IsInStock()
        {
            return _itemQueue.Count > 0;
        }

        public ItemQueue(double price)
        {
            _price = price;
            _itemQueue = new Queue<Item>();
        }
    }
}
