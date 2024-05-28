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
       
        if (firstMaterial != null && secondMaterial != null && distance < 6)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKey(KeyCode.Space) && distance < 6)
            {
                isCrafting = true;
                playerInputText.enabled = false;
                EventCraftMortar.current.MiniGameStart(miniGameId);
            }
        }
        else if (secondMaterial != null && distance > 6)
        {
            playerInputText.enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material" && isCrafting == false && secondMaterial == null)
        { 
            if (distance < 6)
            {
                playerInputText.enabled = true;
                playerInputText.text = "Click R to insert the material";
            }
            else
            {
                playerInputText.enabled = false;
            }
            if(Input.GetKey(KeyCode.R) && distance < 6)
            {
                Debug.Log("1");
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
        Debug.Log("Sadwitch");
        firstMaterial = null; secondMaterial = null;
        Audio.Play("PillcutterEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(2);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        Audio.Play("BellRingEvent");
        isCrafting = false;
        StopAllCoroutines();
    }

    IEnumerator DungSpawn()
    {
        firstMaterial = null; secondMaterial = null;
        Audio.Play("PillcutterEvent"); //MJ - Nieprzetestowane
        yield return new WaitForSeconds(2);
        Instantiate(dung, itemSpawn.transform.position,itemSpawn.transform.rotation);
        Audio.Play("BellRingEvent");
        isCrafting = false;
        StopAllCoroutines();
    }


    void OnMiniGameEnd(int miniGameId)
    {
        if (miniGameId == this.miniGameId)
        {
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
}
