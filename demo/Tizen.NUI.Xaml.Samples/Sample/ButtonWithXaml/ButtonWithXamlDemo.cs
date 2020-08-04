﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.NUI.Examples
{
    public class ButtonWithXamlDemo : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Green;

            ButtonWithXamlPage myPage = new ButtonWithXamlPage();
            window.Add(myPage);
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }
    }
}
