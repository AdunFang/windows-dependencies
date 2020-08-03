
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    internal class UtilityDatePickerStyle : FHDatePickerStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            PickerStyle style = base.GetViewStyle() as PickerStyle;
            style.FocusImage.ResourceUrl = new Selector<string>
            {
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_date_select.png"
            };

            return style;
        }
    }
}
