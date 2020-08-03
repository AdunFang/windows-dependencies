
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyBasicButtonStyle : TextButtonStyle
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
            style.ImageShadow = new ImageShadow
            {
                Url = CommonResource.Instance.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png",
                Border = new Rectangle(5, 5, 5, 5)
            };
            style.Text.TextColor = new Selector<Color>
            {
                Selected = Utility.Hex2Color(Constants.AppColorFamily, 1),
            };
            return style;
        }
    }
}
