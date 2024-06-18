using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 instance;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowScore(0f);
    }

    public void ShowScore(float score)
    {
        scoreText.text = score.ToString("N0") + "%";
    }
}

