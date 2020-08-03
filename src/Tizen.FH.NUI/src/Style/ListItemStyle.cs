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
    /// ListItemAttributes is a class which saves ListItem's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.   
    public class ListItemStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a ListItemAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ListItemStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a ListItemAttributes with attributes.
        /// </summary>
        /// <param name="listItemStyle">Create ListItemAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ListItemStyle(ListItemStyle listItemStyle) : base(listItemStyle)
        {
            if (null == listItemStyle)
            {
                return;
            }
            CopyFrom(listItemStyle);
        }

        /// <summary>
        /// MainText's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle MainText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// MainText's attributes when style is group index  and groupIndexType is none
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle MainText2
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Subtext's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle SubText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Divider view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle DividerLine
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Left item root view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ViewStyle StartItemRoot
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Right item root view's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ViewStyle EndItemRoot
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Left icon's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle StartIcon
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Right icon's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle EndIcon
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Right text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public TextLabelStyle EndText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// Left space's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public uint? StartSpace
        {
            get;
            set;
        }

        /// <summary>
        /// Right space's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public uint? EndSpace
        {
            get;
            set;
        }

        /// <summary>
        /// Space between left item and text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public uint? SpaceBetweenStartItemAndText
        {
            get;
            set;
        }

        /// <summary>
        /// Space between right item and text's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public uint? SpaceBetweenEndItemAndText
        {
            get;
            set;
        }

        /// <summary>
        /// CheckBox style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public string CheckBoxStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Switch style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public string SwitchStyle
        {
            get;
            set;
        }

        /// <summary>
        /// DropDown style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public string DropDownStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Style style's attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ListItem.StyleTypes StyleType
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

            ListItemStyle listItemStyle = that as ListItemStyle;
            MainText.CopyFrom(listItemStyle.MainText);
            MainText2.CopyFrom(listItemStyle.MainText2);
            SubText.CopyFrom(listItemStyle.SubText);
            DividerLine.CopyFrom(listItemStyle.DividerLine);
            StartItemRoot.CopyFrom(listItemStyle.StartItemRoot);
            EndItemRoot.CopyFrom(listItemStyle.EndItemRoot);
            StartIcon.CopyFrom(listItemStyle.StartIcon);
            EndIcon.CopyFrom(listItemStyle.EndIcon);
            EndText.CopyFrom(listItemStyle.EndText);
            StartSpace = listItemStyle.StartSpace;
            EndSpace = listItemStyle.EndSpace;
            SpaceBetweenStartItemAndText = listItemStyle.SpaceBetweenStartItemAndText;
            SpaceBetweenEndItemAndText = listItemStyle.SpaceBetweenEndItemAndText;
            CheckBoxStyle = listItemStyle.CheckBoxStyle;
            SwitchStyle = listItemStyle.SwitchStyle;
            DropDownStyle = listItemStyle.DropDownStyle;
            StyleType = listItemStyle.StyleType;
        }
    }
}
