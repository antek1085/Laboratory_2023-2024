using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DeliverySystem : MonoBehaviour
{
    [Header("List of items to deliver")]
    [SerializeField] private deliveryListDEV deliveryListDev; 
    private ItemID newItem;
    
    [Header("Don't Touch")]
    public List<ItemID> deliveryItemList = new List<ItemID>();
    private bool isCorutineOn;

    [Header("Time for Designers")]
    [SerializeField] private float spawnTimeOfDelivery;

    [Header("Place to Deliver")]
    [SerializeField] private DeliverySpace deliverySpace;
    private ItemID deliveredItem;
    
    private int listNumber;

    private int deliveryItemNumber;
    [Header("Score")]
    [SerializeField] private SOFloat playerMoney;

    private float itemValue;

    int procentValue;
    bool isThereTime = false;
    
    
    
    void Start()
    {
        EventSystemTimeScore.current.onTimeEnd += OnTimeEnd;
        EventSystemTimeScore.current.onTimeStart += OnTimeStart;
        isCorutineOn = false;
    }
    
    void Update()
    {
        if (isCorutineOn == false && deliveryItemList.Count < 2 && isThereTime == true)
        {
            isCorutineOn = true;
            StartCoroutine(RandomDelivery());
        }

        if (deliverySpace.deliveredItemID != null)
        {
            ItemDeliveredCheck();
        }
        
        
          /*for (int i = 0; i < deliveryItemList.Count; i++)
          {
              StartCoroutine(DeleteDeliveryItem(i));
          }*/
    }
    
    IEnumerator RandomDelivery()
    {
        yield return new WaitForSeconds(spawnTimeOfDelivery);
        listNumber = Random.Range(0, deliveryListDev.itemList.Count -1);
        newItem = deliveryListDev.itemList[listNumber];
        //deliveryItemList.Add(newItem._item);
        deliveryItemList.Add(newItem);
        isCorutineOn = false;
    }

    IEnumerator DeleteDeliveryItem(int i)
    {
        yield return new WaitForEndOfFrame();
        deliveryItemList.RemoveAt(i);
        StopCoroutine(DeleteDeliveryItem(i));
    }

    private void ItemDeliveredCheck()
    {
        deliveredItem = deliverySpace.deliveredItemID;
        deliverySpace.deliveredItemID = null;
            
        if (deliveredItem != null)
        {
            IEnumerable<itemSymptoms> resoult = deliveryItemList[0].symptoms.Intersect(deliveredItem.symptoms);

            procentValue = deliveryItemList[0].symptoms.Count() / resoult.Count() * 100;
            
            itemValue = deliveredItem.GetComponent<ItemID>().moneyValue;
            itemValue *= procentValue;
            deliveredItem = null;
            deliveryItemList.RemoveAt(0);
            deliveryItemNumber = -1;
            EventSystemTimeScore.current.MoneyAdded(itemValue);
        }
    }

    void OnTimeStart(bool time)
    {
        isThereTime = time;
        deliveryItemList.Clear();
    }

    void OnTimeEnd(bool time)
    {
        isThereTime = time;
        deliveryItemList.Clear();
    }
}
