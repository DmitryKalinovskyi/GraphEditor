using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class BFSAlgorithm : IBFSAlgorithm
    {
        public TraversalAlgorithmResult Traverse(IGraphModel graph, VertexModel source, params object[] args)
        {
            // idea of algorithm, we add first vertex to the queue, then for each vertice in queue:
            // add their neighbors and edge that direct to that vertex (if they don't visited before)
            // do that while queue is not empty.

            var visited = new HashSet<VertexModel>();

            var resultVertices = new List<VertexModel>();
            var resultEdges = new List<EdgeModel>();


            // vertex and edge that points to that edge
            var queue = new Queue<(VertexModel, EdgeModel?)>();

            // to the first vertex we don't have pointing edges, so we add null and later ingore it.
            queue.Enqueue((source, null));

            visited.Add(source);

            while (queue.Count > 0)
            {
                (VertexModel frontVertex, EdgeModel? frontEdge) = queue.Dequeue();

                resultVertices.Add(frontVertex);
                if (frontEdge != null)
                {
                    resultEdges.Add(frontEdge);
                }

                visited.Add(frontVertex);

                foreach (VertexModel neighbor in graph.GetNeighbors(frontVertex))
                {
                    if (visited.Contains(neighbor) == false)
                    {
                        visited.Add(neighbor);
                        queue.Enqueue((neighbor, graph.GetEdgeBetween(frontVertex, neighbor)));
                    }
                }
            }

            return new TraversalAlgorithmResult(resultVertices, resultEdges);
        }
    }
}
