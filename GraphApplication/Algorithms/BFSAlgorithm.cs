using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms
{
    public class BFSAlgorithm : IIterativeAlgorithm
    {
        public IEnumerable<VertexModel> Implement(GraphModel graph, params object[] args)
        {
            VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Початкова точка не вказана! ");

            HashSet<VertexModel> visited = new HashSet<VertexModel>();

            List<VertexModel> ans = new List<VertexModel>();

            Queue<VertexModel> queue = new Queue<VertexModel>();

            queue.Enqueue(startPoint);

            while (queue.Count > 0)
            {
                VertexModel topElement = queue.Dequeue();

                ans.Add(topElement);

                foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
                {
                    if (visited.Contains(neighbor) == false && neighbor.IsActive)
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(topElement);
                    }
                }
            }

            return ans;
        }
    }
}
