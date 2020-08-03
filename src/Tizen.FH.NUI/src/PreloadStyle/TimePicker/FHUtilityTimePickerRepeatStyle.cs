
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class UtilityTimePickerRepeatStyle : FHTimePickerRepeatStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            TimePickerStyle style = base.GetViewStyle() as TimePickerStyle;
            style.ColonImage.ResourceUrl = new StringSelector
            {
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_time_colon.png"
            };
            style.WeekSelectImage.ResourceUrl = new StringSelector
            {
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_date_select.png"
            };

            return style;
        }
    }
}
