using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { 
    Won,
    Playing,
    GameOver,
    Lost
}

public class LossManager
{
    public GameState gameState;
    public Pet startingPet;
    int petDieCount;
    int petDieNum;

    public LossManager(Pet ps, int petdienum)
    {
        this.gameState = GameState.Playing;
        startingPet = ps;
        petDieCount = 0;
        petDieNum = petdienum;
    }

    public void CheckPet(Pet p)
    {
        if (p.petStats.happiness == 0 || p.petStats.fullness == 0)
        {
            petDieCount++;
        } 

        if (petDieCount == petDieNum)
        {
            this.gameState = GameState.Lost;
        }
    }

    public void Lose(Pet p)
    {
        this.gameState = GameState.Lost;
        ResetPet(p);
    }

    public void Play()
    {
        this.gameState = GameState.Playing;
    }

    public void Win(Pet p)
    {
        this.gameState = GameState.Won;
        ResetPet(p);
    }
    
    public void ResetPet(Pet p)
    {
        p.petStats = startingPet.petStats;
        p.petEvo = startingPet.petEvo;
        p.petMove = startingPet.petMove;
        this.gameState = GameState.Playing;
    }
}
