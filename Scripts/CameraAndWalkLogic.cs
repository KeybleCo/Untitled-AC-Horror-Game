using Godot;
using System;
using System.IO;
using System.Threading.Tasks;

public partial class CameraAndWalkLogic : VideoStreamPlayer
{
    public override async void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
        Position = Vector2.Zero;
        await Task.Delay(1);
        Paused = true;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion motion)
        {
            float ifX = Position.X - motion.Relative.X;
            float ifY = Position.Y - motion.Relative.Y;

            float newX;
            float newY;
            if (ifX >= -16 && ifX <= 16)
            {
                newX = (float) (Position.X - (motion.Relative.X * 0.5));
            } else if (ifX >= -24 && ifX <= 24)
            {
                newX = (float) (Position.X - (motion.Relative.X * 0.2));
            } else if (ifX >= -32 && ifX <= 32)
            {
                newX = (float) (Position.X - (motion.Relative.X * 0.05));
            } else
            {
                newX = Position.X;
            }

            if (ifY >= -12 && ifY <= 12)
            {
                newY = (float) (Position.Y - (motion.Relative.Y * 0.5));
            } else if (ifY >= -18 && ifY <= 18)
            {
                newY = (float) (Position.Y - (motion.Relative.Y * 0.2));
            } else if (ifY >= -24 && ifY <= 24)
            {
                newY = (float) (Position.Y - (motion.Relative.Y * 0.05));
            } else
            {
                newY = Position.Y;
            }

            Position = new Vector2(newX, newY);
        }

        if (Input.IsActionJustPressed("Walk"))
        {
            Paused = false;
        }

        if (Input.IsActionJustReleased("Walk"))
        {
            Paused = true;
        }

        if (Input.IsActionJustPressed("Run"))
        {
            SpeedScale = 1.5f;
        }

        if (Input.IsActionJustReleased("Run"))
        {
            SpeedScale = 1.0f;
        }
    }

}