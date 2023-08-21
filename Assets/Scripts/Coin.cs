using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public TMP_Text coinText;

    private void OnCollisionEnter2D(Collision2D  collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            
            if (playerInventory != null)
            {
                playerInventory.money += 1;
                playerInventory.inventory.UpdateMoney(playerInventory.money);
                AudioManager.Instance.PlayAudio(AudioManager.Instance.coin);
                coinText.gameObject.SetActive(true);
            }
            
            Destroy(gameObject);
        }
    }
}
