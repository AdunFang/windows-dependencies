using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class EffectListItemStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            ListItemStyle style = new ListItemStyle
            {
                StartSpace = 56,
                EndSpace = 56,
                StyleType = ListItem.StyleTypes.Effect,
                MainText = new TextLabelStyle
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 44,
                    },
                    FontFamily = "SamsungOne 400",
                    TextColor = new ColorSelector
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 1),
                        Selected = Utility.Hex2Color(Constants.AppColorUtility, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    },
                },
                DividerLine = new ImageViewStyle
                {
                    Size = new Size(0, 1),
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.1f),
                    }
                }
            };
            return style;
        }

    }
}
