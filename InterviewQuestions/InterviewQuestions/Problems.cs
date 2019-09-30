using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LeetCode
{
    class Problems
    {
        public class MovingAverage
        {
            /** Initialize your data structure here. */
            public Queue<int> Values;
            public int Start;
            public int Size;
            public double Sum;

            public MovingAverage(int size)
            {
                Values = new Queue<int>(size);
                Size = size;
                Start = 0;
                Sum = 0;
            }

            public double Next(int val)
            {
                Values.Enqueue(val);
                Sum += val;

                if (Values.Count > Size)
                {
                    Sum -= Values.Dequeue();

                    return Sum / Size;
                }

                return Sum / Values.Count;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode ReverseList(ListNode head)
            {
                if (head == null || head.next == null) return head;

                ListNode previous = null;
                var current = head;

                while (current != null)
                {
                    ListNode next = current.next;
                    current.next = previous;
                    previous = current;
                    current = next;
                }

                return previous;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0 || nums == null) return null;
            if (nums.Length == 1) return new TreeNode(nums[0]);

            var mid = (0 + nums.Length) / 2;
            var root = new TreeNode(nums[mid])
            {
                left = FillTree(nums, 0, mid - 1),
                right = FillTree(nums, mid + 1, nums.Length - 1)
            };

            return root;
        }
        
        static TreeNode FillTree(int[] nums, int start, int end)
        {
            if (start > end) return null;

            var mid = (start + end) / 2;
            var root = new TreeNode(nums[mid])
            {
                left = FillTree(nums, start, mid - 1),
                right = FillTree(nums, mid + 1, end)
            };

            return root;
        }
        
        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n < 1) return;

            int i1 = m - 1;
            int i2 = n - 1;
            int i = nums1.Length - 1;

            while ((i1 >= 0) && (i2 >= 0))
            {
                nums1[i--] = (nums1[i1] < nums2[i2]) ? nums2[i2--] : nums1[i1--];
            }

            if (i2 < 0) return;
            for (int j = i; j >= 0; j--) nums1[j] = nums2[j];

        }

        static int LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2) return s.Length;

            int start = 0;
            int len = 0;

            int maxstart = 0;
            int maxend = 0;
            int maxlen = 0;

            var d = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (d.ContainsKey(s[i]))
                {
                    if (d[s[i]] >= start) start = d[s[i]] + 1;
                    d[s[i]] = i;
                }

                else d.Add(s[i], i);

                len = (i - start) + 1;
                (maxlen, maxstart, maxend) = (len > maxlen)
                    ? (len, start, i)
                    : (maxlen, maxstart, maxend);
            }

            return Math.Max(len, maxlen);
        }

        static IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            if (matrix == null || matrix.Length < 1) return result;
            if (matrix.Length == 1) return matrix[0];

            var elements = matrix.Length * matrix[0].Length;
            var heigth = matrix.Length - 1;
            var width = matrix[0].Length - 1;
            var offset = 0;

            while (elements > 0)
            {
                var horizontal = offset;
                var vertical = offset;

                if (elements == 1)
                {
                    result.Add(matrix[vertical][horizontal]);
                    return result;
                }

                // go right
                for (; horizontal < width; horizontal++)
                {
                    result.Add(matrix[vertical][horizontal]);
                    if (--elements == 0) return result;
                }

                // go down
                for (; vertical < heigth; vertical++)
                {
                    result.Add(matrix[vertical][horizontal]);
                    if (--elements == 0) return result;
                }

                // go left
                for (; horizontal > offset; horizontal--)
                {
                    result.Add(matrix[vertical][horizontal]);
                    if (--elements == 0) return result;
                }

                // go up 
                for (; vertical > offset; vertical--)
                {
                    result.Add(matrix[vertical][horizontal]);
                    if (--elements == 0) return result;
                }

                ++offset;
                --heigth;
                --width;
            }

            return result;
        }

        static string ReverseWords(string s)
        {
            var split = s.Split(' ');
            var words = new List<string>();

            foreach (var word in split)
            {
                if (!word.Contains(" ") && word != "") words.Add(word);
            }

            var sb = new StringBuilder();

            for (int i = words.Count - 1; i >= 0; i--)
            {
                if (!words[i].Contains(" "))
                {
                    sb.Append(words[i]);
                }

                else continue;

                if (i == 0) continue;
                sb.Append(" ");
            }

            return sb.ToString();
        }

        static void MoveZeroes(int[] nums)
        {
            var zeros = nums.Count(n => n == 0);
            if (zeros == 0) return;
            var insert = 0;

            while (insert < nums.Length && nums[insert] != 0) ++insert;
            var search = insert + 1;

            while (search < nums.Length)
            {
                if (nums[search] != 0)
                {
                    nums[insert] = nums[search];
                    insert++;
                }

                ++search;
            }

            for (int i = nums.Length - zeros; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        static string ReverseOnlyLetters(string S)
        {
            var result = new char[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                if (!char.IsLetter(S[i])) result[i] = S[i];
            }

            var j = S.Length - 1;
            for (int i = 0; i < S.Length; i++)
            {
                if (result[i] == '\0')
                {
                    while (j > 0 && !char.IsLetter(S[j])) --j;
                    result[i] = S[j];
                    --j;
                }
            }

            return new string(result);
        }

        static int NumJewelsInStones(string J, string S)
        {
            var jewels = new HashSet<char>(J);
            var res = 0;
            foreach (var stone in S)
            {
                if (jewels.Contains(stone)) ++res;
            }

            return res;
        }

        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var ds = new Dictionary<char, int>();
            var dt = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (ds.ContainsKey(s[i])) ds[s[i]]++;
                else ds.Add(s[i], 1);

                if (dt.ContainsKey(t[i])) dt[t[i]]++;
                else dt.Add(t[i], 1);
            }

            foreach (var key in ds.Keys)
            {
                if (!dt.ContainsKey(key) || ds[key] != dt[key]) return false;
            }

            return true;
        }

        static int FirstUniqChar(string s)
        {
            var dic = new Dictionary<char, (int times, int index)>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                {
                    dic.Add(s[i], (1, i));
                }

                else
                {
                    var tuple = dic[s[i]];
                    tuple.times++;
                    dic[s[i]] = tuple;
                }
            }

            foreach (var key in dic.Keys)
            {
                if (dic[key].times == 1) return dic[key].index;
            }

            return -1;
        }

        static int[] PlusOne(int[] digits)
        {
            int total = 0;
            for (var i = 0; i < digits.Length; i++)
            {
                var number = digits[i] * Math.Pow(10, digits.Length - i - 1);
                total += (int)number;
            }

            total++;

            //Console.WriteLine(total);

            var temp = total.ToString();
            var result = new int[temp.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (int)char.GetNumericValue(temp[i]);
            }

            return result;
        }

        static int[] RotLeft(int[] a, int d)
        {
            var result = new int[a.Length];
            var length = a.Length;
            for (var i = 0; i < length; ++i)
            {
                result[(i - d + length) % length] = a[i];
            }

            return result;

        }

        static int[] TwoSum(int[] nums, int target)
        {
            var complements = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (complements.ContainsKey(complement))
                {
                    return new int[] { complements[complement], i };
                }

                if (complements.ContainsKey(nums[i]))
                {
                    complements[nums[i]] = i;
                }

                else
                {
                    complements.Add(nums[i], i);
                }

            }

            return null;
        }

        static string AddStringsBigInt(string num1, string num2)
        {
            long tmp1 = 0;
            long tmp2 = 0;

            // ASCII 30 - 39 are numbers

            for (int i = 0; i < num1.Length; i++)
            {
                long n = num1[i] - 48;
                if (num1[i] == '0') continue;

                var exponent = num1.Length - i - 1;
                tmp1 += n * (long)Math.Pow(10, exponent);
            }

            for (int i = 0; i < num2.Length; i++)
            {
                long n2 = num2[i] - 48;
                if (num2[i] == '0') continue;

                var exponent2 = num2.Length - i - 1;
                tmp2 += n2 * (long)Math.Pow(10, exponent2);
            }

            return (tmp1 + tmp2).ToString();

        }
        
        static string AddStrings(string num1, string num2)
        {
            var stack = new Stack<char>();

            char carry = (char)48;
            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;

            while (p1 >= 0 || p2 >= 0)
            {
                char n1 = (p1 >= 0) ? num1[p1--] : (char)48;
                char n2 = (p2 >= 0) ? num2[p2--] : (char)48;
                char res = (char)((carry - 48) + (n1 - 48) + (n2 - 48));

                if (res > 9)
                {
                    carry = (char)49;
                    res = (char)(res - 10 + 48);
                }

                else
                {

                    carry = (char)48;
                    res = (char)(res + 48);
                }

                stack.Push(res);
            }

            if (carry > 48) stack.Push(carry);

            return string.Join("", stack);

        }

        static void CheckMagazine(string[] magazine, string[] note)
        {
            var mag = new Dictionary<string, int>();
            var ransom = new Dictionary<string, int>();
            foreach (var word in magazine)
            {
                if (!mag.ContainsKey(word))
                    mag.Add(word, 1);
                else
                    ++mag[word];
            }

            foreach (var word in note)
            {
                if (!ransom.ContainsKey(word))
                    ransom.Add(word, 1);
                else
                    ++ransom[word];
            }

            foreach (var item in ransom)
            {
                if (!mag.ContainsKey(item.Key) || mag[item.Key] < ransom[item.Key])
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");

        }

        static IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            /* 
                Input: [[1,2], [3], [3], []]  
                Output: [[0,1,3],[0,2,3]]
            */
            var target = graph.Length - 1;
            var result = new List<IList<int>>();

            // Sanity checks.
            if (graph == null) return result;
            if (graph.Length == 1) result.Add(graph[0]);

            FindPath(graph, target, 0, new List<int>(), result);

            // Result = Input: [[1,2], [3], [3], []]  Output: [[0,1,3],[0,2,3]]
            return result;
        }

        static void FindPath(int[][] graph, int target, int index, List<int> path, List<IList<int>> result)
        {
            path.Add(index);

            // Base case check.
            if (index == target) result.Add(path);

            // Find options.
            foreach (var child in graph[index])
            {
                // Explore options.
                FindPath(graph, target, child, new List<int>(path), result);
            }

        }
    }
}
