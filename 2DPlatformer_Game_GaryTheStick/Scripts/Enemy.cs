using Godot;
using System;

public class Enemy : Actor
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SetPhysicsProcess(false);
        sprite = (Sprite)GetNode("EnemySprite");
        vel.x = -movementSpeed;
    }

    private void OnStompDetection(RigidBody2D rigidBody2D){
        if(this.GlobalPosition.y > GetNode<Area2D>("StompDetector").GlobalPosition.y)
        {
            return;
        }
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
        QueueFree();
    }

    public override void _PhysicsProcess(float delta)
    {
        if(IsOnWall()) vel.x *= -1; 
        base._PhysicsProcess(delta);
    } 

    
}
