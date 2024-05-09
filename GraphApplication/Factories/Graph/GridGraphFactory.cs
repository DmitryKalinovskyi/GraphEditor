using GraphApplication.Models.Graph;
using GraphApplication.Models;
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

        //public double MinWeight { get; set; } = 1;

        //public double MaxWeight { get; set; } = 1;

        public DirectedGraphModel CreateDirectedGraph()
        {
            throw new NotImplementedException();
        }

        public UndirectedGraphModel CreateGridGraph()
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

            return new UndirectedGraphModel(vertices, edges);
        }

        public UndirectedGraphModel CreateUndirectedGraph()
        {
            return CreateGridGraph();
        }
    }
}
