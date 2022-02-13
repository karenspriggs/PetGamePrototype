using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityPet : MonoBehaviour
{
    [SerializeField]
    int maxHunger;
    [SerializeField]
    int maxHappiness;
    [SerializeField]
    int Happiness;
    [SerializeField]
    int Fullness;
    [SerializeField]
    int minHappiness;
    [SerializeField]
    int minHunger;

    [SerializeField]
    int minGoodEvo;
    [SerializeField]
    float speed;

    [SerializeField]
    Sprite sprite;

    public Pet pet;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        SetUpPet();
    }

    public void SetUpPet()
    {
        pet = new Pet();

        pet.currentSprite = sprite;

        pet.petStats = new PetStats();
        pet.petStats.maxFull = maxHunger;
        pet.petStats.minFull = minHunger;
        pet.petStats.maxHappy = maxHappiness;
        pet.petStats.minHappy = minHappiness;
        pet.petStats.fullness = Fullness;
        pet.petStats.happiness = Happiness;

        pet.petEvo = new PetEvolution(pet.petStats);
        pet.petEvo.goodMinValue = minGoodEvo;

        pet.petMove = new PetMovement();
        pet.petMove.position = this.transform.position;
        pet.petMove.Speed = speed;
    }

    private void Update()
    {
        pet.petStats.UpdateStates();
        ChooseEvolution();
        pet.petMove.DetermineState();
        this.transform.position = pet.petMove.position;
    }

    void ChooseEvolution()
    {
        if (pet.petEvo.canEvolve)
        {
            Evolve();
        }
    }

    void Evolve()
    {
        pet.petEvo.CheckEvolve();
        pet.currentSprite = pet.petEvo.evoSprite;
        sr.sprite = pet.currentSprite;
    }
}
