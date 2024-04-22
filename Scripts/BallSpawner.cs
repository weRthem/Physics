using Godot;
using System;

public partial class BallSpawner : Node2D
{
	[Export] PackedScene ball;
	[Export] Godot.Collections.Array<Sprite2D> spawnPoints;
	[Export] RichTextLabel ballCounter;

	int ballCount = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Engine.GetProcessFrames() % 10 != 0) return;

		RigidBody2D newBall;

		Vector2 vel = new Vector2((float)GD.RandRange(-1f, 1f), (float)GD.RandRange(-1f, 1f));

		for (int i = 0; i < spawnPoints.Count; i++)
		{
			newBall = ball.Instantiate<RigidBody2D>();

			AddChild(newBall);
			newBall.Position = spawnPoints[i].Position;
			newBall.LinearVelocity = vel;
			ballCount++;
		}
		
		ballCounter.Text = ballCount.ToString();
	}
}
