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
using Tizen.NUI.BaseComponents;
using Tizen.NUI;

namespace Tizen.NUI.Examples
{
    public partial class TestStaticDynamicResourcePage : View
    {
        public TestStaticDynamicResourcePage()
        {
            InitializeComponent();

            Window.Instance.KeyEvent += (object sender, Window.KeyEventArgs e)=>
            {
                bool changePosition = false;

                if (e.Key.State == Key.StateType.Up)
                {
                    if (e.Key.KeyPressedName == "Up")
                    {
                        positionY -= 50;
                        if (positionY < 0)
                        {
                            positionY = 0;
                        }

                        changePosition = true;
                    }
                    else if (e.Key.KeyPressedName == "Down")
                    {
                        positionY += 50;
                        if (positionY > 1000)
                        {
                            positionY = 1000;
                        }

                        changePosition = true;
                    }
                    else if (e.Key.KeyPressedName == "Left")
                    {
                        positionX -= 50;
                        if (positionX < 0)
                        {
                            positionX = 0;
                        }

                        changePosition = true;
                    }
                    else if (e.Key.KeyPressedName == "Right")
                    {
                        positionX += 50;
                        if (positionX > 1200)
                        {
                            positionX = 1200;
                        }

                        changePosition = true;
                    }
                }

                if (true == changePosition)
                {
                    res1["positionKey"] = positionX.ToString() + "," + positionY.ToString();
                }
            };
        }

        int positionX = 200;
        int positionY = 200;
    }
}