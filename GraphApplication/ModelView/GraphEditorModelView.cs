using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class GraphEditorModelView: NotifyModelView
    {
        private GraphEditorModel _model;

        public IEnumerable<VertexModel> VertexObjects
        {
            get { return _model.VertexObjects; }
            set
            {
                _model.VertexObjects = value;
                OnPropertyChanged(nameof(_model.VertexObjects));
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool IsSaved
        {
            get { return _model.IsSaved; }
            set
            {
                _model.IsSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

        public GraphEditorModelView(GraphEditorModel model)
        {
            _model = model;
        }

    }
}
