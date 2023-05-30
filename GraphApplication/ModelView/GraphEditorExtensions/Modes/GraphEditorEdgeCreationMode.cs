using GraphApplication.CustomControls;
using GraphApplication.Model;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorEdgeCreationMode : GraphEditorBuildingMode
    {
        public GraphEditorEdgeCreationMode(GraphEditorModelView modelView) : base(modelView)
        {
            _modelView.SelectionManager.DiselectAll();
        }


        VertexModelView? startVertex;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView? clickedVertex = ((VertexButton)sender).DataContext as VertexModelView;

            if (clickedVertex == null)
                return;

            _modelView.IsSaved = false;

            if (startVertex == null)
            {
                startVertex = clickedVertex;
                clickedVertex.IsSelected = true;
            }
            else if (clickedVertex == startVertex)
            {
                startVertex.IsSelected = false;
                startVertex = null;
            }
            else
            {
                CreateEdge(startVertex, clickedVertex);
                startVertex.IsSelected = false;
                startVertex = null;
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
            if (startVertex != null)
                startVertex.IsSelected = false;
        }
    }
}
