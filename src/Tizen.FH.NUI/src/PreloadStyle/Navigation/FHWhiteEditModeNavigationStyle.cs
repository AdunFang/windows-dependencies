using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class WhiteEditModeNavigationStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            NavigationStyle style = new NavigationStyle
            {
                ImageShadow = new ImageShadow
                {
                    Extents = new Vector2(6, 800),
                    Url = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_editmode_shadow.png",
                },
                BackgroundImage = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_editmode_bg.png" },
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.9f) },
                IsFitWithItems = false,
            };

            return style;
        }
    }
}
