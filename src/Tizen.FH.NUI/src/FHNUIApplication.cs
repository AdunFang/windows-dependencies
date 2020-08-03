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
using System.Reflection;
using Tizen.NUI;
using Tizen.FH.NUI.Components;
using StyleManager = Tizen.NUI.Components.StyleManager;

namespace Tizen.FH.NUI
{
    /// <summary>
    /// The base class of tv nui application. Your ui application code should inherit this class.
    /// </summary>
    /// <code>
    /// class MyUIApp : TVUIApplication
    /// {
    ///     static void Main(string[] args)
    ///     {
    ///         MyUIApp uiApp = new MyUIApp();
    ///         uiApp.Run(args);
    ///     }
    /// }
    /// </code>
    public class FHNUIApplication : NUIApplication
    {
        /// <summary>
        /// Constructor to instantiate the TVUIApplication class.
        /// <param name="windowMode">window mode for deciding whether application window is opaque or transparent.</param>
        /// </summary>
        public FHNUIApplication(WindowMode windowMode = WindowMode.Opaque) : base("", windowMode)
        {
        }

        /// <summary>
        /// Constructor to instantiate the TVUIApplication class.
        /// <param name="styleSheet">The stylesheet url</param>
        /// <param name="windowMode">window mode for deciding whether application window is opaque or transparent.</param>
        /// </summary>
        public FHNUIApplication(string styleSheet, WindowMode windowMode = WindowMode.Opaque) : base(styleSheet, windowMode)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        protected override void OnPreCreate()
        {
            base.OnPreCreate();
            Initialize();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is terminated.
        /// If base.OnTerminate() is not called, the event 'Terminated' will not be emitted.
        /// </summary>
        protected override void OnTerminate()
        {
            CleanUp();
            base.OnTerminate();
        }

        /// <summary>
        /// Runs the TVUIApplication.
        /// </summary>
        /// <version> 5.5.0 </version>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);
        }

        private void Initialize()
        {
            InitializeComponent();
        }

        private void CleanUp()
        {
            
        }

