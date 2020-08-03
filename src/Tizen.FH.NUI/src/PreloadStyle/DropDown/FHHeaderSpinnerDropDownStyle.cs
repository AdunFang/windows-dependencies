using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class HeaderSpinnerDropDownStyle : StyleBase
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
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                Button = new ButtonStyle
                {
                    PositionX = 56,
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
                    Size = new Size(360, 500),
                    ResourceUrl = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png" },
                    Border = new RectangleSelector { All = new Rectangle(51, 51, 51, 51) },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FitToChildren,
                    HeightResizePolicy = ResizePolicyType.FitToChildren,
                },
                SpaceBetweenButtonTextAndIcon = 8,
                ListMargin = new Extents(20, 0, 20, 0),
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                ListPadding = new Extents(4, 4, 4, 4),
            };
            return style;
        }
    }
}
