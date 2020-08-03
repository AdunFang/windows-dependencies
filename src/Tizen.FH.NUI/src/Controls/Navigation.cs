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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// NavigationGroup is used to trace navigations.
    /// Navigation can be added/inserted/delete.
    /// </summary>
    /// <since_tizen> 6.0 </since_tizen>
    public class NavigationGroup
    {
        /// <summary>
        /// Creates a new navigation group.
        /// </summary>
        /// <since_tizen> 6.0 </since_tizen>
        public NavigationGroup()
        {
            NavigationList = new List<Navigation>();
        }

        /// <summary>
        /// A list is used to add / remove Navigations.
        /// </summary>
        /// <since_tizen> 6.0 </since_tizen>
        public List<Navigation> NavigationList { get; }
    }

    /// <summary>
    /// Navigation is one kind of common component, it can be used as instruction, guide or direction.
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Navigation : Control
    {
        private List<NavigationDataItem> itemList = new List<NavigationDataItem>();
        private List<View> dividerLineList = new List<View>();
        private int curIndex = -1;
        private View rootView;
        private EventHandler<TouchEventArgs> itemTouchHander;
        private float navigationLastY = 0.0f;
        private NavigationGroup navigationGroup = null;

        /// <summary>
        /// Creates a new instance of a Navigation.
        /// </summary>
        /// <param name="group">A group to which navigation belongs.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Navigation(NavigationGroup group) : base()
        {
            navigationGroup = group ?? throw new Exception("navigation group is null!");
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Navigation with style.
        /// </summary>
        /// <param name="group">A group to which navigation belongs.</param>
        /// <param name="style">Create Navigation by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Navigation(NavigationGroup group, string style) : base(style)
        {
            navigationGroup = group ?? throw new Exception("navigation group is null!");
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Navigation with attributes.
        /// </summary>
        /// <param name="group">A group to which navigation belongs.</param>
        /// <param name="attributes">Create Navigation by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Navigation(NavigationGroup group, NavigationStyle attributes) : base(attributes)
        {
            navigationGroup = group ?? throw new Exception("navigation group is null!");
            Initialize();
        }

        /// <summary>
        /// An event for the item changed signal which can be used to subscribe
        /// or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public event EventHandler<ItemChangeEventArgs> ItemChangedEvent;

        /// <summary>
        /// An event for the item touch signal which can be used to subscribe
        /// or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public event EventHandler<TouchEventArgs> ItemTouchEvent
        {
            add
            {
                itemTouchHander += value;
            }
            remove
            {
                itemTouchHander -= value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new NavigationStyle Style
        {
            get
            {
                return new NavigationStyle(ViewStyle as NavigationStyle);
            }
        }

        /// <summary>
        /// Selected item's index in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int SelectedItemIndex
        {
            get
            {
                return curIndex;
            }
            set
            {
                if (value < itemList.Count)
                {
                    UpdateSelectedItem(itemList[value]);
                }
            }
        }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int ItemGap
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Divider line's color in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Color DividerLineColor
        {
            get;
            set;
        } = new Color(0, 0, 0, 0.1f);

        /// <summary>
        /// Padding in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Extents Padding
        {
            get;
            set;
        } = new Extents(0, 0, 0, 0);

        /// <summary>
        /// Flag to decide Navigation's size is fill with all navigation items' size or not.
        /// True is fit, false is none. If false, then Navigation's size can be updated by user.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public bool IsFitWithItems
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Add navigation item by item data. The added item will be added to end of all items automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to navigaiton item view.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public void AddItem(NavigationDataItem itemData)
        {
            AddItemByIndex(itemData, itemList.Count);
        }

        /// <summary>
        /// Insert navigation item by item data. The inserted item will be added to
        /// the special position by index automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to navigaiton item view.</param>
        /// <param name="index">Position index where will be inserted.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public void InsertItem(NavigationDataItem itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// <summary>
        /// Delete navigation item by index.
        /// </summary>
        /// <param name="itemIndex">Position index where will be deleted.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public void DeleteItem(int itemIndex)
        {
            if (itemList == null || itemIndex < 0 || itemIndex >= itemList.Count)
            {
                return;
            }

            if (curIndex > itemIndex || (curIndex == itemIndex && itemIndex == itemList.Count - 1))
            {
                curIndex--;
            }

            Remove(itemList[itemIndex]);
            itemList[itemIndex].Dispose();
            itemList.RemoveAt(itemIndex);

            UpdateItem();
            if (curIndex != -1)
            {
                itemList[curIndex].SetControlState(ControlState.Selected);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            NavigationStyle style = viewStyle as NavigationStyle;
            if (style != null)
            {
                ItemGap = style.ItemGap;
                Padding.CopyFrom(style.Padding);
                DividerLineColor = style.DividerLineColor;
                IsFitWithItems = style.IsFitWithItems;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            UpdateItem();
        }

        /// <summary>
        /// Dispose Navigation and all children on it.
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
                if (dividerLineList != null)
                {
                    for (int i = 0; i < dividerLineList.Count; i++)
                    {
                        Utility.Dispose(dividerLineList[i]);
                    }
                    dividerLineList.Clear();
                    dividerLineList = null;
                }
                if (itemList != null)
                {
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        Utility.Dispose(itemList[i]);
                    }
                    itemList.Clear();
                    itemList = null;
                }
                Utility.Dispose(rootView);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Get Navigation attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new NavigationStyle();
        }

        private void Initialize()
        {
            rootView = new View();
            rootView.Name = "RootView";
            Add(rootView);
        }

        private void AddItemByIndex(NavigationDataItem itemData, int index)
        {
            NavigationDataItem item = itemData;
            item.TouchEvent += OnItemTouchEvent;
            rootView.Add(item);
            if (itemData.Size != null)
            {
                item.Size = itemData.Size;
            }
            if (index >= itemList.Count)
            {
                itemList.Add(item);
            }
            else
            {
                itemList.Insert(index, item);
            }

            AddDividerLine();

            UpdateItem();
            if (curIndex != -1)
            {
                itemList[curIndex].SetControlState(ControlState.Selected);
            }
        }

        private void AddDividerLine()
        {
            View dividerLine = new View()
            {
                BackgroundColor = DividerLineColor,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                Position = new Position(0, 0)
            };
            dividerLine.Name = "DividerLine " + dividerLineList.Count;
            rootView.Add(dividerLine);
            dividerLineList.Add(dividerLine);
        }

        private void UpdateItem()
        {
            int totalNum = itemList.Count;
            if (totalNum == 0)
            {
                return;
            }
            int leftSpace = Padding.Start;
            int rightSpace = Padding.End;
            int topSpace = Padding.Top;
            int bottomSpace = Padding.Bottom;

            int preX = leftSpace;
            int preY = topSpace;
            int parentW = (int)itemList[0].Size.Width + leftSpace + rightSpace;
            int parentH = topSpace + bottomSpace;
            int itemGap = ItemGap;
            for (int i = 0; i < totalNum; i++)
            {
                itemList[i].Index = i;
                itemList[i].Name = "Item" + i;
                itemList[i].Position = new Position(preX, preY);
                dividerLineList[i].Size = new Size(itemList[i].Size.Width, itemGap);
                dividerLineList[i].Position = new Position(preX, preY + itemList[i].Size.Height);
                parentH += (int)itemList[i].Size.Height;
                preY += (int)itemList[i].Size.Height + itemGap;

                dividerLineList[i].BackgroundColor = DividerLineColor;
                dividerLineList[i].Show();
            }
            dividerLineList[totalNum - 1].Hide();

            if (rootView.Size.EqualTo(new Size(parentW, parentH)) == false)
            {
                rootView.Size = new Size(parentW, parentH);
            }

            if (IsFitWithItems)
            {
                if (Size.EqualTo(new Size(parentW, parentH)) == false)
                {
                    Size = new Size(parentW, parentH);
                }
            }
            else
            {
                rootView.PositionY = (Size.Height - rootView.Size.Height) / 2;
            }
        }

        private void UpdateSelectedItem(NavigationDataItem item)
        {
            if (item == null || curIndex == item.Index)
            {
                return;
            }

            ItemChangeEventArgs e = new ItemChangeEventArgs
            {
                PreviousIndex = curIndex,
                CurrentIndex = item.Index
            };
            ItemChangedEvent?.Invoke(this, e);

            if (curIndex != -1)
            {
                itemList[curIndex].SetControlState(ControlState.Normal);
            }
            curIndex = item.Index;
            itemList[curIndex].SetControlState(ControlState.Selected);
        }

        private bool OnItemTouchEvent(object source, TouchEventArgs e)
        {
            NavigationDataItem item = source as NavigationDataItem;
            if (item == null)
            {
                return false;
            }

            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                navigationLastY = e.Touch.GetScreenPosition(0).Y;
            }
            else if (state == PointStateType.Motion)
            {
                float current = e.Touch.GetScreenPosition(0).Y;

                int distance = (int)(current - navigationLastY);
                for(int i = 0; i < navigationGroup.NavigationList.Count; i++)
                {
                    navigationGroup.NavigationList[i].Position2D.Y += distance;
                }

                navigationLastY = current;
            }
            else if (state == PointStateType.Up)
            {
                UpdateSelectedItem(item);
            }

            itemTouchHander?.Invoke(this, e);

            return true;
        }   

        /// <summary>
        /// NavigationItemData is a class to record all data which will be applied to Navigation item.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public class NavigationDataItem : Button
        {
            /// <summary>
            /// Creates a new instance of a NavigationItemData.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public NavigationDataItem() : base()
            {
            }

            /// <summary>
            /// Creates a new instance of a NavigationItemData with style.
            /// </summary>
            /// <param name="style">Create NavigationItemData by special style defined in UX.</param>
            /// <since_tizen> 5.5 </since_tizen>
            public NavigationDataItem(string style) : base(style)
            {
            }

            /// <summary>
            /// Creates a new instance of a NavigationItemData with attributes.
            /// </summary>
            /// <param name="attributes">Create NavigationItemData by attributes customized by user.</param>
            /// <since_tizen> 5.5 </since_tizen>
            public NavigationDataItem(NavigationItemStyle attributes) : base(attributes)
            {
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public new NavigationItemStyle Style
            {
                get
                {
                    return new NavigationItemStyle(ViewStyle as NavigationItemStyle);
                }
            }

            /// <summary>
            /// Set button state.
            /// </summary>
            /// <since_tizen> 8.0 </since_tizen>
            public void SetControlState(ControlState state)
            {
                ControlState = state;
            }

            /// <summary>
            /// Sub-text Label.
            /// </summary>
            /// <since_tizen> 8.0 </since_tizen>
            public TextLabel SubText
            {
                get;
                set;
            }

            /// <summary>
            /// Divider line.
            /// </summary>
            /// <since_tizen> 8.0 </since_tizen>
            public View DividerLine
            {
                get;
                set;
            }

            /// <summary>
            /// Padding in Navigation Item.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public new Extents Padding
            {
                get;
                set;
            } = new Extents(0, 0, 0, 0);

            /// <summary>
            /// Flag to decide icon is in center or not in Navigation item view.
            /// If true, icon image will in the center of NavigationItem, if false, it will be decided by TopSpace.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public bool EnableIconCenter
            {
                get;
                set;
            } = false;

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override void ApplyStyle(ViewStyle viewStyle)
            {
                base.ApplyStyle(viewStyle);

                NavigationItemStyle itemStyle = viewStyle as NavigationItemStyle;
                if (SubText == null)
                {
                    SubText = new TextLabel()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Add(SubText);
                }
                SubText.ApplyStyle(itemStyle.SubText);

                if (DividerLine == null)
                {
                    DividerLine = new View()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                    };
                    Add(DividerLine);
                }
                DividerLine.ApplyStyle(itemStyle.DividerLine);

                Padding.CopyFrom(itemStyle.Padding);
                EnableIconCenter = itemStyle.EnableIconCenter;
            }

            internal int Index
            {
                get;
                set;
            }

            /// <summary>
            /// Get attributes.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override ViewStyle GetViewStyle()
            {
                return new NavigationItemStyle();
            }

            /// <summary>
            /// Layout children.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void LayoutChild()
            {
                // important! avoid layout child again.
            }

            /// <summary>
            /// Measure text.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void MeasureText()
            {
                // important! avoid measuring text again.
            }

            /// <summary>
            /// Dispose.
            /// </summary>
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
                    Utility.Dispose(SubText);
                    Utility.Dispose(DividerLine);
                }

                base.Dispose(type);
            }

            protected override void OnUpdate()
            {
                int leftSpace = Padding.Start;
                int rightSpace = Padding.End;
                int topSpace = Padding.Top;
                int bottomSpace = Padding.Bottom;

                Icon.PositionUsesPivotPoint = true;
                if (EnableIconCenter)
                {
                    Icon.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
                    Icon.PivotPoint = Tizen.NUI.PivotPoint.Center;
                }
                else
                {
                    Icon.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                    Icon.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;

                    int w = (int)Size.Width;
                    int h = (int)Size.Height;
                    int iconX = (int)((w - Icon.Size?.Width ?? 0) / 2);
                    int iconY = topSpace;
                    Icon.Position = new Position(iconX, iconY);

                    int textPosX = leftSpace;
                    int textPosY = (int)(iconY + Icon.Size?.Height ?? 0);
                    if (Text != null)
                    {
                        TextLabel.Position = new Position(textPosX, textPosY);
                        if (TextLabel.Size != null)
                        {
                            textPosY += (int)TextLabel.Size.Height;
                        }
                    }
                    if (SubText != null)
                    {
                        SubText.Position = new Position(textPosX, textPosY);
                    }
                }
            }
        }

        /// <summary>
        /// ItemChangeEventArgs is a class to record item change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> previous selected index of Navigation </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public int PreviousIndex;

            /// <summary> current selected index of Navigation </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public int CurrentIndex;
        }
    }
}
