using Godot;
using System;

public partial class HealthMonitor : Node
{
	public static HealthMonitor Instance { get; private set; }
	
	public int max_health = 100;
	public int current_health;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		current_health = max_health;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void DecreaseHealth(int amount)
	{
		current_health -= amount;

		if (current_health < 0)
		{
			current_health = 0;
		}
	}

	public void IncreaseHealth(int amount)
	{
		current_health += amount;

		if (current_health > max_health)
		{
			current_health = max_health;
		}
	}
}
