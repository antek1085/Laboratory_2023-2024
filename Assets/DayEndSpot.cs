using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayEndSpot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interractionText;
    [SerializeField] GameObject dayEndingScreen;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interractionText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                EventSystemTimeScore.current.GoingSleep(1);
                dayEndingScreen.SetActive(true);
            }
        }
    }
}
