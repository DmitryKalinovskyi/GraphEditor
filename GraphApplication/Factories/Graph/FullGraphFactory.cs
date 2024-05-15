using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Factories.Graph
{
    public class FullGraphFactory : IGraphFactory
    {
        public int VertexCount { get; set; } = 5;
        public double Radius { get; set; } = 100;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateFullGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateFullGraph(new UndirectedGraphModel());
        }

        public IGraphModel CreateFullGraph(IGraphModel graph)
        {
            if (VertexCount < 1)
            {
                throw new ArgumentException("VertexCount must be greater than 0.");
            }

            var vertices = new List<VertexModel>();
            var edges = new List<EdgeModel>();

            // Create all vertices
            for (int i = 0; i < VertexCount; i++)
            {
                double angle = 2 * Math.PI * i / VertexCount - Math.PI / 2;
                int x = (int)(Radius * Math.Cos(angle));
                int y = (int)(Radius * Math.Sin(angle));

                var vertex = new VertexModel(i, new Point(x, y));
                vertices.Add(vertex);
            }

            // Create edges between all pairs of vertices
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = i + 1; j < VertexCount; j++)
                {
                    edges.Add(new WeightedEdgeModel<double>(vertices[i], vertices[j]));
                }
            }

            foreach (var vertex in vertices)
                graph.AddVertex(vertex);

            foreach (var edge in edges)
                graph.AddEdge(edge);

            return graph;
        }
    }

}
