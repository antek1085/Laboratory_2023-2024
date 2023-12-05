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
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        {
            text.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                deliveredItemID = other.GetComponent<ItemID>();
                item = other.gameObject;
                StartCoroutine(Destroy());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        text.enabled = false;
    }

    IEnumerator Destroy()
    {
        text.enabled = false;
        yield return new WaitForEndOfFrame();
        Destroy(item);
        StopCoroutine(Destroy());
    }
}
