using System;
using System.Collections.Generic;

namespace day29
{
    public class Solution
    {
        Dictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
        HashSet<int> visited = new HashSet<int>();

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // assemble the map of which courses are prereqs to each other
            foreach (int[] prereq in prerequisites)
            {
                if (!map.ContainsKey(prereq[0]))
                {
                    map[prereq[0]] = new List<int>();
                }

                map[prereq[0]].Add(prereq[1]);
            }

            foreach (int key in map.Keys)
            {
                if (SearchCycle(key, new HashSet<int>()))
                {
                    return false;
                }
            }

            return true;
        }

        private bool SearchCycle(int current, HashSet<int> chain)
        {
            if (chain.Contains(current))
            {
                // we found a cycle
                return true;
            }

            if (visited.Contains(current))
            {
                // we accessed this course already, so no cycle
                return false;
            }

            visited.Add(current);

            if (map.ContainsKey(current))
            {
                // this course has prereqs
                chain.Add(current);

                foreach (int next in map[current])
                {
                    if (SearchCycle(next, chain))
                    {
                        return true;
                    }
                }

                // remove from current chain to avoid impacting backtracking
                chain.Remove(current);
            }

            return false;
        }
    }
}
