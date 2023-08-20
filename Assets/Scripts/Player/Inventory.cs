using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public CanvasGroup inventoryUI;
    // private List<Item> inventory = new List<Item>();
    public bool IsOpen => inventoryUI.interactable;
    public PanelAnimator uimanager = new();
    
    private void Awake()
    {
        Instance = this;
    }
    
    // public void AddItem(Item item)
    // {
    //     inventory.Add(item);
    // }
    //
    // public void RemoveItem(Item item)
    // {
    //     inventory.Remove(item);
    // }
    
    public void OpenInventory(bool boolean)
    {
        if(boolean)
            uimanager.FadeInPanel();
        else
            uimanager.FadeOutPanel();
        inventoryUI.interactable = boolean;
        inventoryUI.blocksRaycasts = boolean;
    }
}
