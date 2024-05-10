using GraphApplication.Commands;
using GraphApplication.ModelViews.ProjectTemplate.Templates;
using GraphApplication.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphApplication.ModelViews.ProjectTemplate
{
    public class TemplateWindowViewModel : NotifyModelView
    {
        public ICommand NavigateToCommand { get; set; }

        public NotifyModelView? SelectedViewModel => _navigationService.CurrentView;

        private NavigationService<NotifyModelView> _navigationService;

        public TemplateWindowViewModel()
        {
            NavigateToCommand = new RelayCommand(NavigateTo);
            _navigationService = new NavigationService<NotifyModelView>();
            _navigationService.ViewChanged += (sender, args) => OnPropertyChanged(nameof(SelectedViewModel));

            // default 
            _navigationService.NavigateTo(new TemplateScrollViewModel());
        }

        private void NavigateTo(object? param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));

            // create modelview from param name
            string factoryType = (string)param;

            _navigationService.NavigateTo(new SnowflakeTemplateViewModel());
        }
    }
}
