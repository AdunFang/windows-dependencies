/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// PaginationAttributes used to config the pagination represent.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    public class PaginationStyle : Tizen.NUI.Components.PaginationStyle
    {
        /// <summary>
        /// Creates a new instance of a PaginationAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public PaginationStyle() : base() { }

        /// <summary>
        /// Creates a new instance of a PaginationAttributes using attributes.
        /// </summary>
        /// <param name="paginationStyle">Create PaginationAttributess by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public PaginationStyle(PaginationStyle paginationStyle) : base(paginationStyle)
        {
            if (null == paginationStyle)
            {
                return;
            }
            CopyFrom(paginationStyle);
        }

        /// <summary>
        /// Gets or sets return arrow icon attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle ReturnArrow
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Gets or sets next arrow icon attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public ImageViewStyle NextArrow
        {
            get;
            set;
        } = new ImageViewStyle();

        /// <summary>
        /// Retrieves a copy of PaginationAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public override void CopyFrom(BindableObject that)
        {
            base.CopyFrom(that);

            PaginationStyle paginationStyle = that as PaginationStyle;
            ReturnArrow.CopyFrom(paginationStyle.ReturnArrow);
            NextArrow.CopyFrom(paginationStyle.NextArrow);
        }
    }
}
