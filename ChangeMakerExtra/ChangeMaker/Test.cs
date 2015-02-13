using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace ChangeMaker
{
    [TestFixture]
    class Test
    {
        [Test,Timeout(500)]
        public void Test419()
        {
            Change amountAsChange = Program.ChangeAmount(4.19m);
            Assert.IsTrue(amountAsChange.Quarters == 16, "Incorrect Quarters");
            Assert.IsTrue(amountAsChange.Dimes == 1, "Incorrect Dimes");
            Assert.IsTrue(amountAsChange.Nickles == 1, "Incorrect Nickles");
            Assert.IsTrue(amountAsChange.Pennies == 4, "Incorrect Pennies");
        }
        
        [Test, Timeout(500)]
        public void Test318()
        {
            Change amountAsChange = Program.ChangeAmount(3.18m);
            Assert.IsTrue(amountAsChange.Quarters == 12, "Incorrect Quarters");
            Assert.IsTrue(amountAsChange.Dimes == 1, "Incorrect Dimes");
            Assert.IsTrue(amountAsChange.Nickles == 1, "Incorrect Nickles");
            Assert.IsTrue(amountAsChange.Pennies == 3, "Incorrect Pennies");
        }
        [Test, Timeout(500)]
        public void Test99()
        {
            Change amountAsChange = Program.ChangeAmount(.99m);
            Assert.IsTrue(amountAsChange.Quarters == 3, "Incorrect Quarters");
            Assert.IsTrue(amountAsChange.Dimes == 2, "Incorrect Dimes");
            Assert.IsTrue(amountAsChange.Nickles == 0, "Incorrect Nickles");
            Assert.IsTrue(amountAsChange.Pennies == 4, "Incorrect Pennies");
        }

        [Test, Timeout(500)]
        public void Test1293()
        {
            Change amountAsChange = Program.ChangeAmount(12.93m);
            Assert.IsTrue(amountAsChange.Quarters == 51, "Incorrect Quarters");
            Assert.IsTrue(amountAsChange.Dimes == 1, "Incorrect Dimes");
            Assert.IsTrue(amountAsChange.Nickles == 1, "Incorrect Nickles");
            Assert.IsTrue(amountAsChange.Pennies == 3, "Incorrect Pennies");
        }

        
        
    }
}
