using System;
using System.Collections.Generic;
using GUILIB.Core;
using GUILIB.Widgets;
using GUILIB.Widgets.Buttons;
using GUILIB.Widgets.Other;
using GUILIB.Widgets.Text;
using Raylib_cs;

namespace Examples
{
    class Program
    {
        //NON-SCALED STUFF
        static ButtonWidget buttonWidget = new ButtonWidget(new Rectangle(64, 64, 64, 64), Color.RED, false, 0.25f, 1, "Maths", 15, true);
        static BackgroundWidget backgroundWidget = new BackgroundWidget(new Rectangle(32, 32, 256, 256), Color.BROWN, false);
        static TextWidget textWidget = new TextWidget(new Rectangle(512, 512, 512, 512), Color.RED, false, "Red", 15, true);
        static ToggleButtonWidget toggleButtonWidget = new ToggleButtonWidget(new Rectangle(512, 256, 75, 27), Color.GRAY, false);
        
        //SCALED ELEMENTS
        static BackgroundWidget backgroundWidget2 = new BackgroundWidget(new Rectangle(80, 0, 20, 100), Color.BROWN, true);
        static ButtonWidget buttonWidget2 = new ButtonWidget(new Rectangle(80, 40, 20, 20), Color.RED, true, 0.25f, 1, "Maths", 15, true);
        //static TextWidget textWidget = new TextWidget(new Rectangle(512, 512, 512, 512), Color.RED, false, "Red", 15, true);

        // Note: { BackgroundWidget, ButtonWidget } will look different than { ButtonWidget, BackgroundWidget}.
        //       Because it will draw the BackgroundWidget THEN the ButtonWidget. If you do the opposite you won't see the button.
        static List<Widget> Widget = new List<Widget>() { backgroundWidget, buttonWidget, textWidget, toggleButtonWidget, backgroundWidget2, buttonWidget2 };

        static void Main()
        {
            buttonWidget.OnMouseInside += ButtonWidget_OnMouseInside;
            buttonWidget.OnMouseOutside += ButtonWidget_OnMouseOutside;
            buttonWidget.OnMousePress += ButtonWidget_OnMousePress;

            toggleButtonWidget.OnButtonToggled += ToggleButtonWidget_OnButtonToggled;

            Window.Setup();
            Window.Run();

            while (!Window.ProgramClosed)
            {
                Window.Draw(Widget.ToArray(), Color.WHITE);
            }
        }

        private static void ToggleButtonWidget_OnButtonToggled(object sender, EventArgs e)
        {
            if (toggleButtonWidget.isToggled)
            {
                toggleButtonWidget.buttonColor = Color.LIME;
            }
            else
            {
                toggleButtonWidget.buttonColor = Color.RED;
            }
        }

        private static void ButtonWidget_OnMousePress(object sender, EventArgs e)
        {
            buttonWidget.outlineThickness = 1;
            backgroundWidget.outlineThickness++;
        }

        private static void ButtonWidget_OnMouseOutside(object sender, EventArgs e)
        {
            buttonWidget.outlineThickness = 2;
        }

        private static void ButtonWidget_OnMouseInside(object sender, EventArgs e)
        {
            buttonWidget.outlineThickness = 3;
        }
    }
}
