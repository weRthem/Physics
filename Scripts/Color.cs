using Godot;
using System;

public partial class Color : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		float r = (float)GD.RandRange(0f, 1f);
		float g = (float)GD.RandRange(0f, 1f);
		float b = (float)GD.RandRange(0f, 1f);
		Modulate = new Godot.Color(r, g, b);
	}

}
