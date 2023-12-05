using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] private deliveryListDEV deliveryListDev; 
    private ItemID newItem;
    [SerializeField] public List<Item> deliveryItemList = new List<Item>();
    [SerializeField] public List<float> deliverItemTimer = new List<float>();
    private bool isCorutineOn;

    [Header("Time for Designers")]
    [SerializeField] private float spawnTimeOfDelivery;
    [SerializeField] private float timeToDelivery;

    [SerializeField] private DeliverySpace deliverySpace;
    private ItemID deliveredItem;
    
    private int listNumber;

    private int deliveryItemNumber;

    [SerializeField] private SOFloat NumberOfPoins;
    // Start is called before the first frame update
    void Start()
    {
        isCorutineOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCorutineOn == false && deliveryItemList.Count <= 4)
        {
            isCorutineOn = true;
            StartCoroutine(RandomDelivery());
        }

        if (deliverySpace.deliveredItemID != null)
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

        if (deliverItemTimer.Count >= 1)
        {
            deliverItemTimer[0] -= Time.deltaTime;
        }
        if (deliverItemTimer.Count >= 2)
        {
            deliverItemTimer[1] -= Time.deltaTime;
        }
        if (deliverItemTimer.Count >= 3)
        {
            deliverItemTimer[2] -= Time.deltaTime;
        }
        if (deliverItemTimer.Count >= 4)
        {
            deliverItemTimer[3] -= Time.deltaTime;
        }
        if (deliverItemTimer.Count >= 5)
        {
            deliverItemTimer[4] -= Time.deltaTime;
        }
        
        
        
          for (int i = 0; i < deliverItemTimer.Count; i++)
          {
              if (deliverItemTimer[i] < 0)
              {
                  deliveryItemList.RemoveAt(i);
                  deliverItemTimer.RemoveAt(i);
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
       //deliveryItemList.Add(GameObject.Instantiate(newItem._item));
       //StartCoroutine(DeleteDeliveryItem());
        isCorutineOn = false;
    }

   /* IEnumerator DeleteDeliveryItem()
    {
        yield return new WaitForSeconds(timeToDelivery);
        deliveryItemList.RemoveAt(0);
    }*/
    
}
