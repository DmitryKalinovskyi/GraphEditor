using GraphApplication.Models.Graph;

namespace GraphApplication.Factories.Graph
{
    public interface IGraphFactory
    {
        public DirectedGraphModel CreateDirectedGraph();

        public UndirectedGraphModel CreateUndirectedGraph();
    }
}
