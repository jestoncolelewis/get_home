using Godot;
using System;

public partial class GameScreen : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void StartScreen()
	{
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Node2D>("HealthBar").Hide();
	}

	private void OnStartButtonPressed()
	{
		GetNode<Button>("StartButton").Hide();
		GetNode<Label>("ScoreLabel").Show();
		GetNode<Node2D>("HealthBar").Show();
		EmitSignal(SignalName.StartGame);
	}

	public void UpdateScore(int score)
	{
		GetNode<Label>("ScoreLabel").Text = score.ToString();
	}
}
