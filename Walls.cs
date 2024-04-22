using Godot;
using System;

public partial class Walls : Node
{
	[Export] RigidBody2D wall1;
	[Export] RigidBody2D wall2;
	[Export] float xForce;
	[Export] RichTextLabel text;

	private Vector2 wall1LastPos;
	private Vector2 wall2LastPos;

    public override void _PhysicsProcess(double delta)
    {
        if(wall1.Position.DistanceTo(wall2.Position) > 32f)
		{
			wall1.AddConstantForce(new Vector2(xForce, 0f));
			wall2.AddConstantForce(new Vector2(-xForce, 0f));
			xForce += 25f;
			GD.Print(xForce + " " + wall1.Position.DistanceTo(wall2.Position));
			text.Text = xForce.ToString();
		}

    }
}
