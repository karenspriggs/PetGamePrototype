using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    public int Money;

    public void EarnMoney()
    {
        Money++;
    }
}
