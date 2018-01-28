using System;
using System.Collections.Generic;

namespace CounterStats.UI.Views.Elements
{
    public interface IMainMenu : IList<MenuItem>
    {
        
    }

    public interface IBottomMenu : IList<MenuItem>
    {

    }

    public class MainMenu : List<MenuItem>, IMainMenu, IBottomMenu
    {
        
    }

    public class MenuItem
    {
        public string Text { get; set; }

        public Action OnClick { get; set; }
    }
}
