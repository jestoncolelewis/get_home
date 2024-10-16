using Godot;
using System;

public partial class World : Node
{
	[Export]
	public PackedScene HornetScene { get; set; }
	
	[Export]
	public PackedScene MonkeyScene { get; set; }
	
	[Export]
	public PackedScene MosquitoScene { get; set; }
	
	[Export]
	public PackedScene PantherScene { get; set; }
	
	[Export]
	public PackedScene SnakeScene { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CollisionPolygon2D collisionPolygon2D = GetNode<CollisionPolygon2D>("StaticBody2D/CollisionPolygon2D");
		CollisionPolygon2D collisionPolygon2D2 = GetNode<CollisionPolygon2D>("StaticBody2D/CollisionPolygon2D2");
		Polygon2D polygon = GetNode<Polygon2D>("StaticBody2D/CollisionPolygon2D/Polygon2D");
		Polygon2D polygon1 = GetNode<Polygon2D>("StaticBody2D/CollisionPolygon2D2/Polygon2D");

		polygon.Polygon = collisionPolygon2D.Polygon;
		polygon1.Polygon = collisionPolygon2D2.Polygon;
		
		NewGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void GameOver()
	{
		GetNode<Timer>("HornetTimer").Stop();
		GetNode<Timer>("MonkeyTimer").Stop();
		GetNode<Timer>("MosquitoTimer").Stop();
		GetNode<Timer>("PantherTimer").Stop();
		GetNode<Timer>("SnakeTimer").Stop();
	}

	public void NewGame()
	{
		var player = GetNode<Player>("Player");
		var startPosition = GetNode<Marker2D>("StartPosition");
		player.Start(startPosition.Position);
		
		GetNode<Timer>("HornetTimer").Start();
		GetNode<Timer>("MonkeyTimer").Start();
		GetNode<Timer>("MosquitoTimer").Start();
		GetNode<Timer>("PantherTimer").Start();
		GetNode<Timer>("SnakeTimer").Start();
	}

	private void OnHornetTimerTimeout()
	{
		Hornet hornet = HornetScene.Instantiate<Hornet>();
		
		var hornetSpawnLocation = GetNode<PathFollow2D>("HornetPath/HornetSpawnLocation");
		hornetSpawnLocation.ProgressRatio = GD.Randf();
		
		float direction = hornetSpawnLocation.Rotation + Mathf.Pi / 2;
		
		hornet.Position = hornetSpawnLocation.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		hornet.Rotation = direction;
		
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		hornet.LinearVelocity = velocity;
		
		AddChild(hornet);
	}

	private void OnMonkeyTimerTimeout()
	{
		Monkey monkey = MonkeyScene.Instantiate<Monkey>();
		
		var monkeySpawnLocation = GetNode<PathFollow2D>("MonkeyPath/MonkeySpawnLocation");
		monkeySpawnLocation.ProgressRatio = GD.Randf();
		
		float direction = monkeySpawnLocation.Rotation + Mathf.Pi / 2;
		
		monkey.Position = monkeySpawnLocation.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		monkey.Rotation = direction;
		
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		monkey.LinearVelocity = velocity;
		
		AddChild(monkey);
	}

	private void OnMosquitoTimerTimeout()
	{
		Mosquito mosquito = MosquitoScene.Instantiate<Mosquito>();
		
		var mosquitoSpawnLocation = GetNode<PathFollow2D>("MosquitoPath/MosquitoSpawnLocation");
		mosquitoSpawnLocation.ProgressRatio = GD.Randf();
		
		float direction = mosquitoSpawnLocation.Rotation + Mathf.Pi / 2;
		
		mosquito.Position = mosquitoSpawnLocation.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		mosquito.Rotation = direction;
		
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		mosquito.LinearVelocity = velocity;
		
		AddChild(mosquito);
	}

	private void OnPantherTimerTimeout()
	{
		Panther panther = PantherScene.Instantiate<Panther>();
		
		var pantherSpawnLocation = GetNode<PathFollow2D>("PantherPath/PantherSpawnLocation");
		pantherSpawnLocation.ProgressRatio = GD.Randf();
		
		float direction = pantherSpawnLocation.Rotation + Mathf.Pi / 2;
		
		panther.Position = pantherSpawnLocation.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		panther.Rotation = direction;
		
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		panther.LinearVelocity = velocity;
		
		AddChild(panther);
	}

	private void OnSnakeTimerTimeout()
	{
		Snake snake = SnakeScene.Instantiate<Snake>();
		
		var snakeSpawnLocation = GetNode<PathFollow2D>("SnakePath/SnakeSpawnLocation");
		snakeSpawnLocation.ProgressRatio = GD.Randf();
		
		float direction = snakeSpawnLocation.Rotation + Mathf.Pi / 2;
		
		snake.Position = snakeSpawnLocation.Position;
		
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		snake.Rotation = direction;
		
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		snake.LinearVelocity = velocity;
		
		AddChild(snake);
	}
}
