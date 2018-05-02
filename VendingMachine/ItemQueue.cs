using System.Collections.Generic;

namespace VendingMachine
{
    public class ItemQueue
    {
        private Queue<Item> _itemQueue;
        private double _price { get; set; }
        
        public void Status() //FOR DEBUGGING
        {
            MachineOutput.QueueStatus(_itemQueue.Peek().Name, _itemQueue.Peek().Flavor, _itemQueue.Peek().WrapperColor, (_itemQueue.Count - 1));
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
