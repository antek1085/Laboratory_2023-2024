using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] private deliveryListDEV deliveryListDev; 
    private ItemID newItem;
    [SerializeField] private List<Item> deliveryItemList = new List<Item>();
    private bool isCorutineOn;

    [Header("Time for Designers")]
    [SerializeField] private float spawnTimeOfDelivery;
    [SerializeField] private float timeToDelivery;

    [SerializeField] private DeliverySpace deliverySpace;
    private float deliveredItem;
    
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

        if (deliverySpace.deliveredItemID != -1)
        {
            deliveredItem = deliverySpace.deliveredItemID;
            deliverySpace.deliveredItemID = -1;
            Debug.Log("1");
            if (deliveredItem != null)
            {
                Debug.Log("2");
                deliveryItemNumber = deliveryItemList.IndexOf(deliveredItem.);
                //Different Instance
                Debug.Log(deliveryItemNumber);
                deliveredItem = null;
                deliveryItemList.RemoveAt(deliveryItemNumber);
                deliveryItemNumber = -1;
                NumberOfPoins.Value += 1;

            }
        }
       
    }
    IEnumerator RandomDelivery()
    {
        yield return new WaitForSeconds(spawnTimeOfDelivery);
        listNumber = Random.Range(0, deliveryListDev.itemList.Count -1);
        newItem = deliveryListDev.itemList[listNumber];
        deliveryItemList.Add(GameObject.Instantiate(newItem._item));
        StartCoroutine(DeleteDeliveryItem());
        isCorutineOn = false;
    }

    IEnumerator DeleteDeliveryItem()
    {
        yield return new WaitForSeconds(timeToDelivery);
        deliveryItemList.RemoveAt(0);
    }
    
}
