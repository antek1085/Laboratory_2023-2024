using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemRenovate : MonoBehaviour
{
    [SerializeField] SOFloat money;
    [SerializeReference] float price;
    private Transform textChild;
    private TextMeshProUGUI text;
    [SerializeField] Sprite spriteItem;
    [SerializeField] Sprite itemToChange;

    private void Start()
    {
        textChild = this.gameObject.transform.GetChild(0);
        Debug.Log(textChild.name);
        text = textChild.GetComponent<TextMeshProUGUI>();
        text.text = price.ToString();
    }

    public void BuyItem()
    {
        if (money.Value >= price)
        {
            money.Value -= price;
            itemToChange = spriteItem;
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
