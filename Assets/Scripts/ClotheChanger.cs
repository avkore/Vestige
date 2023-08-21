using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ClotheChanger : MonoBehaviour
{
    public RendererResolver[] hat;
    public RendererResolver[] torso;

    public Equipment equipment;

    private void Awake()
    {
        equipment = GetComponentInParent<Equipment>();
    }
    
    public Item Equip(ItemType itemType, string label)
    {
        Item currentItem = null;

        // Find the item in the equipment that is of the same type as the item we want to equip
        foreach (var item in equipment.Items)
        {
            if (item.scriptableItem.itemType == itemType)
            {
                currentItem = item;
                break;
            }
        }

        switch (itemType)
        {
            case ItemType.Hat:
                foreach (var item in hat)
                {
                    item.spriteResolver.SetCategoryAndLabel(item.spriteResolver.GetCategory(), label);
                }
                break;
            case ItemType.Torso:
                foreach (var item in torso)
                {
                    item.spriteResolver.SetCategoryAndLabel(item.spriteResolver.GetCategory(), label);
                }
                break;
            default:
                break;
        }
        return currentItem;
    }
}

[System.Serializable]
public class RendererResolver
{
    public ItemType itemType;
    public SpriteRenderer spriteRenderer;
    public SpriteResolver spriteResolver;
}


public static class Labels
{
    public static string BlueHat = "BlueHat";
    public static string BlueTorso = "BlueTorso";
    public static string BrownHat = "BrownHat";
    public static string BrownTorso = "BrownTorso";
    public static string GreenHat = "GreenHat";
    public static string GreenTorso = "GreenTorso";
    public static string GreyHat = "GreyHat";
    public static string GreyTorso = "GreyTorso";
    public static string RedTorso = "RedTorso";
}
