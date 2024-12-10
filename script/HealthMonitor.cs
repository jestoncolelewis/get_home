using Godot;
using System;

public partial class HealthMonitor : Node
{
	public static HealthMonitor Instance { get; private set; }

	private int _maxHealth = 5;
	private int _currentHealth;
	
	[Signal]
	public delegate void OnHealthChangedEventHandler(int health);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		_currentHealth = _maxHealth;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void DecreaseHealth(int amount)
	{
		_currentHealth -= amount;

		if (_currentHealth < 0)
		{
			_currentHealth = 0;
		}
		EmitSignal(SignalName.OnHealthChanged, _currentHealth);
	}
}
