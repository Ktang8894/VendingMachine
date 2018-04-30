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
        private double _price { get; set; } //Price of an item is determined by the owner, not the item
        
        public void Status()
        {
            Console.WriteLine("--- Current Item Queue State ---");
            Console.WriteLine("Dispensing Item: " + _itemQueue.Peek().Name);
            Console.WriteLine("Flavor: " + _itemQueue.Peek().Flavor);
            Console.WriteLine("Wrapper Color: " + _itemQueue.Peek().WrapperColor);
            Console.WriteLine("Remaining in queue: " + (_itemQueue.Count - 1));
            Console.WriteLine("--------------------------------");
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
