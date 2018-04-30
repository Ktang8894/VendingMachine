using NUnit.Framework;

namespace VendingMachine.Unit_Tests
{
    [TestFixture]
    public class VendingMachineTest
    {
        public VendingMachine VendingMachine;

        [SetUp]
        public void SetUp()
        {
            VendingMachine = new VendingMachine();
        }

        [Test]
        public void StartingOnNoMoneyInsertedStateTest()
        {
            //Assert.AreEqual(VendingMachine.CurrentState, VendingMachine.NoMoneyInsertedState);
        }
    }
}
