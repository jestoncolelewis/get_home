using Godot;
using System;

public partial class HealthBar : Node2D
{
	[Export] private Texture2D _healthFull;
	[Export] private Texture2D _healthEmpty;

	private Sprite2D _health1;
	private Sprite2D _health2;
	private Sprite2D _health3;
	private Sprite2D _health4;
	private Sprite2D _health5;
	
	private HealthMonitor _healthMonitor;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_health1 = GetNode<Sprite2D>("Health_1");
		_health2 = GetNode<Sprite2D>("Health_2");
		_health3 = GetNode<Sprite2D>("Health_3");
		_health4 = GetNode<Sprite2D>("Health_4");
		_health5 = GetNode<Sprite2D>("Health_5");
		
		_healthMonitor = GetNode<HealthMonitor>("/root/HealthMonitor");
		_healthMonitor.OnHealthChanged += OnPlayerHealthChanged;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnPlayerHealthChanged(int currentHealth)
	{
		if (currentHealth == 5)
		{
			_health5.Texture = _healthFull;
		}
		else if (currentHealth < 5)
		{
			_health5.Texture = _healthEmpty;
		}
		
		if (currentHealth == 4)
		{
			_health4.Texture = _healthFull;
		}
		else if (currentHealth < 4)
		{
			_health4.Texture = _healthEmpty;
		}
		
		if (currentHealth == 3)
		{
			_health3.Texture = _healthFull;
		}
		else if (currentHealth < 3)
		{
			_health3.Texture = _healthEmpty;
		}
		
		if (currentHealth == 2)
		{
			_health2.Texture = _healthFull;
		}
		else if (currentHealth < 2)
		{
			_health2.Texture = _healthEmpty;
		}

		if (currentHealth == 1)
		{
			_health1.Texture = _healthFull;
		}
		else if (currentHealth < 1)
		{
			_health1.Texture = _healthEmpty;
		}
	}
}
