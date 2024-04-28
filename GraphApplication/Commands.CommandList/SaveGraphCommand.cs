using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Services;
using Microsoft.Win32;

namespace GraphApplication.Commands.CommandList
{
    public class SaveGraphCommand: Command
    {
        private MainWindowModelView _mainWindowsViewModel;
        private IFileService<GraphProjectModel> _fileService;

        public SaveGraphCommand(MainWindowModelView mainWindowModelView) : this(mainWindowModelView, new XMLFileService<GraphProjectModel>()) { }

        public SaveGraphCommand(MainWindowModelView mainWindowModelView, IFileService<GraphProjectModel> fileService)
        {
            _mainWindowsViewModel = mainWindowModelView;
            _fileService = fileService;
        }

        public override void Execute(object? parameter)
        {
            var viewModel = parameter != null ? parameter as GraphProjectModelView : _mainWindowsViewModel.OpenedGraphModelViewsManager.SelectedView;
            if (viewModel == null)
                return;

            if (_mainWindowsViewModel.OpenedGraphModelViewsManager.IsOpened(viewModel))
            {
                viewModel.IsSaved = true;
                _fileService.Save(_mainWindowsViewModel.OpenedGraphModelViewsManager.GetOpenedPath(viewModel), viewModel.Model);
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
                    _mainWindowsViewModel.OpenedGraphModelViewsManager.AssignModelView(viewModel, path);
                    viewModel.Name = System.IO.Path.GetFileName(path);
                }
            }
        }
    }
}
