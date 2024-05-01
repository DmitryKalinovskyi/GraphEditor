using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelViews
{
    public class OpenedProjectsManager: NotifyModelView
    {
        // Use dictionary to limit opening the same graph few times
        private Dictionary<GraphProjectModelView, string> _openedGraphEditorModelViews;

        public bool IsOpened(GraphProjectModelView project)
        {
            return _openedGraphEditorModelViews.ContainsKey(project);
        }

        public bool IsOpened(string path)
        {
            return _openedGraphEditorModelViews.ContainsValue(path);
        }

        public string GetOpenedPath(GraphProjectModelView project)
        {
            return _openedGraphEditorModelViews[project];
        }

        public void AssignProject(GraphProjectModelView project, string path)
        {
            _openedGraphEditorModelViews[project] = path;
        }

        public void RemoveProject(GraphProjectModelView project)
        {
            _openedGraphEditorModelViews.Remove(project);
            _openedProjects.Remove(project);

            if (OpenedProjects.Count == 0)
                SelectedProject = null;
            else
                SelectedProject = OpenedProjects[0];
        }

        private ObservableCollection<GraphProjectModelView> _openedProjects;

        public ObservableCollection<GraphProjectModelView> OpenedProjects
        {
            get { return _openedProjects; }
            set
            {
                _openedProjects = value;
                OnPropertyChanged(nameof(OpenedProjects));
            }
        }

        private GraphProjectModelView? _selectedProject;

        public GraphProjectModelView? SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public OpenedProjectsManager():this(new List<GraphProjectModelView>(), new()) { }

        public OpenedProjectsManager(IEnumerable<GraphProjectModelView> projects) : this(projects, new()) { }

        public OpenedProjectsManager(IEnumerable<GraphProjectModelView> projects, Dictionary<GraphProjectModelView, string> openedGraphEditorModelViews)
        {
            _openedGraphEditorModelViews = openedGraphEditorModelViews;
            _openedProjects = new ObservableCollection<GraphProjectModelView>(projects);
        }
    }
}
