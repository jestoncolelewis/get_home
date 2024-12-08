using Godot;
using System;

public partial class GameScreen : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();
	
	Label timeLeft;
	Timer timer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timeLeft = GetNode<Label>("TimeLeft");
		timer = GetNode<Timer>("Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeLeft.Text = timer.TimeLeft.ToString("0.0");
	}

	public void StartScreen()
	{
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Node2D>("HealthBar").Hide();
		GetNode<Label>("TimeLeft").Hide();
	}

	private void OnStartButtonPressed()
	{
		GetNode<Label>("TimeLeft").Show();
		GetNode<Timer>("Timer").Start();
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
