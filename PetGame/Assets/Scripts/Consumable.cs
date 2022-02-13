using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable
{
    public int Value;

    [SerializeField]
    protected UnityPet Upet;
    protected Pet pet;

    public Consumable(Pet p)
    {
        this.pet = p;
    }
}
