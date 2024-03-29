using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TabletController : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private bool isPlayerInRange;
    
    [SerializeField] Sprite highLightItem;
    private Sprite normalItem;
    private SpriteRenderer spriteRenderer;
    private bool isGamePaused;
    
    void Start()
    {
        isGamePaused = false;
        canvas.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalItem = spriteRenderer.sprite;
    }
    
    void Update()
    {
        
        if (isPlayerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.R) && isGamePaused == false) 
            {
                canvas.enabled = true;
                Time.timeScale = 0;
                isGamePaused = true;
            }
            else if (Input.GetKeyDown(KeyCode.R) && isGamePaused == true)
            {
                isGamePaused = false;
                Time.timeScale = 1;
                canvas.enabled = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = highLightItem;
            isPlayerInRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = normalItem;
            isPlayerInRange = false; 
        }
    }
}
