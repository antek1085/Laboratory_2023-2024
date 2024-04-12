using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TabletController : MonoBehaviour
{
    [Header("Work Button")]
    [SerializeField] GameObject workButton;

    [Header("Plants Button")]
    [SerializeField] GameObject plantButton;

    [Header("Shop Button")]
    [SerializeField] GameObject shopButton;
    
    
    [SerializeField] Canvas canvas;
    int whatTab;

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

    public void WorkButton()
    {
        if (whatTab != 1)
        {
            whatTab = 1;
            workButton.SetActive(true);
            plantButton.SetActive(false);
            shopButton.SetActive(false);
        }
    }
    public void PlantButton()
    {
        if (whatTab != 2)
        {
            whatTab = 2;
            workButton.SetActive(false);
            plantButton.SetActive(true);
            shopButton.SetActive(false);
        }
    }
    public void ShopButton()
    {
        if (whatTab != 3)
        {
            whatTab = 3;
            workButton.SetActive(false);
            plantButton.SetActive(false);
            shopButton.SetActive(true);
        }
    }
}