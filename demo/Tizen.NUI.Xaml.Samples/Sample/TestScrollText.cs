using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TestScrollText : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Yellow;

            textLabel = new TextLabel("1231231231231231231132312122411232r1132313ad2fg13s2y6e5taw21fsd32fh4sf54h1321se324h1fgn1sfg321sdfh4sf3g21ad3f2h4sf3h4s");
            textLabel.AutoScrollStopMode = AutoScrollStopMode.Immediate;
            textLabel.Position = new Position(300, 100);
            textLabel.Size2D = new Size2D(200, 50);
            window.Add(textLabel);

            window.KeyEvent += Window_KeyEvent;
        }

        private TextLabel textLabel;

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                switch (e.Key.KeyCode)
                {
                    case '1':
                        textLabel.EnableAutoScroll = true;
                        break;

                    case '2':
                        textLabel.EnableAutoScroll = false;
                        break;
                }
            }
        }
    }
}
