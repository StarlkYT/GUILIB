using System;
using System.Collections.Generic;
using GUILIB.Core;
using GUILIB.Widgets;
using GUILIB.Widgets.Buttons;
using GUILIB.Widgets.Other;
using GUILIB.Widgets.Text;
using GUILIB.Styles.Buttons;
using Raylib_cs;

namespace Examples
{
    class Program
    {
        //Non-scaling elements (scales by pixels):
        static BackgroundWidget BackgroundWidget = new BackgroundWidget(new Rectangle(32, 32, 128, 128), Color.GOLD, 0.25f, false);
        static ButtonWidget ButtonWidget = new ButtonWidget(new Rectangle(64, 64, 64, 64), new ButtonStyle(), "Click me!", 15, false);

        static int ClicksAmount;
        static LabelWidget LabelWidget = new LabelWidget(new Rectangle(16, 16, 256, 32), Color.WHITE, $"Clicks: {ClicksAmount}", true, 15);

        static ToggleWidget ToggleWidget = new ToggleWidget(new Rectangle(64, 180, 64 ,20), new ToggleStyle(), true);

        //Dynamically scaling elements (live scales by screen %):
        static BackgroundWidget BackgroundWidget2 = new BackgroundWidget(new Rectangle(50, 50, 20, 20), Color.GOLD, 0.25f, true);
        static ButtonWidget ButtonWidget2 = new ButtonWidget(new Rectangle(30, 30, 10, 10), new ButtonStyle(), "Click me!", 15, true);

        // Note: { BackgroundWidget, ButtonWidget } will look different than { ButtonWidget, BackgroundWidget}.
        //       Because it will draw the BackgroundWidget THEN the ButtonWidget. If you do the opposite you won't see the button.
        static List<Widget> Widget = new List<Widget>() { BackgroundWidget, ButtonWidget, LabelWidget, ToggleWidget, BackgroundWidget2, ButtonWidget2 };

        static void Main()
        {
            ButtonWidget.OnButtonPressed += ButtonWidget_OnButtonPressed;
            ButtonWidget.OnMouseExited += ButtonWidget_OnMouseExited;
            ButtonWidget.OnMouseHover += ButtonWidget_OnMouseHover;

            Window.Setup();
            Window.Run();

            while (!Window.ProgramClosed)
            {
                Window.Draw(Widget.ToArray(), Color.GRAY);
            }
        }

        private static void ButtonWidget_OnMouseHover(object sender, EventArgs eventArgs)
        {
            ButtonWidget.textSize = 14;
            ButtonWidget.text = "Hovering";
        }

        private static void ButtonWidget_OnMouseExited(object sender, EventArgs eventArgs)
        {
            ButtonWidget.textSize = 14;
            ButtonWidget.text = "Outside";
        }

        private static void ButtonWidget_OnButtonPressed(object sender, EventArgs eventArgs)
        {
            ButtonWidget.textSize = 14;
            ButtonWidget.text = "Pressed";

            if (ClicksAmount == 15)
            {
                Widget.Add(new LabelWidget(new Rectangle(256, 64, 128, 128), Color.RED, "Level up!", true, 25));
            }

            ClicksAmount++;
            LabelWidget.text = $"Clicks: {ClicksAmount}";
        }
    }
}
