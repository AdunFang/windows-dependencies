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
    /// The Spin is one kind of FH component, used for Time Picker.
    /// It can change time by TapGesture and PanGesture with animation.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    public class Spin : Control
    {
        private InputStyle type = InputStyle.IntStyle;        
        private View clipView = null;
        private View animationView = null;
        private View nameView = null;
        private TextLabel[] itemLabel = null;
        private TextField textField = null;
        private View dividerLine = null;
        private View dividerLine2 = null;
        private ImageView maskTopImage = null;
        private ImageView maskBottomImage = null;        
        private Animation spinAnimation = null;        
        private Timer finishedTimer = null;
        private PanGestureDetector panGestureDetector = null;
        private TapGestureDetector tapGestureDetector = null;
        
        private int upItemIndex = 0;
        private int midItemIndex = 1;
        private int downItemIndex = 2;
        private const int ItemCount = 3;
        private int minValue = 0;
        private int maxValue = 0;
        private int itemHeight = 0;
        private float floatItemHeight = 0f;
        private float floatItemHalfHeight = 0f;
        private int upDownItemTextSize = 0;
        private int midItemTextSize = 0;        
        private int tapAnimationDuration = 200;

        //Gesture variable
        private Direction moveDirection = Direction.None;      
        private int midItemPositionY = 0;
        private float aniViewPositionY = 0f; 
        private float calculateAdjustLen = 0f;
        private float maxMoveDownHeight = 0f;
        private float maxMoveUpHeight = 0f;
        private float curMoveHeight = 0f;
        private float lastMoveHeight = 0f; 
        private FinishAnimationType finishAniType = FinishAnimationType.Tap;
        private FinishAniAction finishAniAction = FinishAniAction.None;
        private PanAnimationState panAnimationState = PanAnimationState.None;
        private uint finishTimerLoopCount = 0;        
        private int finishTimerFirstInterval = 0;
        private int finishTimerIncreaseInterval = 0;
        private bool isTouchRelease = true;
        private bool isWaitInput = false;        

        /// <summary>
        /// Creates a new instance of a Spin.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public Spin() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Spin with style.
        /// </summary>
        /// <param name="style">Create Spin by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        public Spin(string style) : base(style)
        {
            if (style.Contains("str") || style.Contains("Str"))
            {
                type = InputStyle.StringStyle;
            }
            
            Initialize();
        }

        /// <summary>
        /// Name text string in Spin.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        public TextLabel NameTextLabel { get; set; }

        /// <summary>
        /// Min selected value in Spin.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
               minValue = value;
               if (itemLabel != null)
               {
                   itemLabel[upItemIndex].Text = GetStrValue(CurrentValue - 1);
                   itemLabel[midItemIndex].Text = GetStrValue(CurrentValue);
                   itemLabel[downItemIndex].Text = GetStrValue(CurrentValue + 1);
               }
            }
        }

        /// <summary>
        /// Max selected value in Spin.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
               maxValue = value;
               
               if (itemLabel != null)
               {
                   itemLabel[upItemIndex].Text = GetStrValue(CurrentValue - 1);
                   itemLabel[midItemIndex].Text = GetStrValue(CurrentValue);
                   itemLabel[downItemIndex].Text = GetStrValue(CurrentValue + 1);
               }
            }
        }

        /// <summary>
        /// Current selected value in Spin.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        public int CurrentValue { get; set; } = 0;

        /// <summary>
        /// Dispose Spin and all children on it.
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
                Utility.Dispose(maskTopImage);
                Utility.Dispose(maskBottomImage);
                Utility.Dispose(dividerLine);
                Utility.Dispose(dividerLine2);
                if (panGestureDetector != null)
                {
                    panGestureDetector.Detach(clipView);
                    panGestureDetector.Detected -= OnClipViewPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }
                if (tapGestureDetector != null)
                {
                    tapGestureDetector.Detach(clipView);
                    tapGestureDetector.Detected -= OnClipViewTapGestureDetected;
                    tapGestureDetector.Dispose();
                    tapGestureDetector = null;
                }
                if (finishedTimer != null)
                {
                    finishedTimer.Tick -= OnFinishedTickEvent;
                    finishedTimer.Stop();
                    finishedTimer.Dispose();
                    finishedTimer = null;
                }
                if (spinAnimation != null)
                {
                    spinAnimation.Stop();
                    spinAnimation.Dispose();
                    spinAnimation = null;
                }
                if (itemLabel != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (itemLabel[i] != null)
                        {
                            Utility.Dispose(itemLabel[i]);
                        }
                    }
                }
                Utility.Dispose(animationView);
                if (textField != null)
                {
                    textField.FocusGained -= OnTextFieldFocusGained;
                    textField.FocusLost -= OnTextFieldFocusLost;
                    textField.TextChanged -= OnTextFieldTextChanged;
                    textField.KeyEvent -= OnTextFieldKeyEvent;
                    Utility.Dispose(textField);
                }
                Utility.Dispose(clipView);
                Utility.Dispose(NameTextLabel);
                Utility.Dispose(nameView);
            }
            
            base.Dispose(type);
        }

        /// <summary>
        /// Get Spin attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new SpinStyle();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            SpinStyle spinStyle = viewStyle as SpinStyle;

            if (clipView == null)
            {
                clipView = new View();
                clipView.ClippingMode = ClippingModeType.ClipToBoundingBox;//ClipChildren;
                clipView.TouchEvent += OnTouchEvent;
                Add(clipView);
            }
            clipView.ApplyStyle(spinStyle.ClipView);
            if (textField == null)
            {
                textField = new TextField()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed
                };
                textField.Focusable = true;
                textField.MaxLength = 2;
                textField.CursorWidth = 0;
                textField.EnableSelection = true;
                textField.EnableGrabHandlePopup = false;
                textField.EnableGrabHandle = false;
                textField.FocusGained += OnTextFieldFocusGained;
                textField.FocusLost += OnTextFieldFocusLost;
                textField.TextChanged += OnTextFieldTextChanged;
                textField.KeyEvent += OnTextFieldKeyEvent;
                clipView.Add(textField);
                textField.Hide();
            }
            textField.ApplyStyle(spinStyle.TextField);
            if (animationView == null)
            {
                animationView = new View();
                clipView.Add(animationView);
            }
            animationView.ApplyStyle(spinStyle.AnimationView);
            if (itemLabel == null)
            {
                itemLabel = new TextLabel[4];
            }
            for (int i = 0; i < 4; i++)
            {
                if (null == itemLabel[i])
                {
                    itemLabel[i] = new TextLabel();
                    animationView.Add(itemLabel[i]);
                }
                if (itemLabel[i] != null)
                {
                    itemLabel[i].ApplyStyle(spinStyle.ItemText);
                }
            }
            if (dividerLine == null)
            {
                dividerLine = new View();
                Add(dividerLine);
            }
            dividerLine.ApplyStyle(spinStyle.DividerLine);
            if (dividerLine2 == null)
            {
                dividerLine2 = new View();
                Add(dividerLine2);
            }
            dividerLine2.ApplyStyle(spinStyle.DividerLine2);
            if (maskTopImage == null)
            {
                maskTopImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(maskTopImage);
            }
            maskTopImage.ApplyStyle(spinStyle.MaskTopImage);
            if (maskBottomImage == null)
            {
                maskBottomImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(maskBottomImage);
            }
            maskBottomImage.ApplyStyle(spinStyle.MaskBottomImage);
            if (nameView == null)
            {
                nameView = new View();
                Add(nameView);
            }
            nameView.ApplyStyle(spinStyle.NameView);
            if (NameTextLabel == null)
            {
                NameTextLabel = new TextLabel();
                nameView.Add(NameTextLabel);
            }
            NameTextLabel.ApplyStyle(spinStyle.NameText);

            itemHeight = spinStyle.ItemHeight;
            upDownItemTextSize = spinStyle.TextSize;
            midItemTextSize = spinStyle.CenterTextSize;
        }

        /// <summary>
        /// Update Spin by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            floatItemHeight = itemHeight;
            floatItemHalfHeight = itemHeight / 2;
            midItemPositionY = itemHeight;
            
            if (itemLabel != null)
            {
                itemLabel[upItemIndex].Position = new Position(0, 0);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Position = new Position(0, itemHeight); 
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Position = new Position(0, itemHeight * 2); 
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;
                //itemLabel[downItemIndex + 1].Position = new Position(0, itemHeight * 3);
                itemLabel[upItemIndex].Text = GetStrValue(CurrentValue - 1);
                itemLabel[midItemIndex].Text = GetStrValue(CurrentValue);
                itemLabel[downItemIndex].Text = GetStrValue(CurrentValue + 1);
            }                    
        }

        private void Initialize()
        {
            LeaveRequired = true;

            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(clipView);
            panGestureDetector.Detected += OnClipViewPanGestureDetected;

            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Detected += OnClipViewTapGestureDetected;
            tapGestureDetector.Attach(clipView);

            spinAnimation = new Animation(100);
            spinAnimation.EndAction = Animation.EndActions.StopFinal;

            finishedTimer = new Timer(100);
            finishedTimer.Tick += OnFinishedTickEvent;
        }
        
        private void OnTextFieldFocusGained(object source, EventArgs e)
        {
            isWaitInput = true;
        }

        private void OnTextFieldFocusLost(object source, EventArgs e)
        {
            if (textField.Text?.Length != 0)
            {
                int value = CurrentValue;
                
                if (int.TryParse(textField.Text, out value))
                {
                    if (value > maxValue)
                    {
                        textField.Text = GetStrValue(maxValue);
                        CurrentValue = maxValue;
                    }
                    else
                    {
                        CurrentValue = value;
                    }
                }
                SwitchToAniView();
            }
            else
            {
                SwitchToAniView();
            }
            
            isWaitInput = false;
        }

        private void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            int textLength = 0;
            
            if (textField != null && textField.Text != null)
            {
                textLength = textField.Text.Length;
            }
            
            if (textLength != 0)
            {
                if (isWaitInput == false)
                {
                    return;
                }
                if (textLength == 2)
                {
                    int value = CurrentValue;
                    if (int.TryParse(textField.Text, out value))
                    {
                        if (value > maxValue)
                        {
                            textField.Text = GetStrValue(maxValue);
                            CurrentValue = maxValue;
                        }
                        else
                        {
                            CurrentValue = value;
                        }
                    }
                    SwitchToAniView();
                }
            }
        }

        private bool OnTextFieldKeyEvent(object source, KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    // when press "Return" key("Done" key in IME)
                    SwitchToAniView();
                    return true;
                }
            }
            return false;
        }
        
        private bool OnTouchEvent(object source, View.TouchEventArgs e)
        {
            View view = source as View;    
            PointStateType state = e.Touch.GetState(0);
            
            if (panAnimationState == PanAnimationState.FinishAni)
            {
                if (state == PointStateType.Down)
                {
                    finishedTimer.Stop();
                    ResetPositon();  
                    isTouchRelease = false;
                }
            }
            else
            {
                if (state == PointStateType.Down)
                {
                    isTouchRelease = true;
                }
            }
            
            return false;
        }

        private bool OnFinishedTickEvent(object source, Timer.TickEventArgs e)
        {
            if (finishTimerLoopCount == 0)
            {
                ResetPositon();
                return false;
            }
            else
            {
                finishTimerLoopCount--;
                
                switch (finishAniType)
                {
                    case FinishAnimationType.Tap:
                        {
                            if (moveDirection == Direction.Down)
                            {
                                AnimationWithTime(floatItemHalfHeight, tapAnimationDuration / 2);
                            }
                            else
                            {
                                AnimationWithTime(-floatItemHalfHeight, tapAnimationDuration / 2);
                            }
                            
                            AdjustLabelPosition();
                        }
                        break;
                    case FinishAnimationType.Pan:
                        {
                            if (finishTimerLoopCount == 0)
                            {
                                FinishAnimation(true);
                            }
                            else
                            {
                                FinishAnimation(false);
                            }
                        }
                        break;
                    default:
                        break;
                }
                
                return true;
            }    
        }

        private void OnClipViewTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (panAnimationState != PanAnimationState.None)
            {
                return;
            }
            
            if (!isTouchRelease)
            {
                return;
            }
            
            if (!finishedTimer.IsRunning())
            {
                float Y = e.TapGesture.LocalPoint?.Y??0.0f;
                
                if (Y < (dividerLine.Position.Y - clipView.Position.Y))
                {
                    if (CurrentValue == minValue)
                    {
                        return;
                    }
                    else
                    {
                        moveDirection = Direction.Down;
                        calculateAdjustLen = floatItemHalfHeight;
                        AnimationWithTime(floatItemHalfHeight, tapAnimationDuration / 2);

                        finishAniType = FinishAnimationType.Tap;
                        finishTimerLoopCount = 1;
                        finishedTimer.Interval = (uint)spinAnimation.Duration;
                        finishedTimer.Start();
                    }
                }
                else if (Y >= (dividerLine.Position.Y - clipView.Position.Y) 
                    && Y <= (dividerLine2.Position.Y - clipView.Position.Y))
                {
                    if (type != InputStyle.IntStyle)
                    {
                        return;
                    }
                    
                    SwitchToTextField();                    
                    FocusManager.Instance.SetCurrentFocusView(textField);
                    textField.SelectWholeText();
                }
                else
                {
                    if (CurrentValue == maxValue)
                    {
                        return;
                    }
                    else
                    {
                        moveDirection = Direction.Up;
                        calculateAdjustLen = -floatItemHalfHeight;
                        AnimationWithTime(-floatItemHalfHeight, tapAnimationDuration / 2);

                        finishAniType = FinishAnimationType.Tap;
                        finishTimerLoopCount = 1;
                        finishedTimer.Interval = (uint)spinAnimation.Duration;
                        finishedTimer.Start();
                    }
                }
            }            
        }    
        
        private void PanGestureInit()
        {    
            panAnimationState = PanAnimationState.None;
            moveDirection = Direction.None;
            calculateAdjustLen = 0;
            midItemPositionY = itemHeight; 
            aniViewPositionY = 0;
            curMoveHeight = 0;
            finishAniAction = FinishAniAction.None;
            finishTimerLoopCount = 0;
            
            //calculate the max movement
            maxMoveDownHeight = (CurrentValue - minValue) * itemHeight;
            maxMoveUpHeight = (CurrentValue - maxValue) * itemHeight;            
        }

        private void OnClipViewPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                if (finishedTimer.IsRunning())
                {
                    finishedTimer.Stop();
                    ResetPositon();
                }
                
                if (animationView.Position.Y != 0)
                {
                    ResetPositon();
                }
                
                PanGestureInit();
                
                if (e.PanGesture.Displacement.Y > 0)
                {
                    moveDirection = Direction.Down;
                    calculateAdjustLen = itemHeight / 2;
                }
                else
                {
                    moveDirection = Direction.Up;
                    calculateAdjustLen = -itemHeight / 2;
                }
                
                finishAniType = FinishAnimationType.Pan;
            }

            if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
            {
                float calculateMove = 0f;
                
                spinAnimation.Stop();
                curMoveHeight += e.PanGesture.Displacement.Y;
                panAnimationState = PanAnimationState.PanAni;

                if (e.PanGesture.Displacement.Y > 0)
                {
                    if (moveDirection == Direction.Up)
                    {
                        calculateAdjustLen += itemHeight;
                    }
                    
                    lastMoveHeight = e.PanGesture.Displacement.Y;
                    
                    if (curMoveHeight > maxMoveDownHeight)
                    {
                        calculateMove = maxMoveDownHeight - (curMoveHeight - e.PanGesture.Displacement.Y);
                        curMoveHeight = maxMoveDownHeight;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }

                    if(calculateMove != 0)
                    {
                        moveDirection = Direction.Down;
                    }
                    else
                    {
                        moveDirection = Direction.Down;
                        return;
                    }

                    while (calculateMove > floatItemHeight)// need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();                        
                        aniViewPositionY += floatItemHeight;
                        spinAnimation.AnimateTo(animationView, "Position", new Position(0, aniViewPositionY, 0));
                        AdjustLabelPosition();                        
                        calculateMove -= floatItemHeight;
                    }
                    
                    AnimationWithTime(calculateMove, 50);                    
                    calculateAdjustLen += calculateMove;                    
                }
                else if (e.PanGesture.Displacement.Y < 0)
                {
                    if (moveDirection == Direction.Down)
                    {
                        calculateAdjustLen -= itemHeight;
                    }
                    
                    lastMoveHeight = -e.PanGesture.Displacement.Y;
                    
                    if (curMoveHeight < maxMoveUpHeight)
                    {
                        calculateMove = maxMoveUpHeight - (curMoveHeight - e.PanGesture.Displacement.Y);
                        curMoveHeight = maxMoveUpHeight;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }
                                        
                    if(calculateMove != 0)
                    {
                        moveDirection = Direction.Up;
                    }
                    else
                    {
                        moveDirection = Direction.Up;
                        return;
                    }

                    while (calculateMove < -floatItemHeight) // need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();                        
                        aniViewPositionY -= floatItemHeight;
                        spinAnimation.AnimateTo(animationView, "Position", new Position(0, aniViewPositionY, 0));                        
                        AdjustLabelPosition();                   
                        calculateMove += floatItemHeight;
                    }
                    
                    AnimationWithTime(calculateMove, 50);
                    calculateAdjustLen += calculateMove;    
                }
                                
                if ((moveDirection == Direction.Down) && ((calculateAdjustLen >= floatItemHeight)))
                {
                    calculateAdjustLen -= itemHeight;
                    AdjustLabelPosition();
                }
                else if ((moveDirection == Direction.Up) && ((calculateAdjustLen <= -floatItemHeight)))
                {
                    calculateAdjustLen += itemHeight;
                    AdjustLabelPosition();
                }
            }

            if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                panAnimationState = PanAnimationState.FinishAni;
                
                if (lastMoveHeight < 2)
                {
                    finishAniAction = FinishAniAction.MoveToCenter;
                }
                else if (lastMoveHeight >= 2 && lastMoveHeight <= 3)
                {
                    finishAniAction = FinishAniAction.MoveToNext; 
                }
                else if (lastMoveHeight > 3 && lastMoveHeight <= 10)
                {
                    finishAniAction = FinishAniAction.MoveToNext5; 
                }
                else
                {
                    finishAniAction = FinishAniAction.MoveToNext20; 
                }

                if (finishAniAction == FinishAniAction.MoveToCenter)
                {
                    if (finishedTimer != null)
                    {
                        if (moveDirection == Direction.Down)
                        {
                            AnimationWithTime(floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(floatItemHalfHeight - calculateAdjustLen) / itemHeight); 
                            
                        }
                        else if (moveDirection == Direction.Up)
                        {
                            AnimationWithTime(-floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        }
                                                
                        finishedTimer.Interval = (uint)spinAnimation.Duration;
                        finishTimerLoopCount = 0;
                        finishedTimer.Start();
                    }
                }
                else if (finishAniAction == FinishAniAction.MoveToNext)
                {
                    finishTimerFirstInterval = 500;
                    finishTimerIncreaseInterval = 100;
                    StartFinishedAnimation(1);                        
                }
                else if (finishAniAction == FinishAniAction.MoveToNext5)
                {
                    finishTimerFirstInterval = 100;
                    finishTimerIncreaseInterval = 60;
                    StartFinishedAnimation(5);
                }
                else if (finishAniAction == FinishAniAction.MoveToNext20)
                {
                    finishTimerFirstInterval = 15;
                    finishTimerIncreaseInterval = 6;
                    StartFinishedAnimation(20);
                }                    
            }
        }

        private void FinishAnimation(bool isHalfItemHeight)
        {
            float moveHeight = 0;
            
            if (isHalfItemHeight)
            {
                moveHeight = floatItemHalfHeight;
            }
            else
            {
                moveHeight = floatItemHeight;
            }
            
            finishTimerFirstInterval += finishTimerIncreaseInterval;
            spinAnimation.Duration = finishTimerFirstInterval;
            finishedTimer.Interval = (uint)spinAnimation.Duration;

            if (moveDirection == Direction.Down)
            {
                if ((maxMoveDownHeight- curMoveHeight) < floatItemHeight)
                {
                    finishTimerLoopCount = 0;
                    moveHeight = floatItemHalfHeight;
                }
                
                curMoveHeight += moveHeight;

                if (curMoveHeight > maxMoveDownHeight)
                {
                    curMoveHeight = maxMoveDownHeight;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewPositionY += moveHeight;
                    spinAnimation.AnimateTo(animationView, "Position", new Position(0, aniViewPositionY, 0));
                    spinAnimation.Play();
                    AdjustLabelPosition();
                }
            }
            else if (moveDirection == Direction.Up)
            {
                if ((maxMoveUpHeight- curMoveHeight) > -floatItemHeight)
                {
                    finishTimerLoopCount = 0;
                    moveHeight = floatItemHalfHeight;
                }
                
                curMoveHeight -= moveHeight;

                if (curMoveHeight < maxMoveUpHeight)
                {
                    curMoveHeight = maxMoveUpHeight;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewPositionY -= moveHeight;
                    spinAnimation.AnimateTo(animationView, "Position", new Position(0, aniViewPositionY, 0));
                    spinAnimation.Play();                
                    AdjustLabelPosition();
                }
            }
        }
        
        private void AdjustLabelPosition()
        {
            if (moveDirection == Direction.Down)
            {
                midItemPositionY -= itemHeight;
                
                upItemIndex = (upItemIndex == 0) ? ItemCount : upItemIndex - 1;
                midItemIndex = (midItemIndex == 0) ? ItemCount : midItemIndex - 1;
                downItemIndex = (downItemIndex == 0) ? ItemCount : downItemIndex - 1;
                itemLabel[upItemIndex].Position = new Position(0, midItemPositionY - itemHeight);
                itemLabel[upItemIndex].Text = GetStrValue(CurrentValue - 2);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;

                CurrentValue -= 1;
            }
            else if (moveDirection == Direction.Up)
            {
                midItemPositionY += itemHeight;
                
                upItemIndex = (upItemIndex == 3) ? 0 : upItemIndex + 1;
                midItemIndex = (midItemIndex == 3) ? 0 : midItemIndex + 1;
                downItemIndex = (downItemIndex == 3) ? 0 : downItemIndex + 1;
                itemLabel[downItemIndex].Position = new Position(0, midItemPositionY + itemHeight);
                itemLabel[downItemIndex].Text = GetStrValue(CurrentValue + 2);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;

                CurrentValue += 1;
            }
        }

        private void ResetPositon()
        {
            spinAnimation.Stop();
            spinAnimation.Clear();
            panAnimationState = 0;
            calculateAdjustLen= 0;
            upItemIndex = 0;
            midItemIndex = 1;
            downItemIndex = 2;
            animationView.Position = new Position(0, 0);
            itemLabel[0].Position = new Position(0, 0);
            itemLabel[0].Text = GetStrValue(CurrentValue - 1);
            itemLabel[1].Position = new Position(0, itemHeight);
            itemLabel[1].Text = GetStrValue(CurrentValue);
            itemLabel[2].Position = new Position(0, itemHeight * 2);
            itemLabel[2].Text = GetStrValue(CurrentValue + 1);
            itemLabel[upItemIndex].Opacity = 0.4f;
            itemLabel[upItemIndex].PointSize = upDownItemTextSize;
            itemLabel[midItemIndex].Opacity = 1.0f;
            itemLabel[midItemIndex].PointSize = midItemTextSize;
            itemLabel[downItemIndex].Opacity = 0.4f;
            itemLabel[downItemIndex].PointSize = upDownItemTextSize;
            midItemPositionY = itemHeight;
            aniViewPositionY = 0;
        }
        
        private void AnimationWithTime(float move, int time)
        {
            spinAnimation.Stop();
            spinAnimation.Clear();
            aniViewPositionY += move;
            spinAnimation.Duration = time;
            spinAnimation.AnimateTo(animationView, "Position", new Position(0, aniViewPositionY, 0));
            spinAnimation.Play();
        }
        
        private void SwitchToTextField()
        {
            textField.Text = GetStrValue(CurrentValue);
            animationView.Hide();
            dividerLine.Hide();
            dividerLine2.Hide();
            panGestureDetector.Detach(clipView);
            tapGestureDetector.Detach(clipView);
            textField.Show();
        }

        private void SwitchToAniView()
        {
            textField.Hide();
            ResetPositon();
            panGestureDetector.Attach(clipView);
            tapGestureDetector.Attach(clipView);
            animationView.Show();
            dividerLine.Show();
            dividerLine2.Show();
        }

        private void StartFinishedAnimation(uint cnt)
        {
            if (calculateAdjustLen != floatItemHeight / 2 && calculateAdjustLen != -floatItemHeight / 2)
            {
                if (moveDirection == Direction.Down)
                {
                    curMoveHeight += (floatItemHeight - calculateAdjustLen);
                    
                    if (curMoveHeight > maxMoveDownHeight)
                    {
                        AnimationWithTime(floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = 0;
                    }
                    else
                    {
                        AnimationWithTime(floatItemHeight - calculateAdjustLen, 100 * GetAbs(floatItemHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = cnt;
                    }
                }
                else if (moveDirection == Direction.Up)
                {
                    curMoveHeight += (-floatItemHeight - calculateAdjustLen);
                    
                    if (curMoveHeight < maxMoveUpHeight)
                    {
                        AnimationWithTime(-floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = 0;
                    }
                    else
                    {
                        AnimationWithTime(-floatItemHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = cnt;
                    }
                }
                if (finishedTimer != null)
                {
                    finishedTimer.Interval = (uint)spinAnimation.Duration;
                    finishedTimer.Start();
                }
            }
            else
            {
                finishTimerLoopCount = cnt - 1;
                FinishAnimation(false);
                finishedTimer.Start();
            }
        }

        private int GetAbs(float data)
        {
            return data > 0 ? (int)data : (int)-data;
        }

        private string GetStrValue(int data)
        {
            if (data < minValue || data > maxValue)
            {
                return " ";
            }

            if (type == InputStyle.StringStyle)
            {
                switch (data)
                {
                    case 0:
                        return "AM";
                    case 1:
                        return "PM";
                    default:
                        return " ";
                }
            }
            else
            {
                return data.ToString("D2");
            }
        }

        private enum InputStyle
        {
            IntStyle = 1,
            StringStyle = 2
        }

        private enum FinishAnimationType
        {
            Tap = 1,
            Pan = 2
        }

        private enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2
        }

        private enum PanAnimationState
        {
            None = 0,
            PanAni = 1,
            FinishAni = 2
        }

        private enum FinishAniAction
        {
            None = 0,
            MoveToCenter = 1,
            MoveToNext = 2,
            MoveToNext5 = 3,
            MoveToNext20 = 4
        }
    }
}
