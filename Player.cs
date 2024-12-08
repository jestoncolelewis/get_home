using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 100.0f;
	private const float JumpVelocity = -300.0f;
	private int Health = 100;
	private Vector2 ScreenSize;

	private PackedScene Bullet = GD.Load<PackedScene>("res://bullet.tscn");
	private float RateOfFire = 0.5f;
	private bool CanFire = true;
	
	PackedScene Hornet = GD.Load<PackedScene>("res://hornet.tscn");

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		_SkillLoop();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "jump", "crouch");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		
		// if (Position.Y < ScreenSize.Y) {_TakeDamageOnScreenExit();}
	}

	private void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	private void _TakeDamageOnScreenExit()
	{
		Health -= Health;
		if (Health <= 0)
		{
			GD.Print("Game Over");
		}
	}

	private void _SkillLoop()
	{
		if (Input.IsActionJustPressed("shoot"))
		{
			GetNode<Node2D>("Turn Axis").Rotation = GetAngleTo(GetGlobalMousePosition());
			var bulletInstance = Bullet.Instantiate<Bullet>();
			bulletInstance.Position = GetNode<Node2D>("Turn Axis/SpawnPoint").GetGlobalPosition();
			bulletInstance.Rotation = GetAngleTo(GetGlobalMousePosition());
			GetParent().AddChild(bulletInstance);
		}
	}

	private void OnHurtboxBodyEntered(Node2D body)
	{
		if (body.IsInGroup("enemy"))
		{
			var hornetInstance = Hornet.Instantiate<Hornet>();
			HealthMonitor.Instance.DecreaseHealth(hornetInstance.GetDamage());
		}
	}
}
