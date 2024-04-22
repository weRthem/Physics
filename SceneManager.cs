using Godot;
using System;

public partial class SceneManager : MarginContainer
{
	[Export] PackedScene compressionScene;
	[Export] PackedScene singlePointScene;
	[Export] PackedScene container;
	[Export] PackedScene breakout;

	[Export] Node2D rootNode;

	Node lastSceneLoaded = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventKey eventKey && eventKey.Pressed)
		{
			if(eventKey.Keycode == Key.Escape && lastSceneLoaded != null)
			{
				// Unload scene and show menu
				GetNode<Camera2D>("%Camera2D").Zoom = new Vector2(1, 1);
				lastSceneLoaded.QueueFree();
				lastSceneLoaded = null;
				Show();
			}
		}
    }

	public void LoadCompression()
	{
		lastSceneLoaded = compressionScene.Instantiate();
		rootNode.AddChild(lastSceneLoaded);
		Hide();
	}

	public void LoadSinglePoint()
	{
		lastSceneLoaded = singlePointScene.Instantiate();
		rootNode.AddChild(lastSceneLoaded);
		Hide();
	}

	public void LoadContainer()
	{
		lastSceneLoaded = container.Instantiate();
		rootNode.AddChild(lastSceneLoaded);
		GetNode<Camera2D>("%Camera2D").Zoom = new Vector2(0.2f, 0.2f);
		Hide();
	}

	public void LoadContainerBreakout()
	{
		lastSceneLoaded = breakout.Instantiate();
		rootNode.AddChild(lastSceneLoaded);
		Hide();
	}
}
