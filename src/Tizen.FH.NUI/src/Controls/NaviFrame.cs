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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// The NaviFrame could manage head and content views
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class NaviFrame
    {
        private const int AnimationDurationTime = 300;
        private List<NaviItem> pushStack = new List<NaviItem>();
        private NaviItem currentItem;
        private NaviItem prevItem;
        private Animation fadeInOutAnimation;
        private bool popFlag;
        private float startPositionOfCurrentItem;
        private float endPositionOfCurrentItem;
        private float endPositionOfPrevItem;
        private Notifier itemNotifier;
        private View rootView;

        /// <summary>
        /// NaviItem is a wrapper for header and content views.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public class NaviItem
        {
            /// <summary>
            /// create a navi item.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public NaviItem(View header, View content)
            {
                Header = header;
                Content = content;
            }

            /// <summary>
            /// header view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public View Header { get; }

            /// <summary>
            /// content view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            public View Content { get; }

            /// <summary>
            /// header is enabled or not.
            /// </summary>
            /// <since_tizen> 6.0 </since_tizen>
            public bool HeaderEnabled
            {
                get
                {
                    return Header != null && Header.Visibility;
                }
            }
        }

        /// <summary>
        /// Notifier is to notify lifecycle of NaviItem.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public abstract class Notifier
        {
            /// <summary>
            /// Called after NaviItem is created.
            /// </summary>
            /// <param name="item">The view item would be created.</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void OnNaviItemCreated(NaviItem item) { }

            /// <summary>
            /// Called when NaviItem will be destroyed.
            /// </summary>
            /// <param name="item">The view item would be destroyed.</param>
            /// <since_tizen> 6 </since_tizen>
            public virtual void OnNaviItemDestroyed(NaviItem item) { }
        }

        /// <summary>
        /// Initializes a new instance of the NaviFrame class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public NaviFrame()
        {
            Initialize();
        }

        public NaviFrame(View rootView)
        {
            this.rootView = rootView;
            Initialize();
        }


        /// <summary>
        /// Dispose NaviFrame and all children on it.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public void Dispose()
        {
            if (fadeInOutAnimation != null)
            {
                if (fadeInOutAnimation.State == Animation.States.Playing)
                {
                    fadeInOutAnimation.Finished -= OnFadeInOutAnimationFinished;
                    fadeInOutAnimation.Stop();
                }
                fadeInOutAnimation.Dispose();
                fadeInOutAnimation = null;
            }

            for (int i = 0; i < pushStack.Count; i++)
            {
                DestroyNaviItem(pushStack[i]);
                pushStack[i] = null;
            }
            pushStack.Clear();
        }

        /// <summary>
        /// Set a notifier for NaviItem.
        /// </summary>
        /// <param name="notifier">lifecycle notifier of NaviItem</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetNotifier(Notifier notifier)
        {
            itemNotifier = notifier;
        }

        /// <summary>
        /// Item count in navi list.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int Count
        {
            get
            {
                return pushStack.Count;
            }
        }

        /// <summary>
        /// Create a nave naviframe item with given header and content
        /// </summary>
        /// <param name="header"> the header view of the naviframe item.</param>
        /// <param name="content"> the content view of the naviframe item.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public void NaviFrameItemPush(View header,View content)
        {
            StopFadeInOutAnimation();
            popFlag = false;

            NaviItem item = CreateNaviItem(header, content);
            pushStack.Add(item);
            prevItem = currentItem;
            currentItem = pushStack[pushStack.Count - 1];

            if (pushStack.Count == 1)
            {
                return;
            }

            ShowNaviItem(currentItem);
            PlayFadeInOutAnimation(false);
        }

        /// <summary>
        /// Pop the top item of the naviframe and also delete it
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public void NaviFrameItemPop()
        {
            StopFadeInOutAnimation();
            if (pushStack.Count <= 1)
                return;

            popFlag = true;
            prevItem = currentItem;
            currentItem = pushStack[pushStack.Count - 2];
            ShowNaviItem(currentItem);

            PlayFadeInOutAnimation(true);
            pushStack.RemoveAt(pushStack.Count - 1);
        }

        /// <summary>
        /// Create a nave naviframe item with given header and content
        /// </summary>
        /// <param name="itemIndex"> index of naviframe item, range of its value is from 0 to Count - 1.</param>
        /// <param name="enabled"> enable / disable title of naviframe item.</param>
        /// <param name="transition"> enable / disable transition of naviframe item.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public void EnableNaviFrameItemTitle(int itemIndex, bool enabled, bool transition)
        {
            if (itemIndex < 0 || itemIndex >= pushStack.Count)
            {
                return;
            }

            NaviItem item = pushStack[itemIndex];
            if (item.Header == null)
            {
                return;
            }

            if (enabled)
            {
                item.Header.Show();
                item.Content.Position.Y += item.Header.SizeHeight;
                item.Content.SizeHeight -= item.Header.SizeHeight;
            }
            else
            {
                item.Header.Hide();
                item.Content.Position.Y -= item.Header.SizeHeight;
                item.Content.SizeHeight += item.Header.SizeHeight;
            }
        }

        private void Initialize()
        {
            popFlag = false;
            fadeInOutAnimation = new Animation(AnimationDurationTime);
            fadeInOutAnimation.Finished += OnFadeInOutAnimationFinished;
        }

        private void OnFadeInOutAnimationFinished(object sender, EventArgs e)
        {
            if (popFlag)
            {
                DestroyNaviItem(prevItem);
                prevItem = null;
            }
            else
            {
                HideNaviItem(prevItem);
            }
        }

        private void StopFadeInOutAnimation()
        {
            if (fadeInOutAnimation != null)
            {
                if (fadeInOutAnimation.State == Animation.States.Playing)
                {
                    fadeInOutAnimation.Stop();
                }
                fadeInOutAnimation.Clear();
            }

            if (popFlag)
            {
                DestroyNaviItem(prevItem);
                prevItem = null;
            }
            else
            {
                HideNaviItem(prevItem);
            }

            SetNaviItemPositionX(currentItem, endPositionOfCurrentItem);
        }

        private void PlayFadeInOutAnimation(bool nextflag)
        {
            if (currentItem != null)
            {
                if (nextflag)
                {
                    startPositionOfCurrentItem = prevItem.Content.SizeWidth * (-1);
                    endPositionOfCurrentItem = 0;
                }
                else
                {
                    startPositionOfCurrentItem = prevItem.Content.SizeWidth;
                    endPositionOfCurrentItem = 0;
                }

                startPositionOfCurrentItem = startPositionOfCurrentItem / 2;

                SetNaviItemPositionX(currentItem, startPositionOfCurrentItem);
                currentItem.Content.Opacity = 1.0f;
                if (currentItem.Header != null)
                {
                    currentItem.Header.Opacity = 1.0f;
                }

                //flickAnimation.AnimateTo(currentItem.contentView, "Opacity", 1.0f);
                //flickAnimation.AnimateTo(currentItem.header, "Opacity", 1.0f);
                fadeInOutAnimation.AnimateTo(currentItem.Content, "PositionX", endPositionOfCurrentItem);
                if (currentItem.Header != null)
                {
                    fadeInOutAnimation.AnimateTo(currentItem.Header, "PositionX", endPositionOfCurrentItem);
                }
            }
           
            if (prevItem != null)
            {
                if (nextflag)
                {
                    endPositionOfPrevItem = prevItem.Content.SizeWidth;
                }
                else
                {
                    endPositionOfPrevItem = prevItem.Content.SizeWidth * (-1);
                }

                startPositionOfCurrentItem = 0;
                endPositionOfPrevItem = endPositionOfPrevItem / 2;

                ShowNaviItem(prevItem);

                prevItem.Content.Opacity = 1.0f;
                if (prevItem.Header != null)
                {
                    prevItem.Header.Opacity = 1.0f;
                }

                SetNaviItemPositionX(prevItem, 0);

                fadeInOutAnimation.AnimateTo(prevItem.Content, "Opacity", 0f);
                if (prevItem.Header != null)
                {
                    fadeInOutAnimation.AnimateTo(prevItem.Header, "Opacity", 0f);
                }
                fadeInOutAnimation.AnimateTo(prevItem.Content, "PositionX", endPositionOfPrevItem);
                if (prevItem.Header != null)
                {
                    fadeInOutAnimation.AnimateTo(prevItem.Header, "PositionX", endPositionOfPrevItem);
                }
            }

            fadeInOutAnimation.Play();
        }

        private NaviItem CreateNaviItem(View header, View content)
        {
            if (content == null)
                return null;

            NaviItem item = new NaviItem(header, content);
            if (rootView)
            {
                if (header != null)
                {
                    rootView.Add(header);
                }
                rootView.Add(content);
            }
            else
            {
                if (header != null)
                {
                    Window.Instance.GetDefaultLayer().Add(header);
                }
                Window.Instance.GetDefaultLayer().Add(content);
            }

            if (itemNotifier != null)
            {
                itemNotifier.OnNaviItemCreated(item);
            }

            return item;
        }

        private void DestroyNaviItem(NaviItem item)
        {
            if (item == null)
                return;

            item.Header?.Unparent();
            item.Content?.Unparent();

            if (itemNotifier != null)
            {
                itemNotifier.OnNaviItemDestroyed(item);
            }
        }

        private void SetNaviItemPositionX(NaviItem item, float x)
        {
            if (item == null)
                return;

            if (item.Header != null)
            {
                item.Header.PositionX = x;
            }
            item.Content.PositionX = x;
        }

        private void ShowNaviItem(NaviItem item)
        {
            if (item == null)
                return;

            if (item.Header != null)
            {
                item.Header.Show();
            }
            item.Content.Show();
        }

        private void HideNaviItem(NaviItem item)
        {
            if (item == null)
                return;

            if (item.Header != null)
            {
                item.Header.Hide();
            }
            item.Content.Hide();
        }
    }
}
