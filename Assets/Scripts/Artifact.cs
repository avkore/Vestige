using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D  collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                // Inventory.Instance.AddItem(gameObject);
                AudioManager.Instance.PlayAudio(AudioManager.Instance.artifact);
            }
            
            Destroy(this);
        }
    }
}
