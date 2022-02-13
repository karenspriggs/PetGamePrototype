using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement
{
    public PetMoveState movestate;

    public float Speed;
    float currentSpeed;
    float idleSpeed;
    float offset;

    public Vector2 position;
    public Vector2 wanderpoint;

    public PetMovement()
    {
        this.movestate = PetMoveState.Finding;
        idleSpeed = 0;
        currentSpeed = Speed;
        offset = 2;
    }

    public void Wander()
    {
        bool isRight = DetermineDirection(position.x, wanderpoint.x);
        bool isStopped = PointReached(position.x, wanderpoint.x);

        if (!isRight)
        {
            isStopped = PointReachedLeft(position.x, wanderpoint.x);
        }

        if (!isStopped)
        {
            position.x += currentSpeed;
        } else
        {
            this.movestate = PetMoveState.Idle;
        }
    }

    public void DetermineState()
    {
        switch (movestate)
        {
            case (PetMoveState.Idle):
                Idle();
                break;
            case (PetMoveState.Wandering):
                Wander();
                break;
            case (PetMoveState.Occupied):
                Idle();
                break;
            case (PetMoveState.Finding):
                ChangeWanderPoint();
                break;
            case (PetMoveState.Waiting):
                break;
        }
    }

    void ChangeWanderPoint()
    {
        currentSpeed = Speed;
        float destination = GenWanderPoint();
        wanderpoint.x = destination;

        bool isRight = DetermineDirection(position.x, wanderpoint.x);
        
        if (!isRight)
        {
            currentSpeed = -currentSpeed;
        }

        this.movestate = PetMoveState.Wandering;
    }

    float GenWanderPoint()
    {
        float initial = Random.Range(-5, 5);

        while (position.x - offset < initial && initial < position.x + offset)
        {
            initial = Random.Range(-5, 5);
        }

        return initial;
    }

    bool DetermineDirection(float initial, float target)
    {
        // Means target is to the right
        return (target > initial);
    }

    bool PointReachedLeft(float initial, float target)
    {
        return (target == initial || initial <= target + -currentSpeed* offset);
    }

    bool PointReached(float initial, float target)
    {
        return (target == initial || initial >= target - currentSpeed* offset);
    }

    void Idle()
    {
        this.currentSpeed = idleSpeed;

        // Will randomly start moving again
        bool ismoving = Randomize();

        if (ismoving)
        {
            this.movestate = PetMoveState.Finding;
        }
    }

    bool Randomize()
    {
        int number = Random.Range(0, 1000);
        return number == 1;
    }
}

public enum PetMoveState
{
    Wandering,
    Idle,
    Occupied,
    Waiting,
    Finding
}
