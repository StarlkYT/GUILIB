using GUILIB.Widgets;
using Raylib_cs;
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

        /// <summary>
        ///     When the users closes the program, this bool becomes true.
        /// </summary>
        public static bool ProgramClosed { private set { } get { return WindowShouldClose(); } }
        public static Rectangle MouseRectangle { private set; get; }

        /// <summary>
        ///     <para>Prepares all variables for Window class.</para>
        ///     Note: The minimum window size is going to be set according to the passed width and height. (Only if resizable is true).
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
        ///     <para>Initializes the window according to the given data.</para>
        ///     Note: Call this method BEFORE "Show()".
        /// </summary>
        public static void Run()
        {
            if (Resizable)
            {
                SetConfigFlags(ConfigFlag.FLAG_WINDOW_RESIZABLE);
                //SetConfigFlags(ConfigFlag.FLAG_WINDOW_TRANSPARENT);
                //SetConfigFlags(ConfigFlag.FLAG_WINDOW_HIGHDPI);
                //SetConfigFlags(ConfigFlag.FLAG_MSAA_4X_HINT);
            }
            InitWindow(Width, Height, Title);
            SetWindowMinSize(MinimumWidth, MinimumHeight);
            SetTargetFPS(60);
        }

        /// <summary>
        ///     Draws all widgets to the screen.
        /// </summary>
        /// <param name="widgets"> An array that contains all window's widgets.</param>
        /// <param name="backgroundColor"> Set the background's color. Choose colors from the Raylib class "Color".</param>

        public static void Draw(Widget[] widgets, Color backgroundColor)
        {
            if (!ProgramClosed)
            {
                MouseRectangle = new Rectangle(GetMouseX(), GetMouseY(), 1, 1);

                foreach (Widget widget in widgets)
                {
                    widget.Update();
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
