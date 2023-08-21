using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public EventHandler<ItemAddedEventArgs> onItemAdded;
    public EventHandler<ItemAddedEventArgs> onItemRemoved;

    public List<Item> Items = new List<Item>();
    public Transform itemsContainer;
    
    public virtual bool AddItem(Item item, ItemState itemState)
    {
        if(item != null)
        {
            Items.Add(item);
            item.itemState = itemState;
            item.transform.SetParent(itemsContainer);

            onItemAdded?.Invoke(this, new ItemAddedEventArgs(item, true));
            return true;
        }
       
        return false;
    }
    
    public virtual void RemoveItem(Item item)
    {
        if(item != null)
        { 
            Items.Remove(item);

            onItemRemoved?.Invoke(this, new ItemAddedEventArgs(item, false));
        }
    }
}

public class ItemAddedEventArgs : EventArgs
{
    public Item item { get; }
    public bool isAdded { get; }

    public ItemAddedEventArgs(Item item, bool isAdded)
    {
        this.item = item;
        this.isAdded = isAdded;
    }
}
