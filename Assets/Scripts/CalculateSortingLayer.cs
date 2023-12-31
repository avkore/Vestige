using UnityEngine;

public class CalculateSortingLayer : MonoBehaviour
{ 
    public string playerTag = "Player";
    private GameObject playerObject;
    private Renderer rendererComponent;
    private string originalSortingLayer;
    public float offset;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
        rendererComponent = GetComponent<Renderer>();
        originalSortingLayer = rendererComponent.sortingLayerName;
    }

    private void Update()
    {
        if (ShouldMoveToFrontOfPlayer())
        {
            SetSortingLayer("FrontOfPlayer");
        }
        else
        {
            RestoreOriginalSortingLayer();
        }
    }

    private bool ShouldMoveToFrontOfPlayer()
    {
        return playerObject.transform.position.y > transform.position.y - offset;
    }

    private void SetSortingLayer(string layerName)
    {
        rendererComponent.sortingLayerName = layerName;
    }

    private void RestoreOriginalSortingLayer()
    {
        rendererComponent.sortingLayerName = originalSortingLayer;
    }
}