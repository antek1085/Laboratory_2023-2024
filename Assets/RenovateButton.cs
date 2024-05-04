using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RenovateButton : MonoBehaviour
{
    [SerializeField] SOFloat money;
    [SerializeField] Sprite cleanRoom;
    [SerializeField] SpriteRenderer room;
    [SerializeField] float renovateCost;
    [SerializeField] GameObject renovateButton;
    [SerializeField] GameObject renovateContent;
    
    private Transform textChild;
    private TextMeshProUGUI text;

    void Start()
    {
        textChild = this.gameObject.transform.GetChild(0);
        text = textChild.GetComponent<TextMeshProUGUI>();
        text.text = renovateCost.ToString() + "$";
    }

    public void Renovate()
    {
        if (money.Value >= renovateCost)
        {
            money.Value -= renovateCost;
            renovateButton.SetActive(false);
            renovateContent.SetActive(true);
            room.sprite = cleanRoom;
        }
    }
}
