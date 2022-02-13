using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFoodItem : MonoBehaviour
{
    [SerializeField]
    protected UnityPet Upet;
    protected FoodItem food;
    [SerializeField]
    public int value;

    void Start()
    {
        food = new FoodItem(Upet.pet);
        food.Value = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pet")
        {
            Upet.pet.petStats.Feed(food.Value);
            gameObject.SetActive(false);
        }
    }
}
