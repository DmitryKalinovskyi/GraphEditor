using GraphApplication.ModelViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Services.Editor
{
    public class OpenedProjectsService : IOpenedProjectsService
    {
        public ObservableCollection<GraphProjectModelView> OpenedProjects { get; }

        private GraphProjectModelView? _selectedProject;

        public GraphProjectModelView? SelectedProject 
        {
            get
            {
                return _selectedProject;
            } 
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        private Dictionary<GraphProjectModelView, string> _projectToPathMapping;

        public OpenedProjectsService()
        {
            _projectToPathMapping = new();
            OpenedProjects = new();
        }

        //public OpenedProjectsManager(IEnumerable<GraphProjectModelView> openedProjects)
        //{
        //    _projectToPathMapping = new();

        //    OpenedProjects = new(openedProjects);
        //    SelectedProject = OpenedProjects[0];
        //}

        // what we need to do?
        // open new project
        // create new project
        // 

        // Use dictionary to limit opening the same graph few times
        //private Dictionary<GraphProjectModelView, string> _openedGraphEditorModelViews;

        //public bool IsOpened(GraphProjectModelView project)
        //{
        //    return _openedGraphEditorModelViews.ContainsKey(project);
        //}

        //public bool IsOpened(string path)
        //{
        //    return _openedGraphEditorModelViews.ContainsValue(path);
        //}

        //public string GetOpenedPath(GraphProjectModelView project)
        //{
        //    return _openedGraphEditorModelViews[project];
        //}

        //public void AssignProject(GraphProjectModelView project, string path)
        //{
        //    _openedGraphEditorModelViews[project] = path;
        //}

        //public void RemoveProject(GraphProjectModelView project)
        //{
        //    _openedGraphEditorModelViews.Remove(project);
        //    _openedProjects.Remove(project);

        //    if (OpenedProjects.Count == 0)
        //        SelectedProject = null;
        //    else
        //        SelectedProject = OpenedProjects[0];
        //}

        //private ObservableCollection<GraphProjectModelView> _openedProjects;

        //public ObservableCollection<GraphProjectModelView> OpenedProjects
        //{
        //    get { return _openedProjects; }
        //    set
        //    {
        //        _openedProjects = value;
        //        OnPropertyChanged(nameof(OpenedProjects));
        //    }
        //}

        //private GraphProjectModelView? _selectedProject;


        //public GraphProjectModelView? SelectedProject
        //{
        //    get { return _selectedProject; }
        //    set
        //    {
        //        _selectedProject = value;
        //        OnPropertyChanged(nameof(SelectedProject));
        //    }
        //}

        //public OpenedProjectsManager():this(new List<GraphProjectModelView>(), new()) { }

        //public OpenedProjectsManager(IEnumerable<GraphProjectModelView> projects) : this(projects, new()) { }

        //public OpenedProjectsManager(IEnumerable<GraphProjectModelView> projects, Dictionary<GraphProjectModelView, string> openedGraphEditorModelViews)
        //{
        //    _openedGraphEditorModelViews = openedGraphEditorModelViews;
        //    _openedProjects = new ObservableCollection<GraphProjectModelView>(projects);
        //}

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SelectProject(GraphProjectModelView project)
        {
            if(IsOpened(project) == false)
            {
                throw new InvalidOperationException("You can't select object that is not opened.");
            }   

            SelectedProject = project;
        }

        public void AddProject(GraphProjectModelView project, string path)
        {
            OpenedProjects.Add(project);
            _projectToPathMapping.Add(project, path);
        }

        public void AddProject(GraphProjectModelView project)
        {
            OpenedProjects.Add(project);
        }

        public bool IsOpenedWithPath(string path)
        {
            return _projectToPathMapping.ContainsValue(path);
        }

        public void AddProjectAndSelect(GraphProjectModelView project, string path)
        {
            AddProject(project, path);
            SelectProject(project);
        }

        public void AddProjectAndSelect(GraphProjectModelView project)
        {
            AddProject(project);
            SelectProject(project);
        }

        public void RemoveProject(GraphProjectModelView project)
        {
            if (SelectedProject == project)
            {
                SelectedProject = OpenedProjects.FirstOrDefault(proj => proj !=  project, null);
            }

            _projectToPathMapping.Remove(project);

            OpenedProjects.Remove(project);
        }

        public bool IsOpened(GraphProjectModelView project)
        {
            return OpenedProjects.Any(proj => proj == project);
        }

        public string? GetOpenedPath(GraphProjectModelView project)
        {
            if(_projectToPathMapping.ContainsKey(project)) 
                return _projectToPathMapping[project];
            return null;
        }

        public void AssignPath(GraphProjectModelView project, string path)
        {
            _projectToPathMapping[project] = path;
        }
    }
}
