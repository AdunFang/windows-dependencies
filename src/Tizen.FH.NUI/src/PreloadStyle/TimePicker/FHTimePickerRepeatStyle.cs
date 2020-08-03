
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FHTimePickerRepeatStyle : StyleBase
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
                Title = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Start Time" },
                    Size = new Size(1000, 52),
                    Position = new Position(64, 32),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                HourSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(108, 116)
                },
                MinuteSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(416, 116)
                },
                AmPmSpin = new SpinStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(200, 428),
                    Position = new Position(724, 116)
                },
                ColonImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(12, 152),
                    Position = new Position(0, 292),
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                },
                WeekView = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(904, 236),
                    Position = new Position(64, 576)
                },
                WeekTitleText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Repeat the Day" },
                    Size = new Size(904, 52),
                    Position = new Position(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                WeekSelectImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(80, 80),
                    Position = new Position(0, 88),
                },
                WeekText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 15 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Repeat the Day" },
                    Size = new Size(129, 88),
                    Position = new Position(0, 84),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                }
            };
            return style;
        }
    }
}
