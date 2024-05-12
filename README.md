# Graph editor

This is my project related to graphs, algorithm and development in c#.

# For Developers
If you want to contribute please follow by one of the prepared guides or make it by your own.
- Making own project template guide - 

# Features
- Developing your own graph using comfort UI
- Project serialization. You can create, store and view your project.
- Develop several projects in one time with TabControl.
- Popular algoritims with animation (DFS, BFS, Single source shortest path, Spanning tree)
- Project templates - speed up your graph building process

## Patterns inside
- MVVM (Model-View-ViewModel) - main architecture pattern
- Command - to describe action related to the model and modelView.
- State - editor have several states (modes), that you can use to edit your graph and implement algorithms. 
- Strategy - you can use or develop custom algorithm for given purpose (shortest path algorithm can be implemented in several ways).
- Observer - MVVM pattern based in observer pattern. Look at the INotifyPropertyChanged interface. 

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

