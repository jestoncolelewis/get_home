using Godot;
using System;

public partial class World : Node2D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 CollisionPolygon2D collisionPolygon2D = GetNode<CollisionPolygon2D>("StaticBody2D/CollisionPolygon2D");
		 Polygon2D polygon = GetNode<Polygon2D>("StaticBody2D/CollisionPolygon2D/Polygon2D");

		polygon.Polygon = collisionPolygon2D.Polygon;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
