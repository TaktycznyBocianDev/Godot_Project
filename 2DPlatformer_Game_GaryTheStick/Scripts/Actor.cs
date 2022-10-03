using Godot;
using System;


    public class Actor: KinematicBody2D
    {
    [Export] public Vector2 vel = new Vector2(0,0);
    [Export] public float movementSpeed = 100;
    [Export] public float jumpForce = 100;

    //gravity varriables
    [Export]float gravity = 50;
    [Export]float maxFallSpeed = 1000;
    [Export]float minFallSpeed = 5;
     public Sprite sprite;



     public override void _PhysicsProcess(float delta)
    {
        FlipSprite();
        MoveAndSlide(vel, Vector2.Up);
    }

    public  void GravityFalls(float delta){
        vel.y += gravity;
        if(vel.y > maxFallSpeed){
            vel.y = maxFallSpeed;
        }
        if(IsOnFloor()){
            vel.y = minFallSpeed;
        }
    }  

        public void FlipSprite()
    {
        if(vel.x>0)
        {
            sprite.FlipH = false;
        }
        else if(vel.x<0)
        {
            sprite.FlipH = true;
        }
    }
 
    }
