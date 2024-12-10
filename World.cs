using Godot;
using System;

public partial class World : Node
{
	private Player _player;
	private GameScreen _gameScreen;
	
	[Export]
	public PackedScene EnemyScene { get; set; }
	
	private int _score;
	private Timer _enemyTimer;

	private EnemyMonitor _enemyMonitor;
	
	public override void _Ready()
	{
		_player = GetNode<Player>("Player");
		_player.Hide();
		_gameScreen = GetNode<GameScreen>("GameScreen");
		_gameScreen.StartScreen();

		_enemyMonitor = GetNode<EnemyMonitor>("/root/EnemyMonitor");
		_enemyMonitor.OnEnemyDestroyed += OnEnemyDestroyed;

		_enemyTimer = GetNode<Timer>("EnemyTimer");
	}

	public override void _Process(double delta)
	{
	}

	private void GameOver()
	{
		_player.Hide();
		_gameScreen.GameOverScreen(_score);
		_enemyTimer.Stop();
	}

	private void NewGame()
	{
		_enemyTimer.Start();
		_player.Show();
		_score = 0;
		_gameScreen.UpdateScore(_score);
	}

	private void OnEnemyDestroyed()
	{
		_score++;
		_gameScreen.UpdateScore(_score);
	}

	private void OnEnemyTimerTimeout()
	{
		Hornet hornet = EnemyScene.Instantiate<Hornet>();
		
		PathFollow2D hornetSpawnLoc1 = GetNode<PathFollow2D>("EnemyPath1/EnemySpawnLoc1");
		hornetSpawnLoc1.ProgressRatio = GD.Randf();

		hornet.Position = hornetSpawnLoc1.Position;

		hornet.RotationDegrees = 0.0f;

		AddChild(hornet);

		hornet.LinearVelocity = _player.GlobalPosition - hornetSpawnLoc1.GlobalPosition;
	}
}
