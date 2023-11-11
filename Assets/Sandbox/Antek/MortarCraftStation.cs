using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MortarCraftStation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInputText;
    float itemsID;
    [SerializeField] GameObject itemSpawn;
   
    [SerializeField] GameObject item;
    void Start()
    {
        playerInputText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if statement by sie przydał
        switch (itemsID)
        {
            case 1:
                StartCoroutine(ItemCraft());
                itemsID = 0;
                break;
            case 2:
                StartCoroutine(ItemCraft());
                itemsID = 0;
                break;
            case 3:
                StartCoroutine(ItemCraft());
                itemsID = 0;
                break;
            case 4:
                StartCoroutine(ItemCraft());
                itemsID = 0;
                break;
            default:
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        { 
            playerInputText.enabled = true;
           
            if(Input.GetKeyDown(KeyCode.E))
            {
              itemsID = other.GetComponent<ItemID>().iD;
              playerInputText.enabled = false;
              // dodać bool
              Destroy(other.gameObject);
            }
        }
    }

    IEnumerator ItemCraft()
    {
        yield return new WaitForSeconds(5);
        Instantiate(item, itemSpawn.transform.position,itemSpawn.transform.rotation);
        StopAllCoroutines();
    }
}
