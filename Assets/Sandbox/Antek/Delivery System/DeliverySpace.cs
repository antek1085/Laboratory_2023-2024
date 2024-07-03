using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySpace : MonoBehaviour
{
    public ItemID deliveredItemID;
    [SerializeField] TextMeshProUGUI text;

    private GameObject item;

    private bool isInTrigger;
    
    void Start()
    {
        text.enabled = false;
        isInTrigger = false;
    }

    
    void Update()
    {
        if (isInTrigger == true)
        {
            isInTrigger = false;
            deliveredItemID = item.GetComponent<ItemID>();
            item = item.gameObject;
            Audio.Play("KachingEvent");
            StartCoroutine(Destroy());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        {
            item = other.gameObject;
            text.enabled = true;
            if (Input.GetKey(KeyCode.R))
            {
                isInTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        item = null;
        text.enabled = false;
        isInTrigger = false;
    }

    IEnumerator Destroy()
    {
        text.enabled = false;
        yield return new WaitForSecondsRealtime(2);
        Destroy(item);
        StopCoroutine(Destroy());
    }
}
