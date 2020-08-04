using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class AnimationWithXamlDemo : NUIApplication
    {
        private View rootView;
        private Window window;

        protected override void OnCreate() 
        {
            base.OnCreate();

            window = Window.Instance;
            window.BackgroundColor = Color.White;

            rootView = new AnimationWithXamlDemoPage();
            window.Add(rootView);
        }
    }
}
