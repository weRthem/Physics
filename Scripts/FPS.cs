using Godot;
using System;

public partial class FPS : Node
{
	RichTextLabel text;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		text = GetNode<RichTextLabel>("Numbers");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		text.Text = Mathf.RoundToInt(1 / delta).ToString();
	}
}
