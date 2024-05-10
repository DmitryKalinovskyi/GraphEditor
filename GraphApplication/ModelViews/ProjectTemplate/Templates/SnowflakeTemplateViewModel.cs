using GraphApplication.Factories.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelViews.ProjectTemplate.Templates
{
    public class SnowflakeTemplateViewModel: NotifyModelView
    {
        public IGraphFactory GraphFactory { get; set; }

        public SnowflakeTemplateViewModel()
        {
            GraphFactory = new SnowflakeGraphFactory();
        }
    }
}
