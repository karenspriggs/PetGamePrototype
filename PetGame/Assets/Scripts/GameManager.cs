using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    UnityPet Upet;
    Pet pet;

    [SerializeField]
    UIManager ui;
    [SerializeField]
    ItemSpawner itemspawn;

    LossManager lm;

    bool recordedPet;

    // Start is called before the first frame update
    void Start()
    {
        recordedPet = false;
    }

    void RecordPet()
    {
        if (!recordedPet)
        {
            lm = new LossManager(Upet.pet, 2);
            recordedPet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RecordPet();
        SetPetText();
    }

    void SetPetText()
    {
        CheckLossManager();
        ui.PetFoodPoints = Upet.pet.petStats.fullness;
        ui.PetPlayPoints = Upet.pet.petStats.happiness;
        ui.newX = Upet.pet.petMove.wanderpoint.x;
        ui.PetMoney = itemspawn.moneyManager.Money;
        SetPetStateText();
        SetPetMoveStateText();
    }

    void CheckLossManager()
    {
        if (lm.gameState == GameState.Lost)
        {
            Lose();
        }
    }

    public void Lose()
    {
        Upet.pet.petMove.Speed = 0;
        ui.ShowButton();
        ui.showLoseText = true;
    }

    public void Reset()
    {
        Upet.SetUpPet();
        ui.showLoseText = false;
    }

    void SetPetStateText()
    {
        switch (Upet.pet.petStats.state)
        {
            case (PetState.Hungry):
                ui.PetStateText = "Hungry";
                break;
            case (PetState.Sad):
                ui.PetStateText = "Sad";
                break;
            case (PetState.Bad):
                ui.PetStateText = "Bad";
                break;
            default:
                ui.PetStateText = "Neutral";
                break;
        }
    }

    void SetPetMoveStateText()
    {
        switch (Upet.pet.petMove.movestate)
        {
            case (PetMoveState.Idle):
                ui.PetStateMoveText = "Idle";
                break;
            case (PetMoveState.Wandering):
                ui.PetStateMoveText = "Wandering";
                break;
            case (PetMoveState.Finding):
                ui.PetStateMoveText = "Finding";
                break;
        }
    }

    public void AdvanceTime()
    {
        if (Upet.pet.petStats.happiness > 0)
        {
            Upet.pet.petStats.happiness--;

        }

        if (Upet.pet.petStats.fullness > 0)
        {
            Upet.pet.petStats.fullness--;

        }

        lm.CheckPet(Upet.pet);

        Upet.pet.petEvo.days++;

        Upet.pet.petEvo.canEvolve = (Upet.pet.petEvo.days == Upet.pet.petEvo.timeToEvolve);
    }

    public void EvolvePet()
    {
        Upet.pet.petEvo.canEvolve = true;
    }

    public void SpawnPizza()
    {
        itemspawn.SpawnPizza();
        //pet.petMove.wanderpoint.x = itemspawn.pizza.gameObject.transform.position.x;
    }

    public void SpawnGameBoy()
    {
        itemspawn.SpawnGameBoy();
        //pet.petMove.wanderpoint.x = itemspawn.gameboy.gameObject.transform.position.x;
    }

    public void SpawnApple()
    {
        itemspawn.SpawnApple();
    }

    public void SpawnBall()
    {
        itemspawn.SpawnBall();
    }
}
