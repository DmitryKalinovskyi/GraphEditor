using GraphApplication.Views.Editor.Animations;

namespace GraphApplication.ModelViews
{
    public class GraphEditorAnimationManager : NotifyModelView
    {
        private IAnimation? _animation { get; set; }

        public void StartAnimation()
        {
            _animation?.StartAnimation();
        }

        public void SetAnimation(IAnimation anim)
        {
            _animation = anim;
            anim.AnimationKeyFrameDelay = _animationKeyFrameDelay;
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
                    _animation.AnimationKeyFrameDelay = value;
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
