using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MortarCraftingStation : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI playerInputText ;
    [SerializeField] GameObject itemSpawn;
    [SerializeField] GameObject dung;
    
    private Item firstMaterial;
    private Item firstItem;
    [SerializeField] ItemsDBOneIngridient recipeList;
    [SerializeField] Transform playerTransform;
    private float distance;
    private bool isCrafting = false;

    void Start()
    {
    }
    
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
       
        if (firstMaterial != null && distance < 2)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKeyUp(KeyCode.Space) && distance < 2)
            {
                isCrafting = true;
                playerInputText.enabled = false;
              for (int i = 0; i < recipeList.itemList.Count; i++)
              {
                  firstItem = recipeList.itemList[i].FirstItem;
                  if (firstMaterial == firstItem)
                  { 
                      StartCoroutine(ItemCraft(i)); 
                      break;
                  }
              }
              
              if (firstMaterial != null)
              {
                    StartCoroutine(DungSpawn());
              }  
            }
        }
        else if (firstMaterial != null && distance > 2)
        {
            playerInputText.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material" && isCrafting == false && firstMaterial == null)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click R to insert the material";
            if (Input.GetKey(KeyCode.R) && distance < 2)
            {
                firstMaterial = other.GetComponent<ItemID>()._item;
                playerInputText.enabled = false;
                Destroy(other.gameObject);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Material")
        {
            playerInputText.enabled = false;
        }
    }

    IEnumerator ItemCraft(int i)
    {
        firstMaterial = null;
        yield return new WaitForSeconds(5);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }

    IEnumerator DungSpawn()
    {
        firstMaterial = null;
        yield return new WaitForSeconds(5);
        Instantiate(dung, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }
}
