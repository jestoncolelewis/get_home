using Godot;
using System;

public partial class Bullet : RigidBody2D
{
	public float BulletSpeed = 3000f;
	public float LifeTime = 3f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ApplyImpulse(new Vector2(), new Vector2(BulletSpeed, 0).Rotated(Rotation));
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

	private void OnBulletBodyEntered(Node body)
	{
		if (body is Bullet bullet)
		{
			if (bullet.GetContactCount() > 0)
			{
				bullet.Hide();
			}
		}
	}
}
