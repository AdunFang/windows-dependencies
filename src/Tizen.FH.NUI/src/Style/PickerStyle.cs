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
    /// PickerAttributes is a class which saves Date Picker's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    public class PickerStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a PickerAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public PickerStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a PickerAttributes with attributes.
        /// </summary>
        /// <param name="pickerStyle">Create PickerAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public PickerStyle(PickerStyle pickerStyle) : base(pickerStyle)
        {
            if (null == pickerStyle)
            {
                return;
            }

            CopyFrom(pickerStyle);
        }

        /// <summary>
        /// Date Picker shaow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle ShadowImageViewStyle
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker background image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle BackgroundImageViewStyle
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker focus image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle FocusImage
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker end selected image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle EndSelectedImage
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker date view's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ViewStyle DateView
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Date Picker sunday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle SundayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker mondy text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle MondayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker tuesday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle TuesdayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker wensday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public TextLabelStyle WensdayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker thursday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle ThursdayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker friday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle FridayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker saturday text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle SaturdayText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker date text's attributes. Date of a month.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle DateText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker date text's attributes. Date of a month. They have width difference from DateTextAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle DateText2
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker left arrow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle LeftArrow
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker right arrow image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle RightArrow
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Date Picker month text's attributes. Show the current month.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle MonthText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Date Picker year dropdown's attributes. It can change year.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public DropDownStyle YearDropDownStyle
        {
            get;
            set;
        } = new DropDownStyle();

        /// <summary>
        /// Date Picker year dropdown item's attributes. used for YearDropDownAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public DropDownItemStyle YearDropDownItemStyle
        {
            get;
            set;
        } = new DropDownItemStyle();

        /// <summary>
        /// Date Picker year range.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public Vector2 YearRange
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

            PickerStyle pickerStyle = that as PickerStyle;
            //ShadowImageViewStyle.CopyFrom(pickerStyle.ShadowImageViewStyle);
            //BackgroundImageViewStyle.CopyFrom(pickerStyle.BackgroundImageViewStyle);
            FocusImage.CopyFrom(pickerStyle.FocusImage);
            EndSelectedImage.CopyFrom(pickerStyle.EndSelectedImage);
            DateView.CopyFrom(pickerStyle.DateView);
            SundayText.CopyFrom(pickerStyle.SundayText);
            MondayText.CopyFrom(pickerStyle.MondayText);
            TuesdayText.CopyFrom(pickerStyle.TuesdayText);
            WensdayText.CopyFrom(pickerStyle.WensdayText);
            ThursdayText.CopyFrom(pickerStyle.ThursdayText);
            FridayText.CopyFrom(pickerStyle.FridayText);
            SaturdayText.CopyFrom(pickerStyle.SaturdayText);
            DateText.CopyFrom(pickerStyle.DateText);
            DateText2.CopyFrom(pickerStyle.DateText2);
            LeftArrow.CopyFrom(pickerStyle.LeftArrow);
            RightArrow.CopyFrom(pickerStyle.RightArrow);
            MonthText.CopyFrom(pickerStyle.MonthText);
            YearDropDownStyle.CopyFrom(pickerStyle.YearDropDownStyle);
            YearDropDownItemStyle.CopyFrom(pickerStyle.YearDropDownItemStyle);
            YearRange = new Vector2(pickerStyle.YearRange.X, pickerStyle.YearRange.Y);
        }
    }
}
