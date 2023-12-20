using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class DeliveryStstemUiManager : MonoBehaviour
{
    [Header("Number on UI (Numbered like list from 0)")]
    [SerializeField] int numberOnUi;

    [SerializeField] DeliverySystem time;

    float timer;
    private Sprite spriteDisplay;

   [SerializeField] GameObject slider;
   [SerializeField] Image image;
   private bool isValueChanged;

   void Update()
    {
        if (time.deliveryItemList.Count >= numberOnUi + 1)
        {
            image.enabled = true;
            slider.SetActive(true);
            timer = time.deliverItemTimer[numberOnUi];
            spriteDisplay = time.deliveryItemList[numberOnUi].sprite;
            
            slider.GetComponent<Slider>().value = timer;
            
            // if (isValueChanged == false)
            // {
            //     isValueChanged = true;
            //     slider.GetComponent<Slider>().maxValue = timer;
            // }
            
            image.sprite = spriteDisplay;
        }
        else
        {
            isValueChanged = false;
            image.enabled = false;
            slider.SetActive(false);
        }
    }
}
