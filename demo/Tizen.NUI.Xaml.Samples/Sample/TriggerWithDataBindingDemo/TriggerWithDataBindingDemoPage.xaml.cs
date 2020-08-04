/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Examples
{
    public partial class TriggerWithDataBindingDemoPage : View
    {
        public TriggerWithDataBindingDemoPage()
        {
            InitializeComponent();

            FocusManager.Instance.SetCurrentFocusView(Click);

            bool flag = true;
            Click.Clicked += (obj, e) =>
            {
                if (true == flag)
                {
                    label.Text = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_detail.png";
                }
                else
                {
                    label.Text = "*DemoRes*/images/AmbientScreenUXControl/Cut/bixby_sendtophone.png";
                }

                flag = !flag;
                return true;
            };
        }
    }
}