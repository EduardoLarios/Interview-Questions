using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CodeFights
{
    // Definition for linked list:
    public class ListNode<T>
    {
        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }

    // Definition for binary tree:
    public class Tree<T>
    {
        public T value { get; set; }
        public Tree<T> left { get; set; }
        public Tree<T> right { get; set; }
    }

    public static class Methods
    {

        public static bool HasPathWithGivenSum (Tree<int> t, int s)
        {
            if (t == null) return false;

            var subSum = s - t.value;
            if (subSum == 0 && t.left == null && t.right == null)
            {
                return true;
            }

            var ans = false;
            if (t.left != null)
                ans = ans || HasPathWithGivenSum (t.left, subSum);
            if (t.right != null)
                ans = ans || HasPathWithGivenSum (t.right, subSum);

            return ans;

        }

        public static ListNode<int> RemoveValFromList (ListNode<int> head, int val)
        {
            if (head == null) return null;
            if (head.value == val) return RemoveValFromList (head.next, val);
            head.next = RemoveValFromList (head.next, val);
            return head;
        }

        public static ListNode<int> Invert (ListNode<int> head)
        {
            //{3, 1, 2, 4, 5};
            if (head == null || head.next == null) return head;
            ListNode<int> prev = null;
            var next = head.next;

            while (head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }

        public static void ReverseInPlace (ref ListNode<int> list)
        {
            // Reverse a linked list in place, with head at list
            // Return new head pointing to reversed list
            ListNode<int> head = list;
            ListNode<int> next = list.next;
            ListNode<int> tmp = null;

            head.next = null;

            while (next != null)
            {
                tmp = next.next;
                next.next = head;
                head = next;
                next = tmp;
            }

            list = head;
        }

        public static bool IsListPalindrome (ListNode<int> list)
        {
            // {3, 1, 2, 4};
            if (list == null || list.next == null) return true;

            ListNode<int> left = list;
            ListNode<int> right = list;
            ListNode<int> mid = FindMidNode (list);

            Console.WriteLine (mid.value);

            return false;
        }

        public static ListNode<int> FindMidNode (ListNode<int> list)
        {
            if (list == null || list.next == null) return list;
            ListNode<int> slow = list;
            ListNode<int> fast = list;

            while (fast.next != null)
            {
                if (fast.next.next == null)
                {
                    return slow;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return list;
        }

        public static bool CompareLists (ListNode<int> fist, ListNode<int> second)
        {
            // Compare elements of first and second up to the length of the shorter
            // Return false if any elements are different
            while (fist != null && second != null)
            {
                if (fist.value != second.value) return false;
                fist = fist.next;
                second = second.next;
            }
            return true;
        }

        public static int[][] RotateImage (int[][] matrix)
        {
            int i;
            int j, col;

            if (matrix.Length == 1)
                return matrix;

            var input = matrix;
            var output = new int[matrix.GetLength (0)][];

            for (i = 0; i < output.Length; i++)
            {
                output[i] = new int[matrix.Length];
            }

            for (i = 0; i < matrix.Length; i++)
            {
                for (j = 0, col = matrix.Length - 1; j < matrix.Length; j++, col--)
                {
                    output[i][j] = input[col][i];
                }
            }

            return output;
        }

        public static char FirstNonRepeatingCharacter (string str)
        {
            var found = new Dictionary<char, int> ();
            for (var i = 0; i < str.Length; i++)
            {
                if (found.ContainsKey (str[i]))
                    //Console.WriteLine("Key Found:");
                    found[str[i]] += 1;
                else
                    //Console.WriteLine("Key Not Found:");
                    found.Add (str[i], 1);
            }

            if (found.ContainsValue (1))
            {
                return found.FirstOrDefault (x => x.Value == 1).Key;
            }

            return '_';

        }

        public static bool AlmostIncreasingSequence (int[] sequence)
        {
            var counter = 0;
            if (sequence.Length == 2) { return true; }
            for (var i = 0; i < sequence.Length - 1; i++)
            {
                //Console.WriteLine ("Iteration: " + i);
                if (sequence[i] >= sequence[i + 1])
                {
                    //Console.WriteLine ("Inside");
                    //Console.WriteLine (sequence[i] + " is bigger or equal to " + sequence[i + 1]);
                    counter++;
                    //Console.WriteLine ("Counter: " + counter);
                }

                if (i + 2 < sequence.Length && sequence[i] >= sequence[i + 2])
                {
                    //Console.WriteLine ("Weird case");
                    //Console.WriteLine (sequence[i] + " bigger or equal to " + sequence[i + 2]);
                    counter++;
                    //System.Console.WriteLine ("Counter: " + counter);
                }
            }

            return counter <= 2;

        }

        public static int FirstDuplicate (int[] array)
        {
            var len = array.Length;
            var found = new Dictionary<int, bool> ();

            for (var i = 0; i < len; i++)
            {
                if (found.ContainsKey (array[i]))
                    return array[i];
                else
                    found.Add (array[i], true);
            }

            return -1;
        }

        public static string LongestSubstring (string BaseString)
        {
            var currentLongest = new StringBuilder ();
            var tempLongest = new StringBuilder ();
            var len = BaseString.Length;

            for (var i = 0; i < len; i++)
            {
                for (var j = i; j < len; j++)
                {

                    if (tempLongest.ToString ().Contains (BaseString[j].ToString ()))
                    {
                        // System.Console.WriteLine("Current char: {0} - NOT ADDED -", BaseString[j]);
                        if (tempLongest.ToString ().Length > currentLongest.ToString ().Length)
                        {
                            currentLongest.Clear ();
                            currentLongest.Append (tempLongest);
                        }

                        tempLongest.Clear ();
                        // System.Console.WriteLine("Cleared head - Skipping Iteration\n");
                        break;
                    }
                    else
                    {
                        // System.Console.WriteLine("Current char: {0} - ADDED -", BaseString[j]);
                        tempLongest.Append (BaseString[j]);
                    }
                }
            }

            return currentLongest.ToString ();
        }

        public static int MatrixElementsSum (int[][] matrix)
        {
            //TODO: Fix weird case and change algorithm to check from a blacklist of colums.
            var sum = 0;
            var len = matrix[1].Length;
            var width = matrix[2].Length;

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 && matrix[i][j] > 0)
                    {
                        System.Console.WriteLine ("Added: {0}", matrix[i][j]);
                        sum += matrix[i][j];
                    }

                    if (i > 0 && matrix[i][j] > 0 && matrix[i - 1][j] > 0)
                    {
                        System.Console.WriteLine ("Added: {0}", matrix[i][j]);
                        System.Console.WriteLine ("Top: {0}", matrix[i - 1][j]);
                        sum += matrix[i][j];
                    }

                    // System.Console.Write("{0}\t", matrix[i][j]);
                }
                // System.Console.WriteLine();
            }

            return sum;
        }

        public static int MakeConsecutive (int[] statues)
        {
            int i, count = 0;
            Array.Sort (statues);
            var len = statues.Length;

            for (i = len - 1; i > 0; i--)
            {
                if (statues[i] - statues[i - 1] > 1)
                {
                    count += (statues[i] - statues[i - 1] - 1);
                }
            }

            return count;
        }

        public static int GetCentury (int year)
        {
            if (year % 100 == 0)
            {
                return year / 100;
            }
            else
            {
                return (year / 100) + 1;
            }
        }

        public static bool CheckPalindrome (string word)
        {
            var len = word.Length;
            for (var i = 0; i < len - 1; i++)
            {
                if (word[i] == word[len - i - 1])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static int AdjacentElements (int[] inputArray)
        {
            var maxProd = int.MinValue;
            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                if (inputArray[i] * inputArray[i + 1] > maxProd)
                {
                    maxProd = inputArray[i] * inputArray[i + 1];
                }
            }

            return maxProd;
        }

        public static int ShapeArea (int n)
        {
            return (n * n) + ((n - 1) * (n - 1));
        }

    }
}