﻿/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.FH.NUI.Components
{
    public class CommonResource
    {
        private CommonResource() { }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public static CommonResource Instance { get; } = new CommonResource();

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.        
        public string GetFHResourcePath()
        {
            return @"../../../demo/csharp-demo/res/images/FH3/";
        }
    }
}
