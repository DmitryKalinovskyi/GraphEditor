using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class GraphEditorAnimationManager: NotifyModelView
    {
        private IDisplayAnimation? _animation { get; set; }

        public void StartAnimation()
        {
            _animation?.StartAnimation();
        }

        public void SetAnimation(IDisplayAnimation anim)
        {
            _animation = anim;
            anim.UpdateKeyFrameDelay(_animationKeyFrameDelay);
            OnPropertyChanged(nameof(IsAnimationActive));
        }

        public void StopAnimation()
        {
            _animation?.StopAnimation();

            //forget
            _animation = null;
            OnPropertyChanged(nameof(IsAnimationActive));

        }

        public bool IsAnimationActive
        {
            get { return _animation != null; }
        }

        private int _animationKeyFrameDelay;

        public int AnimationSpeed
        {
            get { return _animationKeyFrameDelay; }
            set
            {
                _animationKeyFrameDelay = value;
                if (_animation != null)
                {
                    _animation.UpdateKeyFrameDelay(value);
                }

                OnPropertyChanged(nameof(AnimationSpeed));
            }
        }

        public GraphEditorAnimationManager()
        {
            _animationKeyFrameDelay = 0;
        }
    }
}
