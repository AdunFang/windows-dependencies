using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class BasePopupStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            PopupStyle style = new PopupStyle
            {
                MinimumSize = new Size2D(1032, 184),
                //ShadowExtents = new Extents(24, 24, 24, 24),
                BackgroundImage = new Selector<string> { All = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background.png" },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(0, 0, 81, 81) },
                ImageShadow = new ImageShadow
                {
                    //PositionUsesPivotPoint = true,
                    //ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    //PivotPoint = Tizen.NUI.PivotPoint.Center,
                    //WidthResizePolicy = ResizePolicyType.FillToParent,
                    //HeightResizePolicy = ResizePolicyType.FillToParent,
                    Url = CommonResource.Instance.GetFHResourcePath() + "11. Popup/popup_background_shadow.png",
                    Border = new Rectangle(0, 0, 105, 105)
                },
                Title = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 25 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Size = new Size(0, 68),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Position = new Position(64, 52),
                },
                Buttons = new ButtonStyle
                {
                    Size = new Size(0, 132),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundImage = new Selector<string> { All = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                    ImageShadow = new ImageShadow
                    {
                        Url = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png",
                        Border = new Rectangle(5, 5, 5, 5)
                    },
                    Overlay = new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BackgroundColor = new Selector<Color>
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                            Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                        }
                    },
                    Text = new TextLabelStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextColor = new Selector<Color>()
                    },
                },
            };

            return style;
        }
    }
}
