# GUILIB
Is a graphical user interface library written on top of the [Raylib C# bindings](htthttps://github.com/ChrisDill/Raylib-csp:// "Raylib C# bindings"). 
The library is still in an early stage of development, but yet, we are welcoming contributors! The main goal of this project is to allow developers to create GUI applications with ease.

### How does it work?
The ecosystem of GUILIB mostly revolves around widgets, such as `TextWidget`, `BackgroundWidget` so on and so forth...
Creating a window in GUILIB is as simple as this:
```cs
Window.Setup() // You can specify options like title, width, height, etc...
Window.Run() // Initializes the window according to the given options.

while (!Window.Closed) // Keep rendering the widgets till the program closes.
{
    // Widget is the base class for all widgets.
    Window.Draw(new Widget[] { /* Put widget(s) here. */ }, Color.WHITE);
}
```
