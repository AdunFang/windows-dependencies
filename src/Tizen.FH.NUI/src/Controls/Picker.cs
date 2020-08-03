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
using StyleManager = Tizen.NUI.Components.StyleManager;
using System;
using System.Globalization;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// Picker is one kind of Fhub component, a picker allows the user to change date information: year/month/day.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Picker : Control
    {
        private ImageView focusImage = null;
        private ImageView endSelectedImage = null;
        private View dateView = null;
        private TextLabel sunText = null;
        private TextLabel monText = null;
        private TextLabel tueText = null;
        private TextLabel wenText = null;
        private TextLabel thuText = null;
        private TextLabel friText = null;
        private TextLabel satText = null;
        private TextLabel[,] dateTable = null;
        private ImageView leftArrowImage = null;
        private ImageView rightArrowImage = null;
        private TextLabel monthText = null;
        private DropDown dropDown = null;
        private TextLabel preTouch = null;
        private DateTime showDate;
        private DateTime currentDate;
        private DataArgs data;
        private Vector2 yearRange;

        /// <summary>
        /// Creates a new instance of a Picker.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Picker() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Picker with style.
        /// </summary>
        /// <param name="style">Create Picker by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Picker(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Current date in Picker.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public DateTime CurrentDate
        {
            get
            {
                return currentDate;
            }
            set
            {
                currentDate = value;
                showDate = currentDate;
            }
        }

        /// <summary>
        /// Apply a new style for picker.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            PickerStyle style = viewStyle as PickerStyle;
            if (style.LeftArrow != null)
            {
                if (leftArrowImage == null)
                {
                    leftArrowImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    leftArrowImage.TouchEvent += OnPreMonthTouchEvent;
                    Add(leftArrowImage);
                }
                leftArrowImage.ApplyStyle(style.LeftArrow);
            }
            if (style.RightArrow != null)
            {
                if (rightArrowImage == null)
                {
                    rightArrowImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    rightArrowImage.TouchEvent += OnNextMonthTouchEvent;
                    Add(rightArrowImage);
                }
                rightArrowImage.ApplyStyle(style.RightArrow);
            }
            if (style.MonthText != null)
            {
                if (monthText == null)
                {
                    monthText = new TextLabel();
                    Add(monthText);
                }
                monthText.ApplyStyle(style.MonthText);
            }
            if (style.DateView != null)
            {
                if (dateView == null)
                {
                    dateView = new View();
                    Add(dateView);
                }
                dateView.ApplyStyle(style.DateView);
                if (style.FocusImage != null)
                {
                    if (focusImage == null)
                    {
                        focusImage = new ImageView()
                        {
                            WidthResizePolicy = ResizePolicyType.FillToParent,
                            HeightResizePolicy = ResizePolicyType.FillToParent
                        };
                        focusImage.Hide();
                        dateView.Add(focusImage);
                    }
                    focusImage.ApplyStyle(style.FocusImage);
                }
                if (style.EndSelectedImage != null)
                {
                    if (endSelectedImage == null)
                    {
                        endSelectedImage = new ImageView()
                        {
                            WidthResizePolicy = ResizePolicyType.FillToParent,
                            HeightResizePolicy = ResizePolicyType.FillToParent
                        };
                        endSelectedImage.Hide();
                        dateView.Add(endSelectedImage);
                    }
                    endSelectedImage.ApplyStyle(style.EndSelectedImage);
                }
                if (style.SundayText != null)
                {
                    if (sunText == null)
                    {
                        sunText = new TextLabel();
                        dateView.Add(sunText);
                    }
                    sunText.ApplyStyle(style.SundayText);
                }
                if (style.MondayText != null)
                {
                    if (monText == null)
                    {
                        monText = new TextLabel();
                        dateView.Add(monText);
                    }
                    monText.ApplyStyle(style.MondayText);
                }
                if (style.TuesdayText != null)
                {
                    if (tueText == null)
                    {
                        tueText = new TextLabel();
                        dateView.Add(tueText);
                    }
                    tueText.ApplyStyle(style.TuesdayText);
                }
                if (style.WensdayText != null)
                {
                    if (wenText == null)
                    {
                        wenText = new TextLabel();
                        dateView.Add(wenText);
                    }
                    wenText.ApplyStyle(style.WensdayText);
                }
                if (style.ThursdayText != null)
                {
                    if (thuText == null)
                    {
                        thuText = new TextLabel();
                        dateView.Add(thuText);
                    }
                    thuText.ApplyStyle(style.ThursdayText);
                }
                if (style.FridayText != null)
                {
                    if (friText == null)
                    {
                        friText = new TextLabel();
                        dateView.Add(friText);
                    }
                    friText.ApplyStyle(style.FridayText);
                }
                if (style.SaturdayText != null)
                {
                    if (satText == null)
                    {
                        satText = new TextLabel();
                        dateView.Add(satText);
                    }
                    satText.ApplyStyle(style.SaturdayText);
                }
                if (null == dateTable)
                {
                    dateTable = new TextLabel[6, 7];
                }
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (null == dateTable[i, j])
                        {
                            dateTable[i, j] = new TextLabel();
                            dateTable[i, j].Focusable = true;
                            dateTable[i, j].TouchEvent += OnDateTouchEvent;
                            dateView.Add(dateTable[i, j]);
                        }
                        if (j % 2 == 0)
                        {
                            dateTable[i, j].ApplyStyle(style.DateText);
                        }
                        else
                        {
                            dateTable[i, j].ApplyStyle(style.DateText2);
                        }
                    }
                }
            }

            if (style.YearDropDownStyle != null)
            {
                if (dropDown == null)
                {
                    //dropDown = new DropDown(style.YearDropDownStyle);
                    //dropDown.ItemClickEvent += OnDropDownItemClickEvent;
                    //Add(dropDown);
                }
            }

            yearRange = style.YearRange;
        }

        /// <summary>
        /// Dispose Picker and all children on it.
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
                if (leftArrowImage != null)
                {
                    leftArrowImage.TouchEvent -= OnPreMonthTouchEvent;
                    Utility.Dispose(leftArrowImage);
                }                
                if (rightArrowImage != null)
                {
                    rightArrowImage.TouchEvent -= OnNextMonthTouchEvent;
                    Utility.Dispose(rightArrowImage);
                }
                Utility.Dispose(monthText);              
                if (dropDown != null)
                {
                    dropDown.ItemClickEvent -= OnDropDownItemClickEvent;
                    Utility.Dispose(dropDown);
                }
                Utility.Dispose(focusImage);                
                Utility.Dispose(endSelectedImage);
                Utility.Dispose(sunText);
                Utility.Dispose(monText);
                Utility.Dispose(tueText);
                Utility.Dispose(wenText);
                Utility.Dispose(thuText);
                Utility.Dispose(friText);
                Utility.Dispose(satText);
                for (int i = 0; i < 6; i++)
                {
                    for(int j = 0; j < 7; j++)
                    {
                        if (dateTable[i, j] != null)
                        {
                            dateTable[i, j].TouchEvent -= OnDateTouchEvent;
                            Utility.Dispose(dateTable[i, j]);
                        }
                    }
                }
                Utility.Dispose(dateView);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Get Picker attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new PickerStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            PickerStyle pickerStyle = StyleManager.Instance.GetViewStyle(StyleName) as PickerStyle;
            if (pickerStyle != null)
            {
                ApplyStyle(pickerStyle);
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Update Picker by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            PickerStyle style = ViewStyle as PickerStyle;

            if (style.YearDropDownItemStyle != null)
            {
                int value = showDate.Year;
                
                for (int i = (int)yearRange.X; i <= (int)yearRange.Y; i++)
                {
                    //DropDown.DropDownDataItem item = new DropDown.DropDownDataItem(style.YearDropDownItemStyle);
                    //item.Text = i.ToString();
                    //dropDown.AddItem(item);
                }
                
                //dropDown.FocusedItemIndex = value - (int)Style.YearRange.X;
                //dropDown.SelectedItemIndex = dropDown.FocusedItemIndex;
                //dropDown.Style.Button.Text.Text = showDate.Year.ToString();
            }
                        
            int tableX = 0;
            int tableY = (int)sunText.Size.Height;
            int tableW = (int)dateTable[0, 0].Size.Width;
            int tableH = (int)dateTable[0, 0].Size.Height;
            
            for (int i = 0; i < 6; i++)
            { 
                tableX = 0;                
                for (int j = 0; j < 7; j++)
                {
                    dateTable[i, j].Position = new Position(tableX, tableY );                    
                    if (j % 2 == 0)
                    {
                        tableW = (int)dateTable[0, 0].Size.Width; 
                    }
                    else
                    {
                        tableW = (int)dateTable[0, 1].Size.Width; 
                    }                    
                    tableX += tableW;
                }                
                tableY += tableH;
            }
            UpdateDate();
        }

        private void Initialize()
        {
            LeaveRequired = true;
            data = new DataArgs();
            showDate = DateTime.Now;
            currentDate = showDate;
        }

        private void OnDropDownItemClickEvent(object sender, DropDown.ItemClickEventArgs e)
        {
            int year = 0;
            
            if (int.TryParse(e.Text, out year))
            {
                if (year == showDate.Year)
                {
                    return;
                }
                
                int month = showDate.Month;
                
                if (month == currentDate.Month && year == currentDate.Year)
                {
                    showDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month, 1);
                }
                
                //dropDown.FocusedItemIndex = dropDown.SelectedItemIndex;
                //dropDown.Style.Button.Text.Text = showDate.Year.ToString();

                UpdateDate();
            }
        }
        
        private bool OnNextMonthTouchEvent(object source, View.TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            
            if (state == PointStateType.Down)
            {
                if (showDate.Month == 12)
                {
                    if (showDate.Year == (int)yearRange.Y)
                    {
                        return false;
                    }
                    else
                    {
                        //dropDown.FocusedItemIndex += 1;
                        //dropDown.SelectedItemIndex = dropDown.FocusedItemIndex;
                        //dropDown.Style.Button.Text.Text = (showDate.Year + 1).ToString();
                    }
                }
                
                int month = (showDate.Month == 12) ? 1 : showDate.Month + 1;
                int year = (showDate.Month == 12) ? showDate.Year + 1 : showDate.Year;
                
                if (month == currentDate.Month && year == currentDate.Year)
                {
                    showDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month, 1);
                }
                
                UpdateDate();
            } 
            
            return false;
        }
        
        private bool OnPreMonthTouchEvent(object source, View.TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            
            if (state == PointStateType.Down)
            {
                if (showDate.Month == 1)
                {
                    if (showDate.Year == (int)yearRange.X)
                    {
                        return false;
                    }
                    else
                    {
                        //dropDown.FocusedItemIndex -= 1;
                        //dropDown.SelectedItemIndex = dropDown.FocusedItemIndex;
                        //dropDown.Style.Button.Text.Text = (showDate.Year - 1).ToString();
                    }
                }
                
                int month = (showDate.Month == 1) ? 12 : showDate.Month - 1;
                int year = (showDate.Month == 1) ? showDate.Year - 1 : showDate.Year;
                
                if (month == currentDate.Month && year == currentDate.Year)
                {
                    showDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);
                }
                else
                {
                    showDate = new DateTime(year, month, 1);
                }
                
                UpdateDate();
            }
            
            return false;
        }

        private bool OnDateTouchEvent(object source, View.TouchEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;           
            int line = (int)((textLabel.Position.Y - dateTable[0, 0].Position.Y) / dateTable[0, 0].Size.Height);
            int i = 0;
            
            for (i = 0; i < 7; i++)
            {
                if (dateTable[line, i].Position.X == textLabel.Position.X)
                {
                     break;
                }
            }

            int index = line * 7 + i;
            
            if (index < data.prenum || index >= (42 - data.nextnum))
            {
                return false;
            }

            if (preTouch != null)
            {
                int X = (int)preTouch.Position.X;
                
                if (X == 0)
                {
                    preTouch.TextColor = Color.Red;
                }
                else
                {
                    preTouch.TextColor = Color.Black;
                }
            }
            
            int focusX = (int)(textLabel.Position.X + (textLabel.Size.Width - focusImage.Size.Width) / 2);
            int focusY = (int)(textLabel.Position.Y + (textLabel.Size.Height - focusImage.Size.Height) / 2);
            
            focusImage.Position = new Position(focusX, focusY);
            focusImage.Show();            
            textLabel.TextColor = Color.White;
            preTouch = textLabel;
            return false;
        }
        
        private void UpdateDate()
        {
            DateTime dateTime = new DateTime(showDate.Year, showDate.Month, 1);
            int weekStart = Convert.ToInt32(dateTime.DayOfWeek);
            int days = DateTime.DaysInMonth(showDate.Year, showDate.Month); 
            int lines = ((days + weekStart) % 7 == 0) ? (days + weekStart) / 7 : ((days + weekStart) / 7 + 1);
            
            dateView.Size = new Size(dateView.Size.Width, dateTable[0, 0].Size.Height*(lines + 1));
            data.curnum = days;
            data.prenum = weekStart;
            data.nextnum = 42 - weekStart - days;

            int[] value = new int[42];
            int idx = 0;
            for (int i = 0; i < data.prenum; i++)
            {
                value[idx++] = 0xFF;
            }
            
            int t = 1;
            for(int i = 0; i < data.curnum; i++)
            {
                value[idx++] = t++;
            }
            
            for (int i = 0; i < data.nextnum; i++)
            {
                value[idx++] = 0xFF;
            }

            for (int i = 0; i < 42; i++)
            {
                int x = i / 7;
                int y = i % 7;
                if (value[i] != 0xFF)
                {
                    dateTable[x, y].Text = value[i].ToString();
                }
                else
                {
                    dateTable[x, y].Text = " ";
                }
            }

            for (int i = data.prenum; i < data.prenum+data.curnum; i++)
            {
                int x = i / 7;
                int y = i % 7;                
                if(y == 0)
                {
                    dateTable[x, y].TextColor = Color.Red;
                }
                else
                {
                    dateTable[x, y].TextColor = Color.Black;
                }
            }

            int focusidx = data.prenum + showDate.Day - 1;
            dateTable[focusidx / 7, focusidx % 7].TextColor = Color.White;

            int focusX = (int)(dateTable[focusidx / 7, focusidx % 7].Position.X + (dateTable[focusidx / 7, focusidx % 7].Size.Width - focusImage.Size.Width) / 2);
            int focusY = (int)(dateTable[focusidx / 7, focusidx % 7].Position.Y + (dateTable[focusidx / 7, focusidx % 7].Size.Height - focusImage.Size.Height) / 2);
            focusImage.Position = new Position(focusX, focusY);
            focusImage.Show();

            if (showDate.Month == currentDate.Month && showDate.Year == currentDate.Year)
            {
                endSelectedImage.Position = new Position(focusX, focusY);
                endSelectedImage.Show();
                if (showDate.Day == currentDate.Day)
                {
                    focusImage.Hide();
                }
            }
            else
            {
                endSelectedImage.Hide();
            }

            preTouch = dateTable[focusidx / 7, focusidx % 7];
            monthText.Text =  showDate.ToString("MMMM", new CultureInfo("en-us"));
        }

        private struct DataArgs
        {
            internal int prenum;
            internal int curnum;
            internal int nextnum;
        }
    }
}
