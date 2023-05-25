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
        private readonly VertexModel _model;

        private readonly GraphEditorModelView _editorModelView;

        public string Caption
        {
            get { return _model.Caption; }
            set
            {
                _model.Caption = value;
                OnPropertyChanged(nameof(_model.Caption));
            }
        }

        public double Top
        {
            get { return _model.Top; }
            set
            {
                _model.Top = value;
                OnPropertyChanged(nameof(_model.Top));
            }
        }
        public double Left
        {
            get { return _model.Left; }
            set
            {
                _model.Left = value;
                OnPropertyChanged(nameof(_model.Left));
            }
        }


        public VertexModelView(VertexModel model, GraphEditorModelView editorModelView)
        {
            _model = model;
            _editorModelView = editorModelView;
        }

        //events
        public event EventHandler<MouseEventArgs> MouseEventHandler;

        public MouseEventHandler MouseDown, MouseUp, MouseMove;


    }
}
