using Godot;
using System;

public partial class Panther : RigidBody2D
{
	[Export]
	PathFollow2D _pathFollow2D;
	private float _speed = 15.0f;
	private int Health = 20;
	private int Damage = 20;
	
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

	public int GetDamage()
	{
		return Damage;
	}
	
	private void MoveLoop(double delta)
	{
		_pathFollow2D = GetParent<PathFollow2D>();
		_pathFollow2D.SetProgress(_pathFollow2D.GetProgress() + _speed * (float)delta);
	}

	private void OnPantherHurtboxAreaEntered(Area2D area)
	{
		if (area.GetParent().HasMethod("GetDamage"))
		{
			var node = area.GetParent<Bullet>();
			Health -= node.GetDamage();

			if (Health <= 0)
			{
				QueueFree();
			}
		}
	}
}
