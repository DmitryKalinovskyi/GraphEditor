using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelViews
{
    public class OpenedGraphModelViewsManager: NotifyModelView
    {
        // Use dictionary to limit opening the same graph few times
        private Dictionary<GraphProjectModelView, string> _openedGraphEditorModelViews;

        public bool IsOpened(GraphProjectModelView modelView)
        {
            return _openedGraphEditorModelViews.ContainsKey(modelView);
        }

        public bool IsOpened(string path)
        {
            return _openedGraphEditorModelViews.ContainsValue(path);
        }

        public string GetOpenedPath(GraphProjectModelView modelView)
        {
            return _openedGraphEditorModelViews[modelView];
        }

        public void AssignModelView(GraphProjectModelView modelView, string path)
        {
            _openedGraphEditorModelViews[modelView] = path;
        }

        public void RemoveModelView(GraphProjectModelView modelView)
        {
            _openedGraphEditorModelViews.Remove(modelView);
            _graphEditorViews.Remove(modelView);

            if (GraphEditorViews.Count == 0)
                SelectedView = null;
            else
                SelectedView = GraphEditorViews[0];
        }

        private ObservableCollection<GraphProjectModelView> _graphEditorViews;

        public ObservableCollection<GraphProjectModelView> GraphEditorViews
        {
            get { return _graphEditorViews; }
            set
            {
                _graphEditorViews = value;
                OnPropertyChanged(nameof(GraphEditorViews));
            }
        }

        private GraphProjectModelView? _selectedView;

        public GraphProjectModelView? SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        public OpenedGraphModelViewsManager():this(new(), new()) { }

        public OpenedGraphModelViewsManager(ObservableCollection<GraphProjectModelView> graphEditorViews) : this(graphEditorViews, new()) { }

        public OpenedGraphModelViewsManager(ObservableCollection<GraphProjectModelView> graphEditorViews, Dictionary<GraphProjectModelView, string> openedGraphEditorModelViews)
        {
            _openedGraphEditorModelViews = openedGraphEditorModelViews;
            _graphEditorViews = graphEditorViews;
        }
    }
}
