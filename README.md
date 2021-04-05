# GUILIB
A graphical user interface library written on top of the [Raylib C# bindings](htthttps://github.com/ChrisDill/Raylib-csp:// "Raylib C# bindings"). 
GUILIB is still in an early stage of development, but yet, we are welcoming contributors! GUILIB makes it easier to create simple GUI applications.

### How does it work?
The ecosystem of GUILIB mostly revolves around widgets, such as `TextWidget`, `PanelWidget`, etc...
An example of creating a window in GUILIB can be as simple as this:
```cs
Window.Setup() // You can specify options like title, width, height, etc...
Window.Run() // Initializes the window according to the given options.

while (!Window.Closed) // Keep rendering the widgets till the program closes.
{
    // Widget is the base class for all widgets.
    Window.Draw(new Widget[] { /* Put widget(s) here. */ }, Color.WHITE);
}
```
