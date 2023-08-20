using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coinsPrefab;
    public List<GameObject> artifactPrefabs = new List<GameObject>();

    public int coinCount = 10;
    public int artifactCount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.chest);
            int randomValue = Random.Range(0, 10);

            if (randomValue <= 6)
            {
                DropCoins();
            }
            else
            {
                DropArtifact();
            }
            
            Destroy(gameObject);
        }
    }

    private void DropCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

            GameObject coin = Instantiate(coinsPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void DropArtifact()
    {
        int randomIndex = Random.Range(0, artifactPrefabs.Count);
        GameObject randomArtifactPrefab = artifactPrefabs[randomIndex];
        
        Vector2 randomOffset = Random.insideUnitCircle * 0.5f;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        GameObject artifact = Instantiate(randomArtifactPrefab, spawnPosition, Quaternion.identity);
    }
}
