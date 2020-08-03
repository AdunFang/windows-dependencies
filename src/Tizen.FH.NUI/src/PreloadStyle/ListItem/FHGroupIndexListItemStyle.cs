using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class GroupIndexListItemStyle : StyleBase
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
                BackgroundColor = new ColorSelector
                {
                    All = Utility.Hex2Color(0x282828, 0.05f),
                },
                SwitchStyle = "ListIndexSwitch",
                StyleType = ListItem.StyleTypes.GroupIndex,
                MainText = new TextLabelStyle
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
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
                },
                MainText2 = new TextLabelStyle
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 24,
                    },
                    FontFamily = "SamsungOne 500C",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    }
                },
                EndItemRoot = new ViewStyle
                {

                },
                EndIcon = new ImageViewStyle
                {
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_next_button.png"
                    }
                }
            };

            return style;
        }
    }
}
