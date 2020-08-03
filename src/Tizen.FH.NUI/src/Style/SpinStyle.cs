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
    /// SpinAttributes is a class which saves Spin's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.   
    public class SpinStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a SpinAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a SpinAttributes with attributes.
        /// </summary>
        /// <param name="spinStyle">Create SpinAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public SpinStyle(SpinStyle spinStyle) : base(spinStyle)
        {
            if (null == spinStyle)
            {
                return;
            }
            CopyFrom(spinStyle);
        }

        /// <summary>
        /// Spin item text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.       
        public TextLabelStyle ItemText
        {
            get;
            set;
        }

        /// <summary>
        /// Spin name text's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle NameText
        {
            get;
            set;
        }

        /// <summary>
        /// Spin top mask image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ImageViewStyle MaskTopImage
        {
            get;
            set;
        }

        /// <summary>
        /// Spin bottom mask image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ImageViewStyle MaskBottomImage
        {
            get;
            set;
        }

        /// <summary>
        /// Spin animation view's attributes. AniView is attached to Anination Control.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle AnimationView
        {
            get;
            set;
        }

        /// <summary>
        /// Spin clip view's attributes. ClipView is used for hiding exceed content when animation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle ClipView
        {
            get;
            set;
        }

        /// <summary>
        /// Spin name view's attributes. NameView is used for adding name text.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle NameView
        {
            get;
            set;
        }

        /// <summary>
        /// Spin first divider line's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle DividerLine
        {
            get;
            set;
        }

        /// <summary>
        /// Spin sencond divider line's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle DividerLine2
        {
            get;
            set;
        }

        /// <summary>
        /// Spin text field's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextFieldStyle TextField
        {
            get;
            set;
        }

        /// <summary>
        /// Spin min value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int MinValue
        {
            get;
            set;
        }

        /// <summary>
        /// Spin max value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int MaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// Spin current value's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int CurrentValue
        {
            get;
            set;
        }

        /// <summary>
        /// Spin item height.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int ItemHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Spin up and down item text size.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int TextSize
        {
            get;
            set;
        }

        /// <summary>
        /// Spin center item text size.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int CenterTextSize
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

            SpinStyle spinStyle = that as SpinStyle;
            if (ItemText != null)
            {
                ItemText.CopyFrom(spinStyle.ItemText);
            }
            if (NameText != null)
            {
                NameText.CopyFrom(spinStyle.NameText);
            }
            if (MaskTopImage != null)
            {
                MaskTopImage.CopyFrom(spinStyle.MaskTopImage);
            }
            if (MaskBottomImage != null)
            {
                MaskBottomImage.CopyFrom(spinStyle.MaskBottomImage);
            }
            if (AnimationView != null)
            {
                AnimationView.CopyFrom(spinStyle.AnimationView);
            }
            if (ClipView != null)
            {
                ClipView.CopyFrom(spinStyle.ClipView);
            }
            if (NameView != null)
            {
                NameView.CopyFrom(spinStyle.NameView);
            }
            if (DividerLine != null)
            {
                DividerLine.CopyFrom(spinStyle.DividerLine);
            }
            if (DividerLine2 != null)
            {
                DividerLine2.CopyFrom(spinStyle.DividerLine2);
            }
            if (TextField != null)
            {
                TextField.CopyFrom(spinStyle.TextField);
            }
            MinValue = spinStyle.MinValue;
            MaxValue = spinStyle.MaxValue;
            CurrentValue = spinStyle.CurrentValue;
            ItemHeight = spinStyle.ItemHeight;
            TextSize = spinStyle.TextSize;
            CenterTextSize = spinStyle.CenterTextSize;
        }
    }
}
