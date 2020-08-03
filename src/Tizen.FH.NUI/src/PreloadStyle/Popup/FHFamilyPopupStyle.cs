
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyPopupStyle : BasePopupStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            PopupStyle style = base.GetViewStyle() as PopupStyle;
            style.Buttons.Text.TextColor.All = Utility.Hex2Color(Constants.AppColorFamily, 1);
            return style;
        }
    }
}
