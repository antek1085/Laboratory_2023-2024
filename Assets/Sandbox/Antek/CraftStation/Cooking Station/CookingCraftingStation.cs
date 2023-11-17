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

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (firstMaterial != null && secondMaterial != null && thirdMaterial != null)
        {
            playerInputText.enabled = true;
            playerInputText.text = "Click Space to start crafting";
            if (Input.GetKeyUp(KeyCode.Space))
            {
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
        
        IEnumerator ItemCraft(int i)
        {
            firstMaterial = null;
            secondMaterial = null;
            thirdMaterial = null;
            yield return new WaitForSeconds(5);
            Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position, itemSpawn.transform.rotation);
            StopAllCoroutines();
        }

        IEnumerator DungSpawn()
        {
            firstMaterial = null;
            secondMaterial = null;
            thirdMaterial = null;
            yield return new WaitForSeconds(5);
            Instantiate(dung, itemSpawn.transform.position, itemSpawn.transform.rotation);
            StopAllCoroutines();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        { 
            playerInputText.enabled = true;
            playerInputText.text = "Click R to insert the material";
            
            if (Input.GetKey(KeyCode.R))
            {
                if (firstMaterial != null)
                {
                    secondMaterial = other.GetComponent<ItemID>()._item;
                }
                if (firstMaterial != null && secondMaterial != null)
                {
                    thirdMaterial = other.GetComponent<ItemID>()._item;
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
}