using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 5f;
    private bool countingDown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        countingDown = true;
        Debug.Log("Countdown started");
        StartCoroutine(StartCountdown());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        countingDown = false;
        StopAllCoroutines();
        Debug.Log("Countdown stopped");
    }
    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0 && countingDown)
        {
            Debug.Log("Time left: " + countdownTime.ToString("F1") + " seconds");
            yield return new WaitForSeconds(1f);
            countdownTime -= 1f;
        }
        Debug.Log("Countdown finished");
    }

    
}
