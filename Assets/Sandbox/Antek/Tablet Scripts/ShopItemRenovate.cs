using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemRenovate : MonoBehaviour
{
    [SerializeField] SOFloat money;
    [SerializeReference] float price;
    private Transform textChild;
    private TextMeshProUGUI text;
    [SerializeField] Sprite spriteItem;
    [SerializeField] SpriteRenderer itemToChange;

    bool isItemBought;

    private void Start()
    {
        textChild = this.gameObject.transform.GetChild(0);
        text = textChild.GetComponent<TextMeshProUGUI>();
        text.text = price.ToString();
        isItemBought = false;
    }

    public void BuyItem()
    {
        if (money.Value >= price && isItemBought == false)
        {
            money.Value -= price;
            itemToChange.sprite = spriteItem;
            //this.gameObject.GetComponent<Button>().interactable = false;
            isItemBought = true;
            text.text = null;
        }
        if (isItemBought == true)
        {
            itemToChange.sprite = spriteItem;
        }
    }
    
}
