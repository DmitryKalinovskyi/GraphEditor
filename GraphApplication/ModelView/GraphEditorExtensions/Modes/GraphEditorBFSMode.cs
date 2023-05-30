using GraphApplication.Algorithms;
using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorBFSMode : GraphEditorSelectionMode, IAlgorithmImplementer
    {
        public GraphEditorBFSMode(GraphEditorModelView modelView) : base(modelView)
        {
            _algorithm = new BFSAlgorithm();
        }


        BFSAlgorithm _algorithm;
        BFSDisplayer? _displayer;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if (_displayer != null)
            {
                CancelAnimation();
            }

            base.VertexClicked(sender, e);
        }

        public void Implement()
        {
            List<VertexModelView> selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("Алгоритм пошуку в ширину реалізувати не можливо, поки не обрано тільки одну вершину!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            IEnumerable<VertexModel> iterator = _algorithm.Implement(_modelView.GraphModelView.Model, selected[0].Model);


            if (iterator == null)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(iterator);

            _displayer = new(_modelView.GraphModelView, vertexModelViews);

            _displayer.StartAnimation();
        }

        private void CancelAnimation()
        {
            if (_displayer != null)
            {
                _displayer.StopAnimation();
                _displayer.RestoreAnimation();
                _displayer = null;
                _modelView.SelectionManager.DiselectAll();
            }
        }

        public override void OnModeSwitch()
        {
            CancelAnimation();
        }
    }
}
