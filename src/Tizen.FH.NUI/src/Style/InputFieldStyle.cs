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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// InputFieldStyle is a class which saves InputField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.   
    public class InputFieldStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a InputFieldStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public InputFieldStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a InputFieldStyle with attributes.
        /// </summary>
        /// <param name="inputFieldStyle">Create InputFieldStyle by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.      
        public InputFieldStyle(InputFieldStyle inputFieldStyle) : base(inputFieldStyle)
        {
            if (null == inputFieldStyle)
            {
                return;
            }
            CopyFrom(inputFieldStyle);
        }

        /// <summary>
        /// Gets or sets input box attributes of input field.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextFieldStyle InputBox { get; set; } = new TextFieldStyle();

        /// <summary>
        /// Gets or sets space.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int? Space { get; set; }

        /// <summary>
        /// Cancel button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public ImageViewStyle CancelButton { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Delete button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle DeleteButton { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Add button background's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public ImageViewStyle AddButtonBackground { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Add button over lay's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle AddButtonOverlay { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Add button foreground's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle AddButtonForeground { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Search  button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle SearchButton { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Space bwtwwen text field and right button 's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public int? SpaceBetweenTextFieldAndRightButton { get; set; }

        /// <summary>
        /// Space betwwen text field and left button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.      
        public int? SpaceBetweenTextFieldAndLeftButton { get; set; }

        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            InputFieldStyle inputFieldStyle = that as InputFieldStyle;
            InputBox.CopyFrom(inputFieldStyle.InputBox);
            CancelButton.CopyFrom(inputFieldStyle.CancelButton);
            DeleteButton.CopyFrom(inputFieldStyle.DeleteButton);
            AddButtonBackground.CopyFrom(inputFieldStyle.AddButtonBackground);
            AddButtonOverlay.CopyFrom(inputFieldStyle.AddButtonOverlay);
            AddButtonForeground.CopyFrom(inputFieldStyle.AddButtonForeground);
            SearchButton.CopyFrom(inputFieldStyle.SearchButton);

            SpaceBetweenTextFieldAndRightButton = inputFieldStyle.SpaceBetweenTextFieldAndRightButton;
            SpaceBetweenTextFieldAndLeftButton = inputFieldStyle.SpaceBetweenTextFieldAndLeftButton;
            Space = inputFieldStyle.Space;
        }
    }
}
