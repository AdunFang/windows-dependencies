using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class DefaultPaginationStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            PaginationStyle style = new PaginationStyle
            {
                IndicatorSize = new Size(26, 26),
                IndicatorImageUrl = new Selector<string>
                {
                    Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                    Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
                },
                IndicatorSpacing = 8,
                ReturnArrow = new ImageViewStyle
                {
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_return.png"
                    },
                    Size = new Size(26, 26),
                    ParentOrigin = ParentOrigin.CenterLeft,
                    PivotPoint = PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true
                },
                NextArrow = new ImageViewStyle
                {
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_next.png"
                    },
                    Size = new Size(26, 26),
                    ParentOrigin = ParentOrigin.CenterRight,
                    PivotPoint = PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                }
            };
            return style;
        }
    }
}

