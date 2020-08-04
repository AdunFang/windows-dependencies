using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class DataTriggerDemo : NUIApplication
    {
        private View rootView;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            rootView = new DataTriggerDemoPage();
            window.Add(rootView);
        }
    }
}
