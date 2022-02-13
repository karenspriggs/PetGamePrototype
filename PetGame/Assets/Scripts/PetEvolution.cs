using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetEvoStage
{
    Kid,
    Teen,
    Adult
}

public class PetEvolution
{
    public PetEvoStage evoStage;
    public EvolutionDatabase evoDatabase;

    public PetStats evoStats;
    public Sprite evoSprite;

    // Value that determines how the pet evolves
    public int goodMinValue;

    public int timeToEvolve;
    public int days;

    public bool canEvolve;
    public bool canGoodEvolve;

    public PetEvolution(PetStats _evoStats)
    {
        canEvolve = false;
        this.evoDatabase = new EvolutionDatabase(this);
        this.evoStats = _evoStats;
        this.evoStage = PetEvoStage.Kid;
        days = 0;
        timeToEvolve = 5;
    }

    public void CheckEvolve()
    {
        if (canEvolve)
        {
            DetermineEvolution();
            ChangeEvoSprite();
            canEvolve = false;
        }
    }

    void DetermineEvolution()
    {
        if (evoStats.fullness >= goodMinValue && evoStats.happiness >= goodMinValue)
        {
            canGoodEvolve = true;
        } else
        {
            canGoodEvolve = false;
        }
    }

    void ChangeEvoSprite()
    {
        evoDatabase.NextEvolution();
        ChangeEvoState();
    }

    void ChangeEvoState()
    {
        switch (evoStage)
        {
            case (PetEvoStage.Kid):
                evoStage = PetEvoStage.Teen;
                break;
            case (PetEvoStage.Teen):
                evoStage = PetEvoStage.Adult;
                break;
        }
    }
}
