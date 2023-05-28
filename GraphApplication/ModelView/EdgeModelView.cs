using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class EdgeModelView: NotifyModelView
    {
        public readonly EdgeModel EdgeModel;

        public VertexModelView Start { get; private set; }
        public VertexModelView End { get; private set; }

        public double X1
        {
            get { return EdgeModel.Start.Left; }
            set {
                EdgeModel.Start.Left = value;
                OnPropertyChanged(nameof(X1));
            }
        }

        public double Y1
        {
            get { return EdgeModel.Start.Top; }
            set
            {
                EdgeModel.Start.Top = value;
                OnPropertyChanged(nameof(Y1));
            }
        }

        public double X2
        {
            get { return EdgeModel.End.Left; }
            set
            {
                EdgeModel.End.Left = value;
                OnPropertyChanged(nameof(X2));
            }
        }

        public double Y2
        {
            get { return EdgeModel.End.Top; }
            set
            {
                EdgeModel.End.Top = value;
                OnPropertyChanged(nameof(Y2));
            }
        }

        public EdgeModelView(VertexModelView start, VertexModelView end)
        { 
            EdgeModel = new EdgeModel(start.Model, end.Model);
            Start = start;
            End = end;
        }

        //public EdgeModelView(EdgeModel edgeModel)
        //{
        //    this.EdgeModel = edgeModel;
        //}
    }
}
