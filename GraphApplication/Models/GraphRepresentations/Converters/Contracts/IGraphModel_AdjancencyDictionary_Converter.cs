namespace GraphApplication.Models.GraphRepresentations.Converters.Contracts
{
    public interface IGraphModel_AdjancencyDictionary_Converter
    {
        GraphModel_AdjancencyDictionary Convert(GraphModel_VertexEdgeList graphModel);
    }
}
