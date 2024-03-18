using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.GraphRepresentations;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class BFSShortestPathAlgorithm : IShortestPathAlgorithm
    {
        private IterativeAlgorithmResult BuildPathByParents(
            GraphModel graphModel,
            ref Dictionary<VertexModel, VertexModel> parents,
            VertexModel end)
        {
            List<VertexModel> path = new();

            List<EdgeModel> edges = new();

            while (true)
            {
                if (path.Count > 0)
                {
                    edges.Insert(0, graphModel.EdgeDictionary[(end, path[0])]);
                }

                path.Insert(0, end);

                if (parents.ContainsKey(end) == false)
                {
                    break;
                }

                end = parents[end];
            }

            return new(path, edges);
        }

        /// <summary>
        /// Build shortest path in graph between two points, as arguments you should pass 2 VertexModels
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IterativeAlgorithmResult BuildRoute(GraphModel graph, params object[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException("Для знаходження шляху потрібно передати 2 аргументи!");

            VertexModel start = args[0] as VertexModel ?? throw new ArgumentException("First argument should be vertex model.");
            VertexModel end = args[1] as VertexModel ?? throw new ArgumentException("Second argument should be vertex model.");

            Dictionary<VertexModel, VertexModel> parents = new();
            HashSet<VertexModel> visited = new();

            Queue<VertexModel> queue = new Queue<VertexModel>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                VertexModel topElement = queue.Dequeue();

                foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
                {
                    if (visited.Contains(neighbor) == false && neighbor.IsActive)
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(topElement);

                        if (parents.ContainsKey(neighbor) == false)
                            parents[neighbor] = topElement;

                        if (neighbor == end)
                            return BuildPathByParents(graph, ref parents, end);

                    }
                }
            }

            return IterativeAlgorithmResult.FailedToBuildRouteResult;
        }
    }
}
