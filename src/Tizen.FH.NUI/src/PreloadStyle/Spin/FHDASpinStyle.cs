
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.FH.NUI.Components
{
    internal class DASpinStyle : FHSpinStyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            SpinStyle style = base.GetViewStyle() as SpinStyle;
            style.TextField.Size = new Size(200, 152);
            style.TextField.Position = new Position(0, 100);

            return style;
        }
    }
}
