using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    class VertexModelView: NotifyModelView
    {
        private readonly VertexModel _model;

        public string Caption
        {
            get { return _model.Caption; }
            set
            {
                _model.Caption = value;
                OnPropertyChanged(nameof(_model.Caption));
            }
        }

        public VertexModelView(VertexModel model)
        {
            _model = model;
        }

    }
}
