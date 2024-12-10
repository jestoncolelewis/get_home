using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float Speed = 100.0f;
	private const float JumpVelocity = -300.0f;
	private Vector2 _screenSize;

	private PackedScene _bullet = GD.Load<PackedScene>("res://bullet.tscn");
	private bool _canFire;
	
	private PackedScene _hornet = GD.Load<PackedScene>("res://hornet.tscn");

	public override void _Ready()
	{
		_screenSize = GetViewportRect().Size;
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

	public void SetCanFire(bool canFire)
	{
		_canFire = canFire;
	}

	private void _TakeDamageOnScreenExit()
	{
	}

	private void _SkillLoop()
	{
		if (Input.IsActionJustPressed("shoot") && _canFire)
		{
			GetNode<Node2D>("Turn Axis").Rotation = GetAngleTo(GetGlobalMousePosition());
			var bulletInstance = _bullet.Instantiate<Bullet>();
			bulletInstance.Position = GetNode<Node2D>("Turn Axis/SpawnPoint").GetGlobalPosition();
			bulletInstance.Rotation = GetAngleTo(GetGlobalMousePosition());
			GetParent().AddChild(bulletInstance);
		}
	}

	private void OnHurtboxBodyEntered(Node2D body)
	{
		if (body.IsInGroup("enemy"))
		{
			var hornetInstance = _hornet.Instantiate<Hornet>();
			HealthMonitor.Instance.DecreaseHealth(hornetInstance.GetDamage());
		}
	}
}
