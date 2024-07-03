using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MortarCraftingStation : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI playerInputText ;
    [SerializeField] GameObject itemSpawn;
    [SerializeField] GameObject dung;
    
    private Item firstMaterial;
    private Item firstItem;
    [SerializeField] ItemsDBOneIngridient recipeList;
    [SerializeField] Transform playerTransform;
    [SerializeField] private List<Image> imageList;
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
        for (int j = 0; j < imageList.Count -1; j++)
        {
            imageList[j].enabled = false;
        }
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
                imageList[0].sprite = null;
                imageList[0].enabled = false;
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
                imageList[0].enabled = true;
                imageList[0].sprite = other.GetComponent<ItemID>()._item.sprite;
                playerInputText.enabled = false;
                Destroy(other.gameObject);
                Audio.Play("PlaceDownEvent");
            }
            if (Input.GetKey(KeyCode.F) && distance < 5)
            {
                imageList[0].enabled = false;
                imageList[0].sprite = null;
                firstItem = null;
            }
        }

        if (other.tag == "Player")
        {
            imageList[0].enabled = true;
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
            imageList[0].enabled = false;
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
