using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyItem : Consumable
{
    public ToyItem(Pet p) : base(p)
    {
        pet = p;
    }
}
