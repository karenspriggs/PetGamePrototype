using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int PetFoodPoints;
    public int PetPlayPoints;
    public int PetMoney;

    public string PetStateText;
    public string PetStateMoveText;

    public float newX;
    public bool showLoseText;

    [SerializeField]
    Text foodText;

    [SerializeField]
    Text playText;

    [SerializeField]
    Text stateText;

    [SerializeField]
    Text moveText;

    [SerializeField]
    Text xText;

    [SerializeField]
    Text moneyText;

    [SerializeField]
    Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        HideButton();
        showLoseText = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    public void SetText()
    {
        if (showLoseText)
        {
            stateText.text = "HE DIED";
            moveText.text = "DEAD";
        } else
        {
            foodText.text = "Fullness: " + PetFoodPoints;
            playText.text = "Happiness: " + PetPlayPoints;
            stateText.text = PetStateText;
            moveText.text = PetStateMoveText;
            xText.text = $"{newX}";
            moneyText.text = $"Coins: {PetMoney}";
        }
    }

    public void ShowButton()
    {
        resetButton.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        resetButton.gameObject.SetActive(false);
    }
}
