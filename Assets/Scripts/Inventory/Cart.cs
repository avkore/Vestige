using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : Container
{
    public string merchantTag = "Merchant1"; 
    public TMPro.TMP_Text totalPriceTxt;
    public int totalPrice;
    public Merchant merchant;

    private void Awake()
    {
        totalPriceTxt.text = totalPrice.ToString();
            
        onItemAdded += UpdateCartPrice;
        onItemRemoved += UpdateCartPrice;

        merchant = GameObject.FindGameObjectWithTag(merchantTag).GetComponent<Merchant>();
    }
        
    public override bool AddItem(Item item, ItemState itemState)
    {
        base.AddItem(item, itemState);
        return true;
    }
        
    private void UpdateCartPrice(object sender, ItemAddedEventArgs e)
    { 
        if(e.isAdded) 
        { 
            totalPrice += e.item.price;
        }
        else
        {
            totalPrice -= e.item.price;
        }
        totalPriceTxt.text = totalPrice.ToString();
    }
    
    public void BuyCartItems()
    {
        bool openBubbleSpeech = Items.Count > 0;

        if(merchant.playerInventory.RemoveMoney(totalPrice))
        {
            merchant.OnEnoughMoney?.Invoke(this, null);
            foreach (var item in Items)
            {
                merchant.playerInventory.AddItem(item, ItemState.InInventory);
                onItemRemoved?.Invoke(this, new ItemAddedEventArgs(item, false));
                item.equipmentChanger = merchant.playerInventory.GetComponentInChildren<ClotheChanger>();
            }
            
            Items.Clear();
        }
        else
        {
            merchant.OnNotEnoughMoney?.Invoke(this, null);
        }
            
        if(openBubbleSpeech)
            StartCoroutine(merchant.Speech());
    }
    
}
