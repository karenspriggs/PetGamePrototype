using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    List<Consumable> items;

    [SerializeField]
    public UnityFoodItem pizza;
    [SerializeField]
    public UnityToyItem gameboy;
    [SerializeField]
    public UnityFoodItem apple;
    [SerializeField]
    public UnityToyItem ball;

    [SerializeField]
    public MoneyManager moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        pizza.gameObject.SetActive(false);
        gameboy.gameObject.SetActive(false);
        apple.gameObject.SetActive(false);
        ball.gameObject.SetActive(false);
    }

    public void SpawnPizza()
    {
        if (moneyManager.Money > 0) 
        {
            pizza.gameObject.SetActive(true);
            moneyManager.Money--;
        }
    }

    public void SpawnGameBoy()
    {
        if (moneyManager.Money > 0)
        {
            gameboy.gameObject.SetActive(true);
            moneyManager.Money--;
        }
    }

    public void SpawnApple()
    {
        if (moneyManager.Money > 0)
        {
            apple.gameObject.SetActive(true);
            moneyManager.Money--;
        }
    }

    public void SpawnBall()
    {
        if (moneyManager.Money > 0)
        {
            ball.gameObject.SetActive(true);
            moneyManager.Money--;
        }
    }
}
