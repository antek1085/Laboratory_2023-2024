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

    [SerializeField] private int miniGameId;

    void Start()
    {
        EventCraftMortar.current.onMiniGameEnd += OnMiniGameEnd;
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
            if (Input.GetKey(KeyCode.Space) && distance < 5)
            {
                EventCraftMortar.current.MiniGameStart(miniGameId);
                isCrafting = true;
                playerInputText.enabled = false;
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

        if (other.tag == "Player")
        {
            spriteRenderer.sprite = highLightItem;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Material")
        {
            spriteRenderer.sprite = normalItem;
            playerInputText.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = normalItem;
        }
    }

    IEnumerator ItemCraft(int i)
    {
        firstMaterial = null;
        Audio.Play("MortarEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(2);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        Audio.Play("BellRingEvent");
        isCrafting = false;
        StopAllCoroutines();
    }

    IEnumerator DungSpawn()
    {
        firstMaterial = null;
        Audio.Play("MortarEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(2);
        Instantiate(dung, itemSpawn.transform.position,itemSpawn.transform.rotation);
        Audio.Play("BellRingEvent");
        isCrafting = false;
        StopAllCoroutines();
    }

    private void OnMiniGameEnd(int miniGameId)
    {
        if (miniGameId == this.miniGameId)
        {
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

    private void OnDestroy()
    {
        EventCraftMortar.current.onMiniGameEnd -= OnMiniGameEnd;
    }
}
