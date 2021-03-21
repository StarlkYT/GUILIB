# GUILIB
Is a graphical user interface library written on top of the [Raylib C# bindings](htthttps://github.com/ChrisDill/Raylib-csp:// "Raylib C# bindings"). 
The library is still in an early stage of development, but yet, we are welcoming contributors! The main goal of this project is to allow developers to create GUI applications with ease.

### How does it work?
The ecosystem of GUILIB mostly revolves around widgets, such as `TextWidget`, `BackgroundWidget` so on and so forth...
To create a window in GUILIB, initialize the window, for example:
```cs
Window.Setup() // You can specify options like title, width, height, etc...
Window.Run() // Initializes the window according to the given options.

while (!Window.ProgramClosed) // Keep rendering the widgts till the program closes.
{
    // "Widget" is the base/parent class for all widgets in GUILIB
    Window.Draw(new Widget[] { new TextWidget(new Rectangle(64, 64, 64, 64), Color.RED, "Hello, world!", 15, true ) }, Color.WHITE);
}
```
