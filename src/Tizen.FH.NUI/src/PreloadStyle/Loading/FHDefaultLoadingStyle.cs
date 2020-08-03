using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Components
{
    internal class DefaultLoadingStyle : StyleBase
    {
        protected override ViewStyle GetViewStyle()
        {
            if (Content != null)
            {
                ViewStyle contentStyle = (ViewStyle)global::System.Activator.CreateInstance(Content.GetType());
                contentStyle.CopyFrom(Content as ViewStyle);
                return contentStyle;
            }
            string[] images = new string[36];
            for (int i = 0; i < 36; i++)
            {
                if (i < 10)
                {
                    images[i] = CommonResource.Instance.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_0" + i + ".png";
                }
                else
                {
                    images[i] = CommonResource.Instance.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_" + i + ".png";
                }
            }
            LoadingStyle style = new LoadingStyle { Images = images };
            return style;
        }
    }
}
