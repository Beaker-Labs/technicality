using Godot;
using System;

public class LoadingDoors : AnimationPlayer
{
    public void Transition()
    {
        Play("door_shut");
        GD.Print("Shutting Doors");
    }

    public void _on_AnimationPlayer_animation_finished()
    {
        if (CurrentAnimation == "Door_Shut")
        {
            GD.Print("Emit signal transitioned");
            EmitSignal("doors_shut");
            Play("door_open");
        }
    }
}
