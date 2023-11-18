using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PillsCraftingStation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInputText;
    [SerializeField] GameObject itemSpawn;
    [SerializeField] GameObject dung;
    
    private Item firstMaterial;
    private Item secondMaterial;
    private Item firstItem;
    private Item secondItem;
    [SerializeField] private ItemsDBTwoIngridients recipeList;
    
    [SerializeField] Transform playerTransform;
    private float distance;
    private bool isCrafting = false;

    void Start()
    {
    }
    
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
       
        if (firstMaterial != null && secondMaterial != null && distance < 2)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKeyDown(KeyCode.Space) && distance < 2)
            {
                isCrafting = true;
                playerInputText.enabled = false;
              for (int i = 0; i < recipeList.itemList.Count; i++)
              {
                  Debug.Log("Loop");
                  firstItem = recipeList.itemList[i].FirstItem;
                  secondItem = recipeList.itemList[i].SeconItem;
                  if (firstMaterial == firstItem && secondMaterial == secondItem)
                  {
                      StartCoroutine(ItemCraft(i));
                      break;
                  }
                  if (secondMaterial == firstItem && firstMaterial == secondItem)
                  {
                      StartCoroutine(ItemCraft(i));
                      break;
                  } 
              }
              if (firstMaterial != null && secondMaterial != null)
              {
                  StartCoroutine(DungSpawn());
              }  
            }
        }
        else if (secondMaterial != null && distance > 2)
        {
            playerInputText.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material" && isCrafting == false && secondMaterial == null)
        { 
            playerInputText.enabled = true;
            playerInputText.text = "Click R to insert the material";
            if(Input.GetKeyUp(KeyCode.R) && distance < 2)
            {
                if (firstMaterial != null)
              {
                  secondMaterial = other.GetComponent<ItemID>()._item;
              }
              else
              {
                  firstMaterial = other.GetComponent<ItemID>()._item;
              }
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
        Debug.Log("Sadwitch");
        firstMaterial = null; secondMaterial = null;
        yield return new WaitForSeconds(5);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }

    IEnumerator DungSpawn()
    {
        firstMaterial = null; secondMaterial = null;
        yield return new WaitForSeconds(5);
        Instantiate(dung, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }
}
