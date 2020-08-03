using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class BlackConditionNavigationStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            NavigationStyle style = new NavigationStyle
            {
                BackgroundImage = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_bg_b.png" },
                BackgroundImageBorder = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                Padding = new Extents(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(1, 1, 1, 0.1f),
                IsFitWithItems = true,
            };

            return style;
        }
    }
}
