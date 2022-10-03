using Godot;
using System;

public class Player : Actor
{

    [Export] float stompImpulse = 1000;
    
    public override void _Ready()
    {
        sprite = (Sprite)GetNode("PlayerSprite");
    }

    public void EnemyDetectorEnter(Area2D area2D){
            vel.y = CalculateStompVelocity(vel, stompImpulse);
    }

    public void OnBodyEnter(PhysicsBody2D physicsBody2D)
    {
        QueueFree();
    }

    private float CalculateStompVelocity( Vector2 velocity, float stompImpulse)
    {
            Vector2 output = new Vector2();
            output.y = -stompImpulse;
            return output.y;

    }

    public override void _PhysicsProcess(float delta)
    {   
        GravityFalls(delta);   
        PlayerMovement();
        Jump();
        base._PhysicsProcess(delta);
    }


   private void PlayerMovement()
    {
        vel.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        vel.x *= movementSpeed;
    }

    private void Jump()
    {
        if(IsOnFloor()&&Input.IsActionJustPressed("jump"))
        {
            vel.y= -jumpForce;
        }
    }

}
 