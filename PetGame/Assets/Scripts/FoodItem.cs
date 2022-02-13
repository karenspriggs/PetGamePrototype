using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Consumable
{
    public FoodItem(Pet p) : base(p)
    {
        pet = p;
    }
}
