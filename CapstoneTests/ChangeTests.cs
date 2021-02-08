using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        Capstone.Change change = new Capstone.Change();

        [TestMethod]
        public void MostQuartersOneDimeOneNickel()
        {
            decimal leftOverMoney = 1.40M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 5, 1, 1};

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void OneQuarterTwoDimes()
        {
            decimal leftOverMoney = 0.45M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 1, 2, 0 };

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void OneQuarterOneDimesOneNickel()
        {
            decimal leftOverMoney = 0.40M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 1, 1, 1 };

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void OneQuarter()
        {
            decimal leftOverMoney = 0.25M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 1, 0, 0 };

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void OneDime()
        {
            decimal leftOverMoney = 0.1M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 0, 1, 0 };

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void OneNickel()
        {
            decimal leftOverMoney = 0.05M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 0, 0, 1 };

            CollectionAssert.AreEqual(test, result);
        }
        [TestMethod]
        public void NoChange()
        {
            decimal leftOverMoney = 0M;
            int[] result = new int[3];
            result = change.MakeChange(leftOverMoney);
            int[] test = new int[] { 0, 0, 0 };

            CollectionAssert.AreEqual(test, result);
        }
    }
}
