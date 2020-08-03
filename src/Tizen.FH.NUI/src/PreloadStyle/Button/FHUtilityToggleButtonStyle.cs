using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class UtilityToggleButtonStyle : TextButtonStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            ButtonStyle style = base.GetViewStyle() as ButtonStyle;
            style.BackgroundImage = new Selector<string>
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_toggle_btn_normal.png",
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png",
            };
            style.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            style.ImageShadow = new ImageShadow
            {
                Url = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png",
                Border = new Rectangle(5, 5, 5, 5)
            };
            style.Text.TextColor = new Selector<Color>
            {
                Normal = Utility.Hex2Color(Constants.AppColorUtility, 1),
                Selected = new Color(1, 1, 1, 1),
            };
            return style;
        }
    }
}
