
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class DAScrollBarStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            ScrollBarStyle style = new ScrollBarStyle
            {
                Track = new ImageViewStyle
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.6f),
                    }
                },
                Thumb = new ImageViewStyle
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.2f)
                    }
                },
            };
            return style;
        }
    }
}
