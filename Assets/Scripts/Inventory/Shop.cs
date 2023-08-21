using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : Container
    {
        public string merchantTag = "Merchant1";
        public CanvasGroup shopUI;
        public GameObject itemPrefab;
        public List<ScriptableItem> ShopScriptableItem = new List<ScriptableItem>();
        
        public Merchant merchant;
        public bool IsOpen => shopUI.interactable;

        public Button close;
        public PanelAnimator uiManager = new();

        private void Awake() 
        {
            shopUI = GetComponent<CanvasGroup>();
            close.onClick.AddListener(() => OpenShop(false));
            FillShop();
        }
        
        public void OpenShop(bool boolean)
        {
            if(boolean)
            {
                uiManager.FadeInPanel();
            }
            else
            {
                uiManager.FadeOutPanel();
            }
            merchant.inventory.OpenInventory(boolean);
            shopUI.alpha = boolean ? 1 : 0;
            shopUI.interactable = boolean;
            shopUI.blocksRaycasts = boolean;
        }
        
        private void FillShop()
        {
            merchant = GameObject.FindGameObjectWithTag(merchantTag).GetComponent<Merchant>();
            foreach (var item in ShopScriptableItem)
            {
                GameObject itemInstance = Instantiate(itemPrefab, itemsContainer);
                Item itemComponent = itemInstance.GetComponent<Item>();
                itemComponent.merchant = merchant;
                itemComponent.scriptableItem = item;
                itemComponent.itemState = ItemState.InShop;
                itemComponent.img.sprite = item.itemSpriteUI;
                itemComponent.price = item.price;
                itemComponent.priceTxt.text = itemComponent.price.ToString();
                
                Items.Add(itemComponent);
            }
        }
    }
