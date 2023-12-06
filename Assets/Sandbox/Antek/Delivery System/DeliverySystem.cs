using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

public class DeliverySystem : MonoBehaviour
{
    [Header("List of items to deliver")]
    [SerializeField] private deliveryListDEV deliveryListDev; 
    private ItemID newItem;
    
    [Header("Don't Touch")]
    public List<Item> deliveryItemList = new List<Item>();
    public List<float> deliverItemTimer = new List<float>();
    private bool isCorutineOn;

    [Header("Time for Designers")]
    [SerializeField] private float spawnTimeOfDelivery;

    [Header("Place to Deliver")]
    [SerializeField] private DeliverySpace deliverySpace;
    private ItemID deliveredItem;
    
    private int listNumber;

    private int deliveryItemNumber;
    [Header("Score")]
    [SerializeField] private SOFloat NumberOfPoins;
    
    void Start()
    {
        isCorutineOn = false;
    }
    
    void Update()
    {
        if (isCorutineOn == false && deliveryItemList.Count <= 4)
        {
            isCorutineOn = true;
            StartCoroutine(RandomDelivery());
        }

        if (deliverySpace.deliveredItemID != null)
        {
            ItemDeliveredCheck();
        }
        
        
          for (int i = 0; i < deliveryItemList.Count; i++)
          {
              deliverItemTimer[i] -= Time.deltaTime;
              if (deliverItemTimer[i] < 0)
              {
                  StartCoroutine(DeleteDeliveryItem(i));
              }
          }
    }
    
    IEnumerator RandomDelivery()
    {
        yield return new WaitForSeconds(spawnTimeOfDelivery);
        listNumber = Random.Range(0, deliveryListDev.itemList.Count -1);
        newItem = deliveryListDev.itemList[listNumber];
        deliveryItemList.Add(newItem._item);
        deliverItemTimer.Add(newItem.time);
        isCorutineOn = false;
    }

    IEnumerator DeleteDeliveryItem(int i)
    {
        yield return new WaitForEndOfFrame();
        deliveryItemList.RemoveAt(i);
        deliverItemTimer.RemoveAt(i);
    }

    private void ItemDeliveredCheck()
    {
        deliveredItem = deliverySpace.deliveredItemID;
        deliverySpace.deliveredItemID = null;
            
        if (deliveredItem != null)
        {
            deliveryItemNumber = deliveryItemList.IndexOf(deliveredItem._item);
            deliveredItem = null;
            if (deliveryItemNumber != -1)
            {
                deliveryItemList.RemoveAt(deliveryItemNumber);                          
                deliverItemTimer.RemoveAt(deliveryItemNumber);
                deliveryItemNumber = -1;
                NumberOfPoins.Value += 1;
            }
        }
    }
}
