/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using StyleManager = Tizen.NUI.Components.StyleManager;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// TimePicker is one kind of Fhub component, a timePicker allows the user to
    /// change time information: hour/minute/second/AMPM.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class TimePicker : Control
    {
        private ImageView colonImage = null;
        private ImageView colonImage2 = null;        
        private Spin hourSpin = null;
        private Spin minuteSpin = null;
        private Spin secondSpin = null;
        private Spin amPmSpin = null;
        private View weekView = null;
        private TextLabel title = null;
        private ImageView[] weekSelectImage = null;
        private TextLabel[] weekText = null;
        private TextLabel weekTitleText = null;
        private bool[] selected = null;
        private Extents shadowExtents = new Extents(0, 0, 0, 0);

        /// <summary>
        /// Creates a new instance of a TimePicker.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public TimePicker() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a TimePicker with style.
        /// </summary>
        /// <param name="style">Create TimePicker by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public TimePicker(string style) : base(style)
        {
            Initialize();
        }

        public new TimePickerStyle Style
        {
            get
            {
                return new TimePickerStyle(ViewStyle as TimePickerStyle);
            }
        }

        /// <summary>
        /// Current time in TimePicker.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public DateTime CurrentTime
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            TimePickerStyle timePickerStyle = viewStyle as TimePickerStyle;
            if (colonImage == null)
            {
                colonImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(colonImage);
            }
            colonImage.ApplyStyle(timePickerStyle.ColonImage);
            if (colonImage2 == null)
            {
                colonImage2 = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(colonImage2);
            }
            colonImage2.ApplyStyle(timePickerStyle.ColonImage);
            if (timePickerStyle.Title != null && title == null)
            {
                title = new TextLabel();
                Add(title);
            }
            title.ApplyStyle(timePickerStyle.Title);
            if (timePickerStyle.WeekView != null && weekView == null)
            {
                weekView = new View();
                Add(weekView);
            }
            weekView.ApplyStyle(timePickerStyle.WeekView);
            if (timePickerStyle.WeekSelectImage != null)
            {
                if (weekSelectImage == null)
                {
                    weekSelectImage = new ImageView[7];
                }
                selected = new bool[7];
                for (int i = 0; i < 7; i++)
                {
                    if (null == weekSelectImage[i])
                    {
                        weekSelectImage[i] = new ImageView()
                        {
                            WidthResizePolicy = ResizePolicyType.FillToParent,
                            HeightResizePolicy = ResizePolicyType.FillToParent
                        };
                        weekSelectImage[i].Hide();
                        weekView.Add(weekSelectImage[i]);
                        selected[i] = false;
                    }
                    if (null != weekSelectImage[i])
                    {
                        weekSelectImage[i].ApplyStyle(timePickerStyle.WeekSelectImage);
                    }
                }
            }
            if (timePickerStyle.WeekText != null)
            {
                if (weekText == null)
                {
                    weekText = new TextLabel[7];
                }
                for (int i = 0; i < 7; i++)
                {
                    if (weekText[i] == null)
                    {
                        weekText[i] = new TextLabel();
                        weekText[i].TouchEvent += OnRepeatTextTouchEvent;
                        weekView.Add(weekText[i]);
                    }
                    weekText[i].ApplyStyle(timePickerStyle.WeekText);
                }
            }
            if (timePickerStyle.WeekTitleText != null)
            {
                if (weekTitleText == null)
                {
                    weekTitleText = new TextLabel();
                    weekView.Add(weekTitleText);
                }
                weekTitleText.ApplyStyle(timePickerStyle.WeekTitleText);
            }

            CurrentTime = DateTime.Now;
            if (hourSpin == null)
            {
                hourSpin = new Spin("DASpin");
                hourSpin.NameTextLabel.Text = "Hours";
                if (timePickerStyle.AmPmSpin != null)
                {
                    hourSpin.CurrentValue = CurrentTime.Hour % 12;
                }
                else
                {
                    hourSpin.CurrentValue = CurrentTime.Hour % 24;
                }
                Add(hourSpin);
            }
            hourSpin.ParentOrigin = timePickerStyle.HourSpin.ParentOrigin;
            hourSpin.PivotPoint = timePickerStyle.HourSpin.PivotPoint;
            hourSpin.PositionUsesPivotPoint = (bool)timePickerStyle.HourSpin.PositionUsesPivotPoint;
            hourSpin.Size = timePickerStyle.HourSpin.Size;
            hourSpin.Position = timePickerStyle.HourSpin.Position;

            if (minuteSpin == null)
            {
                minuteSpin = new Spin("DASpin");
                minuteSpin.NameTextLabel.Text = "Minutes";
                minuteSpin.CurrentValue = CurrentTime.Minute;
                Add(minuteSpin);
            }
            minuteSpin.ParentOrigin = timePickerStyle.MinuteSpin.ParentOrigin;
            minuteSpin.PivotPoint = timePickerStyle.MinuteSpin.PivotPoint;
            minuteSpin.PositionUsesPivotPoint = (bool)timePickerStyle.MinuteSpin.PositionUsesPivotPoint;
            minuteSpin.Size = timePickerStyle.MinuteSpin.Size;
            minuteSpin.Position = timePickerStyle.MinuteSpin.Position;

            if (timePickerStyle.SecondSpin != null)
            {
                if (secondSpin == null)
                {
                    secondSpin = new Spin("DASpin");
                    secondSpin.NameTextLabel.Text = "Seconds";
                    secondSpin.CurrentValue = CurrentTime.Second;
                    Add(secondSpin);
                }
                secondSpin.ParentOrigin = timePickerStyle.SecondSpin.ParentOrigin;
                secondSpin.PivotPoint = timePickerStyle.SecondSpin.PivotPoint;
                secondSpin.PositionUsesPivotPoint = (bool)timePickerStyle.SecondSpin.PositionUsesPivotPoint;
                secondSpin.Size = timePickerStyle.SecondSpin.Size;
                secondSpin.Position = timePickerStyle.SecondSpin.Position;
            }
            if (timePickerStyle.AmPmSpin != null)
            {
                if (amPmSpin == null)
                {
                    amPmSpin = new Spin("DAStrSpin");
                    amPmSpin.CurrentValue = CurrentTime.Hour / 12;
                    Add(amPmSpin);
                }
                amPmSpin.ParentOrigin = timePickerStyle.AmPmSpin.ParentOrigin;
                amPmSpin.PivotPoint = timePickerStyle.AmPmSpin.PivotPoint;
                amPmSpin.PositionUsesPivotPoint = (bool)timePickerStyle.AmPmSpin.PositionUsesPivotPoint;
                amPmSpin.Size = timePickerStyle.AmPmSpin.Size;
                amPmSpin.Position = timePickerStyle.AmPmSpin.Position;
            }

            shadowExtents.CopyFrom(timePickerStyle.ShadowExtents);
        }

        /// <summary>
        /// Dispose TimePicker and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {              
                Utility.Dispose(colonImage);
                Utility.Dispose(colonImage2);
                Utility.Dispose(hourSpin);
                Utility.Dispose(minuteSpin);
                Utility.Dispose(secondSpin);
                Utility.Dispose(amPmSpin);
                Utility.Dispose(title);
                Utility.Dispose(weekTitleText);
                if (weekSelectImage != null)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Utility.Dispose(weekSelectImage[i]);
                    }
                }
                if (weekText!= null)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        weekText[i].TouchEvent -= OnRepeatTextTouchEvent;
                        Utility.Dispose(weekText[i]);
                    }
                }
                Utility.Dispose(weekView);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Get TimePicker attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new TimePickerStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            TimePickerStyle timePickerStyle = StyleManager.Instance.GetViewStyle(StyleName) as TimePickerStyle;
            if (timePickerStyle != null)
            {
                ApplyStyle(timePickerStyle);
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Update TimePicker by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (ImageShadow != null)
            {
                ImageShadow.Extents = new Vector2(shadowExtents.Start + shadowExtents.End,
                    shadowExtents.Top + shadowExtents.Bottom);
            }

            if (minuteSpin != null)
            {
                int x = 0;
                if (colonImage2 != null)
                {
                    x = (int)(minuteSpin.Position.X + minuteSpin.Size.Width + (minuteSpin.Position.X - hourSpin.Position.X - hourSpin.Size.Width - colonImage.Size.Width) / 2);
                    colonImage2.Position = new Position(x, colonImage2.Position.Y);
                }
                x = (int)(hourSpin.Position.X + hourSpin.Size.Width + (minuteSpin.Position.X - hourSpin.Position.X - hourSpin.Size.Width - colonImage.Size.Width) / 2);
                colonImage.Position = new Position(x, colonImage.Position.Y);
            }

            if (weekView != null)
            {
                if ((weekText != null) && (weekSelectImage != null))
                {
                    for (int i = 0; i < 7; i++)
                    {
                        weekText[i].Position = new Position(i * weekText[i].Size.Width, weekText[i].Position.Y);
                        weekSelectImage[i].Position = new Position(i * weekText[i].Size.Width + (weekText[i].Size.Width -weekSelectImage[i].Size.Width)/2, weekSelectImage[i].Position.Y);
                    }
                    weekText[0].Text = "Sun";
                    weekText[0].TextColor = Color.Red;
                    weekText[1].Text = "Mon";
                    weekText[2].Text = "Tue";
                    weekText[3].Text = "Wen";
                    weekText[4].Text = "Thu";
                    weekText[5].Text = "Fri";
                    weekText[6].Text = "Sat";
                }                
            }
            if (amPmSpin != null)
            {
                hourSpin.MaxValue = 11;
                hourSpin.MinValue = 0;
                amPmSpin.MaxValue = 1;
                amPmSpin.MinValue = 0;
            }
            else
            {
                hourSpin.MaxValue = 23;
                hourSpin.MinValue = 0;
            }
            if (minuteSpin !=null)
            {
                minuteSpin.MaxValue = 59;
                minuteSpin.MinValue = 0;
            }
            if (secondSpin !=null)
            {
                secondSpin.MaxValue = 59;
                secondSpin.MinValue = 0;
            }
        }

        private void Initialize()
        {
            LeaveRequired = true;
        }

        private bool OnRepeatTextTouchEvent(object source, View.TouchEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;
            PointStateType state = e.Touch.GetState(0);
            
            if (state == PointStateType.Down)
            {
                int i = 0;                
                for (i = 0; i < 7; i++)
                {
                    if (weekText[i] == textLabel)
                    {
                        break;
                    }
                }                
                if (selected[i] == false)
                {
                    selected[i] = true;
                    weekSelectImage[i].Show();
                }
                else
                {
                    selected[i] = false;
                    weekSelectImage[i].Hide();
                }
            }
            
            return false;
        }
    }    
}

