using GUILIB.Core;
using GUILIB.Styles.Buttons;
using GUILIB.Styles.Panels;
using GUILIB.Styles.Texts;
using GUILIB.Widgets;
using GUILIB.Widgets.Buttons;
using GUILIB.Widgets.Panels;
using GUILIB.Widgets.Texts;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;

namespace Examples
{
    class Program
    {
        static List<Widget> widgets = new List<Widget>() { };

        static void Main()
        {
            Window.Setup();
            Window.Run();

            // Panels
            widgets.Add(new PanelWidget(new Rectangle(0, 0, 256, 256), new PanelStyle()));

            // Text
            widgets.Add(new TextWidget(new Rectangle(0, 0, 256, 64), new TextStyle(), "Enter username:", true));
            widgets.Add(new TextEntryWidget(new Rectangle(0, 32, 128, 64), new TextEntryStyle(), true, 10));

            // Buttons                                                                                                                   
            widgets.Add(new ButtonWidget(new Rectangle(0, 128, 128, 64), new ButtonStyle(), new TextWidget(new Rectangle(0, 128, 128, 64), new TextStyle(), "Add", false)));
            widgets.Add(new ToggleButtonWidget(new Rectangle(0, 256, 128, 64), new ToggleButtonStyle(), new ButtonStyle(), new Vector2(1, 1)));

            while (!Window.Closed)
            {
                Window.Draw(widgets.ToArray(), Color.BLACK);
            }
        }
    }
}
