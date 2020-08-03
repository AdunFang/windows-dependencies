using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class TextListItemStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            DropDownItemStyle style = new DropDownItemStyle
            {
                BackgroundColor = new ColorSelector
                {
                    Pressed = new Color(0, 0, 0, 0.4f),
                    Other = new Color(1, 1, 1, 0),
                },
                Text = new TextLabelStyle
                {
                    PointSize = new FloatSelector { All = 18 },
                    FontFamily = "SamsungOne 500",
                    Position = new Position(28, 0),
                },
                CheckImage = new ImageViewStyle
                {
                    Size = new Size(40, 40),
                    ResourceUrl = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png" },
                },
                CheckImageGapToBoundary = 16,
            };

            return style;
        }
    }
}
