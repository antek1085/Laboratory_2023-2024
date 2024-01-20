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
    
    [SerializeField] Sprite highLightItem;
    private Sprite normalItem;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalItem = spriteRenderer.sprite;
    }
    
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
       
        if (firstMaterial != null && distance < 5)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKeyUp(KeyCode.Space) && distance < 5)
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
        else if (firstMaterial != null && distance > 5)
        {
            playerInputText.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material" && isCrafting == false && firstMaterial == null)
        {
            if (distance < 5)
            {
                 playerInputText.enabled = true;
                 playerInputText.text = "Click R to insert the material";
                 spriteRenderer.sprite = highLightItem;

            }
            else
            {
                playerInputText.enabled = false;
            }
           
            if (Input.GetKey(KeyCode.R) && distance < 5)
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
            spriteRenderer.sprite = normalItem;
            playerInputText.enabled = false;
        }
    }

    IEnumerator ItemCraft(int i)
    {
        firstMaterial = null;
        Audio.Play("MortarEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(5);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }

    IEnumerator DungSpawn()
    {
        firstMaterial = null;
        Audio.Play("MortarEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(5);
        Instantiate(dung, itemSpawn.transform.position,itemSpawn.transform.rotation);
        isCrafting = false;
        StopAllCoroutines();
    }
}
