using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public TMP_Text coinText;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void UpdateCoinText(int coinCount)
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }
    }
}
