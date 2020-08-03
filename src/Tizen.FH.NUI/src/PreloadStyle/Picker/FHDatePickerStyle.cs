
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FHDatePickerStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }

            PickerStyle style = new PickerStyle
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                YearRange = new Vector2(1900, 2099),
                FocusImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new Selector<Rectangle>
                    {
                        All = new Rectangle(0, 0, 1, 1)
                    },
                    Size = new Size(80, 80),
                    ResourceUrl = new Selector<string>
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_24c447.png"
                    }
                },
                EndSelectedImage = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new Selector<Rectangle>
                    {
                        All = new Rectangle(0, 0, 1, 1)
                    },
                    Size = new Size(80, 80),
                    ResourceUrl = new Selector<string>
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_date_endscheduling.png"
                    }
                },
                LeftArrow = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new Selector<Rectangle>
                    {
                        All = new Rectangle(0, 0, 1, 1)
                    },
                    Size = new Size(48, 48),
                    Position = new Position(344, 42),
                    ResourceUrl = new Selector<string>
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_spin_btn_back.png"
                    }
                },
                RightArrow = new ImageViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new Selector<Rectangle> { All = new Rectangle(0, 0, 1, 1) },
                    Size = new Size(48, 48),
                    Position = new Position(640, 42),
                    ResourceUrl = new Selector<string>
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_spin_btn_next.png"
                    }
                },
                MonthText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 30 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Size = new Size(248, 68),
                    Position = new Position(392, 32),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateView = new ViewStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size = new Size(1032, 528),
                    Position = new Position(0, 132)
                },
                SundayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Red },
                    Text = new Selector<string> { All = "Sun" },
                    Size = new Size(147, 88),
                    Position = new Position(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                MondayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Mon" },
                    Size = new Size(147, 88),
                    Position = new Position(147, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                TuesdayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Tue" },
                    Size = new Size(147, 88),
                    Position = new Position(295, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                WensdayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Wen" },
                    Size = new Size(147, 88),
                    Position = new Position(442, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                ThursdayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Thu" },
                    Size = new Size(147, 88),
                    Position = new Position(590, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                FridayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Fri" },
                    Size = new Size(147, 88),
                    Position = new Position(737, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                SaturdayText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Text = new Selector<string> { All = "Sat" },
                    Size = new Size(147, 88),
                    Position = new Position(885, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateText = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Size = new Size(147, 88),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateText2 = new TextLabelStyle
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new Selector<float?> { All = 20 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Size = new Size(148, 88),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                YearDropDownStyle = new DropDownStyle
                {
                    Button = new ButtonStyle
                    {
                        PositionX = 100,
                        Text = new TextLabelStyle
                        {
                            Text = new StringSelector { All = "Year" },
                            PointSize = new Selector<float?> { All = 30 },
                            TextColor = new Selector<Color> { All = new Color(0, 0, 0, 1) },
                            FontFamily = "SamsungOneUI 500",
                            PositionUsesPivotPoint = true,
                            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                            PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                            WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                            HeightResizePolicy = ResizePolicyType.FillToParent,
                            Position = new Position(0, 0),
                            HorizontalAlignment = HorizontalAlignment.End,
                            VerticalAlignment = VerticalAlignment.Center,
                        },
                        Icon = new ImageViewStyle
                        {
                            Size = new Size(48, 48),
                            ResourceUrl = new Selector<string>
                            {
                                All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_dropdown.png"
                            },
                            PositionUsesPivotPoint = true,
                            ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                            PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        },
                    },
                    ListBackgroundImage = new ImageViewStyle
                    {
                        ResourceUrl = new StringSelector
                        {
                            All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png"
                        },
                        Border = new Selector<Rectangle> { All = new Rectangle(51, 51, 51, 51) },
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.FitToChildren,
                        HeightResizePolicy = ResizePolicyType.FitToChildren,
                        Size = new Size(304, 500),
                    },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    SpaceBetweenButtonTextAndIcon = 20,
                    ListMargin = new Extents(20, 0, 20, 0),
                    BackgroundColor = new Selector<Color> { All = new Color(1, 1, 1, 1) },
                    ListPadding = new Extents(4, 4, 4, 4),
                    Size = new Size(288, 68),
                    Position = new Position(688, 32),
                    //FocusedItemIndex = 0
                },
                YearDropDownItemStyle = new DropDownItemStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Size = new Size(250, 80),
                    CheckImageGapToBoundary = 16,
                    Text = new TextLabelStyle
                    {
                        Position = new Position(28, 0),
                        PointSize = new FloatSelector { All = 18 }
                    },
                    CheckImage = new ImageViewStyle
                    {
                        Size = new Size(40, 40),
                        ResourceUrl = new Selector<string>
                        {
                            All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png"
                        },
                    },
                    BackgroundColor = new Selector<Color>
                    {
                        Pressed = new Color(0, 0, 0, 0.4f),
                        Other = new Color(1, 1, 1, 0)
                    },
                }
            };
            return style;
        }
    }
}
