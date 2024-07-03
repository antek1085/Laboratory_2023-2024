 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Image = UnityEngine.UI.Image;

public class TabletController : MonoBehaviour
{
    [Header("Work Button")]
    [SerializeField] GameObject workButton;

    [Header("Plants Button")]
    [SerializeField] GameObject plantButton;

    [Header("Shop Button")]
    [SerializeField] GameObject shopButton;
    
    [Header("Tutorial Button")]
    [SerializeField] GameObject tutorialButton;

    [Header("Start Day Button")]
    [SerializeField] GameObject startButton;

    [Header("Close Button")]
    [SerializeField] GameObject closeButton;


    [SerializeField] Canvas canvas;
    int whatTab;

    public bool isPlayerInRange;
    
    [SerializeField] Sprite highLightItem;
    [SerializeField] TextMeshProUGUI playerInputText;
    private Sprite normalItem;
    private SpriteRenderer spriteRenderer;
    private bool isGamePaused;

    public ClockUI isTimeFlowing;
    void Start()
    {
        EventSystemTimeScore.current.onGoingSleep += OnGoingSleep;
        isGamePaused = false;
        canvas.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalItem = spriteRenderer.sprite;
    }
    
    void Update()
    {
        
        if (isPlayerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isGamePaused == false)
            {
                isTimeFlowing.isTimeFlowing = false;
                canvas.enabled = true;
                Time.timeScale = 0;
                isGamePaused = true;
            }
            else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && isGamePaused == true)
            {
                isTimeFlowing.isTimeFlowing = true;
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
            playerInputText.enabled = true;
            playerInputText.text = "Press E to interact";
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = normalItem;
            isPlayerInRange = false;
            playerInputText.enabled = false;
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
            tutorialButton.SetActive(false);
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
            tutorialButton.SetActive(false);
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
            tutorialButton.SetActive(false);
        }
    }

    public void TutorialButton()
    {
        if (whatTab != 4)
        {
            whatTab = 4;
            workButton.SetActive(false);
            plantButton.SetActive(false);
            shopButton.SetActive(false);
            tutorialButton.SetActive(true);
        }
    }

    public void CloseButton()
    {
        isTimeFlowing.isTimeFlowing = true;
        isGamePaused = false;
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void StartWorkingDay()
    {
        EventSystemTimeScore.current.TimeStart(true);
        startButton.SetActive(false);
    }

    void OnGoingSleep(int i)
    {
        startButton.SetActive(false);
    }
}
