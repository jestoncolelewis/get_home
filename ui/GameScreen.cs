using Godot;
using System;

public partial class GameScreen : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();

	[Signal]
	public delegate void GameOverEventHandler();
	
	private Label _timeLeft;
	private Timer _timer;
	private Label _finalMessage;
	private Label _finalScore;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timeLeft = GetNode<Label>("TimeLeft");
		_timer = GetNode<Timer>("Timer");
		_finalMessage = GetNode<Label>("FinalMessage");
		_finalScore = GetNode<Label>("FinalScore");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_timeLeft.Text = _timer.TimeLeft.ToString("0.0");
	}

	public void StartScreen()
	{
		_finalMessage.Hide();
		_finalScore.Hide();
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

	public void GameOverScreen(int score)
	{
		_timeLeft.Hide();
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Node2D>("HealthBar").Hide();
		_finalMessage.Show();
		_finalScore.Text = score.ToString();
		_finalScore.Show();
	}

	private void OnTimerTimeout()
	{
		EmitSignal(SignalName.GameOver);
	}
}
