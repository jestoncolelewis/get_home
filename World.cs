using Godot;
using System;

public partial class World : Node
{
	Player player;
	GameScreen gameScreen;
	
	[Export]
	public PackedScene EnemyScene { get; set; }
	
	private int _score;
	private Timer _enemyTimer;

	private EnemyMonitor _enemyMonitor;
	
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		player.Hide();
		gameScreen = GetNode<GameScreen>("GameScreen");
		gameScreen.StartScreen();

		_enemyMonitor = GetNode<EnemyMonitor>("/root/EnemyMonitor");
		_enemyMonitor.OnEnemyDestroyed += OnEnemyDestroyed;

		_enemyTimer = GetNode<Timer>("EnemyTimer");
	}

	public override void _Process(double delta)
	{
	}

	public void GameOver()
	{
		player.Hide();
		gameScreen.GameOverScreen(_score);
		_enemyTimer.Stop();
	}

	public void NewGame()
	{
		_enemyTimer.Start();
		player.Show();
		_score = 0;
		gameScreen.UpdateScore(_score);
	}

	private void OnEnemyDestroyed()
	{
		_score++;
		gameScreen.UpdateScore(_score);
	}

	private void OnEnemyTimerTimeout()
	{
		Hornet hornet = EnemyScene.Instantiate<Hornet>();
		
		PathFollow2D hornetSpawnLoc1 = GetNode<PathFollow2D>("EnemyPath1/EnemySpawnLoc1");
		hornetSpawnLoc1.ProgressRatio = GD.Randf();

		hornet.Position = hornetSpawnLoc1.Position;

		hornet.RotationDegrees = 0.0f;

		AddChild(hornet);

		hornet.LinearVelocity = player.GlobalPosition - hornetSpawnLoc1.GlobalPosition;
	}
}
