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
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.AddCoins(coinValue);
                AudioManager.Instance.PlayAudio(AudioManager.Instance.coin);
                coinText.gameObject.SetActive(true);
            }
            
            Destroy(gameObject);
        }
    }
}
