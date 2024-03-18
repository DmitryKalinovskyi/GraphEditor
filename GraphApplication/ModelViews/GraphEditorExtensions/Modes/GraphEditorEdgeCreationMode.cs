using GraphApplication.CustomControls;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace GraphApplication.ModelViews.GraphEditorExtensions.Modes
{
    public class GraphEditorEdgeCreationMode : GraphEditorMode, IBuildingMode
    {
        public GraphEditorEdgeCreationMode(GraphEditorModelView modelView) : base(modelView)
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

            if (_modelView.GraphModelView.Model.EdgeDictionary.ContainsKey((start.Model, end.Model)) == false)
            {
                EdgeModelView edgeModelView = new EdgeModelView(start, end);
                _modelView.GraphModelView.EdgeModelViews.Add(edgeModelView);
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
