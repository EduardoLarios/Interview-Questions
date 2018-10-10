using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CodeFights {
    class Program {
        static void Main (string[] args) {
            var nums = new int[] {3, 1, 2, 4};
            ListNode<int> start = null;
            var i = nums.Length - 1;

            while (i >= 0)
            {
                var aux = new ListNode<int>();
                aux.value = nums[i];
                aux.next = start;
                start = aux;
                i--;
            }

            System.Console.WriteLine("Write a word: ");
            //var word = Console.ReadLine();
            var ans = Methods.LongestSubstringNew("cesarricardo");
            System.Console.WriteLine("Longest: {0}", ans);

            // while (ans != null)
            // {
            //     System.Console.WriteLine(ans.value);
            //     ans = ans.next;
            // }

            // var palindrome = Methods.IsListPalindrome(ans);
            // Console.WriteLine(palindrome);

            Console.ReadLine();
        }
    }
}
