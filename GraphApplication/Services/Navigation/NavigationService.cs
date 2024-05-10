using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Services.Navigation
{
    public class NavigationService<TNavigationBase>
    {
        public TNavigationBase? CurrentView { get; set; }

        public event EventHandler<EventArgs>? ViewChanged;

        public void NavigateTo<TNavigationTarget>(TNavigationTarget target)
            where TNavigationTarget: TNavigationBase
        {
            CurrentView = target;
            ViewChanged?.Invoke(this, new EventArgs()); 
        }
    }
}
