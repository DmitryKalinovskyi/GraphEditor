using GraphApplication.Algorithms;
using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorBFSMode : GraphEditorMode, IAlgorithmImplementer
    {
        public GraphEditorBFSMode(GraphEditorModelView modelView) : base(modelView)
        {
            algorithm = new BFSAlgorithm();
        }


        VertexModelView _selected;
        BFSAlgorithm algorithm;


        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView clicked = (sender as FrameworkElement).DataContext as VertexModelView;

            if (clicked == null)
                return;

            if (clicked == _selected)
                _selected.IsSelected = false;

            if (_selected != null)
            {
                _selected.IsSelected = false;
            }

            _selected = clicked;
            _selected.IsSelected = true;
        }

        public override void OnModeSwitch()
        {
            if (_selected != null)
            {
                _selected.IsSelected = false;
            }
        }

        public void Implement()
        {
            IEnumerable<VertexModel> iterator = algorithm.Implement(_modelView.GraphModelView.Model, _selected.Model);

            string path = "";

            foreach (VertexModel model in iterator)
                path += "->" + model.Caption;

            MessageBox.Show($"Finded path: {path}");
        }




    }
}
