using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class TransparencyHeaderStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            HeaderStyle style = new HeaderStyle
            {
                Size = new Size(1080, 128),
                BackgroundColor = new ColorSelector
                {
                    All = new Color(1, 1, 1, 0)
                },
                Title = new TextLabelStyle
                {
                    FontFamily = "SamsungOne 500",
                    PointSize = new FloatSelector
                    {
                        All = 50,
                    },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new ColorSelector
                    {
                        All = new Color(1, 1, 1, 1)
                    },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = ParentOrigin.Center,
                    PivotPoint = PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    SizeModeFactor = new Vector3(-112, 0, 0),
                },
                BottomLine = new ViewStyle
                {
                    Size = new Size(1080, 1),
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(1, 1, 1, 0.2f),
                    },
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = ParentOrigin.BottomLeft,
                    PivotPoint = PivotPoint.TopLeft,
                    Position = new Position(0, 0),
                },
            };
            return style;
        }
    }
}

