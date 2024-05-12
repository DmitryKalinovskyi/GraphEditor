using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GraphApplication.Factories.Graph
{
    public class GridGraphFactory : IGraphFactory
    {
        public int Rows { get; set; } = 1;

        public int Columns { get; set; } = 1;

        public double RowGap { get; set; } = 50;

        public double ColumnGap { get; set; } = 50;

        public DirectedGraphModel CreateDirectedGraph()
        {
            return (DirectedGraphModel)CreateGridGraph(new DirectedGraphModel());
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return (UndirectedGraphModel)CreateGridGraph(new UndirectedGraphModel());
        }


        public IGraphModel CreateGridGraph(IGraphModel graphModel)
        {
            if (Rows < 1 || Columns < 1)
            {
                throw new ArgumentException("Grid dimensions must be greater than 0.");
            }

            var vertices = new List<VertexModel>();
            var edges = new List<EdgeModel>();

            // Create vertices
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var vertex = new VertexModel(i * Columns + j, new Point(j * RowGap, i * ColumnGap)); // Adjust spacing as needed
                    vertices.Add(vertex);
                }
            }

            // Create horizontal edges
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns - 1; j++)
                {
                    edges.Add(new WeightedEdgeModel<double>(vertices[i * Columns + j], vertices[i * Columns + j + 1]));
                }
            }

            // Create vertical edges
            for (int i = 0; i < Rows - 1; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    edges.Add(new WeightedEdgeModel<double>(vertices[i * Columns + j], vertices[(i + 1) * Columns + j]));
                }
            }

            foreach (var vertex in vertices)
                graphModel.AddVertex(vertex);

            foreach (var edge in edges)
                graphModel.AddEdge(edge);

            return graphModel;
        }

    }
}
