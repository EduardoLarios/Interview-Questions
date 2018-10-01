using System;
using System.Text;

namespace CodeFights {
    class Program {
        static void Main (string[] args) {
            var nums = new int[] {3, 1, 2, 3, 4, 5};
            var input = new ListNode<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                input.value = nums[i];
            }
            //var ans = Methods.RotateImage(input);
            
            Console.ReadLine();
        }
    }
}
