﻿using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class FoodTabStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            TabStyle style = new TabStyle
            {
                ItemPadding = new Extents(56, 56, 1, 0),
                UnderLine = new ViewStyle
                {
                    Size = new Size(1, 3),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new ColorSelector { All = Utility.Hex2Color(Constants.AppColorFood, 1) },
                },
                Text = new TextLabelStyle
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector
                    {
                        Normal = Color.Black,
                        Selected = Utility.Hex2Color(Constants.AppColorFood, 1),
                    },
                },
            };
            return style;
        }
    }
}
