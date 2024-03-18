using GraphApplication.Fabrication;
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
            GraphModelArgs args = new GraphModelArgs();
            args.MaxTop = 2000;
            args.MaxLeft = 2000;
            args.Deegre = 3;
            args.VerticlesCount = 100;

            GraphModelGenerator generator = new GraphModelGenerator();

            object generated = generator.Generate(args);

            _mainWindowsViewModel.CreateGraphCommand?.Execute(generated);
        }
    }
}
