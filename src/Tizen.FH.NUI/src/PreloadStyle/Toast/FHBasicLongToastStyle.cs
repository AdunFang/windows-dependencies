
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class BasicLongToastStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            ToastStyle style = new ToastStyle
            {
                Size = new Size(1000, 132),
                BackgroundImage = CommonResource.Instance.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                BackgroundImageBorder = new Rectangle(64, 64, 4, 4),
                Text = new TextLabelStyle
                {
                    Padding = new Extents(204, 96, 38, 38),
                    PointSize = new Selector<float?> { All = 26, },
                    TextColor = new Selector<Color> { All = Color.White }
                }       
            };
            return style;
        }
    }
}
