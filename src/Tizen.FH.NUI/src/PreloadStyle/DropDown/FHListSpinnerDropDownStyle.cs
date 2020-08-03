using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class ListSpinnerDropDownStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            DropDownStyle style = new DropDownStyle
            {
                HeaderText = new TextLabelStyle
                {
                    PointSize = new FloatSelector { All = 28 },
                    TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    Position = new Position(56, 0),
                },
                Button = new ButtonStyle
                {
                    PositionX = 900,
                    Text = new TextLabelStyle
                    {
                        PointSize = new FloatSelector { All = 20 },
                        TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                        FontFamily = "SamsungOneUI 500",
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        Position = new Position(0, 0),
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        VerticalAlignment = VerticalAlignment.Center,
                    },
                    Icon = new ImageViewStyle
                    {
                        Size = new Size(48, 48),
                        ResourceUrl = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_dropdown.png" },
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    },
                },
                ListBackgroundImage = new ImageViewStyle
                {
                    Size = new Size(360, 192),
                    ResourceUrl = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png" },
                    Border = new RectangleSelector { All = new Rectangle(51, 51, 51, 51) },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopRight,
                    PivotPoint = Tizen.NUI.PivotPoint.TopRight,
                    WidthResizePolicy = ResizePolicyType.FitToChildren,
                    HeightResizePolicy = ResizePolicyType.FitToChildren,
                },
                SpaceBetweenButtonTextAndIcon = 8,
                ListMargin = new Extents(0, 20, 20, 0),
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                ListPadding = new Extents(4, 4, 4, 4),
                ListRelativeOrientation = DropDown.ListOrientation.Right,
            };
            return style;
        }
    }
}
