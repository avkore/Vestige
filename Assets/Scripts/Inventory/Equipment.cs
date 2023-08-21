using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Container
{
    public GameObject itemPrefab;
    public List<ScriptableItem> equippedScriptableItems = new();
    
    private void Start()
    {
        FillEquipment();
    }

    private void FillEquipment()
    {
        foreach (var item in equippedScriptableItems)
        {
            GameObject itemInstance = Instantiate(itemPrefab, itemsContainer);
            Item itemComponent = itemInstance.GetComponent<Item>();
            
            itemComponent.scriptableItem = item;
            
            itemComponent.equipmentChanger = GetComponentInChildren<ClotheChanger>();
            itemComponent.itemState = ItemState.Equipped;
            itemComponent.img.sprite = item.itemSpriteUI;
            itemComponent.price = item.price;
            itemComponent.priceTxt.text = itemComponent.price.ToString();

            Items.Add(itemComponent);
        }
    }
}
