using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControler : MonoBehaviour
{
    [SerializeField] private List<GameObject> miniGamesList = new List<GameObject>();
     void Start()
    {
        EventCraftMortar.current.onMiniGameStart += onMiniGameStart;
        EventCraftMortar.current.onMiniGameEnd += onMiniGameEnd;
    }

    void onMiniGameStart(int id)
    {
        switch (id)
        {
            case 0:
                miniGamesList[id].SetActive(true);
                break;
            case 1:
                miniGamesList[id].SetActive(true);
                break;
            case 2:
                miniGamesList[id].SetActive(true);
                break;
        }
    }
    
    void onMiniGameEnd(int id)
    {
        switch (id)
        {
            case 0:
                miniGamesList[id].SetActive(false);
                break;
            case 1:
                miniGamesList[id].SetActive(false);
                break;
            case 2:
                miniGamesList[id].SetActive(false);
                break;
        }
    }
}
