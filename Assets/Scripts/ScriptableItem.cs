using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableItem")]
public class ScriptableItem : ScriptableObject
{
    public ItemType itemType;
    public int price;
    public Sprite itemSpriteUI;
    public string label;
}

[System.Serializable]
public enum ItemType
{
    Hat,
    Torso
}
