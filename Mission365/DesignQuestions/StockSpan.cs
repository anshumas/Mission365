using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.DesignQuestions
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            StockSpanner obj = new StockSpanner();
            int param_1 = obj.Next(100);
            param_1 = obj.Next(80);
            param_1 = obj.Next(60);
            param_1 = obj.Next(70);
            param_1 = obj.Next(160);
            param_1 = obj.Next(75);
            param_1 = obj.Next(85);

        }

    }
    public class StockSpanner
    {
        
        int PrevPrice=Int32.MaxValue;
        int PrevSpan = 0;
        int index = 0;
        public StockSpanner()
        {

        }

        public int Next(int price)
        {
            if(PrevPrice> price)
            {
                PrevSpan = 1;
            }
            else
            {
                PrevSpan = PrevSpan + 1;
            }
            PrevPrice = price;
            return PrevSpan;


        }
        //private void updateSpan()
        //{
        //    int count = 0;
        //    for (int i = index; i >= 0; i--)
        //    {
        //        if (prices[i] <= prices[index])
        //        {
        //            count++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    spans[index] = count;
        //}
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */
}
