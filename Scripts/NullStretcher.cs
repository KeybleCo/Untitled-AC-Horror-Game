using Godot;

public partial class NullStretcher : Sprite2D
{
    private Camera2D camera;

    public override void _Ready()
    {
        camera = GetParent<Camera2D>();

        UpdateScale();
        GetViewport().SizeChanged += UpdateScale;
    }

    private void UpdateScale()
    {
        if (Texture == null || camera == null)
            return;

        Vector2 viewportSize = GetViewportRect().Size;
        Vector2 cameraSize = viewportSize * camera.Zoom;
        Vector2 texSize = Texture.GetSize();

        float s = Mathf.Max(
            cameraSize.X / texSize.X,
            cameraSize.Y / texSize.Y
        );

        Scale = new Vector2(s, s);
        Position = Vector2.Zero; // ensure centered
    }

}