using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySpace : MonoBehaviour
{
    public ItemID deliveredItemID;
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
            Debug.Log("3");
            deliveredItemID = other.GetComponent<ItemID>();
            Destroy(other);
        }
    }
}
