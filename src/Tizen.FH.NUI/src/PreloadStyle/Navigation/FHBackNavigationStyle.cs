using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class BackNavigationStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            NavigationStyle style = new NavigationStyle
            {
                IsFitWithItems = true,
            };

            return style;
        }
    }
}
