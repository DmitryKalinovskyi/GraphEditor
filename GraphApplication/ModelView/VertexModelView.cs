using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphApplication.ModelView
{
    public class VertexModelView: NotifyModelView
    {
        public readonly VertexModel Model;

        public string Caption
        {
            get { return Model.Caption; }
            set
            {
                Model.Caption = value;
                OnPropertyChanged(nameof(Model.Caption));
            }
        }

        public double Top
        {
            get { return Model.Top; }
            set
            {
                Model.Top = value;
                OnPropertyChanged(nameof(Model.Top));
            }
        }
        public double Left
        {
            get { return Model.Left; }
            set
            {
                Model.Left = value;
                OnPropertyChanged(nameof(Model.Left));
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get{ return _isSelected; }

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
                OnPropertyChanged(nameof(Model.IsActive));
            }
        }

        public VertexModelView(VertexModel model)
        {
            Model = model;
        }
    }
}
