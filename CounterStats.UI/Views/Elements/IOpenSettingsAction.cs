using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStats.UI.Views.Elements
{
    public interface IOpenSettingsAction
    {
        void Invoke();
    }

    public class OpenSettingsAction : IOpenSettingsAction
    {
        private readonly Action _actionToInvoke;
        public OpenSettingsAction(Action actionToInvoke)
        {
            _actionToInvoke = actionToInvoke;
        }

        public void Invoke()
        {
            _actionToInvoke.Invoke();
        }
    }
}
