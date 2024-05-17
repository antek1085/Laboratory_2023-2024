using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpriteController : MonoBehaviour
{
    public DeliverySystem deliveryItemList;
    
    [SerializeField] private List<SymptomsSpriteList> gameObjectsList = new List<SymptomsSpriteList>();
    [SerializeField] TabletController isPlayerinRange;

    void OnEnable()
    {
        for (int i = 0; i < deliveryItemList.deliveryItemList.Count; i++)
        {
            Debug.Log(i +"i");
            for (int j = 0; j < deliveryItemList.deliveryItemList[i].SpritesSymptoms.Count ; j++)
            {
                Debug.Log(i +"j");
                gameObjectsList[i].TasksSpritesSymptoms[j].sprite = deliveryItemList.deliveryItemList[i].SpritesSymptoms[j];
            }
        }
    }

    void Update()
    {
        if (isPlayerinRange.isPlayerInRange == true)
        {
            for (int i = 0; i < deliveryItemList.deliveryItemList.Count; i++)
            {
                Debug.Log(i +"i");
                for (int j = 0; j < deliveryItemList.deliveryItemList[i].SpritesSymptoms.Count ; j++)
                {
                    Debug.Log(i +"j");
                    gameObjectsList[i].TasksSpritesSymptoms[j].sprite = deliveryItemList.deliveryItemList[i].SpritesSymptoms[j];
                }
            }
        }
    }

}
