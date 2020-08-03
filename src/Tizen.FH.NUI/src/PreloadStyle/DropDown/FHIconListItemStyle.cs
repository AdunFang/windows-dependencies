using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class IconListItemStyle : StyleBase
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
                Icon = new ImageViewStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Size = new Size(28, 28),
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
