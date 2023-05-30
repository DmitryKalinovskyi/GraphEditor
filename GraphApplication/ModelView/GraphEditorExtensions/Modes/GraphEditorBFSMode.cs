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

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if (_modelView.AnimationManager.IsAnimationActive)
            {
                MessageBox.Show("Завершіть програвання минулого алгоритму!",
                   "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            base.VertexClicked(sender, e);
        }

        public bool Implement()
        {
            List<VertexModelView> selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count != 1)
            {
                MessageBox.Show("Алгоритм пошуку в ширину реалізувати не можливо, поки не обрано тільки одну вершину!",
                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            (IEnumerable<VertexModel>?, IEnumerable<EdgeModel>?) iterator = _algorithm.Implement(_modelView.GraphModelView.Model, selected[0].Model);


            if (iterator.Item1 == null)
            {
                MessageBox.Show("Шляху між вершинами не існує!", "Інформація",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            List<VertexModelView> vertexModelViews = _modelView.GraphModelView.GetVertexModelViewsByModels(iterator.Item1);
            List<EdgeModelView> edgesModelViews = _modelView.GraphModelView.GetEdgeModelViewsByModels(iterator.Item2);

            BFSDisplayer _displayer = new(_modelView.GraphModelView, (vertexModelViews, edgesModelViews));

            _modelView.AnimationManager.SetAnimation( _displayer);

            _displayer.StartAnimation();
            return true;
        }

        public override void OnModeSwitch()
        {
        }
    }
}
