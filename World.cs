using Godot;
using System;

public partial class World : Node
{
	Player player;
	GameScreen gameScreen;
	
	private int _score;
	
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		player.Hide();
		gameScreen = GetNode<GameScreen>("GameScreen");
		gameScreen.StartScreen();
	}
	
	public override void _Process(double delta)
	{
	}

	public void GameOver()
	{
	}

	public void NewGame()
	{
		player.Show();
		_score = 0;
		gameScreen.UpdateScore(_score);
	}

	private void OnEnemyDestruction()
	{
		_score++;
		gameScreen.UpdateScore(_score);
	}
}
