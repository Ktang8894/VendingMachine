using System.Collections.Generic;

namespace VendingMachine
{
    public class TrashCompartment
    {
        private Dictionary<string, int> Wrappers = new Dictionary<string, int>();
 
        public void AddWrapper(string wrapper)
        {
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
