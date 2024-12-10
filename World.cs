using Godot;
using System;

public partial class World : Node
{
	Player player;
	GameScreen gameScreen;
	
	[Export]
	public PackedScene EnemyScene { get; set; }
	
	private int _score;

	private EnemyMonitor _enemyMonitor;
	
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		player.Hide();
		gameScreen = GetNode<GameScreen>("GameScreen");
		gameScreen.StartScreen();

		_enemyMonitor = GetNode<EnemyMonitor>("/root/EnemyMonitor");
		_enemyMonitor.OnEnemyDestroyed += OnEnemyDestroyed;
	}
	
	public override void _Process(double delta)
	{
	}

	public void GameOver()
	{
		player.Hide();
		gameScreen.GameOverScreen(_score);
	}

	public void NewGame()
	{
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

		float direction = hornetSpawnLoc1.Rotation + Mathf.Pi / 2;
		
		hornet.Position = hornetSpawnLoc1.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		hornet.Rotation = direction;

		AddChild(hornet);
	}
}
