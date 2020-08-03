using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class DefaultSearchInputFieldStyle : FHInputFieldStyle
    {
        protected override ViewStyle GetViewStyle()
        {
            InputFieldStyle style = base.GetViewStyle() as InputFieldStyle;
            style.SpaceBetweenTextFieldAndLeftButton = 16; // this property is not set in other styles....
            style.CancelButton.Size = new Size(56, 56);
            style.CancelButton.ResourceUrl = new StringSelector
            {
                All = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/field_ic_cancel.png",
            };
            style.SearchButton.Size = new Size(56, 56);
            style.SearchButton.ResourceUrl = new StringSelector
            {
                All = CommonResource.Instance.GetFHResourcePath() + "7. Input Field/search_ic_search.png",
            };

            return style;
        }
    }
}
