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
    /// HeaderAttributes is a class which saves Header's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    public class HeaderStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a HeaderAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public HeaderStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a HeaderAttributes with attributes.
        /// </summary>
        /// <param name="style">Create HeaderAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public HeaderStyle(HeaderStyle style) : base(style)
        {
            if (null == style)
            {
                return;
            }
            CopyFrom(style);
        }

        /// <summary>
        /// Header text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle Title
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Header line's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle BottomLine
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            HeaderStyle headerStyle = that as HeaderStyle;
            Title.CopyFrom(headerStyle.Title);
            BottomLine.CopyFrom(headerStyle.BottomLine);
        }
    }
}
