using GraphApplication.Models.Graph;
using GraphApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GraphApplication.Factories.Graph
{
    public class BipartiteGraphFactory : IGraphFactory
    {
        public int VertexCountGroup1 { get; set; } = 4;
        public int VertexCountGroup2 { get; set; } = 4;
        public double Radius { get; set; } = 200;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateBipartiteGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateBipartiteGraph(new UndirectedGraphModel());
        }

        public IGraphModel CreateBipartiteGraph(IGraphModel graph)
        {
            if (VertexCountGroup1 < 1 || VertexCountGroup2 < 1)
            {
                throw new ArgumentException("VertexCount for both groups must be greater than 0.");
            }

            var verticesGroup1 = new List<VertexModel>();
            var verticesGroup2 = new List<VertexModel>();
            var edges = new List<EdgeModel>();

            // Create all vertices for group 1
            for (int i = 0; i < VertexCountGroup1; i++)
            {
                double x = -Radius;
                double y = 2 * Radius * i / (VertexCountGroup1 - 1) - Radius;

                var vertex = new VertexModel(i, new Point(x, y));
                verticesGroup1.Add(vertex);
            }

            // Create all vertices for group 2
            for (int i = 0; i < VertexCountGroup2; i++)
            {
                double x = Radius;
                double y = 2 * Radius * i / (VertexCountGroup2 - 1) - Radius;

                var vertex = new VertexModel(VertexCountGroup1 + i, new Point(x, y));
                verticesGroup2.Add(vertex);
            }

            // Create edges between all pairs of vertices from different groups
            for (int i = 0; i < VertexCountGroup1; i++)
            {
                for (int j = 0; j < VertexCountGroup2; j++)
                {
                    edges.Add(new WeightedEdgeModel<double>(verticesGroup1[i], verticesGroup2[j]));
                }
            }

            foreach (var vertex in verticesGroup1.Concat(verticesGroup2))
                graph.AddVertex(vertex);

            foreach (var edge in edges)
                graph.AddEdge(edge);

            return graph;
        }
    }

}
