
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class DATimePickerAMPMStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            TimePickerStyle style = new TimePickerStyle
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                ShadowExtents = new Extents(1, 1, 1, 1),
                BackgroundImage = new StringSelector
                {
                    All = CommonResource.Instance.GetFHResourcePath() + "0. BG/background_default_overlay.png"
                },
                BackgroundImageBorder = new RectangleSelector { All = new Rectangle(0, 0, 81, 81) },
                HourSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(108, 32)
                },
                MinuteSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(416, 32)
                },
                AmPmSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(724, 32)
                },
                ColonImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(12, 152),
                    Position = new Position(0, 208),
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    ResourceUrl = new StringSelector {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_time_colon.png"
                    }
                }
            };
            return style;
        }
    }
}
