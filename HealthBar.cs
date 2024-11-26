using Godot;
using System;

public partial class HealthBar : Node2D
{
	[Export] private Texture2D HealthFull;
	[Export] private Texture2D HealthEmpty;

	private Sprite2D Health_1;
	private Sprite2D Health_2;
	private Sprite2D Health_3;
	private Sprite2D Health_4;
	private Sprite2D Health_5;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Health_1 = GetNode<Sprite2D>("Health_1");
		Health_2 = GetNode<Sprite2D>("Health_2");
		Health_3 = GetNode<Sprite2D>("Health_3");
		Health_4 = GetNode<Sprite2D>("Health_4");
		Health_5 = GetNode<Sprite2D>("Health_5");
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
