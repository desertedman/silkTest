using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

public class Program
{
    private static IWindow _window ;
    private static GL _gl;

    public static void Main(string[] args)
    {
        // "with" keyword creates a shallow copy
        WindowOptions options = WindowOptions.Default with
        {
            Size = new Vector2D<int>(800, 600),
            Title = "My first Silk.NET application!",
        };

        _window = Window.Create(options);

        // Subscribe to events
        _window.Load += OnLoad;
        _window.Update += OnUpdate;
        _window.Render += OnRender;

        _window.Run();
    }

    private static void KeyDown(IKeyboard keyboard, Key key, int keyCode)
    {
        if (key == Key.Escape)
            _window.Close();
    }

    private static void OnLoad()
    {
        IInputContext input = _window.CreateInput();

        for (int i = 0; i < input.Keyboards.Count; i++)
            input.Keyboards[i].KeyDown += KeyDown;

        _gl = _window.CreateOpenGL();
    }

    private static void OnUpdate(double deltaTime) { }

    private static void OnRender(double deltaTime) { }
}
