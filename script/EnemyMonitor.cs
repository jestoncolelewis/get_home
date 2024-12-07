using Godot;
using System;

public partial class EnemyMonitor : Node
{
	public static EnemyMonitor Instance { get; private set; }

	[Signal]
	public delegate void OnEnemyDestroyedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Destroyed()
	{
		EmitSignal(SignalName.OnEnemyDestroyed);
	}
}
