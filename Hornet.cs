using Godot;
using System;

public partial class Hornet : RigidBody2D
{
	[Export]
	PathFollow2D _pathFollow2D;
	private float _speed = 10.0f;
	public float Health = 100.0f; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveLoop(delta);
	}

	private void MoveLoop(double delta)
	{
		_pathFollow2D = GetParent<PathFollow2D>();
		_pathFollow2D.SetProgress(_pathFollow2D.GetProgress() + _speed * (float)delta);
	}

	private void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
