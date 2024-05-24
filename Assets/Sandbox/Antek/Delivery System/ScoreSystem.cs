using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float numberOfMoney;
    [SerializeField] private TextMeshProUGUI rentText;
    [SerializeField] private float rentToPay;
    private float multiplier = 1.5f;
    

    [Header("End of level")]
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private string scene;
    [SerializeField] private TextMeshProUGUI endText;
    private Scene thisScene;


    private void Start()
    {
        EventSystemTimeScore.current.onMoneyAdded += OnMoneyAdded;
        rentToPay *= multiplier;
    }


    void OnMoneyAdded (float money)
    {
        numberOfMoney += money;
    }

    private void Update()
    {
        rentText.text = "Rent:" + numberOfMoney + " / " + rentToPay;
    }
}
