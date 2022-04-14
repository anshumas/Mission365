using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p705
    {
        [TestMethod]
        public void MyHashSetTest()
        {

            MyHashSet obj = new MyHashSet();
            obj.Add(1);
            obj.Add(2);
            bool param_3 = obj.Contains(1);
            param_3 = obj.Contains(3);
            obj.Add(2);
            param_3 = obj.Contains(2);
            obj.Remove(2);
            param_3 = obj.Contains(2);

        }

    }
    public class MyHashSet
    {
        private ListNode head;
        public MyHashSet()
        {
            head = null;
        }

        public void Add(int key)
        {
            var node = new ListNode(key);
            if (head == null)
            {
                head = node;
                return;
            }
            ListNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = node;


        }

        public void Remove(int key)
        {
            if (head == null) return;
            if (head.val == key)
            {
                head = head.next;
                return;
            }
           
            var current = head;
            while (current.next != null)
            {
                if (current.next.val == key)
                    current.next = current.next.next;
                else
                    current = current.next;
            }
        

        }

        public bool Contains(int key)
        {
            if (head == null) return false;
            var current = head;
            while (current != null)
            {
                if (current.val == key)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }
    }


}
