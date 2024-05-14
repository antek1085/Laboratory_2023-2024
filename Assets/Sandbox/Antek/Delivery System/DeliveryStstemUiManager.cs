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
    private Sprite spriteDisplayOld;

  // [SerializeField] GameObject slider;
   [SerializeField] Image image;

   void Update()
    {
         if (time.deliveryItemList.Count >= numberOnUi + 1)
         {
             image.enabled = true;
             spriteDisplay = time.deliveryItemList[numberOnUi]._item.sprite;

             if (spriteDisplay != spriteDisplayOld)
             {
                 spriteDisplayOld = spriteDisplay;
             }
             
             image.sprite = spriteDisplay;
         }
         else
         {
             image.enabled = false;
         }
    }
}
