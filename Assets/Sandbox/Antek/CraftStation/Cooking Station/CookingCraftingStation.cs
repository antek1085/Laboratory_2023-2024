using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CookingCraftingStation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInputText;
    [SerializeField] GameObject itemSpawn;
    [SerializeField] GameObject dung;

    private Item firstMaterial;
    private Item secondMaterial;
    private Item thirdMaterial;
    private Item firstItem;
    private Item secondItem;
    private Item thirdItem;

    [SerializeField] private ItemDBThreeIngridients recipeList;
    
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

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
        if (firstMaterial != null && secondMaterial != null && thirdMaterial != null && distance < 2)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKey(KeyCode.Space) && distance < 6)
            {
                isCrafting = true;
                playerInputText.enabled = false;
                for (int i = 0; i < recipeList.itemList.Count; i++) 
                {
                    Debug.Log("Loop");
                    firstItem = recipeList.itemList[i].FirstItem;
                    secondItem = recipeList.itemList[i].SecondItem;
                    thirdItem = recipeList.itemList[i].ThirdItem;
                    if (firstMaterial == firstItem || firstMaterial == secondItem || firstMaterial == thirdItem)
                    { 
                        if (secondMaterial == firstItem || secondMaterial == secondItem || secondMaterial == thirdItem)
                        {
                            if (thirdMaterial == firstItem || thirdMaterial == secondItem || thirdMaterial == thirdItem)
                            { 
                                StartCoroutine(ItemCraft(i)); 
                                break;
                            }
                        }
                    }
                }
                            
                if (firstMaterial != null && secondMaterial != null && thirdMaterial != null)
                { 
                    StartCoroutine(DungSpawn());
                }
            }
            
        }
        else if (secondMaterial != null && distance > 6)
        {
            playerInputText.enabled = false;
        }
        
        
        
        
        
        IEnumerator ItemCraft(int i)
        {
            firstMaterial = null;
            secondMaterial = null;
            thirdMaterial = null;
            Audio.Play("LabstationEvent"); //MJ - Nieprzetestowane
            yield return new WaitForSeconds(5);
            Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position, itemSpawn.transform.rotation);
            isCrafting = false;
            StopAllCoroutines();
        }

        IEnumerator DungSpawn()
        {
            firstMaterial = null;
            secondMaterial = null;
            thirdMaterial = null;
            Audio.Play("LabstationEvent"); //MJ - Nieprzetestowane
            yield return new WaitForSeconds(5);
            Instantiate(dung, itemSpawn.transform.position, itemSpawn.transform.rotation);
            isCrafting = false;
            StopAllCoroutines();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material" && isCrafting == false & thirdMaterial == null)
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
            if (Input.GetKey(KeyCode.R) && distance < 6)
            {
                if (firstMaterial != null && secondMaterial != null)
                {
                    thirdMaterial = other.GetComponent<ItemID>()._item;
                }
                else if (firstMaterial != null)
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
}