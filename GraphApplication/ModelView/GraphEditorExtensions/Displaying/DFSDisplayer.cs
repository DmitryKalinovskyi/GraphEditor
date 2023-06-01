using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphApplication.ModelView.GraphEditorExtensions.Displaying
{
    public class DFSDisplayer: Animation
    {
        private (List<VertexModelView>, List<EdgeModelView>) _path;

        private GraphModelView _graphModelView;

        public DFSDisplayer(GraphModelView graphModelView, (List<VertexModelView>, List<EdgeModelView>) path)
        {
            _path = path;
            _graphModelView = graphModelView;
            _animationThread = new(Animation);
        }

        public void Animation()
        {
            _path.Item1[0].IsMarked = true;

            Thread.Sleep(AnimationKeyFrameDelay);


            for (int i = 1; i < _path.Item1.Count(); i++)
            {
                if (_isCanceled) return;

                try
                {
                    _path.Item1[i].IsMarked = true;

                    VertexModelView prev = _path.Item1[i - 1];
                    VertexModelView next = _path.Item1[i];

                    _path.Item2[i - 1].IsMarked = true;
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }

                Thread.Sleep(AnimationKeyFrameDelay);
            }
        }

        public override void RestoreAnimation()
        {
            foreach (var v in _path.Item1)
            {
                v.IsMarked = false;
            }

            if (_path.Item2.Count > 0)
                foreach (var e in _path.Item2)
                {
                    e.IsMarked = false;
                }
        }
    }
}
