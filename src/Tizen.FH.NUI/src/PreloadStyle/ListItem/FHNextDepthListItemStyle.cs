using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class NextDepthListItemStyle : StyleBase
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
                SpaceBetweenEndItemAndText = 0,
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
                EndItemRoot = new ViewStyle
                {
                    Size = new Size(48, 48),
                },
                EndIcon = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_arrow_right.png"
                    }
                }
            };
            return style;
        }
    }
}
