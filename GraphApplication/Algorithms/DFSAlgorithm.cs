using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class DFSAlgorithm : IDFSAlgorithm
    {
        public TraversalAlgorithmResult Traverse(IGraphModel graph, VertexModel source, params object[] args)
        {
            HashSet<VertexModel> visited = new();

            List<VertexModel> ans = new();
            List<EdgeModel> edges = new();

            Stack<VertexModel> stack = new();
            Stack<EdgeModel> edgesStack = new();

            stack.Push(source);

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

                foreach (VertexModel neighbor in graph.GetNeighbors(topElement))
                {
                    if (visited.Contains(neighbor) == false && neighbor.IsActive)
                    {
                        stack.Push(neighbor);

                        edgesStack.Push(graph.GetEdgeBetween(topElement, neighbor));
                    }
                }

            }

            return new(ans, edges);
        }
    }
}
