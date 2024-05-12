using GraphApplication.Models;

namespace GraphApplication.ModelViews
{
    public class EdgeModelView : NotifyModelView
    {
        public readonly WeightedEdgeModel<double> Model;

        public double Weight
        {
            get { return Model.Weight; }
            set
            {
                Model.Weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private bool _isMarked;

        public bool IsMarked
        {
            get
            {
                return _isMarked;
            }

            set
            {
                _isMarked = value;
                OnPropertyChanged(nameof(IsMarked));
            }
        }

        public VertexModelView Start { get; private set; }
        public VertexModelView End { get; private set; }

        public EdgeModelView(VertexModelView start, VertexModelView end)
        {
            Model = new(start.Model, end.Model);
            Start = start;
            End = end;
        }

        public EdgeModelView(WeightedEdgeModel<double> model, VertexModelView start, VertexModelView end)
        {
            Model = model;
            Start = start;
            End = end;
        }
    }
}
