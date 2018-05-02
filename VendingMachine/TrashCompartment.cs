using System.Collections.Generic;

namespace VendingMachine
{
    public class TrashCompartment
    {
        private Dictionary<string, int> Wrappers = new Dictionary<string, int>();
 
        public void AddWrapper(Item item)
        {
            string wrapper = item.Name;
            if (Wrappers.ContainsKey(wrapper))
            {
                Wrappers[wrapper]++;
            }
            else
            {
                Wrappers.Add(wrapper, 1);
            }
        }

        public void Report()
        {
            MachineOutput.ReportTrashStatus(Wrappers);
        }
    }
}
