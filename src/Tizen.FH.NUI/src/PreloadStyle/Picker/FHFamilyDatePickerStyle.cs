
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    internal class FamilyDatePickerStyle : FHDatePickerStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            PickerStyle style = base.GetViewStyle() as PickerStyle;
            style.FocusImage.ResourceUrl = new Selector<string>
            {
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_24c447.png"
            };

            return style;
        }
    }
}
