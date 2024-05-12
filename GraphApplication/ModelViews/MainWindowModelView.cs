using GraphApplication.Commands;
using GraphApplication.Commands.CommandList;
using GraphApplication.Services.Editor;
using System.Collections.Generic;
using System.Linq;

namespace GraphApplication.ModelViews
{
    public class MainWindowModelView : NotifyModelView
    {
        #region Commands
        public Command? CreateEmptyProjectCommand { get; set; }

        public Command? CreateProjectTemplateCommand { get; set; }

        public Command? SaveProjectCommand { get; set; }

        public Command? CloseProjectCommand { get; set; }

        public Command? LoadProjectCommand { get; set; }
        #endregion

        public IOpenedProjectsService OpenedProjectsService { get; set; }

        public MainWindowModelView()
        {
            OpenedProjectsService = new OpenedProjectsService();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            CreateEmptyProjectCommand = new CreateEmptyProjectCommand(this);
            CreateProjectTemplateCommand = new CreateProjectTemplateCommand(this);
            SaveProjectCommand = new SaveProjectCommand(this);
            CloseProjectCommand = new CloseProjectCommand(this);
            LoadProjectCommand = new LoadProjectCommand(this);
        }

        public void CloseAndSave()
        {
            IEnumerable<GraphProjectModelView> graphViewsToClose = OpenedProjectsService.OpenedProjects.ToList();

            foreach (GraphProjectModelView view in graphViewsToClose)
            {
                CloseProjectCommand?.Execute(view);
            }
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseAndSave();
        }
    }
}
