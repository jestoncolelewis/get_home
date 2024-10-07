using Godot;
using System;

public partial class World : Node2D
{
	private CollisionPolygon2D _collisionPolygon2D;

	private Polygon2D _polygon;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 _collisionPolygon2D = GetNode<CollisionPolygon2D>("CollisionPolygon2D");
		 _polygon = GetNode<Polygon2D>("Polygon2D");

		// _polygon.Polygons = (Vector2)collisionPolygon2D.Polygon;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
