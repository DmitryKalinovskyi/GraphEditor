using GraphApplication.Models.Graph;
using System.Runtime.Serialization;

namespace GraphApplication.Models
{
    /// <summary>
    /// Store all information about project
    /// </summary>
    /// 

    [DataContract(IsReference = true)]
    public class GraphProjectModel
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
        public IGraphModel? GraphModel { get; set; }

        public GraphProjectModel(IGraphModel graphModel)
        {
            GraphModel = graphModel;
        }

        public GraphProjectModel()
        {
            GraphModel = null;
        }
    }
}
