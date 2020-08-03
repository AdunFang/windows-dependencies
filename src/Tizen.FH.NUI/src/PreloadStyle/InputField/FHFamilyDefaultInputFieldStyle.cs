using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyDefaultInputFieldStyle : FHInputFieldStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            InputFieldStyle style = base.GetViewStyle() as InputFieldStyle;
            style.CancelButton.Size = new Size(56, 56);
            style.CancelButton.ResourceUrl = new StringSelector
            {
                All = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/[Input Field] App Primary Color/field_ic_cancel_24c447.png",
            };

            return style;
        }
    }
}
