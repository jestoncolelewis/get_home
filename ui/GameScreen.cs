using Godot;
using System;

public partial class GameScreen : CanvasLayer
{
	[Signal]
	public delegate void StartGameEventHandler();

	[Signal]
	public delegate void GameOverEventHandler();

	private Label _scoreLabel;
	private Button _startButton;
	private Label _timeLeft;
	private Timer _timer;
	private Label _finalMessage;
	private Label _finalScore;
	private HealthBar _healthBar;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_scoreLabel = GetNode<Label>("ScoreLabel");
		_startButton = GetNode<Button>("StartButton");
		_timeLeft = GetNode<Label>("TimeLeft");
		_timer = GetNode<Timer>("Timer");
		_finalMessage = GetNode<Label>("FinalMessage");
		_finalScore = GetNode<Label>("FinalScore");
		_healthBar = GetNode<HealthBar>("HealthBar");
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
		_scoreLabel.Hide();
		_healthBar.Hide();
		_timeLeft.Hide();
	}

	private void OnStartButtonPressed()
	{
		_timeLeft.Show();
		_timer.Start();
		_startButton.Hide();
		_scoreLabel.Show();
		_healthBar.Show();
		EmitSignal(SignalName.StartGame);
	}

	public void UpdateScore(int score)
	{
		_scoreLabel.Text = score.ToString();
	}

	public void GameOverScreen(int score)
	{
		_timeLeft.Hide();
		_scoreLabel.Hide();
		_healthBar.Hide();
		_finalMessage.Show();
		_finalScore.Text = score.ToString();
		_finalScore.Show();
	}

	private void OnTimerTimeout()
	{
		EmitSignal(SignalName.GameOver);
	}
}
