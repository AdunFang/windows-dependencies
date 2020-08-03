
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    internal class DAStrSpinStyle : FHSpinStyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            SpinStyle style = base.GetViewStyle() as SpinStyle;
            style.TextField.Size = new Size(200, 116);
            style.Position = new Position(0, 116);

            return style;
        }
    }
}
