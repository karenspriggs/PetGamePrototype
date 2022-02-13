using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStats
{
    public int fullness;
    public int happiness;

    public int maxFull;
    public int minFull;
    public int maxHappy;
    public int minHappy;

    public string petName;
    public PetState state;


    public PetStats()
    {
        state = PetState.Neutral;
    }

    public void Feed(int value)
    {
        fullness += value;
    }

    public void Play(int value)
    {
        happiness += value; 
    }

    public void UpdateStates()
    {
        if (fullness < minFull && happiness < minHappy)
        {
            this.state = PetState.Bad;
            return;

        }
        else
        {
            if (fullness < minFull)
            {
                this.state = PetState.Hungry;
                return;

            }

            if (happiness < minHappy)
            {
                this.state = PetState.Sad;
                return;
            }
        }

        this.state = PetState.Neutral;

    }

    public void AdvanceTime()
    {
        this.happiness--;
        this.fullness--;
    }
}

public enum PetState 
{
    Hungry, 
    Sad,
    Good,
    Bad,
    Neutral
}
