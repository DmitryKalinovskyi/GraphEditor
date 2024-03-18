using GraphApplication.Models;
using GraphApplication.Views.GraphEditorToolbar;

namespace GraphApplication.ModelViews
{
    public class ToolBarModelView
    {
        public GraphEditorTool? SelectedTool { get; set; }

        public ToolBarModel ToolBarModel { get; set; }

        public ToolBarModelView() : this(new()) { }

        public ToolBarModelView(ToolBarModel toolBarModel)
        {
            ToolBarModel = toolBarModel;
        }
    }
}
