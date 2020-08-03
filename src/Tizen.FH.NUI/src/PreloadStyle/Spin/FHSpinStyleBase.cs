
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FHSpinStyleBase : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            SpinStyle style = new SpinStyle
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true,
                ItemHeight = 116,
                TextSize = 50,
                CenterTextSize = 55,
                BackgroundImage = new StringSelector
                {
                    All = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background.png"
                },
                BackgroundImageBorder = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                ItemText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 50 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size = new Size(200, 116),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center,
                },
                NameText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size = new Size(200, 56),
                    Position = new Position(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                MaskTopImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(200, 64),
                    Position = new Position(0, 76),
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_top.png"
                    }
                },
                MaskBottomImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(200, 64),
                    Position = new Position(0, 364),
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_mask_bottom.png"
                    }
                },
                NameView = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 56),
                    Position = new Position(0, 0)
                },
                ClipView = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 352),
                    Position = new Position(0, 76)
                },
                AnimationView = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 352),
                    Position = new Position(0, 0),
                },
                DividerLine = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity = new FloatSelector { All = 0.4f },
                    Size = new Size(200, 2),
                    Position = new Position(0, 176)
                },
                DividerLine2 = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    BackgroundColor = new ColorSelector { All = Color.Black },
                    Opacity = new FloatSelector { All = 0.4f },
                    Size = new Size(200, 2),
                    Position = new Position(0, 328)
                },
                TextField = new TextFieldStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 55 },
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                }
            };
            return style;
        }
    }
}
