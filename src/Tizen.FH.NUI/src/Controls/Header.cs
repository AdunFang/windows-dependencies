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
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// The Header is a component that contain a lable and a 1 pixel line  under it
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Header : Control
    {
        private TextLabel titleTextLabel = null;
        private View bottomLine = null;

        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Header() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Header(string style) : base(style)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        /// <param name="style">Create Header by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Header(HeaderStyle style) : base(style)
        {
        }

        /// <summary>
        /// The text label displayed in the header
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        public TextLabel TitleLabel
        {
            get
            {
                if (null == titleTextLabel)
                {
                    titleTextLabel = new TextLabel
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    };
                    Add(TitleLabel);
                }
                return titleTextLabel;
            }
            set
            {
                titleTextLabel = value;
            }
        }

        /// <summary>
        /// The view of one pixel line under the header
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        public View BottomLine
        {
            get
            {
                if (null == bottomLine)
                {
                    bottomLine = new View
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        Size = new Size(1080, 1),
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft
                    };
                    Add(BottomLine);
                }
                return bottomLine;
            }
            set
            {
                bottomLine = value;
            }
        }

        /// <summary>
        /// Style for the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new HeaderStyle Style
        {
            get
            {
                return new HeaderStyle(ViewStyle as HeaderStyle);
            }
        }

        /// <summary>
        /// The text showed in the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get text from TextLabel directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title
        {
            get
            {
                return Style?.Title?.Text?.All;
            }
            set
            {
                Style.Title.Text = new Selector<string>() { All = value };
            }
        }

        /// <summary>
        /// The color of text showed in the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get textColor from TextLabel directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TitleColor
        {
            get
            {
                return Style?.Title?.TextColor?.All;
            }
            set
            {
                Style.Title.TextColor = new Selector<Color> { All = value };
            }
        }

        /// <summary>
        /// The color of one pixel line under the header
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get backgroundColor from BottomLine directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color BottomLineColor
        {
            get
            {
                return Style?.BottomLine?.BackgroundColor?.All;
            }
            set
            {
                Style.BottomLine.BackgroundColor = new Selector<Color> { All = value };
            }
        }

        /// <summary>
        /// Apply a new style for header.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            HeaderStyle style = viewStyle as HeaderStyle;
            if (style != null)
            {
                TitleLabel.ApplyStyle(style.Title);
                BottomLine.ApplyStyle(style.BottomLine);
            }
        }

        /// <summary>
        /// Get Header attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new HeaderStyle();
        }

        /// <summary>
        /// Dispose Header and all children on it.
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
                Utility.Dispose(TitleLabel);
                Utility.Dispose(BottomLine);
            }
            base.Dispose(type);
        }
    }
}
