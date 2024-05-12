# Creating custom project template (With custom graph)

Hello, i glad for you visit to that page, here you can follow step by step guide how to create custom Project template.

## Prerequirements
- Writing basic .xaml Views (Optional)
- Knowledge of basic graph theory

## Result
You can use custom template for graph generation or just project with prepared settings by pressing Ctr+G and selecting it.
<img src="https://github.com/DmitryKalinovskyi/GraphEditor/assets/117343778/52279301-242a-48d7-a9cb-ee492eb196f7" height="400">
<img src="https://github.com/DmitryKalinovskyi/GraphEditor/assets/117343778/4da22775-c26c-4306-8cf1-dbf096e49b1a" height="400">

## Guide
To do minimal project template you need to do this steps:
- Create a page for the your template in the ProjectTemplates folder ([SnowflakePage.xaml](https://github.com/DmitryKalinovskyi/GraphEditor/blob/main/GraphApplication/Views/ProjectTemplates/SnowflakePage.xaml)  for example)
- Add reference to your template in the [TemplatesPage](https://github.com/DmitryKalinovskyi/GraphEditor/blob/main/GraphApplication/Views/ProjectTemplates/TemplatesPage.xaml#L15) by creating NavButton
- Create a [factory](https://github.com/DmitryKalinovskyi/GraphEditor/blob/main/GraphApplication/Factories/Graph/IGraphFactory.cs) for your graph (if you want to :smile:)
- Add factory to the [DataContext](https://github.com/DmitryKalinovskyi/GraphEditor/blob/main/GraphApplication/Views/ProjectTemplates/SnowflakePage.xaml#L16) for the your template page.
- Test, refactor your factory if needed and enjoy from result.

>[!TIP]
You can create Page by pressing Ctr+Shift+A






