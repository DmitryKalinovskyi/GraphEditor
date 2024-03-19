using GraphApplication.Models.GraphRepresentations;
using System.Runtime.Serialization;

namespace GraphApplication.Models
{
    /// <summary>
    /// Store all information about GraphEditor but not actual graph
    /// </summary>
    /// 

    [DataContract(IsReference = true)]
    public class GraphEditorModel
    {
        public static double MinScale = 0.25;
        public static double MaxScale = 6;
        public static double DefaultScale = 1;
        public static double DefaultCachingScale = 0.8;

        [DataMember]
        public double ScaleValue { get; set; } = DefaultScale;

        [DataMember]
        public double OffsetX { get; set; }

        [DataMember]
        public double OffsetY { get; set; }

        [DataMember]
        public double CachingScale { get; set; } = DefaultCachingScale;

        [DataMember]
        public GraphModel_VertexEdgeList GraphModel { get; set; }

        [DataMember]
        public ToolBarModel ToolBarModel { get; set; }

        public GraphEditorModel() : this(new()) { }

        public GraphEditorModel(GraphModel_VertexEdgeList graphModel)
        {
            GraphModel = graphModel;
            ToolBarModel = new();
        }
    }
}
