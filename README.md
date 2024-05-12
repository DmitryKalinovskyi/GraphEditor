# Graph editor

This is my project related to graphs, algorithm and development in c#.

# For Developers
If you want to contribute please follow by one of the prepared guides or make it by your own.
- Making own [Project Template Guide](https://github.com/DmitryKalinovskyi/GraphEditor/blob/main/GraphApplication/Views/ProjectTemplates/README.md)

# Features
- Developing your own graph using comfort UI
- Project serialization. You can create, store and view your project.
- Develop several projects in one time with TabControl.
- Popular algoritims with animation (DFS, BFS, Single source shortest path, Spanning tree)
- Project templates - speed up your graph building process

## Design Patterns
### MVVM (Model-View-ViewModel)
Main architecture pattern from the MVC family. Used to separate business logic and UI development. Also have strong binding system. 

### Command
Used for create bindings to the hotkeys in the menu. 

```xaml
<Window.InputBindings>
    <KeyBinding Key="N"
                Command="{Binding CreateEmptyProjectCommand}"
                Modifiers="Ctrl"
                />
</Window.InputBidnings>
```

```cs
public class CreateEmptyProjectCommand : Command
{
    private MainWindowModelView _mainWindowModelView;

    public CreateEmptyProjectCommand(MainWindowModelView mainWindowModelView) {
        _mainWindowModelView = mainWindowModelView;
    }

    public override void Execute(object? parameter)
    {
        // load from application settings default graph model.
        GraphProjectModel editorModel = new(new UndirectedGraphModel());

        var project = new GraphProjectModelView(editorModel, "");

        _mainWindowModelView.OpenedProjectsService.AddProjectAndSelect(project);
    }
}
```

### State
Editor have several states (modes), that you can change using ui. Each state can be used to edit your graph or implement algorithms. 
This pattern solve problematic code below.

```cs
public void Vetex_Click(object sender, EventArgs args){
  switch(selectedTool){
    case "HideTool":
        ((Vertex)sender).Hide(); break;
    case "RemoveTool":
        // get graph where this vertex located and remove it.
    // more more and more, for each added tool we should edit this method. Even harder it makes thing that Vertex_Click it's not single event callback we should handle. 
  }
}
```

```cs
public void Vetex_Click(object sender, EventArgs args){
   Editor.State.Vertex_Click(sender, args);
}

public class HideState: EditorState { }
public class RemoveState: EditorState { }
```

### Strategy
You can use or develop custom algorithm for given purpose (shortest path algorithm can be implemented in several ways).

```cs
public interface IShortestPathAlgorithm
{
    public ShortestPathResult FindShortestPath(IGraphModel graph, VertexModel source, VertexModel target, params object[] args);
}

public class DijkstraAlgorithm : IShortestPathAlgorithm
{
    public ShortestPathResult FindShortestPath(IGraphModel graph, VertexModel source, VertexModel target, params object[] args);
}

public class AStar : IShortestPathAlgorithm
{
    public ShortestPathResult FindShortestPath(IGraphModel graph, VertexModel source, VertexModel target, params object[] args);
}

```

### Observer 
MVVM pattern based in observer pattern. Also WPF have strong binding tool that is based in INotifyPropertyChanged interface.
How that works? We have several viewModels that have properties, when they change, they call PropertyChanged event, which reflects to the UI.
>[!NOTE]
>Commands can be created as properties and used with binding.

```cs
public abstract class NotifyModelView : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class GraphProjectModelView: NotifyModelView{
    public double OffsetY
    {
        get { return Model.OffsetY; }
        set
        {
            Model.OffsetY = value;
            OnPropertyChanged(nameof(OffsetY));
        }
    }
}
```
In example above we have OffsetY property, if we try to set some value, UI will be updated after that.


Also as bonus i used events in the GraphModel to simplify GraphModelView
```cs
public interface IGraphModel: IGraphModel<VertexModel, EdgeModel> { }

public interface IGraphModel<TVertex, TEdge>
    where TVertex : VertexModel
    where TEdge : EdgeModel
{
    // Basic methods for the graph.
    
    public event EventHandler<TVertex>? OnVertexAdded;
    public event EventHandler<TEdge>? OnEdgeAdded;
    public event EventHandler<TVertex>? OnVertexRemoved;
    public event EventHandler<TEdge>? OnEdgeRemoved;
}

public class GraphModelView: NotifyModelView{
    public IGraphModel Model { get; private set; }

    private void AssignEvents()
    {
        // this private methods depends from graph model, when model changes, modelView updates, then it notificate the view.
    
        Model.OnEdgeAdded += (sender, edge) => AddEdgeView(edge);
        Model.OnEdgeRemoved += (sender, edge) => RemoveEdgeView(edge);
        Model.OnVertexAdded += (sender, vertex) => AddVertexView(vertex);
        Model.OnVertexRemoved += (sender, vertex) => RemoveVertexView(vertex);
    }
}

```

### Abstract Factory
Abstract factory pattern used for GraphModel generation via Ctr+G command.
```cs
public interface IGraphFactory
{
    public DirectedGraphModel CreateDirectedGraph();
    public UndirectedGraphModel CreateUndirectedGraph();
}

public class SnowflakeGraphFactory: IGraphFactory
{
    public DirectedGraphModel CreateDirectedGraph(){}

    public UndirectedGraphModel CreateUndirectedGraph(){}
}
```

## Future plans
- history for your commands, ctr+z (implement via Memento pattern)
- custom editor component
- centralized editor camera
- directed graph

## Models 
Models manages data that can be serialized such as camera zoom, position, project properties, graph ...

## ModelViews
Purpose of ModelViews to bind values from the models to views and provide commands for interaction from views.

## Views
In the views we define our MainWindow and other components like Editor, ToolBar, GraphElements (Edges, Vertices). 

