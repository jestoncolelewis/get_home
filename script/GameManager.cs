using Godot;
using System;

public partial class GameManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RenderingServer.SetDefaultClearColor(new Color(0.0f, 0.188235f, 0.0f, 1.0f));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
