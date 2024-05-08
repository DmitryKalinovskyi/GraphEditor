# Graph editor

This is my project related to graphs, algorithm and development in c#.

# Features
- Developing your own graph using comfort UI
- Project serialization. You can create, store and view your project.
- Develop several projects in one time with TabControl.
- Popular algoritims with animation (DFS, BFS, Single source shortest path, Spanning tree)

# Development
:warning: - this project in active refactoring phase.

## Patterns inside
- MVVM (Model-View-ViewModel) - main architecture pattern
- Command - each action that executed from view should be maked using command.
- State - editor have several states (modes), that you can use to edit your graph and implement algorithms. 
- Strategy - you can use or develop custom algorithm for given purpose (shortest path algorithm can be implemented in several ways).
- Observer - MVVM pattern based in observer pattern. Look at the INotifyPropertyChanged interface. 

## Possible patterns 
- Memento - history for your commands, ctr+z
- Abstract Factory - creating project with several graph templates (Grid graph, Graph Snowflake, Graph Circle, Graph Wheel).


## Models 
Models manages data that can be serialized such as editor scaling, camera position, graph currently working on in editor ...

- GraphEditorModel

Graph Related models
- GraphModel
- VertexModel
- EdgeModel

## ModelViews
Purpose of ModelViews to give provide commands like serialization, algorithm execution for views

- MainWindowViewModel
- GraphEditorViewModel

## Views
At this point, views is very simple and can be extended.

- MainWindow
- GraphEditorView

## Ways to improve

- Move editor tools to the views, because this is actually part of UI, this is huge design mistake.
- Thinks to make cool animation is also part of the UI


