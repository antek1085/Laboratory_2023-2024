using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItemControllerUI : MonoBehaviour
{
    [SerializeField] private SOSprite sprite;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite.sprite != null)
        {
            image.enabled = true;
            image.sprite = sprite.sprite;
        }
        else
        {
            image.sprite = null;
            image.enabled = false;
        }
    }
}
