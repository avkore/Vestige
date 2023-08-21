using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public Shop shop;
    public Cart cart;
    public Inventory inventory;
    public PlayerInventory playerInventory;
    
    public RectTransform messagePopup;
    public Transform speech;
    
    public Vector2 offset;
    public Vector2 speechOffset;

    public Button noBtn;
    public Button yesBtn;

    public PanelAnimator shopDotweens = new();
    public PanelAnimator speechTween = new();
    
    public EventHandler OnEnoughMoney;
    public EventHandler OnNotEnoughMoney;
    public EventHandler OnItemBought;
    public EventHandler OnItemNotBought;

    private void Awake()
    {
        shop.merchant = this;
        cart.merchant = this;

        noBtn.onClick.AddListener(() => ShowPopup(false));
        yesBtn.onClick.AddListener(() => OpenShop(true));

        OnNotEnoughMoney += NotEnoughMoney;
        OnEnoughMoney += EnoughMoney;
        OnItemNotBought += ItemNotBought;
        OnItemBought += ItemBought;
    }

    private void ChangeSpeechBubbleText(string text)
    {
        speech.GetComponentInChildren<TMPro.TMP_Text>().text = text;
    }
    
    private void ItemNotBought(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Sorry! Find the right shopkeeper!");
    }

    private void ItemBought(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Nice Trade. Thanks for the item!");
    }

    private void NotEnoughMoney(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Hmm, Sorry! I Think You don't have enough money!");
    }
    
    private void EnoughMoney(object sender, EventArgs e)
    {
        ChangeSpeechBubbleText("Thank you For your purchase hero. Come again!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInventory = other.GetComponent<PlayerInventory>();
            inventory.UpdateMoney(playerInventory.money);
            ShowPopup(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ShowPopup(false);

            if(shop.IsOpen)
                OpenShop(false);
        }
    }

    private void ShowPopup(bool boolean)
    {
        if(boolean) 
        {
            shopDotweens.FadeInPanel();
            if(shop.Items.Count == 0)
                messagePopup.GetComponentInChildren<TMPro.TMP_Text>().text = "Ahh, I don't have more items to sell. Maybe you can sell me some!";
            else
                messagePopup.GetComponentInChildren<TMPro.TMP_Text>().text = "Hello! Would you like to trade some cool items with me?";
        }
        else shopDotweens.FadeOutPanel();
    }

    private void OpenShop(bool boolean)
    {
        ShowPopup(false);
        shop.OpenShop(boolean);
    }
    
    void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        messagePopup.position = new Vector3(screenPos.x + offset.x, screenPos.y + offset.y, 0);
        speech.position = new Vector3(screenPos.x + speechOffset.x, screenPos.y + speechOffset.y, 0);
    }
    
    public IEnumerator Speech()
    {
        speechTween.FadeInPanel();
        yield return new WaitForSeconds(2f);
        speechTween.FadeOutPanel();
    }
}
