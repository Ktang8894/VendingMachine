using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class TrashCompartment
    {
        public List<Item> Wrappers = new List<Item>();
        //Need to verify whether the vending machine needs to report this automatically or if someone will manually come to count
        //If automatic, then keep dictionary. If manual, then make list of items.
        //public Dictionary<string, int> Wrappers = new Dictionary<string, int>();
        
        //public void AddWrapper(string wrapper)
        //{
        //    if (Wrappers.ContainsKey(wrapper))
        //    {
        //        Wrappers[wrapper]++;
        //    }
        //    else
        //    {
        //        Wrappers.Add(wrapper, 1);
        //    }
        //}

        public void AddWrapper(Item wrapper)
        {
            Wrappers.Add(wrapper);
        }

        public void Report()
        {
            foreach (Item wrapper in Wrappers)
            {
                Console.WriteLine(wrapper.Flavor);
            }
        }
    }
}
