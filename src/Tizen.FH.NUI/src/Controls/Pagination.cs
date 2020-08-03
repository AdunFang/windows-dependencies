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
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using System.ComponentModel;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Pagination : Tizen.NUI.Components.Pagination
    {
        private ImageView returnArrow = null;
        private ImageView nextArrow = null;
        private int indicatorCount;
        private int selectedIndex;
        private int maxCountOnePage = 10;

        private TapGestureDetector tapGestureDetector;

        private EventHandler<SelectChangeEventArgs> selectChangeEventHandlers;

        /// <summary>
        /// Creates a new instance of a Pagination.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Pagination() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PaginationStyle Style
        {
            get
            {
                return new PaginationStyle(ViewStyle as PaginationStyle);
            }
        }

        /// <summary>
        /// Select indicator changed event.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public event EventHandler<SelectChangeEventArgs> SelectChangeEvent
        {
            add
            {
                selectChangeEventHandlers += value;
            }
            remove
            {
                selectChangeEventHandlers -= value;
            }
        }

        /// <summary>
        /// The return arrow displayed in the pagination.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        public ImageView ReturnArrow
        {
            get
            {
                if (null == returnArrow)
                {
                    returnArrow = new ImageView()
                    {
                        Name = "ReturnArrow",
                    };
                    Add(ReturnArrow);
                }
                return returnArrow;
            }
            set
            {
                returnArrow = value;
            }
        }

        /// <summary>
        /// The next arrow displayed in the pagination.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        public ImageView NextArrow
        {
            get
            {
                if (nextArrow == null)
                {
                    nextArrow = new ImageView()
                    {
                        Name = "NextArrow",
                    };
                    Add(nextArrow);
                }
                return nextArrow;
            }
            set
            {
                nextArrow = value;
            }
        }

        /// <summary>
        /// Gets or sets the resource of return arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get/set ResourceUrl of ReturnArrow directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> ReturnArrowUrl
        {
            get
            {
                return Style?.ReturnArrow?.ResourceUrl;
            }
            set
            {
                if (value == null || Style == null)
                {
                    return;
                }
                Style.ReturnArrow.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the resource of next arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get/set ResourceUrl of NextArrow directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> NextArrowUrl
        {
            get
            {
                return Style?.NextArrow?.ResourceUrl;
            }
            set
            {
                if (value == null || Style == null)
                {
                    return;
                }
                Style.NextArrow.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of return arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get/set Size of ReturnArrow directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ReturnArrowSize
        {
            get
            {
                return Style?.ReturnArrow?.Size;
            }
            set
            {
                if (value == null || Style == null)
                {
                    return;
                }
                Style.ReturnArrow.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of next arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [Obsolete("Deprecated. Please get/set Size of NextArrow directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size NextArrowSize
        {
            get
            {
                return Style?.NextArrow?.Size;
            }
            set
            {
                if (value == null || Style == null)
                {
                    return;
                }
                Style.NextArrow.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of the pages/indicators.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public new int IndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (indicatorCount == value)
                {
                    return;
                }
                indicatorCount = value;
                LayoutUpdate();
            }
        }

        /// <summary>
        /// Gets or sets the index of the select indicator.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public new int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex == value)
                {
                    return;
                }
                int previousIndex = selectedIndex;
                selectedIndex = value;
                LayoutUpdate();
                SelectChangeEventArgs args = new SelectChangeEventArgs();
                args.PreviousIndex = previousIndex;
                args.CurrentIndex = selectedIndex;
                OnSelectChangeEvent(this, args);
            }
        }

        /// <summary>
        /// Apply a new style for pagination.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            PaginationStyle style = viewStyle as PaginationStyle;
            if (style != null)
            {
                ReturnArrow.ApplyStyle(style.ReturnArrow); 
                NextArrow.ApplyStyle(style.NextArrow);
            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
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
                if (tapGestureDetector != null)
                {
                    tapGestureDetector.Detected -= OnTapGestureDetected;
                    tapGestureDetector.Dispose();
                    tapGestureDetector = null;
                }
                Utility.Dispose(returnArrow);
                Utility.Dispose(nextArrow);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// you can override it to create your own default attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new PaginationStyle();
        }

        /// <summary>
        /// you can override it to handle the tap gesture.
        /// </summary>
        /// <param name="source">TapGestureDetector</param>
        /// <param name="e">DetectedEventArgs</param>
        /// <since_tizen> 5.5 </since_tizen>
        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (e.View == ReturnArrow)
            {
                if (selectedIndex > 0)
                {
                    SelectedIndex = selectedIndex - 1;
                }
            }
            else if (e.View == NextArrow)
            {
                if (selectedIndex < indicatorCount - 1)
                {
                    SelectedIndex = selectedIndex + 1;
                }
            }
            else
            {
                Position selectIndicatorPosition = GetIndicatorPosition(selectedIndex % maxCountOnePage);
                if (e.TapGesture.LocalPoint.X < selectIndicatorPosition.X)
                {
                    if (selectedIndex > 0)
                    {
                        SelectedIndex = selectedIndex - 1;
                    }
                }
                else if (e.TapGesture.LocalPoint.X > selectIndicatorPosition.X + IndicatorSize.Width)
                {
                    if (selectedIndex < indicatorCount - 1)
                    {
                        SelectedIndex = selectedIndex + 1;
                    }
                }
            }
        }

        private void Initialize()
        {
            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Detected += OnTapGestureDetected;
            tapGestureDetector.Attach(ReturnArrow);
            tapGestureDetector.Attach(NextArrow);
        }

        private void LayoutUpdate()
        {
            int maxCount = GetMaxCountOnePage();
            if (maxCountOnePage != maxCount)
            {
                maxCountOnePage = maxCount;
            }

            int pageCount = (indicatorCount + maxCountOnePage - 1) / maxCountOnePage;
            int pageIndex = selectedIndex / maxCountOnePage;
            if (pageIndex == pageCount - 1)
            {
                base.IndicatorCount = indicatorCount % maxCountOnePage;
            }
            else
            {
                base.IndicatorCount = maxCountOnePage;
            }
            base.SelectedIndex = selectedIndex % maxCountOnePage;

            if (pageIndex == 0)
            {
                ReturnArrow.Hide();
            }
            else
            {
                ReturnArrow.Show();
            }

            if (pageIndex == pageCount - 1)
            {
                NextArrow.Hide();
            }
            else
            {
                NextArrow.Show();
            }
        }

        private int GetMaxCountOnePage()
        {
            int count = 10;

            int returnArrowWidth = 0, nextArrowWidth = 0;
            if (ReturnArrow != null && ReturnArrow.Size != null)
            {
                returnArrowWidth = (int)ReturnArrow.Size.Width;
            }
            if (NextArrow != null && NextArrow.Size != null)
            {
                nextArrowWidth = (int)NextArrow.Size.Width;
            }
            int indicatorWidth = 0, indicatorHeight = 0;
            int indicatorSpacing = 0;
            if (IndicatorSize != null)
            {
                indicatorWidth = (int)IndicatorSize.Width;
                indicatorHeight = (int)IndicatorSize.Height;
            }
            indicatorSpacing = IndicatorSpacing;
            if (indicatorWidth + indicatorSpacing == 0)
            {
                throw new ArithmeticException("width and space of indictor is 0.");
            }
            count = (int)((SizeWidth - returnArrowWidth - nextArrowWidth) / (indicatorWidth + indicatorSpacing));

            return count;
        }

        private void OnSelectChangeEvent(object sender, SelectChangeEventArgs e)
        {
            selectChangeEventHandlers?.Invoke(sender, e);
        }


        /// <summary>
        /// SelectChange Event Arguments.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public class SelectChangeEventArgs : EventArgs
        {
            /// <summary>
            /// Previous select indicator index.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public int PreviousIndex;

            /// <summary>
            /// Previous select indicator index.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public int CurrentIndex;
        }
    }
}
