using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructureAlgorithm.CompanyInterviews
{

    [TestClass]
    public class Citrix
    {
        [TestMethod]
        public void ArrangeWordsBasedOnfrequencyTest()
        {
            string result = ArrangeWordsBasedonFreq("Hello World Hello");
            Console.WriteLine(result);
        }
        public static string ArrangeWordsBasedonFreq(string input)
        {
            Dictionary<string, int> wordFred = new Dictionary<string, int>();
            foreach (string word in input.Split(' '))
            {
                if (wordFred.ContainsKey(word))
                {
                    wordFred[word]++;
                }
                else
                {
                    wordFred.Add(word, 1);
                }
            }
            var items = from p in wordFred orderby p.Value descending select p;
            StringBuilder result = new StringBuilder();
            foreach (var item in items)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    result.Append(item.Key).Append(" ");
                }
            }
            return result.ToString();
        }
        [TestMethod]
        public void CompressString()
        {
            string s = "aabbbcccccd";
            string result = CompressString(s);
            Assert.AreEqual(result, "abcd");

        }

        public static string CompressString(string s)
        {
            Queue<char> ch = new Queue<char>();
            ch.Enqueue(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    ch.Enqueue(s[i]);
                }
            }
            StringBuilder result = new StringBuilder();
            while (ch.Count > 0)
            {
                result.Append(ch.Dequeue());
            }
            return result.ToString();
        }
        [TestMethod]
        public void compressSentenceWithFreqTest()
        {
            string s = "aabbbccccdd";
            string result = compressSentenceWithFreq(s);
            Assert.AreEqual(result, "a2b3c4d2");
        }
        public static string compressSentenceWithFreq(string s)
        {
            Queue<string> ch = new Queue<string>();
            string pre = s[0].ToString();
            int index = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    ch.Enqueue(pre);
                    ch.Enqueue(index.ToString());
                    pre = s[i].ToString();
                    index = 1;
                }
                else
                {
                    index++;
                }
            }
            StringBuilder ans = new StringBuilder();
            while (ch.Count > 0)
            {
                ans.Append(ch.Dequeue());
            }
            ans.Append(pre).Append(index);
            return ans.ToString();
        }
        [TestMethod]
        public void LongestValidParenthesesTest()
        {
            int r = LongestValidParentheses(")()())");

        }
        public int LongestValidParentheses(string s)
        {
            int maxans = 0;
            int[] dp = new int[s.Length];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    int preLen;
                    if (s[i - 1] == '(')
                    {
                        preLen = i >= 2 ? dp[i - 2] : 0;
                        dp[i] = preLen + 2;
                    }
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        preLen = i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0;
                        dp[i] = dp[i - 1] + preLen + 2;
                    }
                    maxans = Math.Max(maxans, dp[i]);
                }
            }
            return maxans;
        }
        [TestMethod]
        public void MyTestMethod()
        {
            string result = AddStrings("924", "89");
        }
        public string AddStrings(string num1, string num2)
        {
            char[] num1Ch = num1.ToCharArray();
            char[] num2Ch = num2.ToCharArray();
            int len1 = num1.Length - 1;
            int len2 = num2.Length - 1;
            int rem = 0;
            bool isLen1Big = len1 > len2 ? true : false;
            while (len1 >= 0 || len2 >= 0)
            {
                int int1 = 0;
                int int2 = 0;
                if (len1 >= 0)
                {
                    int1 = (int)num1Ch[len1] - (int)'0';
                    len1--;
                }
                if (len2 >= 0)
                {
                    int2 = (int)num2Ch[len2] - (int)'0';
                    len2--;
                }
                int val = (int1 + int2 + rem) % 10;
                rem = (int1 + int2 + rem) / 10;
                if (isLen1Big)
                {
                    num1Ch[len1 + 1] = (char)val;
                }
                else
                {
                    num2Ch[len2 + 1] = (char)val;
                }

            }

            string result = "";
            if (isLen1Big)
            {
                for (int i = 0; i < num1Ch.Length; i++)
                {
                    result += ((int)num1Ch[i]).ToString();
                }
            }
            else
            {
                for (int i = 0; i < num2Ch.Length; i++)
                {
                    result += ((int)num2Ch[i]).ToString();
                }
            }
            result = (rem > 0 ? rem + result : result);
            return result;
        }
        [TestMethod]
        public void IsPalindromeTest()
        {
            bool ans = IsPalindrome("A man, a plan, a canal: Panama");
        }
        public bool IsPalindrome(string s)
        {
            int left = 0;

            int right = s.Length - 1;
            s = Regex.Replace(s, "[^0-9a-zA-Z]", string.Empty);
            Console.WriteLine(s);
            while (left < right)
            {
                Console.WriteLine(s[left] + "!=" + s[right]);
                if (s[left].ToString().ToUpper() != s[right].ToString().ToUpper())
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
        public string Reformat(string s)
        {
            Queue<char> chq = new Queue<char>();
            Queue<int> intq = new Queue<int>();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    chq.Enqueue(s[i]);
                }
                if (Char.IsDigit(s[i]))
                {
                    intq.Enqueue(s[i]);
                }
            }
            if (Math.Abs(chq.Count - intq.Count) > 1)
            {
                return "";
            }
            else
            {

                bool isChBig = chq.Count > intq.Count ? true : false;
                while (chq.Count > 0 || intq.Count > 0)
                {
                    if (isChBig)
                    {
                        if (chq.Count > 0)
                        {
                            result.Append(chq.Dequeue());
                        }
                        if (intq.Count > 0)
                        {
                            result.Append(intq.Dequeue());
                        }
                    }
                    else
                    {
                        if (intq.Count > 0)
                        {
                            result.Append(intq.Dequeue());
                        }
                        if (chq.Count > 0)
                        {
                            result.Append(chq.Dequeue());
                        }

                    }
                }
            }
            return result.ToString();

        }
        [TestMethod]
        public void LengthOfLongestSubstringTest()
        {
            int t = LengthOfLongestSubstring("abcadefgbb");
        }
        public int LengthOfLongestSubstring1(string s)
        {
            if (s.Length <= 1) return s.Length;
            int tail = 0;
            int longest = 0;
            int[] characters = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                char value = s[i];
                if (characters[value] <= tail)
                {
                    characters[value] = (i + 1);
                    longest = Math.Max(longest, (i + 1) - tail);
                }
                else
                {
                    tail = characters[value];
                    characters[value] = (i + 1);
                }
            }

            return longest;

        }
        public int LengthOfLongestSubstring(String s)
        {
            int n = s.Length;
            int longest = 0;
            int tail = 0;
            int[] characters = new int[256];
            for (int i = 0; i < n; i++)
            {
                char value = s[i];
                tail = Math.Max(characters[value], tail);
                longest = Math.Max(longest, (i + 1) - tail);
                characters[value] = (i + 1);
            }
            return longest;
        }
    }
}
