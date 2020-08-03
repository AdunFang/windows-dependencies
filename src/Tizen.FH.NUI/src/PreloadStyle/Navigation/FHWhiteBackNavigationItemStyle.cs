using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class WhiteBackNavigationItemStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            NavigationItemStyle style = new NavigationItemStyle
            {
                Size = new Size(120, 140),
                Icon = new ImageViewStyle
                {
                    Size = new Size(56, 56),
                    ResourceUrl = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_back.png" },
                },
                BackgroundImage = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_back_bg.png" },
                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new StringSelector
                    {
                        Pressed = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/sidenavi_back_bg_press_overlay.png",
                        Other = "",
                    },
                },
                EnableIconCenter = true
            };

            return style;
        }
    }
}
