using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    protected const float ScoreLimit = 100f;
    [SerializeField] public float CheckRate = 5f;
    protected float countdownTime = ScoreLimit;
    private bool countingDown = false;
    [SerializeField] int miniGameId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        countingDown = true;
        Debug.Log("Countdown started");
        Audio.Play("SucessEvent");
        StartCoroutine(StartCountdown());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        countingDown = false;
        StopAllCoroutines();
        Audio.Play("FailEvent");
        Debug.Log("Countdown stopped");
    }
    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0 && countingDown)
        {
             Debug.Log("Time left: " + countdownTime.ToString("F1") + " seconds");
            yield return new WaitForSecondsRealtime(1f/CheckRate);
            countdownTime -= 1f;
            ShowScore();
        }
        ShowScore();
        EventCraftMortar.current.MiniGameEnd(miniGameId);
        countdownTime = ScoreLimit;

    }

    private void ShowScore()
    {
        float display = ScoreLimit - countdownTime;
        if (display > 100) display = 100;
        if (display < 0) display = 0;
        UIManager2.instance.ShowScore(display);
    }
}
