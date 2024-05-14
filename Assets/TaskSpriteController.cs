using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpriteController : MonoBehaviour
{
    public DeliverySystem deliveryItemList;

    [SerializeField] private List<SOGameObjectList> spriteLits = new List<SOGameObjectList>();
    [SerializeField] private List<SymptomsSpriteList> gameObjectsList = new List<SymptomsSpriteList>();

    void Start()
    {
        
        for (int i = 0; i < spriteLits.Count -1; i++)
        {
            for (int j = 0; j < spriteLits.Count -1; j++)
            {
                gameObjectsList[i].TasksSpritesSymptoms[j].sprite = deliveryItemList.deliveryItemList[i].SpritesSymptoms[j];
            }
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < spriteLits.Count -1; i++)
        {
            for (int j = 0; j < spriteLits.Count -1; j++)
            {
                gameObjectsList[i].TasksSpritesSymptoms[j].sprite = deliveryItemList.deliveryItemList[i].SpritesSymptoms[j];
            }
        }
    }
    
}
