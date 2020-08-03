
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    internal class FoodDatePickerStyle : FHDatePickerStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            PickerStyle style = base.GetViewStyle() as PickerStyle;
            style.FocusImage.ResourceUrl = new Selector<string>
            {
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_ec7510.png"
            };
            
            return style;
        }
    }
}
