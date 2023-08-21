using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

 public class Item : MonoBehaviour
    {
        public ScriptableItem scriptableItem;
        public Image img;
        public Button itemBtn;
        public TMP_Text priceTxt;
        public int price;
        public Merchant merchant;
        public ClotheChanger equipmentChanger;

        public ItemState itemState;

        private void Start()
        {
            itemBtn.onClick.AddListener(HandleItemClick);
        }
        
        private void HandleItemClick()
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.buttonClick);
            
            if(itemState == ItemState.InShop)
            {
                if(merchant.cart.AddItem(this, ItemState.InCart))
                    merchant.shop.RemoveItem(this);
            }
            else if(itemState == ItemState.InCart)
            {
                merchant.shop.AddItem(this, ItemState.InShop);
                merchant.cart.RemoveItem(this);
            }
            else if(itemState == ItemState.InInventory)
            {
                if(merchant.shop.IsOpen && merchant.shop.IsOpen != null)
                {
                    Debug.Log("not null");
                    merchant.shop.AddItem(this, ItemState.InShop);
                    merchant.playerInventory.RemoveItem(this);
                    merchant.playerInventory.AddMoney(price);
                    merchant.OnItemBought?.Invoke(this, null);
                    StartCoroutine(merchant.Speech());
                }
                // else if(Shop.CurrentlyOpenShop != null)
                // {
                //     Shop.CurrentlyOpenShop.merchant.OnItemNotBought?.Invoke(this, null);
                //     StartCoroutine(Shop.CurrentlyOpenShop.merchant.Speech());
                // }
                else
                {
                    Item item = equipmentChanger.Equip(scriptableItem.itemType, scriptableItem.label);
                    merchant.playerInventory.equipment.AddItem(this, ItemState.Equipped);
                    merchant.playerInventory.RemoveItem(this);

                    merchant.playerInventory.equipment.RemoveItem(item);
                    merchant.playerInventory.AddItem(item, ItemState.InInventory);

                    merchant.OnItemNotBought?.Invoke(this, null);
                    StartCoroutine(merchant.Speech());
                }
                
            }
        }

    }

    [System.Serializable]
    public enum ItemState
    {
        InShop,
        InCart,
        InInventory,
        Equipped
    }
