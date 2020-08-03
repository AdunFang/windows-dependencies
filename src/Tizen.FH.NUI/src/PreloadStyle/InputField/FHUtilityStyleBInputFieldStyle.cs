using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class UtilityStyleBInputFieldStyle : FHInputFieldStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            InputFieldStyle style = base.GetViewStyle() as InputFieldStyle;
            style.AddButtonBackground.Size = new Size(92, 92);
            style.AddButtonBackground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_add_bg.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_add_bg.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_add_bg_dim.png",
            };
            style.AddButtonForeground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_add.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_add_press.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_add_dim.png",
            };
            style.AddButtonOverlay.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_add_bg_press_overlay.png",
                Other = "",
            };
            style.DeleteButton.Size = new Size(92, 92);
            style.DeleteButton.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete_press.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_btn_ic_delete_dim.png",
            };

            return style;
        }
    }
}
