using GraphApplication.Factories.Graph;
using GraphApplication.ModelViews;

namespace GraphApplication.Commands.CommandList
{
    public class GenerateGraphCommand: Command
    {
        private MainWindowModelView _mainWindowsViewModel;

        public GenerateGraphCommand(MainWindowModelView mainWindowModelView)
        {
            _mainWindowsViewModel = mainWindowModelView;
        }

        public override void Execute(object? parameter)
        {
            //var factory = new RandomizedGraphFactory();

            //// set up parameters for factory
            //factory.MaxX = 1000;
            //factory.MaxY = 1000;


            //_mainWindowsViewModel.CreateGraphCommand?.Execute(factory.CreateUndirectedGraph());

            //var factory = new SnowflakeGraphFactory();

            ////// set up parameters for factory
            //factory.Depth = 3;
            //factory.K = 5;
            //factory.Radius = 300;

            //_mainWindowsViewModel.CreateGraphCommand?.Execute(factory.CreateUndirectedGraph());

            var factory = new GridGraphFactory();

            //// set up parameters for factory
            factory.Rows = 5;
            factory.Columns = 6;
            factory.ColumnGap = 100;
            factory.RowGap= 100;

            _mainWindowsViewModel.CreateGraphCommand?.Execute(factory.CreateUndirectedGraph());
        }
    }
}
