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
    /// NavigationAttributes is a class which saves Navigation's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    public class NavigationStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a NavigationAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public NavigationStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a NavigationAttributes with attributes.
        /// </summary>
        /// <param name="navigationStyle">Create NavigationAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public NavigationStyle(NavigationStyle navigationStyle) : base(navigationStyle)
        {
            if (null == navigationStyle)
            {
                return;
            }
            CopyFrom(navigationStyle);
        }

        /// <summary>
        /// DividerLine's color.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public Color DividerLineColor
        {
            get;
            set;
        } = new Color(0, 0, 0, 0.1f);

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public int ItemGap
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Padding in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public new Extents Padding
        {
            get;
            set;
        } = new Extents(0, 0, 0, 0);

        /// <summary>
        /// Flag to decide if item is fill with item text's natural width.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public bool IsFitWithItems
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            NavigationStyle navigationStyle = that as NavigationStyle;
            DividerLineColor = new Color(navigationStyle.DividerLineColor.R, navigationStyle.DividerLineColor.G,
                navigationStyle.DividerLineColor.B, navigationStyle.DividerLineColor.A);
            ItemGap = navigationStyle.ItemGap;
            Padding.CopyFrom(navigationStyle.Padding);
            IsFitWithItems = navigationStyle.IsFitWithItems;
        }
    }

    /// <summary>
    /// NavigationItemAttributes is a class which saves Navigation item's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    public class NavigationItemStyle : ButtonStyle
    {
        /// <summary>
        /// Creates a new instance of a NavigationItemAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public NavigationItemStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a NavigationItemAttributes with attributes.
        /// </summary>
        /// <param name="itemStyle">Create NavigationItemAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public NavigationItemStyle(NavigationItemStyle itemStyle) : base(itemStyle)
        {
            if (null == itemStyle)
            {
                return;
            }
            CopyFrom(itemStyle);
        }

        /// <summary>
        /// SubText's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public TextLabelStyle SubText
        {
            get;
            set;
        } = new TextLabelStyle();

        /// <summary>
        /// DividerLine's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public ViewStyle DividerLine
        {
            get;
            set;
        } = new ViewStyle();

        /// <summary>
        /// Padding in Navigation Item.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public new Extents Padding
        {
            get;
            set;
        } = new Extents(0, 0, 0, 0);

        /// <summary>
        /// Flag to decide if item icon is center or not.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public bool EnableIconCenter
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            NavigationItemStyle navigationItemStyle = that as NavigationItemStyle;
            SubText.CopyFrom(navigationItemStyle.SubText);
            DividerLine.CopyFrom(navigationItemStyle.DividerLine);
            Padding.CopyFrom(navigationItemStyle.Padding);
            EnableIconCenter = navigationItemStyle.EnableIconCenter;
        }
    }
}
