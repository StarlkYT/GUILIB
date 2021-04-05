using GUILIB.Widgets;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GUILIB.Core
{
    public static class Window
    {
        public static string Title;
        public static int Width;
        public static int Height;
        public static int MinimumWidth;
        public static int MinimumHeight;
        public static bool Resizable;

        public static bool Closed { private set { } get { return WindowShouldClose(); } }
        public static Vector2 MousePosition { private set { } get { return GetMousePosition(); } }

        /// <summary>
        /// <para>Prepares all variables for Window class.</para>
        /// Note: The minimum window size is going to be set according to the passed width and height. (Only if resizable is true).
        /// </summary>
        /// <param name="title"> The window's title.</param>
        /// <param name="width"> Sets the window's width.</param>
        /// <param name="height"> Sets the window's height.</param>
        /// <param name="minimumWidth"> Sets the window's minimum width.</param>
        /// <param name="minimumHeight"> Sets the window's minimum height.</param>
        /// <param name="resizable"> Enable or disable window resizing.</param>
        public static void Setup(string title = "GUILIB", int width = 1024, int height = 576,
                                 int minimumWidth = 256, int minimumHeight = 144, bool resizable = true)
        {
            Title = title;
            Width = width;
            Height = height;
            MinimumWidth = minimumWidth;
            MinimumHeight = minimumHeight;
            Resizable = resizable;
        }

        /// <summary>
        /// <para>Initializes the window according to the given data.</para>
        /// Note: This method must be called after "Setup".
        /// </summary>
        public static void Run()
        {
            if (Resizable)
            {
                SetConfigFlags(ConfigFlag.FLAG_WINDOW_RESIZABLE);
            }
            //SetConfigFlags(ConfigFlag.FLAG_MSAA_4X_HINT);
            //SetConfigFlags(ConfigFlag.FLAG_WINDOW_HIGHDPI);

            InitWindow(Width, Height, Title);
            SetWindowMinSize(MinimumWidth, MinimumHeight);
            //SetTargetFPS(60);
        }

        /// <summary>
        /// Draws all widgets to the screen.
        /// </summary>
        /// <param name="widgets"> An array that contains all window's widgets.</param>
        /// <param name="backgroundColor"> Set the background's color. Choose colors from the Raylib class.</param>
        /// <param name="isWidgetScalable"> Should the widgets resize/reposition according to the windows size or not.</param>
        public static void Draw(Widget[] widgets, Color backgroundColor, bool isWidgetScalable = false)
        {
            if (!Closed)
            {
                foreach (Widget widget in widgets)
                {
                    widget.Update(isWidgetScalable);
                }

                BeginDrawing();
                ClearBackground(backgroundColor);

                foreach (Widget widget in widgets)
                {
                    widget.Draw();
                }

                EndDrawing();
            }
            else
            {
                CloseWindow();
            }
        }
    }
}
