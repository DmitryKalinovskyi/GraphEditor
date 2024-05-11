using GraphApplication.CustomControls;
using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace GraphApplication.Views.Editor.State
{
    public class EdgeCreationState : EditorState, IBuildingMode
    {
        public EdgeCreationState(GraphProjectModelView modelView) : base(modelView)
        {
            _modelView.SelectionManager.DiselectAll();
        }


        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Edge clicked!");

            VertexModelView? clickedVertex = ((VertexButton)sender).DataContext as VertexModelView;

            if (clickedVertex == null)
                return;
            Trace.WriteLine($"Edge Proceeded! {clickedVertex.Model.Id}");


            _modelView.IsSaved = false;

            _modelView.SelectionManager.Select(clickedVertex);

            var selected = _modelView.SelectionManager.SelectedVerticles;
            if (selected.Count() == 2)
            {
                CreateEdge(selected[0], selected[1]);
                _modelView.SelectionManager.DiselectAll();
            }
        }

        private void CreateEdge(VertexModelView start, VertexModelView end)
        {

            if (_modelView.GraphModelView.Model.IsConnectionBetween(start.Model, end.Model) == false)
            {
                EdgeModel edgeModel = new WeightedEdgeModel<double>(start.Model, end.Model);
                _modelView.GraphModelView.AddEdgeCommand.Execute(edgeModel);
            }
            else
            {
                Trace.WriteLine("Such edge has been created");
            }

        }

        public override void OnModeSwitch()
        {
            _modelView.SelectionManager.DiselectAll();
        }
    }
}
