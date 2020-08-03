using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class ItemAlignListItemStyle : StyleBase
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
                SpaceBetweenStartItemAndText = 24,
                SpaceBetweenEndItemAndText = 56,
                CheckBoxStyle = "CheckBox",
                StyleType = ListItem.StyleTypes.ItemAlign,
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
                        All = new Color(0, 0, 0, 1),
                    },
                },
                StartItemRoot = new ViewStyle
                {
                },                
                EndItemRoot = new ViewStyle
                {
                },
                StartIcon = new ImageViewStyle
                {
                },
                EndText = new TextLabelStyle
                {
                    HorizontalAlignment = HorizontalAlignment.End,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 30,
                    },
                    FontFamily = "SamsungOne 500",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    },
                }
            };
            return style;
        }
    }
}
