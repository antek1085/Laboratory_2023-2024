using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = score.ToString() + " / 10";
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " / 10";
    }
    public void RemovePoint()
    {
        score -= 1;
        scoreText.text = score.ToString() + " / 10";
    }

    public void ResetPoint()
    {
        score = 0;
        scoreText.text = score.ToString() + " / 10";
    }
}
