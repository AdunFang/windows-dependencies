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
using StyleManager = Tizen.NUI.Components.StyleManager;

namespace Tizen.FH.NUI.Components
{
    /// <summary>
    /// InputField is a editable input compoment with delete button or delete and add button.
    /// After pressing Return key, search button will show
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.    
    public class InputField : Control
    {
        private TextField textField = null;
        // the cancel button
        private ImageView cancelBtn = null;
        // the delete button
        private ImageView deleteBtn = null;
        // the add button background image
        private ImageView addBtnBg = null;
        // the add button overlay image
        private ImageView addBtnOverlay = null;
        // the add button foreground image
        private ImageView addBtnFg = null;
        // the search button
        private ImageView searchBtn = null;
        // Gets or sets space.     
        private int Space = 0;


        private InputStyle inputStyle = InputStyle.None;

        private ControlStates textFieldState = ControlStates.Normal;
        private TextState textState = TextState.Guide;
        private bool isDoneKeyPressed = false;

        private EventHandler<ButtonClickArgs> cancelBtnClickHandler;
        private EventHandler<ButtonClickArgs> deleteBtnClickHandler;
        private EventHandler<ButtonClickArgs> addBtnClickHandler;
        private EventHandler<ButtonClickArgs> searchBtnClickHandler;
        private EventHandler<KeyEventArgs> keyEventHandler;

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>      
        public InputField() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>         
        public InputField(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Click Event attached to Cancel Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>        
        public event EventHandler<ButtonClickArgs> CancelButtonClickEvent
        {
            add
            {
                cancelBtnClickHandler += value;
            }
            remove
            {
                cancelBtnClickHandler -= value;
            }
        }

        /// <summary>
        /// Click Event attached to Delete Button
        /// </summary>
        /// <since_tizen> 6 </since_tizen>              
        public event EventHandler<ButtonClickArgs> DeleteButtonClickEvent
        {
            add
            {
                deleteBtnClickHandler += value;
            }
            remove
            {
                deleteBtnClickHandler -= value;
            }
        }

        /// <summary>
        /// Click Event attached to Add Button
        /// </summary>
        /// <since_tizen> 6 </since_tizen>       
        public event EventHandler<ButtonClickArgs> AddButtonClickEvent
        {
            add
            {
                addBtnClickHandler += value;
            }
            remove
            {
                addBtnClickHandler -= value;
            }
        }

        /// <summary>
        /// Click Event attached to Search Button
        /// </summary>
        /// <since_tizen> 6 </since_tizen>   
        public event EventHandler<ButtonClickArgs> SearchButtonClickEvent
        {
            add
            {
                searchBtnClickHandler += value;
            }
            remove
            {
                searchBtnClickHandler -= value;
            }
        }

        /// <summary>
        /// The handler Event of Key
        /// </summary>
        /// <since_tizen> 6 </since_tizen>      
        public new event EventHandler<KeyEventArgs> KeyEvent
        {
            add
            {
                keyEventHandler += value;
            }
            remove
            {
                keyEventHandler -= value;
            }
        }

        /// <summary>
        /// The  state of Button Click
        /// </summary>
        /// <since_tizen> 6 </since_tizen>        
        public enum ButtonClickState
        {
            /// <summary> Press down </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.            
            PressDown,
            /// <summary> Bounce up </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.            
            BounceUp
        }

        private enum TextState
        {
            Guide,
            Input,
        }

        private enum InputStyle
        {
            None,
            Default,
            StyleB,
            SearchBar
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("Deprecated. Please set the properties of TextField directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new InputFieldStyle Style
        {
            get
            {
                return new InputFieldStyle(ViewStyle as InputFieldStyle);
            }
        }

        /// <summary>
        /// Set the status of the Input Field editable or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>  
        public bool StateEnabled
        {
            get
            {
                return Sensitive;
            }
            set
            {
                if (Sensitive == value)
                {
                    return;
                }
                UpdateComponentsByStateEnabledChanged(value);
                Sensitive = value;
            }
        }

        /// <summary>
        /// Space bwtwwen text field and right button 's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private int? SpaceBetweenTextFieldAndRightButton { get; set; }

        /// <summary>
        /// Space betwwen text field and left button's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private int? SpaceBetweenTextFieldAndLeftButton { get; set; }

        // <summary>
        /// Gets or sets the property for the TextField.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextField TextField
        {
            get
            {
                if(null== textField)
                {
                    textField = new TextField()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true,
                    };
                    textField.FocusGained += OnTextFieldFocusGained;
                    textField.FocusLost += OnTextFieldFocusLost;
                    textField.TextChanged += OnTextFieldTextChanged;
                    textField.KeyEvent += OnTextFieldKeyEvent;
                    this.Add(textField);
                }
               
                return textField;
            }
            set
            {
                textField = value;
            }
        }

        // <summary>
        /// Gets or sets the property for the cancelBtn.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]       
        public ImageView CancelButton
        {
            get
            {
                if (null == cancelBtn)
                {
                    cancelBtn = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        PositionUsesPivotPoint = true
                    };
                    this.Add(cancelBtn);
                    cancelBtn.TouchEvent += OnCancelBtnTouchEvent;
                }
                return cancelBtn;
            }
            set
            {
                cancelBtn = value;
            }
        }

        // <summary>
        /// Gets or sets the property for the deleteBtn.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView DeleteButton
        {
            get
            {
                if (null == deleteBtn)
                {
                    deleteBtn = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        PositionUsesPivotPoint = true
                    };
                    this.Add(deleteBtn);
                    deleteBtn.TouchEvent += OnDeleteBtnTouchEvent;
                }
                return deleteBtn;
            }
            set
            {
                deleteBtn = value;
            }
        }

