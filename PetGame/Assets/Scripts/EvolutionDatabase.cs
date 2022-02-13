using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionDatabase
{
    public PetEvolution petEvo;

    Sprite GoodTeen;
    Sprite BadTeen;

    Sprite GoodBadAdult;
    Sprite GoodGoodAdult;
    Sprite BadBadAdult;
    Sprite BadGoodAdult;

    public EvolutionDatabase(PetEvolution _petEvo)
    {
        this.petEvo = _petEvo;

        GoodTeen = Resources.Load<Sprite>("happypet");
        BadTeen = Resources.Load<Sprite>("petangry");

        GoodBadAdult = Resources.Load<Sprite>("happypetsad");
        GoodGoodAdult = Resources.Load<Sprite>("happypethappy");
        BadBadAdult = Resources.Load<Sprite>("angriestpet");
        BadGoodAdult = Resources.Load<Sprite>("angrypethappy");
    }

    public void NextEvolution()
    {
        switch (petEvo.evoStage)
        {
            case (PetEvoStage.Kid):
                petEvo.evoSprite = TeenEvo();
                break;
            case (PetEvoStage.Teen):
                petEvo.evoSprite = AdultEvo();
                break;
        }
    }

    public Sprite TeenEvo()
    {
        if (petEvo.canGoodEvolve)
        {
            return GoodTeen;
        }

        return BadTeen;
    }

    public Sprite GoodEvoAdult()
    {
        if (petEvo.canGoodEvolve)
        {
            return GoodGoodAdult;
        }

        return GoodBadAdult;
    }

    public Sprite BadEvoAdult()
    {
        if (petEvo.canGoodEvolve)
        {
            return BadGoodAdult;
        }

        return BadBadAdult;
    }

    public Sprite AdultEvo()
    {
        Sprite evosprite;

        if (petEvo.evoSprite == BadTeen)
        {
            evosprite = BadEvoAdult();
        } else
        {
            evosprite = GoodEvoAdult();
        }

        return evosprite;
    }
}
