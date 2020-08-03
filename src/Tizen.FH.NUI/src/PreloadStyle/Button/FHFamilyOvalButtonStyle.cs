﻿using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyOvalButtonStyle : IconButtonStyle
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
                Selected = CommonResource.Instance.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_24c447.png",
            };
            style.ImageShadow = new ImageShadow
            {
                Url = CommonResource.Instance.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png"
            };
            return style;
        }
    }
}
