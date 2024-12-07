using Godot;
using System;

public partial class Hornet : RigidBody2D
{
	[Export]
	PathFollow2D _pathFollow2D;
	private float _speed = 20.0f;
	private int Health = 1;
	private int Damage = 1;
	
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
	}
	
	public int GetDamage()
	{
		return Damage;
	}

	private void OnHurtboxAreaEntered(Area2D area)
	{
		if (area.GetParent().HasMethod("GetDamage"))
		{
			var node = area.GetParent<Bullet>();
			Health -= node.GetDamage();

			if (Health <= 0)
			{
				EnemyMonitor.Instance.Destroyed();
				QueueFree();
			}
		}
	}
}
