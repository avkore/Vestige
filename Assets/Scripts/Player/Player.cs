using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int coins;

    public void AddCoins(int amount)
    {
        coins += amount;
        UiManager.Instance.UpdateCoinText(coins);
    }
}
