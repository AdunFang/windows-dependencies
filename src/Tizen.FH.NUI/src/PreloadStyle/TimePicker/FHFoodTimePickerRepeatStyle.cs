﻿
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FoodTimePickerRepeatStyle : FHTimePickerRepeatStyle
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
                All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_ec7510.png"
            };

            return style;
        }
    }
}
