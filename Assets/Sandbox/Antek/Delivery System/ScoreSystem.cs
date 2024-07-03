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
    [SerializeField] private Transform player;
    public Dictionary<Quaternion, Vector3> playerValues = new Dictionary<Quaternion, Vector3>();


    [Header("End of level")]
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private string scene;
    [SerializeField] private TextMeshProUGUI endText;
    private Scene thisScene;
    [SerializeField] SOFloat SOmoney;

    void OnEnable()
    {
        EventSystemTimeScore.current.onMoneyAdded += OnMoneyAdded;
        EventSystemTimeScore.current.onGoingSleep += OnGoingSleep;
       
    }

    void OnDestroy()
    {
        EventSystemTimeScore.current.onMoneyAdded -= OnMoneyAdded;
        EventSystemTimeScore.current.onGoingSleep -= OnGoingSleep;
        
    }
    private void Start()
    {
        SaveSystemEvents.current.OnLoadGame += OnLoadGame;
        //rentToPay *= multiplier;
    }


    void OnMoneyAdded (float money)
    {
        numberOfMoney += money;
        numberOfMoneyEarnedToday += money;
        SOmoney.Value = numberOfMoney;
    }

    void OnGoingSleep(int dayPassed)
    {
        dayCount += dayPassed; 
        playerValues.Add(player.rotation,player.position);
        EventSystemTimeScore.current.EndDay(numberOfMoneyEarnedToday, rentToPay, rentPayDay);
        SaveSystemEvents.current.SaveGame(numberOfMoney,rentToPay,dayCount,playerValues);
        playerValues.Clear();
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

    void OnLoadGame(float rentAmount, int dayCount, Dictionary<Quaternion, Vector3> playerValuesSave)
    {
        rentToPay = rentAmount;
        this.dayCount = dayCount;
        //player.rotation = playerValues.GetEnumerator().Current.Key;
        //player.position = playerValues.GetEnumerator().Current.Value;
    }

    private void Update()
    {
        rentText.text = "Rent:" + numberOfMoney + " / " + rentToPay;
    }
    
}
