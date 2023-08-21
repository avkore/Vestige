using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Container
{
    public int money = 100;
    public Inventory inventory;
    public Equipment equipment;

    private void Awake()
    {
        inventory.UpdateMoney(money);
    }
    
    public void AddMoney(int amount)
    {
        money += amount;
        inventory.UpdateMoney(money);
    }

    public bool RemoveMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;
            inventory.UpdateMoney(money);
            return true;
        }
        return false;
    }

}
