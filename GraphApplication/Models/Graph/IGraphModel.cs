using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Models.Graph
{
    public interface IGraphModel { }

    public interface IGraphModel<TVertex, TEdge>: IGraphModel
        where TVertex : VertexModel
        where TEdge : EdgeModel
    {
        // Methods should notify about each event.
        public void AddVertex(TVertex vertex);

        public void RemoveVertex(TVertex vertex);

        public void AddEdge(TEdge edge);

        public void RemoveEdge(TEdge edge);

        public bool IsConnectionBetween(TVertex source, TVertex destination);

        public TEdge? GetEdgeBetween(TVertex source, TVertex destination);

        public IEnumerable<TVertex> GetVertices();

        public IEnumerable<TEdge> GetEdges();

        public int GetVerticesCount();

        public int GetEdgesCount();

        // using events we can go from idea, where it the same time store all representations in one class, to 
        // idea implement another class, that can handle changes of the graph, and upbuild own version 

        // purpose of creating different graph representations, it's to speed up algorithm usage.
        public event EventHandler<TVertex>? OnVertexAdded;
        public event EventHandler<TEdge>? OnEdgeAdded;
        public event EventHandler<TVertex>? OnVertexRemoved;
        public event EventHandler<TEdge>? OnEdgeRemoved;
    }

    // use weighted edgeModel
    public interface IWeightedGraphModel: IGraphModel<VertexModel, EdgeModel> { }
}
