﻿namespace GraphApplication.Models.GraphRepresentations.Converters.Contracts
{
    public interface IGraphModel_EdgeDictionary_Converter
    {
        GraphModel_EdgeDictionary Convert(GraphModel_VertexEdgeList graphModel);
    }
}
