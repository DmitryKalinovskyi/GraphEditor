using GraphApplication.Model;
using GraphApplication.Services.Commands;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView
{
    public class MainWindowModelView: NotifyModelView
    {
        private RelayCommand _createGraphCommand;
        
        public RelayCommand CreateGraphCommand
        {
            get 
            {
                return _createGraphCommand ??
                     (_createGraphCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             GraphViews.Add(new GraphModel("graph1"));   
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                         }
                     }));
            }
        }
        private RelayCommand _removeGraphCommand;

        public RelayCommand RemoveGraphCommand
        {
            get
            {
                return _createGraphCommand ??
                     (_createGraphCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             if(obj is GraphModel) 
                             { 

                             }
                         }
                         catch (Exception ex)
                         {
                         }
                     }));
            }
        }

        private ObservableCollection<GraphModel> _graphViews;

        public ObservableCollection<GraphModel> GraphViews
        {
            get { return _graphViews; }
            set
            {
                _graphViews = value;
                OnPropertyChanged(nameof(GraphViews));
            }
        }

        public MainWindowModelView(ObservableCollection<GraphModel>  graphViews)
        {
            GraphViews = graphViews;
        }
    }
}
