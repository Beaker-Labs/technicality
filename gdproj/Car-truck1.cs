using Godot;
using System;

public partial class Car-truck1 : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("vehicle_right"))
		{
			velocity.x += 1;
		}

		if (Input.IsActionPressed("vehicle_left"))
		{
			velocity.x -= 1;
		}

		if (Input.IsActionPressed("vehicle_down"))
		{
			velocity.y += 1;
		}

		if (Input.IsActionPressed("vehicle_up"))
		{
			velocity.y -= 1;
		}

		//var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			//animatedSprite.Play();
		}
		else
		{
			//animatedSprite.Stop();
		}
	}
}
