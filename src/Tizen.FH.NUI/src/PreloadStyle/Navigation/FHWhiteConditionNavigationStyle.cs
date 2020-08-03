using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class WhiteConditionNavigationStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            NavigationStyle style = new NavigationStyle
            {
                BackgroundImage = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_bg.png" },
                BackgroundImageBorder = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                Padding = new Extents(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(0, 0, 0, 0.1f),
                IsFitWithItems = true,
            };

            return style;
        }
    }
}
