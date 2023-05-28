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

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    public class GraphEditorEdgeCreationMode : GraphEditorMode
    {
        public GraphEditorEdgeCreationMode(GraphEditorModelView modelView) : base(modelView)
        {

        }


        VertexModelView? startVertex;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView? clickedVertex = ((VertexButton)sender).DataContext as VertexModelView;

            if (clickedVertex == null)
                return;

            if(startVertex == null)
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
            EdgeModelView edgeModelView = new EdgeModelView(start, end);

            _modelView.EdgeModelViews.Add(edgeModelView);
        }
    }
}
