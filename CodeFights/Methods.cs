using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CodeFights
{

    public class ListNode<T>
    {
        public T value { get; set; }
        public ListNode<T> next { get; set; }
    }

    public static class Methods
    {

        public static ListNode<int> RemoveValFromList (ListNode<int> head, int val)
        {
            if (head == null) return null;
            if (head.value == val) return RemoveValFromList (head.next, val);
            head.next = RemoveValFromList (head.next, val);
            return head;
        }

        public static bool IsListPalindrome (ListNode<int> list)
        {
            if (list == null) return false;

            return false;
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
                {
                    //Console.WriteLine("Key Found:");
                    found[str[i]] += 1;
                }
                else
                {
                    //Console.WriteLine("Key Not Found:");
                    found.Add (str[i], 1);
                }
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
                    Console.WriteLine (sequence[i] + " is bigger or equal to " + sequence[i + 1]);
                    counter++;
                    //Console.WriteLine ("Counter: " + counter);
                }

                if (i + 2 < sequence.Length && sequence[i] >= sequence[i + 2])
                {
                    //Console.WriteLine ("Weird case");
                    Console.WriteLine (sequence[i] + " bigger or equal to " + sequence[i + 2]);
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
                {
                    return array[i];
                }
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
                        // System.Console.WriteLine("i: {0}\nj: {1}\n", i, j);

                        // System.Console.WriteLine("Temp: {0}\tLength: {1}", tempLongest.ToString(), tempLongest.ToString().Length);
                        // System.Console.WriteLine("Current: {0}\tLength: {1}", currentLongest.ToString(), currentLongest.ToString().Length);

                        if (tempLongest.ToString ().Length > currentLongest.ToString ().Length)
                        {
                            currentLongest.Clear ();
                            currentLongest.Append (tempLongest);
                            //System.Console.WriteLine("Saved Current Longest: {0}\n", currentLongest.ToString());
                        }

                        tempLongest.Clear ();
                        // System.Console.WriteLine("head: {0}", tempLongest.ToString());
                        // System.Console.WriteLine("Cleared head - Skipping Iteration\n");
                        break;
                    }
                    else
                    {
                        // System.Console.WriteLine("Current char: {0} - ADDED -", BaseString[j]);
                        // System.Console.WriteLine("i: {0}\nj: {1}\n", i, j);
                        tempLongest.Append (BaseString[j]);
                        // System.Console.WriteLine("Added: {0} to [{1}]\n", BaseString[j], tempLongest.ToString());
                        // System.Console.WriteLine("Current Longest: {0}\tLength: {1}", currentLongest.ToString(), currentLongest.ToString().Length);
                        // System.Console.WriteLine("Temp Longest: {0}\tLength: {1}", tempLongest.ToString(), tempLongest.ToString().Length);
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