        // <summary>
        /// Gets or sets the property for the searchBtn.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView SearchButton
        {
            get
            {              
                if (null == searchBtn)
                {
                    searchBtn = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true
                    };
                    this.Add(searchBtn);
                    searchBtn.TouchEvent += OnSearchBtnTouchEvent;
                }
                return searchBtn;
            }
            set
            {
                searchBtn = value;
            }
        }

        // <summary>
        /// Gets or sets the property for the addBtnBg.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView AddButtonBackground
        {
            get
            {
                if (null == addBtnBg)
                {
                    addBtnBg = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        PositionUsesPivotPoint = true
                    };
                    this.Add(addBtnBg);
                }
                return addBtnBg;
            }
            set
            {
                addBtnBg = value;
            }
        }


        // <summary>
        /// Gets or sets the property for the addBtnOverlay.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView AddButtonOverlay
        {
            get
            {
                if (null == addBtnOverlay)
                {
                    addBtnOverlay = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };
                    AddButtonBackground.Add(addBtnOverlay);
                }
                return addBtnOverlay;
            }
            set
            {
                addBtnOverlay = value;
            }
        }

        // <summary>
        /// Gets or sets the property for the addBtnFg.
        /// </summary>
        /// <since_tizen> 8.0 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView AddButtonForeground
        {
            get
            {
                if (null == addBtnFg)
                {
                    addBtnFg = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };
                    AddButtonOverlay.Add(addBtnFg);
                    addBtnFg.TouchEvent += OnAddBtnTouchEvent;
                }
                return addBtnFg;
            }
            set
            {
                addBtnFg = value;
            }
        }
               
      
        /// <summary>
        /// Gets or sets the property for the text content.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated. Please get text from TextField directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return textField?.Text;
            }
            set
            {
                if (null != textField) textField.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the property for the hint text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated. Please get PlaceholderText from TextField directly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HintText
        {
            get
            {
                return textField?.PlaceholderText;
            }
            set
            {
                if (null != textField) textField.PlaceholderText = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            InputFieldStyle inputFieldStyle = viewStyle as InputFieldStyle;
            if (null != inputFieldStyle.InputBox)
            {                
                TextField.ApplyStyle(inputFieldStyle.InputBox);
            }
            if (null != inputFieldStyle?.CancelButton)
            {
                CancelButton.ApplyStyle(inputFieldStyle.CancelButton);
            }
            if (null != inputFieldStyle.DeleteButton)
            {
                DeleteButton.ApplyStyle(inputFieldStyle.DeleteButton);
            }
            if (null != inputFieldStyle.SearchButton)
            {
                SearchButton.ApplyStyle(inputFieldStyle.SearchButton);
            }
            if (null != inputFieldStyle.AddButtonBackground)
            {
                AddButtonBackground.ApplyStyle(inputFieldStyle.AddButtonBackground);
            }
            if (null != inputFieldStyle.AddButtonOverlay)
            {
                AddButtonOverlay.ApplyStyle(inputFieldStyle.AddButtonOverlay);
            }
            if (null != inputFieldStyle.AddButtonForeground)
            {
                AddButtonForeground.ApplyStyle(inputFieldStyle.AddButtonForeground);
            }
            if(null != inputFieldStyle.SpaceBetweenTextFieldAndRightButton)
            {
                SpaceBetweenTextFieldAndRightButton = inputFieldStyle.SpaceBetweenTextFieldAndRightButton;
            }
            if (null != inputFieldStyle.SpaceBetweenTextFieldAndLeftButton)
            {
                SpaceBetweenTextFieldAndLeftButton = inputFieldStyle.SpaceBetweenTextFieldAndLeftButton;
            }          
            if (cancelBtn.ResourceUrl != "")
            {
                if (searchBtn.ResourceUrl == "")
                {
                    inputStyle = InputStyle.Default;
                }
                else
                {
                    inputStyle = InputStyle.SearchBar;
                }
            }
            else
            {
                if (deleteBtn.ResourceUrl != "" && addBtnBg.ResourceUrl != "" && addBtnOverlay.ResourceUrl != "" && addBtnFg.ResourceUrl != "")
                {
                    inputStyle = InputStyle.StyleB;
                }
            }
        }

        /// <summary>
        /// Dispose Input Field and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            if (type == DisposeTypes.Explicit)
            {
                if (cancelBtn != null)
                {
                    cancelBtn.TouchEvent -= OnCancelBtnTouchEvent;
                    Utility.Dispose(cancelBtn);
                }
                if (deleteBtn != null)
                {
                    deleteBtn.TouchEvent -= OnDeleteBtnTouchEvent;
                    Utility.Dispose(deleteBtn);
                }
                if (searchBtn != null)
                {
                    searchBtn.TouchEvent -= OnSearchBtnTouchEvent;
                    Utility.Dispose(searchBtn);
                }
                if (addBtnFg != null)
                {
                    addBtnFg.TouchEvent -= OnAddBtnTouchEvent;
                    Utility.Dispose(addBtnFg);
                }
                Utility.Dispose(addBtnOverlay);
                Utility.Dispose(addBtnBg);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Get Input Field attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>     
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new InputFieldStyle();
        }

        /// <summary>
        /// Update Input Field by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>  
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            //RelayoutTextField(false);
            base.OnUpdate();     
            RelayoutComponents();
            UpdateComponentsByStateEnabledChanged(Sensitive);
            OnLayoutDirectionChanged();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>      
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            InputFieldStyle inputFieldStyle = StyleManager.Instance.GetViewStyle(StyleName) as InputFieldStyle;
            if (inputFieldStyle != null)
            {
                ApplyStyle(inputFieldStyle);
                RelayoutRequest();
            }
        }

        /// <summary>
        ///  Text field focus gain callback when focus is getted, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnTextFieldFocusGained(object source, EventArgs e)
        {
            // when press on TextField, it will gain focus
            textFieldState = ControlStates.Selected;
            RelayoutComponents(false, true, true, false);
        }

        /// <summary>
        /// Text field lost gain  callback when focus is lost, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnTextFieldFocusLost(object source, EventArgs e)
        {
            textFieldState = ControlStates.Normal;
            RelayoutComponents(false, true, true, false);
        }

        /// <summary>
        /// Text field change callback when text  is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>     
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            if (sender is TextField)
            {
                TextField textField = sender as TextField;
                int textLen = textField.Text?.Length??0;
                if (textLen == 0)
                {
                    textState = TextState.Guide;
                }
                else
                {
                    textState = TextState.Input;
                }
                isDoneKeyPressed = false;
                RelayoutComponents(false, true, true, false);
            }
        }

        /// <summary>
        /// Text field key callback when "Return"  click down, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>        
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool OnTextFieldKeyEvent(object source, KeyEventArgs e)
        {
            keyEventHandler?.Invoke(this, e);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    // when press "Return" key("Done" key in IME), the searchBtn should show.
                    isDoneKeyPressed = true;
                    RelayoutComponents(false, false, true, false);
                    return true;
                }
            }
            return false;
        }

        private void Initialize()
        {            
            if (cancelBtn.ResourceUrl != "")
            {
                if (searchBtn.ResourceUrl == "")
                {
                    inputStyle = InputStyle.Default;
                }
                else
                {
                    inputStyle = InputStyle.SearchBar;
                }
            }
            else
            {
                if (deleteBtn.ResourceUrl != "" && addBtnBg.ResourceUrl != "" && addBtnOverlay.ResourceUrl != "" && addBtnFg.ResourceUrl != "")
                {
                    inputStyle = InputStyle.StyleB;
                }
            }
        }

        private void OnLayoutDirectionChanged()
        {
            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (cancelBtn)
                {                    
                    cancelBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    cancelBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    cancelBtn.PositionUsesPivotPoint = true;
                }
                if(addBtnBg)
                {                  
                    addBtnBg.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    addBtnBg.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    addBtnBg.PositionUsesPivotPoint = true;
                }
                if(searchBtn)
                {                   
                    searchBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    searchBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    searchBtn.PositionUsesPivotPoint = true;
                }
                if(deleteBtn)
                {                   
                    deleteBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    deleteBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    deleteBtn.PositionUsesPivotPoint = true;
                }
                if(textField)
                {
                    textField.HorizontalAlignment = HorizontalAlignment.Begin;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    textField.PositionUsesPivotPoint = true;
                }
            }
            else
            {
                if (cancelBtn)
                {                    
                    cancelBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    cancelBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    cancelBtn.PositionUsesPivotPoint = true;
                }
                if (addBtnBg)
                {                   
                    addBtnBg.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    addBtnBg.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    addBtnBg.PositionUsesPivotPoint = true;
                }
                if (searchBtn)
                {                   
                    searchBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    searchBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    searchBtn.PositionUsesPivotPoint = true;
                }
                if (deleteBtn)
                {                    
                    deleteBtn.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    deleteBtn.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    deleteBtn.PositionUsesPivotPoint = true;
                }
                if(textField)
                {
                    textField.HorizontalAlignment = HorizontalAlignment.End;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    textField.PositionUsesPivotPoint = true;
                }
            }
        }

        private void RelayoutComponents(bool shouldUpdate = true, bool enableRelayoutDefault = true,
            bool enableRelayoutSearchBar = true, bool enableRelayoutStyleB = true)
        {
            switch(inputStyle)
            {
                case InputStyle.Default:
                    if (enableRelayoutDefault)
                    {
                        RelayoutComponentsForDefault(shouldUpdate);
                    }
                    break;
                case InputStyle.SearchBar:
                    if (enableRelayoutSearchBar)
                    {
                        RelayoutComponentsForSearchBar(shouldUpdate);
                    }
                    break;
                case InputStyle.StyleB:
                    if (enableRelayoutStyleB)
                    {
                        RelayoutComponentsForStyleB(shouldUpdate);
                    }
                    break;
                default:
                    break;
            }
        }

        private void RelayoutComponentsForDefault(bool shouldUpdate)
        {
            if (null == cancelBtn || null == textField)
            {
                return;
            }
            // 2 type layouts:
            // #1 TextField                 normal state, text's length == 0;
            // #2 TextField + CancelBtn     except #1.
            int space = Space;
            if (textFieldState == ControlStates.Normal && textState == TextState.Guide)
            {
                //SetTextFieldSize2D((int)Size.Width - space * 2, (int)Size.Height);
                textField.Size = new Size((int)Size.Width - space * 2, (int)Size.Height);
                cancelBtn.Hide();
            }
            else
            {
                //SetTextFieldSize2D((int)(Size.Width - space * 2 - cancelBtn.Size.Width - SpaceBetweenTextFieldAndRightButton()), (int)Size.Height);
                textField.Size = new Size((int)(Size.Width - space * 2 - cancelBtn.Size.Width - SpaceBetweenTextFieldAndRightButton??0), (int)Size.Height);
                cancelBtn.Show();
            }
            if (shouldUpdate)
            {
                if(this.LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    //SetTextFieldPosX(-space);
                    textField.PositionX = -space;
                    cancelBtn.PositionX = space;
                }
                else
                {
                    //SetTextFieldPosX(space);
                    textField.PositionX = space;
                    cancelBtn.PositionX = -space;
                }
            }
        }

        private void RelayoutComponentsForSearchBar(bool shouldUpdate)
        {
            if (null == searchBtn || null == cancelBtn || null == textField)
            {
                return;
            }
            // 3 type layouts:
            // #1 SearchBtn + TextField                 normal state, text's length == 0;
            // #2 SearchBtn + TextField + CancelBtn     input state, text's length > 0, press "Done" key on IME;
            // #3 TextField + CancelBtn                 excepte #1 & #2.
            int space = Space;
            int textfieldX = 0;
            if (textFieldState == ControlStates.Normal && textState == TextState.Guide)
            {// #1
                int spaceBetweenTextFieldAndLeftButton = SpaceBetweenTextFieldAndLeftButton??0;
                //SetTextFieldSize2D((int)(Size.Width - space * 2 - searchBtn.Size.Width - spaceBetweenTextFieldAndLeftButton), (int)Size.Height);
                textField.Size = new Size((int)(Size.Width - space * 2 - searchBtn.Size.Width - spaceBetweenTextFieldAndLeftButton), (int)Size.Height);

                textfieldX = (int)(space + searchBtn.Size.Width + spaceBetweenTextFieldAndLeftButton);
                searchBtn.Show();
                cancelBtn.Hide();
            }
            else if (textFieldState == ControlStates.Selected && textState == TextState.Input && isDoneKeyPressed)
            {// #2
                int spaceBetweenTextFieldAndLeftButton = SpaceBetweenTextFieldAndLeftButton??0;
                int spaceBetweenTextFieldAndRightButton = SpaceBetweenTextFieldAndRightButton??0;
                //SetTextFieldSize2D((int)(Size.Width - space * 2 - searchBtn.Size.Width - spaceBetweenTextFieldAndLeftButton - cancelBtn.Size.Width - spaceBetweenTextFieldAndRightButton), (int)Size.Height);
                textField.Size = new Size((int)(Size.Width - space * 2 - searchBtn.Size.Width - spaceBetweenTextFieldAndLeftButton - cancelBtn.Size.Width - spaceBetweenTextFieldAndRightButton), (int)Size.Height);

                textfieldX = (int)(space + searchBtn.Size.Width + spaceBetweenTextFieldAndLeftButton);
                searchBtn.Show();
                cancelBtn.Show();
            }
            else
            {// #3
                int spaceBetweenTextFieldAndRighttButton = SpaceBetweenTextFieldAndRightButton??0;
                //SetTextFieldSize2D((int)(Size.Width - space * 2 - cancelBtn.Size.Width - spaceBetweenTextFieldAndRighttButton), (int)Size.Height);
                textField.Size = new Size((int)(Size.Width - space * 2 - cancelBtn.Size.Width - spaceBetweenTextFieldAndRighttButton), (int)Size.Height);

                textfieldX = space;
                searchBtn.Hide();
                cancelBtn.Show();
            }

            if (this.LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                if (shouldUpdate)
                {
                    searchBtn.PositionX = -space;
                    cancelBtn.PositionX = space;
                }
                //SetTextFieldPosX(-textfieldX);
                textField.PositionX = -textfieldX;
            }
            else
            {
                if (shouldUpdate)
                {
                    searchBtn.PositionX = space;
                    cancelBtn.PositionX = -space;
                }
                //SetTextFieldPosX(textfieldX);
                textField.PositionX = textfieldX;
            }
        }

        private void RelayoutComponentsForStyleB(bool shouldUpdate)
        {
            if (null == addBtnBg || null == deleteBtn || null == textField)
            {
                return;
            }
            if (!shouldUpdate)
            {
                return;
            }
            int space = Space;
            int spaceBetweenTextFieldAndRightButton = SpaceBetweenTextFieldAndRightButton??0;
            //SetTextFieldSize2D((int)(Size.Width - space - spaceBetweenTextFieldAndRightButton - deleteBtn.Size.Width - addBtnBg.Size.Width), (int)Size.Height);
            textField.Size = new Size((int)(Size.Width - space - spaceBetweenTextFieldAndRightButton - deleteBtn.Size.Width - addBtnBg.Size.Width), (int)Size.Height);

            if (this.LayoutDirection == ViewLayoutDirectionType.RTL)
            {
                //SetTextFieldPosX(-space);

                textField.PositionX = -space;
                addBtnBg.PositionX = 0;
                deleteBtn.PositionX = addBtnBg.Size.Width;
            }
            else
            {
                //SetTextFieldPosX(space);
                textField.PositionX = space;
                addBtnBg.PositionX = 0;
                deleteBtn.PositionX = -addBtnBg.Size.Width;
            }
        }      
        private void UpdateComponentsByStateEnabledChanged(bool isEnabled)
        {
            if (isEnabled)
            {
                UpdateTextFieldTextColor(ControlStates.Selected);
                UpdateDeleteBtnState(ControlStates.Normal);
                UpdateAddBtnState(ControlStates.Normal);
            }
            else
            {
                UpdateTextFieldTextColor(ControlStates.Disabled);
                UpdateDeleteBtnState(ControlStates.Disabled);
                UpdateAddBtnState(ControlStates.Disabled);
            }
        }
        
        private void UpdateTextFieldTextColor(ControlStates state)
        {
            if (null != Style && null != Style.InputBox
                && null != Style.InputBox.TextColor && null != textField)
            {
                switch (state)
                {
                    case ControlStates.Disabled:
                    case ControlStates.DisabledSelected:
                        //SetTextFieldTextColor(Style.InputBoxAttributes.TextColor.Disabled);
                        textField.TextColor = Style.InputBox.TextColor.Disabled;
                        break;
                    case ControlStates.Normal:
                    case ControlStates.Selected:
                        //SetTextFieldTextColor(Style.InputBoxAttributes.TextColor.Normal);
                        textField.TextColor = Style.InputBox.TextColor.Normal;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateDeleteBtnState(ControlStates state)
        {
            if (deleteBtn != null && Style != null && Style.DeleteButton != null
                && Style.DeleteButton.ResourceUrl != null)
            {
                switch (state)
                {
                    case ControlStates.Disabled:
                    case ControlStates.DisabledSelected:
                        deleteBtn.ResourceUrl = Style.DeleteButton.ResourceUrl.Disabled;
                        break;
                    case ControlStates.Selected:
                        deleteBtn.ResourceUrl = Style.DeleteButton.ResourceUrl.Pressed;
                        break;
                    case ControlStates.Normal:
                        deleteBtn.ResourceUrl = Style.DeleteButton.ResourceUrl.Normal;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateAddBtnState(ControlStates state)
        {
            if (Style == null || addBtnBg == null || addBtnOverlay == null || addBtnFg == null)
            {
                return;
            }
            switch (state)
            {
                case ControlStates.Disabled:
                case ControlStates.DisabledSelected:
                    {
                        if (Style.AddButtonBackground != null
                            && Style.AddButtonBackground.ResourceUrl != null)
                        {
                            addBtnBg.ResourceUrl = Style.AddButtonBackground.ResourceUrl.Disabled;
                        }
                        if (Style.AddButtonOverlay != null
                            && Style.AddButtonOverlay.ResourceUrl != null)
                        {
                            addBtnOverlay.ResourceUrl = Style.AddButtonOverlay.ResourceUrl.Disabled;
                        }
                        if (Style.AddButtonForeground != null
                            && Style.AddButtonForeground.ResourceUrl != null)
                        {
                            addBtnFg.ResourceUrl = Style.AddButtonForeground.ResourceUrl.Disabled;
                        }
                    }
                    break;
                case ControlStates.Selected:
                    {
                        if (Style.AddButtonBackground != null
                            && Style.AddButtonBackground.ResourceUrl != null)
                        {
                            addBtnBg.ResourceUrl = Style.AddButtonBackground.ResourceUrl.Pressed;
                        }
                        if (Style.AddButtonOverlay != null
                            && Style.AddButtonOverlay.ResourceUrl != null)
                        {
                            addBtnOverlay.ResourceUrl = Style.AddButtonOverlay.ResourceUrl.Pressed;
                        }
                        if (Style.AddButtonForeground != null
                            && Style.AddButtonForeground.ResourceUrl != null)
                        {
                            addBtnFg.ResourceUrl = Style.AddButtonForeground.ResourceUrl.Pressed;
                        }
                    }
                    break;
                case ControlStates.Normal:
                    {
                        if (Style.AddButtonBackground != null
                            && Style.AddButtonBackground.ResourceUrl != null)
                        {
                            addBtnBg.ResourceUrl = Style.AddButtonBackground.ResourceUrl.Normal;
                        }
                        if (Style.AddButtonOverlay != null
                            && Style.AddButtonOverlay.ResourceUrl != null)
                        {
                            addBtnOverlay.ResourceUrl = Style.AddButtonOverlay.ResourceUrl.Normal;
                        }
                        if (Style.AddButtonForeground != null
                            && Style.AddButtonForeground.ResourceUrl != null)
                        {
                            addBtnFg.ResourceUrl = Style.AddButtonForeground.ResourceUrl.Normal;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private bool OnDeleteBtnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (deleteBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.PressDown;
                    deleteBtnClickHandler(this, args);
                }
                UpdateDeleteBtnState(ControlStates.Selected);
            }
            else if (state == PointStateType.Finished)
            {
                if (deleteBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    deleteBtnClickHandler(this, args);
                }
                UpdateDeleteBtnState(ControlStates.Normal);
            }
            return true;
        }

        private bool OnSearchBtnTouchEvent(object source, TouchEventArgs e)
        {
            if (textState == TextState.Guide)
            {
                return true;
            }
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (searchBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.PressDown;
                    searchBtnClickHandler(this, args);
                }
            }
            else if (state == PointStateType.Finished)
            {
                if (searchBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    searchBtnClickHandler(this, args);
                }
            }
            return true;
        }

        private bool OnAddBtnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (addBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.PressDown;
                    addBtnClickHandler(this, args);
                }
                UpdateAddBtnState(ControlStates.Selected);
            }
            else if (state == PointStateType.Finished)
            {
                if (addBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    addBtnClickHandler(this, args);
                }
                UpdateAddBtnState(ControlStates.Normal);
            }
            return true;
        }

        private bool OnCancelBtnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (cancelBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.PressDown;
                    cancelBtnClickHandler(this, args);
                }
            }
            else if (state == PointStateType.Finished)
            {
                if (cancelBtnClickHandler != null)
                {
                    ButtonClickArgs args = new ButtonClickArgs();
                    args.State = ButtonClickState.BounceUp;
                    cancelBtnClickHandler(this, args);
                }
            }
            return true;
        }

        public class ButtonClickArgs : EventArgs
        {
            public ButtonClickState State;
        }
    }
}
