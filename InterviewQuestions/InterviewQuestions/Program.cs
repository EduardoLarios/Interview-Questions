using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        // come on dude pls no flamerino
        static void MinimumBribes(int[] q)
        {
            var bribes = 0;
            for (var i = 0; i < q.Length; ++i)
            {
                var places = q[i] - (i + 1);
                if (places < 3)
                {
                    bribes += places;
                    i += places;
                }
                else
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }

            Console.WriteLine(bribes);
        }

        static IList<IList<int>> AllPathsSourceTargetMemo(int[][] graph)
        {
            /* 
                Input: [[1,2], [3], [3], []]  
                Output: [[0,1,3],[0,2,3]]
            */
            var target = graph.Length - 1;
            var result = new List<IList<int>>();
            var memo = new Dictionary<int, List<List<int>>>();

            // Sanity checks.
            if (graph == null) return result;
            if (graph.Length == 1) result.Add(graph[0]);

            FindPathMemo(graph, target, 0, new List<int>(), result, memo);

            // Result = Input: [[1,2], [3], [3], []]  Output: [[0,1,3],[0,2,3]]
            return result;
        }
        static bool FindPathMemo(int[][] graph, int target, int index, List<int> path, List<IList<int>> result, Dictionary<int, List<List<int>>> memo)
        {
            path.Add(index);

            // Base case check.
            if (index == target)
            {
                memo.Add(index, new List<int>() { index });
                result.Add(path);
                return true;
            }

            // Find options.
            foreach (var child in graph[index])
            {
                if (memo.ContainsKey(child))
                {
                    var memoPath = new List<int>() { index };
                    memoPath.AddRange(memo[child]);

                    result.Add(memoPath);
                    continue;
                }

                // Explore options.
                var valid = FindPathMemo(graph, target, child, new List<int>(path), result, memo);
                if (valid)
                {
                    var memoPath = new List<int>() { index };
                    memoPath.AddRange(memo[child]);

                    memo.Add(index, memoPath);
                }
            }

            return false;

        }

        static void Main(string[] args)
        {

        }
    }
}