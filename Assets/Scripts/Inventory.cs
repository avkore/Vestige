using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public PanelAnimator uiManager = new();
    public Button inventory;
    public Button closeSettings;

    private void Awake()
    {
        Instance = this;
        closeSettings.onClick.AddListener(() => OpenInventory(false));
        inventory.onClick.AddListener(() => OpenInventory(true));
    }
    
    public void OpenInventory(bool boolean)
    {
        if(boolean)
            uiManager.FadeInPanel();
        else
            uiManager.FadeOutPanel();
    }
}
