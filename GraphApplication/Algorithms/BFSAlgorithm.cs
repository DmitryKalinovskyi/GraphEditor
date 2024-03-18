using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class BFSAlgorithm : IBFSAlgorithm
    {
        /// <summary>
        /// Build bfs path in graph, as first argument you should pass VertexModel
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IterativeAlgorithmResult BuildRoute(GraphModel graph, params object[] args)
        {
            VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Starting pos is not defined.");

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

            return new IterativeAlgorithmResult(ans, edges);
        }
    }
}
