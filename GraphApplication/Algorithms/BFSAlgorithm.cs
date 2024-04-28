using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class BFSAlgorithm : IBFSAlgorithm
    {
        public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
    //public class BFSAlgorithm : IBFSAlgorithm
    //{
    //    /// <summary>
    //    /// Build bfs path in graph, as first argument you should pass VertexModel
    //    /// </summary>
    //    /// <param name="graph"></param>
    //    /// <param name="args"></param>
    //    /// <returns></returns>
    //    /// <exception cref="ArgumentException"></exception>
    //    public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
    //    {
    //        VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Starting pos is not defined.");

    //        var visited = new HashSet<VertexModel>();

    //        var ans = new List<VertexModel>();
    //        var edges = new List<EdgeModel>();

    //        var queue = new Queue<VertexModel>();
    //        var edgesQueue = new Queue<EdgeModel>();

    //        queue.Enqueue(startPoint);

    //        visited.Add(startPoint);

    //        while (queue.Count > 0)
    //        {
    //            VertexModel topElement = queue.Dequeue();

    //            ans.Add(topElement);
    //            if (edgesQueue.Count > 0)
    //                edges.Add(edgesQueue.Dequeue());

    //            visited.Add(topElement);


    //            foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
    //            {
    //                if (visited.Contains(neighbor) == false && neighbor.IsActive)
    //                {
    //                    visited.Add(neighbor);
    //                    queue.Enqueue(neighbor);


    //                    edgesQueue.Enqueue(graph.EdgeDictionary[(topElement, neighbor)]);
    //                }
    //            }
    //        }

    //        return new IterativeAlgorithmResult(ans, edges);
    //    }
    //}
}
