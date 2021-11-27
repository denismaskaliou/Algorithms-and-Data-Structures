using System.Collections.Generic;

namespace Algorithms.Tasks
{
    public static class Chees_BredthFirstTraversal
    {
        public static string[] FindShortestWayForHorse(
            this IDictionary<string, IList<string>> graph,
            string startPoint,
            string targetPoint)
        {
            var points = new Dictionary<string, int> { { startPoint, 0 } };
            var parents = new Dictionary<string, string>();
            var queue = new Queue<string>(new[] { startPoint });

            while (queue.TryDequeue(out var currentPoint))
                foreach (var childPoint in graph[currentPoint])
                    if (!points.ContainsKey(childPoint))
                    {
                        queue.Enqueue(childPoint);
                        points.Add(childPoint, points[currentPoint]);
                        parents.Add(childPoint, currentPoint);

                        if (childPoint == targetPoint)
                        {
                            queue.Clear();
                            break;
                        }
                    }

            var path = new List<string>();
            var parrent = parents[targetPoint];
            while (parrent != startPoint)
            {
                path.Add(parrent);
                parrent = parents[parrent];
            }

            return path.ToArray();
        }
    }
}