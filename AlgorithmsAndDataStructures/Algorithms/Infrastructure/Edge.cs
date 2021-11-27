using System;

namespace Algorithms.Infrastructure
{
    public class Edge : IComparable<Edge>
    {
        public int CurrentVertex { get; set; }
        public int NextVertex { get; set; }
        public int Weight { get; set; }

        public Edge(int currnet, int next, int w)
        {
            CurrentVertex = currnet;
            NextVertex = next;
            Weight = w;
        }

        public int CompareTo(Edge other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            return Weight > other.Weight
                ? 1
                : Weight == other.Weight
                    ? 0
                    : -1;
        }
    }
}