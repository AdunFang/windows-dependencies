using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class TextButtonStyle : StyleBase
    {
        public TextButtonStyle()
        {
        }

        protected override ViewStyle GetViewStyle()
        {
            ButtonStyle style = new ButtonStyle
            {
                IsSelectable = true,
                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Text = new TextLabelStyle
                {
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = Utility.Hex2Color(Constants.AppColorUtility, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    }
                }
            };
            return style;
        }
    }
}

