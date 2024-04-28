using GraphApplication.Algorithms.Contracts;
using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;

namespace GraphApplication.Algorithms
{
    public class DFSAlgorithm : IDFSAlgorithm
    {
        public IterativeAlgorithmResult BuildRoute(IGraphModel graph, params object[] args)
        {
            throw new NotImplementedException();
        }
    }

    //public class DFSAlgorithm : IDFSAlgorithm
    //{
    //    /// <summary>
    //    /// Build dfs path in graph, as first argument you should pass VertexModel
    //    /// </summary>
    //    /// <param name="graph"></param>
    //    /// <param name="args"></param>
    //    /// <returns></returns>
    //    /// <exception cref="ArgumentException"></exception>
    //    public IterativeAlgorithmResult BuildRoute(GraphModel graph, params object[] args)
    //    {
    //        VertexModel startPoint = args[0] as VertexModel ?? throw new ArgumentException("Початкова точка не вказана! ");

    //        HashSet<VertexModel> visited = new();

    //        List<VertexModel> ans = new();
    //        List<EdgeModel> edges = new();

    //        Stack<VertexModel> stack = new();
    //        Stack<EdgeModel> edgesStack = new();

    //        stack.Push(startPoint);

    //        while (stack.Count > 0)
    //        {
    //            VertexModel topElement = stack.Pop();
    //            EdgeModel? edge = null;

    //            if (edgesStack.Count > 0)
    //                edge = edgesStack.Pop();

    //            if (visited.Contains(topElement))
    //            {
    //                continue;
    //            }

    //            ans.Add(topElement);
    //            if (edge != null)
    //            {
    //                edges.Add(edge);
    //            }

    //            visited.Add(topElement);

    //            foreach (VertexModel neighbor in graph.AdjancencyDictionary[topElement])
    //            {
    //                if (visited.Contains(neighbor) == false && neighbor.IsActive)
    //                {
    //                    stack.Push(neighbor);

    //                    edgesStack.Push(graph.EdgeDictionary[(topElement, neighbor)]);
    //                }
    //            }

    //        }

    //        return new(ans, edges);
    //    }
    //}
}
