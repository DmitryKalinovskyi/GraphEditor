using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms
{
    public class DFSAlgorithm : IIterativeAlgorithm
    {
        public (IEnumerable<VertexModel>?, IEnumerable<EdgeModel>?) Implement(GraphModel graph, params object[] args)
        {
            VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Початкова точка не вказана! ");

            HashSet<VertexModel> visited = new HashSet<VertexModel>();

            List<VertexModel> ans = new List<VertexModel>();
            List<EdgeModel> edges = new List<EdgeModel>();

            Stack<VertexModel> stack = new Stack<VertexModel>();
            Stack<EdgeModel> edgesStack = new Stack<EdgeModel>();

            stack.Push(startPoint);


            while (stack.Count > 0)
            {
                VertexModel topElement = stack.Pop();
                EdgeModel? edge = null;

                if (edgesStack.Count > 0)
                edge = edgesStack.Pop();

                if (visited.Contains(topElement))
                {
                    continue;
                }

                ans.Add(topElement);
                if (edge != null)
                {
                    edges.Add(edge);
                }

                visited.Add(topElement);

                foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
                {
                    if (visited.Contains(neighbor) == false && neighbor.IsActive)
                    {
                        stack.Push(neighbor);

                        edgesStack.Push(graph.EdgeDictionary[(topElement, neighbor)]);
                    }
                }

            }

            return (ans, edges);
        }
    }
}
