using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayEndSpot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interractionText;
    [SerializeField] GameObject dayEndingScreen;
    [SerializeField] GameObject endingScreenLoosing;
    [SerializeField] GameObject endingScreenContinuing;

    //[Header("Ending Screen values")]
    float moneyEarnedToday;
    float rent;
    [SerializeField] int dayPassed;
    [SerializeField] int rentPayDay = 99;
    Scene thisScene;
    
    [SerializeField] private SOInt SaveFileNumber;
    static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    bool canHePayRent;
    void Start()
    {
        EventSystemTimeScore.current.onEndDay += OnEndDay;
        EventSystemTimeScore.current.onPayRent += OnPayRent;
        thisScene = SceneManager.GetActiveScene();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interractionText.enabled = true;
            if (Input.GetKeyUp(KeyCode.R))
            {
                dayPassed++;
                EventSystemTimeScore.current.GoingSleep(1);
                if (dayPassed % rentPayDay == 0)
                {
                    if (canHePayRent == false)
                    {
                        endingScreenLoosing.SetActive(true);
                    }
                }
                else
                {
                    endingScreenContinuing.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interractionText.enabled = false;
        }   
    }

    void OnEndDay(float moneyEarned, float rentToPay,int rentPayDayE)
    {
        moneyEarnedToday = moneyEarned;
        rent = rentToPay;
        rentPayDay = rentPayDayE;
    }

    void OnPayRent(bool canPayRent)
    {
        canHePayRent = canPayRent;
    }

     public void ResetLevel()
     {
         File.Delete(SAVE_FOLDER + "/save" + SaveFileNumber.value + ".txt");
         SceneManager.LoadScene("Antek StartMenu");
     }

     public void NextDay()
     {
         endingScreenContinuing.SetActive(false);
     }
}
