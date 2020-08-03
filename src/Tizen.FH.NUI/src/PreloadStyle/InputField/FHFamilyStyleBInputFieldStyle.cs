using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyStyleBInputFieldStyle : FHInputFieldStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            InputFieldStyle style = base.GetViewStyle() as InputFieldStyle;
            style.AddButtonBackground.Size = new Size(92, 92);
            style.AddButtonBackground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_24c447.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_24c447.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_dim_24c447.png",
            };
            style.AddButtonForeground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_24c447_normal.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_24c447_press.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_24c447_dim.png",
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
