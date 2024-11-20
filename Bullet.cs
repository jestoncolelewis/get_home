using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	public float BulletSpeed = 500f;
	public float LifeTime = 3f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_SelfDestruct();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		OnBulletBodyEntered(this);
	}

	public async void _SelfDestruct()
	{
		await ToSignal(GetTree().CreateTimer(LifeTime), "timeout");
		QueueFree();
	}

	private void OnHitboxAreaEntered()
	{
		GD.Print("Hitbox entered");
	}
}
