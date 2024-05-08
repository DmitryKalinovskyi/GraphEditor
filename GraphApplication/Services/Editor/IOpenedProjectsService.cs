using GraphApplication.ModelViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Services.Editor
{
    public interface IOpenedProjectsService: INotifyPropertyChanged
    {
        public ObservableCollection<GraphProjectModelView> OpenedProjects { get; }
        public GraphProjectModelView? SelectedProject { get; set; }

        public void SelectProject(GraphProjectModelView project);

        public void AddProject(GraphProjectModelView project, string path);

        public void AddProject(GraphProjectModelView project);

        public void AddProjectAndSelect(GraphProjectModelView project, string path);

        public void AddProjectAndSelect(GraphProjectModelView project);

        public void RemoveProject(GraphProjectModelView project);

        public bool IsOpened(GraphProjectModelView project);

        public string? GetOpenedPath(GraphProjectModelView project);

        public bool IsOpenedWithPath(string path);

        public void AssignPath(GraphProjectModelView project, string path);
    }
}
