using System;
using System.Text;
using System.Collections.Generic;

namespace CodeFights {
    class Program {
        static void Main (string[] args) {
            var nums = new int[] {3, 1, 2, 4};
            ListNode<int> start = null;
            var i = nums.Length - 1;

            Tree<int> tree = new Tree<int>();

            // Left Side
            tree.value = 4;
            tree.left = new Tree<int>();
            tree.left.value = 1;
            tree.left.left = new Tree<int>();
            tree.left.left.value = -2;
            tree.left.left.right = new Tree<int>();
            tree.left.left.right.value = 3;

            // Right Side
            tree.right = new Tree<int>();
            tree.right.value = 3;
            tree.right.left = new Tree<int>();
            tree.right.left.value = 1;
            tree.right.right = new Tree<int>();
            tree.right.right.value = 2;
            tree.right.right.left = new Tree<int>();
            tree.right.right.left.value = -2;
            tree.right.right.right = new Tree<int>();
            tree.right.right.right.value = -3;

            while(i >= 0)
            {
                var aux = new ListNode<int>();
                aux.value = nums[i];
                aux.next = start;
                start = aux;
                i--;
            }

            var ans = Methods.HasPathWithGivenSum(tree, 6);
            System.Console.WriteLine(ans);

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
