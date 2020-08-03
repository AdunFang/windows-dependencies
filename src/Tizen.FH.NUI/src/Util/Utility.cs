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

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// Utility class.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    internal class Utility
    {
        /// <summary>
        /// Transfer color value(#rgb) to Color.
        /// </summary>
        /// <param name="hex">rgb value</param>
        /// <param name="a">alpha value</param>
        /// <returns>Transfered color</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public static Color Hex2Color(int hex, float a)
        {
            float r = 0, g = 0, b = 0;
            b = (hex & 0xff) / 255.0f;
            g = (hex >> 8 & 0xff) / 255.0f;
            r = (hex >> 16 & 0xff) / 255.0f;

            return new Color(r, g, b, a);
        }

        /// <summary>
        /// Dispose the child view.
        /// </summary>
        /// <param name="child">a view would be disposed.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public static void Dispose(View child)
        {
            View parent = child?.GetParent() as View;
            if (child != null)
            {
                if (parent != null)
                {
                    parent.Remove(child);
                }
                child.Dispose();
                child = null;
            }
        }
    }
}
