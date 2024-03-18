using System.Collections.Generic;
using System.Linq;

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    public class GraphEditorSelectionManager
    {
        private HashSet<VertexModelView> _selectedVerticles;

        public bool IsSelected(VertexModelView v) => _selectedVerticles.Contains(v);
        public List<VertexModelView> SelectedVerticles => _selectedVerticles.ToList(); 
        public GraphEditorSelectionManager()
        {
            _selectedVerticles = new();
        }

        public void Select(VertexModelView vertexModelView)
        {
            //we can't interact with UnActivated elements
            if (vertexModelView.IsActive == false)
                return;

            if(_selectedVerticles.Contains(vertexModelView))
            {
                Diselect(vertexModelView);
                return;
            }

            _selectedVerticles.Add(vertexModelView);
            vertexModelView.IsSelected = true;
        }

        public void Diselect(VertexModelView vertexModelView) 
        {
           

            if (_selectedVerticles.Contains(vertexModelView))
            {
                _selectedVerticles.Remove(vertexModelView);
                vertexModelView.IsSelected = false;
            }
        }

        public void DiselectAll()
        {
            foreach(var selectedVerticle in _selectedVerticles)
            {
                selectedVerticle.IsSelected = false;
            }

            _selectedVerticles.Clear();
        }
    }
}
