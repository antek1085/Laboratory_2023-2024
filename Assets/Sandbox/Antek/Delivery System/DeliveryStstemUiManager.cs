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
    [SerializeField] int numberOnUi;

    [SerializeField] DeliverySystem time, sprite;

    float timer;
    Sprite spriteDisplay;

   [SerializeField] GameObject slider;
   [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.deliveryItemList.Count >= numberOnUi + 1)
        {
            image.enabled = true;
            slider.SetActive(true);
            timer = time.deliverItemTimer[numberOnUi];
            spriteDisplay = sprite.deliveryItemList[numberOnUi].sprite;
            
            slider.GetComponent<Slider>().value = timer;
            image.sprite = spriteDisplay;
        }
        else
        {
            image.enabled = false;
            slider.SetActive(false);

        }
    }
}
