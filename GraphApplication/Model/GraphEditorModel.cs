﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
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
        public GraphModel GraphModel { get; set; }

        public GraphEditorModel()
        {
            GraphModel = new GraphModel();
        }

        public GraphEditorModel(GraphModel graphModel)
        {
            GraphModel = graphModel;
        }
    }
}
