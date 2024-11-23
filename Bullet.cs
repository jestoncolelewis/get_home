using Godot;
using System;

public partial class Bullet : Sprite2D
{
	private float BulletSpeed = 500f;
	private float LifeTime = .5f;
	public int Damage = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_SelfDestruct();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveLocalX(BulletSpeed * (float)delta);
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
