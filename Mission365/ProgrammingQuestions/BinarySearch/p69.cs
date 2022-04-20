using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p69
    {
        [TestMethod]
        public void MySqrtTest()
        {

            Assert.AreEqual(MySqrt(1), 1);
            Assert.AreEqual(MySqrt(2), 1);
            Assert.AreEqual(MySqrt(3), 1);
            Assert.AreEqual(MySqrt(4), 2);
            Assert.AreEqual(MySqrt(5), 2);
            Assert.AreEqual(MySqrt(8), 2);
            Assert.AreEqual(MySqrt(9), 3);
            Assert.AreEqual(MySqrt(2147395599), 46339);

        }
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }
            long s = 1;
            long e = x/2;
            while (s <= e)
            {
                long m = (s + e) / 2;
                long sqr = m * m;
                if (sqr == x) return (int)m;
                if (sqr < 0 || sqr > x)
                {
                    e = m - 1;
                }
                else
                {
                    s = m + 1;
                }
            }
            return (int)e;
        }
    }


}
