using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class ListIndexSwitchStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            SwitchStyle style = new SwitchStyle
            {
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    Size = new Size(72, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_on.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_off_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_swich_bg_on_dim.png",
                    },
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich_dim.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_controller_swich_dim.png",
                    },
                },
            };

            return style;
        }
    }
}
