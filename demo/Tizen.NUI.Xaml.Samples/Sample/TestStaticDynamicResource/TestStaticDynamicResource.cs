using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TestStaticDynamicResource : NUIApplication
    {
        private View rootView;
        private Window window;

        protected override void OnCreate() 
        {
            window = Window.Instance;
            rootView = new TestStaticDynamicResourcePage();
            window.Add(rootView);
        }
    }
}
