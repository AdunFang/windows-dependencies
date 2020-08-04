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
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public partial class AnimationWithXamlDemoPage : View
    {
        public AnimationWithXamlDemoPage()
        {
            InitializeComponent();

            Transition newAnimation = GetTransition("Type1");
            Transition orientationAnimation = GetTransition("Orientation");
            FocusManager.Instance.SetCurrentFocusView(Click);

            Click.Clicked += (obj, e) =>
            {
                if (newAnimation != null)
                {
                    Console.WriteLine("newAnimation.Duration: {0}", newAnimation.Duration);
                    newAnimation.AnimateTo(label, "DestOpacity");
                    newAnimation.AnimateTo(label, "DestPosition");
                    newAnimation.Play();
                }
                return true;
            };

            orientationCheck.Clicked += (obj, e) =>
            {
                if (orientationAnimation != null)
                {
                    Console.WriteLine("orientationAnimation.Duration: {0}", orientationAnimation.Duration);
                    orientationAnimation.AnimateTo(orientation, "DestOrientation");
                    orientationAnimation.Play();
                }
                return true;
            };
        }
    }
}