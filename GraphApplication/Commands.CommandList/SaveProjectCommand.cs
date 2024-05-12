using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Services;
using Microsoft.Win32;

namespace GraphApplication.Commands.CommandList
{
    public class SaveProjectCommand : Command
    {
        private MainWindowModelView _mainWindowsViewModel;
        private IFileService<GraphProjectModel> _fileService;

        public SaveProjectCommand(MainWindowModelView mainWindowModelView) : this(mainWindowModelView, new XMLFileService<GraphProjectModel>()) { }

        public SaveProjectCommand(MainWindowModelView mainWindowModelView, IFileService<GraphProjectModel> fileService)
        {
            _mainWindowsViewModel = mainWindowModelView;
            _fileService = fileService;
        }

        public override void Execute(object? parameter)
        {
            var viewModel = parameter != null ? parameter as GraphProjectModelView : _mainWindowsViewModel.OpenedProjectsService.SelectedProject;
            if (viewModel == null)
                return;

            var projectsService = _mainWindowsViewModel.OpenedProjectsService;
            if (projectsService.IsOpened(viewModel) && projectsService.GetOpenedPath(viewModel) != null)
            {
                viewModel.IsSaved = true;
                _fileService.Save(projectsService.GetOpenedPath(viewModel), viewModel.Model);
            }
            else // create as new file
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML files (*.xml)|*.xml";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string path = saveFileDialog.FileName;

                    viewModel.IsSaved = true;
                    _fileService.Save(path, viewModel.Model);
                    _mainWindowsViewModel.OpenedProjectsService.AssignPath(viewModel, path);
                    viewModel.Name = System.IO.Path.GetFileName(path);
                }
            }
        }
    }
}
