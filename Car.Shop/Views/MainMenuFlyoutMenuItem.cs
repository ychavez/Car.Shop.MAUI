using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Shop.Views
{

    public class MainMenuFlyoutMenuItem
    {
        public MainMenuFlyoutMenuItem()
        {
            TargetType = typeof(MainMenuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}