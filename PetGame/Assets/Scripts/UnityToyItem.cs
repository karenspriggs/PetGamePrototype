using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityToyItem : MonoBehaviour
{
    [SerializeField]
    protected UnityPet Upet;
    protected ToyItem toy;
    [SerializeField]
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        toy = new ToyItem(Upet.pet);
        toy.Value = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pet")
        {
            Upet.pet.petStats.Play(toy.Value);
            gameObject.SetActive(false);
        }
    }
}
