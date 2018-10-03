using System;
using System.Text;
using System.Collections.Generic;

namespace CodeFights {
    class Program {
        static void Main (string[] args) {
            var nums = new int[] {3, 1, 2, 4};
            ListNode<int> start = null;
            var i = nums.Length - 1;

            while(i >= 0)
            {
                var aux = new ListNode<int>();
                aux.value = nums[i];
                aux.next = start;
                start = aux;
                i--;
            }
            
            var ans = Methods.Invert(start);

            // while (ans != null)
            // {
            //     System.Console.WriteLine(ans.value);
            //     ans = ans.next;
            // }

            var palindrome = Methods.IsListPalindrome(ans);
            Console.WriteLine(palindrome);
            
            // var ans = Methods.IsListPalindrome(start);
            // Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
