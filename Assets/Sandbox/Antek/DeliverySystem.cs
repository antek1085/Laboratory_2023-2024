using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] private DeliveryList deliveryList;
    private Item deliveryItem;
    private GameObject itemToDeliver;

    private int listNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomDelivery());
    }

    IEnumerator RandomDelivery()
    {
        yield return new WaitForSeconds(30);
        listNumber = Random.Range(0, deliveryList.itemList.Count - 1);
        itemToDeliver =  deliveryList.itemList[listNumber].itemToSpawn;
        

    }
}
