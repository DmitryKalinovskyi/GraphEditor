using GraphApplication.Models;
using System.Windows;

namespace GraphApplication.ModelViews
{
    public class VertexModelView : NotifyModelView
    {
        public readonly VertexModel Model;

        public string Caption
        {
            get { return Model.Caption; }
            set
            {
                Model.Caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public double X
        {
            get { return Model.X; }
            set
            {
                Model.X = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get { return Model.Y; }
            set
            {
                Model.Y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public bool IsActive
        {
            get { return Model.IsActive; }

            set
            {
                Model.IsActive = value;
                OnPropertyChanged(nameof(IsActive));
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


        public VertexModelView()
        {
            Model = new VertexModel(-1, 0, 0);
        }

        public VertexModelView(VertexModel model)
        {
            Model = model;
        }
    }
}
