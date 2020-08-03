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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// TimePickerAttributes is a class which saves Time Picker's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    public class TimePickerStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a TimePickerAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TimePickerStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a TimePickerAttributes with attributes.
        /// </summary>
        /// <param name="pickerStyle">Create TimePickerAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TimePickerStyle(TimePickerStyle pickerStyle) : base(pickerStyle)
        {
            if (null == pickerStyle)
            {
                return;
            }
            CopyFrom(pickerStyle);
        }

        /// <summary>
        /// Time Picker title text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle Title
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Extents of Shadow.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public Extents ShadowExtents
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker hour spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle HourSpin
        {
            get;
            set;
        } = new SpinStyle();

        /// <summary>
        /// Time Picker minute spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle MinuteSpin
        {
            get;
            set;
        } = new SpinStyle();

        /// <summary>
        /// Time Picker second spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle SecondSpin
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker AMPM spin's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle AmPmSpin
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker colon image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ImageViewStyle ColonImage
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Time Picker week view's attributes. Used for add week title and week text.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle WeekView
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Time Picker week title text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle WeekTitleText
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week select image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ImageViewStyle WeekSelectImage
        {
            get;
            set;
        }

        /// <summary>
        /// Time Picker week text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle WeekText
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            TimePickerStyle timePickerStyle = that as TimePickerStyle;
            if (Title != null)
            {
                Title.CopyFrom(timePickerStyle.Title);
            }
            ShadowExtents = new Extents(timePickerStyle.ShadowExtents.Start,
                timePickerStyle.ShadowExtents.End, timePickerStyle.ShadowExtents.Top, timePickerStyle.ShadowExtents.Bottom);
            HourSpin.CopyFrom(timePickerStyle.HourSpin);
            MinuteSpin.CopyFrom(timePickerStyle.MinuteSpin);
            if (SecondSpin != null)
            {
                SecondSpin.CopyFrom(timePickerStyle.SecondSpin);
            }
            if (AmPmSpin != null)
            {
                AmPmSpin.CopyFrom(timePickerStyle.AmPmSpin);
            }
            ColonImage.CopyFrom(timePickerStyle.ColonImage);
            if (WeekView != null)
            {
                WeekView.CopyFrom(timePickerStyle.WeekView);
            }
            if (WeekTitleText != null)
            {
                WeekTitleText.CopyFrom(timePickerStyle.WeekTitleText);
            }
            if (WeekSelectImage != null)
            {
                WeekSelectImage.CopyFrom(timePickerStyle.WeekSelectImage);
            }
            if (WeekText != null)
            {
                WeekText.CopyFrom(timePickerStyle.WeekText);
            }
        }
    }
}
