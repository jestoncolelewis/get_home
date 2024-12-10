using Godot;
using System;

public partial class GameScreen : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();
	
	private Label timeLeft;
	private Timer timer;
	private Label finalMessage;
	private Label finalScore;

	private GameManager _gameManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timeLeft = GetNode<Label>("TimeLeft");
		timer = GetNode<Timer>("Timer");
		finalMessage = GetNode<Label>("FinalMessage");
		finalScore = GetNode<Label>("FinalScore");

		_gameManager = GetNode<GameManager>("/root/GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeLeft.Text = timer.TimeLeft.ToString("0.0");
	}

	public void StartScreen()
	{
		finalMessage.Hide();
		finalScore.Hide();
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Node2D>("HealthBar").Hide();
	}

	private void OnStartButtonPressed()
	{
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
		timeLeft.Hide();
		GetNode<Label>("ScoreLabel").Hide();
		GetNode<Node2D>("HealthBar").Hide();
		finalMessage.Show();
		finalScore.Text = score.ToString();
	}

	public void OnTimerTimeout()
	{
		_gameManager.EmitSignal("GameOver");
	}
}
