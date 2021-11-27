using System.Collections.Generic;

namespace DataStructures
{
    public sealed class UnionSet
    {
        private readonly IDictionary<int, (int Root, List<int> Children)> _unions;

        public UnionSet(int length)
        {
            _unions = new Dictionary<int, (int root, List<int> children)>();

            for (var i = 0; i < length; i++)
                _unions.Add(i, (i, new List<int> { i }));
        }

        public int Find(int vaertex)
        {
            return _unions[vaertex].Root;
        }

        public void Union(int x, int y)
        {
            var p1 = Find(x);
            var p2 = Find(y);

            var (toP, fromP) = _unions[p1].Children.Count > _unions[p2].Children.Count ? (p1, p2) : (p2, p1);

            _unions[fromP].Children.ForEach(p => _unions[p] = (toP, _unions[p].Children));
            _unions[toP].Children.AddRange(_unions[fromP].Children);
            _unions[fromP].Children.Clear();
        }
    }
}
