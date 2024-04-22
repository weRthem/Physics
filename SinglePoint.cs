using Godot;
using System;

public partial class SinglePoint : Node2D
{
	[Export] PackedScene ballScene;
	[Export] int numberOfBalls;
	[Export] RichTextLabel ballCounter;
	[Export] RichTextLabel canBallsSleepText;

	int ballCount;
	bool canBallsSleep = true;
    public override void _Input(InputEvent @event)
    {
		if(@event is InputEventKey eventKey && eventKey.Pressed)
		{
			if(eventKey.Keycode == Key.T)
			{
				canBallsSleep = !canBallsSleep;
				canBallsSleepText.Text = canBallsSleep.ToString();
				return;
			}

			if(eventKey.Keycode != Key.Space) return;

			ballCount += numberOfBalls;
			ballCounter.Text = ballCount.ToString();

			RigidBody2D lastSceneSpawned;
			for (int i = 0; i < numberOfBalls; i++)
			{
				lastSceneSpawned = ballScene.Instantiate<RigidBody2D>();
				lastSceneSpawned.CanSleep = canBallsSleep;
				AddChild(lastSceneSpawned);
			}
		}
    }

}