        private void InitializeComponent()
        {
            StyleManager.Instance.Theme = "Utility";
            RegisterAssembly(typeof(FHNUIApplication).GetTypeInfo().Assembly);

            StyleManager.Instance.RegisterStyle("BasicButton", "Family", typeof(FamilyBasicButtonStyle));
            StyleManager.Instance.RegisterStyle("BasicButton", "Utility", typeof(UtilityBasicButtonStyle), true);
            StyleManager.Instance.RegisterStyle("BasicButton", "Food", typeof(FoodBasicButtonStyle));
            StyleManager.Instance.RegisterStyle("BasicButton", "Kitchen", typeof(KitchenBasicButtonStyle));

            StyleManager.Instance.RegisterStyle("ServiceButton", "Family", typeof(FamilyServiceButtonStyle));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Utility", typeof(UtilityServiceButtonStyle), true);
            StyleManager.Instance.RegisterStyle("ServiceButton", "Food", typeof(FoodServiceButtonStyle));
            StyleManager.Instance.RegisterStyle("ServiceButton", "Kitchen", typeof(KitchenServiceButtonStyle));

            StyleManager.Instance.RegisterStyle("ToggleButton", "Family", typeof(FamilyToggleButtonStyle));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Utility", typeof(UtilityToggleButtonStyle), true);
            StyleManager.Instance.RegisterStyle("ToggleButton", "Food", typeof(FoodToggleButtonStyle));
            StyleManager.Instance.RegisterStyle("ToggleButton", "Kitchen", typeof(KitchenToggleButtonStyle));

            StyleManager.Instance.RegisterStyle("OvalButton", "Family", typeof(FamilyOvalButtonStyle));
            StyleManager.Instance.RegisterStyle("OvalButton", "Utility", typeof(UtilityOvalButtonStyle), true);
            StyleManager.Instance.RegisterStyle("OvalButton", "Food", typeof(FoodOvalButtonStyle));
            StyleManager.Instance.RegisterStyle("OvalButton", "Kitchen", typeof(KitchenOvalButtonStyle));

            StyleManager.Instance.RegisterStyle("DefaultPagination", null, typeof(DefaultPaginationStyle));

            StyleManager.Instance.RegisterStyle("CheckBox", "Utility", typeof(UtilityCheckBoxStyle), true);
            StyleManager.Instance.RegisterStyle("CheckBox", "Food", typeof(FoodCheckBoxStyle));
            StyleManager.Instance.RegisterStyle("CheckBox", "Family", typeof(FamilyCheckBoxStyle));
            StyleManager.Instance.RegisterStyle("CheckBox", "Kitchen", typeof(KitchenCheckBoxStyle));

            StyleManager.Instance.RegisterStyle("RadioButton", "Utility", typeof(UtilityRadioButtonStyle), true);
            StyleManager.Instance.RegisterStyle("RadioButton", "Food", typeof(FoodRadioButtonStyle));
            StyleManager.Instance.RegisterStyle("RadioButton", "Family", typeof(FamilyRadioButtonStyle));
            StyleManager.Instance.RegisterStyle("RadioButton", "Kitchen", typeof(KitchenRadioButtonStyle));

            StyleManager.Instance.RegisterStyle("Switch", "Utility", typeof(UtilitySwitchStyle), true);
            StyleManager.Instance.RegisterStyle("Switch", "Food", typeof(FoodSwitchStyle));
            StyleManager.Instance.RegisterStyle("Switch", "Family", typeof(FamilySwitchStyle));
            StyleManager.Instance.RegisterStyle("Switch", "Kitchen", typeof(KitchenSwitchStyle));
            StyleManager.Instance.RegisterStyle("ListIndexSwitch", null, typeof(ListIndexSwitchStyle));

            StyleManager.Instance.RegisterStyle("DAScrollbar", null, typeof(DAScrollBarStyle));

            StyleManager.Instance.RegisterStyle("Progressbar","Family", typeof(FamilyProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar","Food", typeof(FoodProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar","Kitchen", typeof(KitchenProgressbarStyle));
            StyleManager.Instance.RegisterStyle("Progressbar", "Utility", typeof(UtilityProgressbarStyle));

            StyleManager.Instance.RegisterStyle("Popup", "Family", typeof(FamilyPopupStyle));
            StyleManager.Instance.RegisterStyle("Popup", "Utility", typeof(UtilityPopupStyle), true);
            StyleManager.Instance.RegisterStyle("Popup", "Food", typeof(FoodPopupStyle));
            StyleManager.Instance.RegisterStyle("Popup", "Kitchen", typeof(KitchenPopupStyle));

            StyleManager.Instance.RegisterStyle("Tab", "Family", typeof(FamilyTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Utility", typeof(UtilityTabStyle), true);
            StyleManager.Instance.RegisterStyle("Tab", "Food", typeof(FoodTabStyle));
            StyleManager.Instance.RegisterStyle("Tab", "Kitchen", typeof(KitchenTabStyle));

            StyleManager.Instance.RegisterStyle("HeaderDropDown", null, typeof(HeaderSpinnerDropDownStyle));
            StyleManager.Instance.RegisterStyle("ListDropDown", null, typeof(ListSpinnerDropDownStyle));
            StyleManager.Instance.RegisterStyle("TextListItem", null, typeof(TextListItemStyle));
            StyleManager.Instance.RegisterStyle("IconListItem", null, typeof(IconListItemStyle));

            StyleManager.Instance.RegisterStyle("Back", null, typeof(BackNavigationStyle));
            StyleManager.Instance.RegisterStyle("WhiteCondition", null, typeof(WhiteConditionNavigationStyle));
            StyleManager.Instance.RegisterStyle("BlackCondition", null, typeof(BlackConditionNavigationStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditMode", null, typeof(WhiteEditModeNavigationStyle));
            StyleManager.Instance.RegisterStyle("BlackEditMode", null, typeof(BlackEditModeNavigationStyle));

            StyleManager.Instance.RegisterStyle("WhiteBackItem", null, typeof(WhiteBackNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackBackItem", null, typeof(BlackBackNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteConditionItem", null, typeof(WhiteConditionNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackConditionItem", null, typeof(BlackConditionNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeItem", null, typeof(WhiteEditModeNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeFirstItem", null, typeof(WhiteEditModeFirstNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("WhiteEditModeLastItem", null, typeof(WhiteEditModeLastNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeItem", null, typeof(BlackEditModeNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeFirstItem", null, typeof(BlackEditModeFirstNavigationItemStyle));
            StyleManager.Instance.RegisterStyle("BlackEditModeLastItem", null, typeof(BlackEditModeLastNavigationItemStyle));

            StyleManager.Instance.RegisterStyle("DefaultSlider", "Utility", typeof(UtilityDefaultSliderStyle), true);
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Food", typeof(FoodDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Family", typeof(FamilyDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("DefaultSlider", "Kitchen", typeof(KitchenDefaultSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Utility", typeof(UtilityTextSliderStyle), true);
            StyleManager.Instance.RegisterStyle("TextSlider", "Food", typeof(FoodTextSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Family", typeof(FamilyTextSliderStyle));
            StyleManager.Instance.RegisterStyle("TextSlider", "Kitchen", typeof(KitchenTextSliderStyle));

            StyleManager.Instance.RegisterStyle("DefaultInputField", "Family", typeof(FamilyDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Family", typeof(FamilyStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Food", typeof(FoodDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Food", typeof(FoodStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Kitchen", typeof(KitchenDefaultInputFieldStyle));
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Kitchen", typeof(KitchenStyleBInputFieldStyle));
            StyleManager.Instance.RegisterStyle("DefaultInputField", "Utility", typeof(UtilityDefaultInputFieldStyle), true);
            StyleManager.Instance.RegisterStyle("StyleBInputField", "Utility", typeof(UtilityStyleBInputFieldStyle), true);
            StyleManager.Instance.RegisterStyle("DefaultSearchInputField", null, typeof(DefaultSearchInputFieldStyle));

            StyleManager.Instance.RegisterStyle("BasicShortToast", null, typeof(BasicShortToasStyle));
            StyleManager.Instance.RegisterStyle("BasicLongToast", null, typeof(BasicLongToastStyle));

            StyleManager.Instance.RegisterStyle("DefaultListItem", null, typeof(DefaultListItemStyle));
            StyleManager.Instance.RegisterStyle("MultiSubTextListItem", null, typeof(MultiSubTextListItemStyle));
            StyleManager.Instance.RegisterStyle("EffectListItem", null, typeof(EffectListItemStyle));
            StyleManager.Instance.RegisterStyle("ItemAlignListItem", null, typeof(ItemAlignListItemStyle));
            StyleManager.Instance.RegisterStyle("NextDepthListItem", null, typeof(NextDepthListItemStyle));
            StyleManager.Instance.RegisterStyle("GroupIndexListItem", null, typeof(GroupIndexListItemStyle));

            StyleManager.Instance.RegisterStyle("DefaultLoading", null, typeof(DefaultLoadingStyle));

            StyleManager.Instance.RegisterStyle("DAPicker", "Utility", typeof(UtilityDatePickerStyle), true);
            StyleManager.Instance.RegisterStyle("DAPicker", "Food", typeof(FoodDatePickerStyle));
            StyleManager.Instance.RegisterStyle("DAPicker", "Family", typeof(FamilyDatePickerStyle));
            StyleManager.Instance.RegisterStyle("DAPicker", "Kitchen", typeof(KitchenDatePickerStyle));

            StyleManager.Instance.RegisterStyle("DATimePicker", null, typeof(DATimePickerStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerAMPM", null, typeof(DATimePickerAMPMStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", "Utility", typeof(UtilityTimePickerRepeatStyle), true);
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", "Food", typeof(FoodTimePickerRepeatStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", "Family", typeof(FamilyTimePickerRepeatStyle));
            StyleManager.Instance.RegisterStyle("DATimePickerRepeat", "Kitchen", typeof(KitchenTimePickerRepeatStyle));

            StyleManager.Instance.RegisterStyle("DASpin", null, typeof(DASpinStyle));
            StyleManager.Instance.RegisterStyle("DAStrSpin", null, typeof(DAStrSpinStyle));
            StyleManager.Instance.RegisterStyle("DefaultHeader", null, typeof(DefaultHeaderStyle));
            StyleManager.Instance.RegisterStyle("OpaqueHeader", null, typeof(OpaqueHeaderStyle));
            StyleManager.Instance.RegisterStyle("TransparencyHeader", null, typeof(TransparencyHeaderStyle));
        }
    }
}
