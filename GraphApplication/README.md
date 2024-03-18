# Graph editor

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


