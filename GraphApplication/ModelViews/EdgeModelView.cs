using GraphApplication.Models;

namespace GraphApplication.ModelViews
{
    public class EdgeModelView : NotifyModelView
    {
        public readonly EdgeModel Model;

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
            Model = new EdgeModel(start.Model, end.Model);
            Start = start;
            End = end;
        }

        public EdgeModelView(EdgeModel model, VertexModelView start, VertexModelView end)
        {
            Model = model;
            Start = start;
            End = end;
        }
    }
}
