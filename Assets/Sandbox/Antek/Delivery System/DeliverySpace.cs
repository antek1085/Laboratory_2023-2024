using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySpace : MonoBehaviour
{
    public ItemID deliveredItemID;

    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                deliveredItemID = other.GetComponent<ItemID>();
                item = other.gameObject;
                StartCoroutine(Destroy());
            }
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(item);
        StopCoroutine(Destroy());
    }
}
