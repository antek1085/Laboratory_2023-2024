using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
    }


    public void OnClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
