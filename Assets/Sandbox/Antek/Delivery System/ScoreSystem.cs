using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float numberOfMoney;
    [SerializeField] private float numberOfMoneyEarnedToday;
    [SerializeField] private TextMeshProUGUI rentText;
    [SerializeField] private float rentToPay;
    private float multiplier = 1.5f;
    private int dayCount;

    [SerializeField] private int rentPayDay;


    [Header("End of level")]
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private string scene;
    [SerializeField] private TextMeshProUGUI endText;
    private Scene thisScene;
    [SerializeField] SOFloat SOmoney;


    private void Start()
    {
        EventSystemTimeScore.current.onMoneyAdded += OnMoneyAdded;
        EventSystemTimeScore.current.onGoingSleep += OnGoingSleep;
        //rentToPay *= multiplier;
    }


    void OnMoneyAdded (float money)
    {
        numberOfMoney += money;
        numberOfMoneyEarnedToday += money;
    }

    void OnGoingSleep(int dayPassed)
    {
        dayCount += dayPassed;
        EventSystemTimeScore.current.EndDay(numberOfMoneyEarnedToday, rentToPay, rentPayDay);
        SaveSystemEvents.current.SaveGame(numberOfMoney,rentToPay,dayCount);
        if (dayCount % rentPayDay == 0)
        {
            if (rentToPay > numberOfMoney)
            {
                EventSystemTimeScore.current.PayRent(false);
            }
            else
            {
                EventSystemTimeScore.current.PayRent(true);
            }
        }
    }

    private void Update()
    {
        SOmoney.Value = numberOfMoney;
        rentText.text = "Rent:" + numberOfMoney + " / " + rentToPay;
    }
    
}
