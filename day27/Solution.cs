using System;
using System.Collections.Generic;
using System.Linq;

namespace day27
{
    public class Solution
    {
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            if (dislikes == null || dislikes.Length == 0)
            {
                return true;
            }

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            foreach (int[] entry in dislikes)
            {
                if (!dict.ContainsKey(entry[0]))
                {
                    dict[entry[0]] = new List<int>();
                }

                dict[entry[0]].Add(entry[1]);

                if (!dict.ContainsKey(entry[1]))
                {
                    dict[entry[1]] = new List<int>();
                }

                dict[entry[1]].Add(entry[0]);
            }

            int[] groups = new int[N + 1];
            List<int> list =  dict.Keys.ToList();

            foreach (int k in list)
            {
                if (groups[k] == 0 && !CheckPossibility(dict, k, groups, 1))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckPossibility(Dictionary<int, List<int>> dict, int k, int[] groups, int groupNumber)
        {
            if (groups[k] != 0)
            {
                return groups[k] == groupNumber;
            }

            groups[k] = groupNumber;

            foreach (var entry in dict[k])
            {
                if (!CheckPossibility(dict, entry, groups, -groupNumber))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
