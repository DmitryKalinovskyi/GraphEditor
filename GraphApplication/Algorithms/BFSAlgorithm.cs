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
        public (IEnumerable<VertexModel>, IEnumerable<EdgeModel>) Implement(GraphModel graph, params object[] args)
        {
            VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Початкова точка не вказана! ");

            HashSet<VertexModel> visited = new HashSet<VertexModel>();

            List<VertexModel> ans = new List<VertexModel>();
            List<EdgeModel> edges = new List<EdgeModel>();

            Queue<VertexModel> queue = new Queue<VertexModel>();
            Queue<EdgeModel> edgesQueue = new Queue<EdgeModel>();

            queue.Enqueue(startPoint);

            visited.Add(startPoint);

            while (queue.Count > 0)
            {
                VertexModel topElement = queue.Dequeue();

                ans.Add(topElement);
                if (edgesQueue.Count > 0)
                    edges.Add(edgesQueue.Dequeue());

                visited.Add(topElement);


                foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
                {
                    if (visited.Contains(neighbor) == false && neighbor.IsActive)
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);


                        edgesQueue.Enqueue(graph.EdgeDictionary[(topElement, neighbor)]);
                    }
                }
            }

            return (ans, edges);
        }
    }
}
