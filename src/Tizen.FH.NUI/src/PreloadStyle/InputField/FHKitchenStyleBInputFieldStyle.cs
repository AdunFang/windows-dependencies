using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class KitchenStyleBInputFieldStyle : FHInputFieldStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            InputFieldStyle style = base.GetViewStyle() as InputFieldStyle;
            style.AddButtonBackground.Size = new Size(92, 92);
            style.AddButtonBackground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_9762d9.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_9762d9.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_btn_add_bg_dim_9762d9.png",
            };
            style.AddButtonForeground.ResourceUrl = new StringSelector
            {
                Normal = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_9762d9_normal.png",
                Pressed = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_9762d9_press.png",
                Disabled = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/html/input_btn_add_9762d9_dim.png",
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
