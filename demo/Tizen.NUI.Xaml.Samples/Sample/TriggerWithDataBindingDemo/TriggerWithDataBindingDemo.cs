using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TriggerWithDataBindingDemo : NUIApplication
    {
        private View rootView;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            rootView = new TriggerWithDataBindingDemoPage();

            window.Add(rootView);
        }
    }
}
