using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MortarCraftingStation : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI playerInputText;
    [SerializeField] GameObject itemSpawn;
    
    private Item firstMaterial;
    private Item firstItem;
    [SerializeField] private ItemsDBOneIngridient recipeList;

    void Start()
    {
        playerInputText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstMaterial != null)
        {
            for (int i = 0; i < recipeList.itemList.Count; i++)
            {
                Debug.Log("Loop");
                firstItem = recipeList.itemList[i].FirstItem;
                if (firstMaterial == firstItem)
                {
                    StartCoroutine(ItemCraft(i));
                    break;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        { 
            playerInputText.enabled = true;
           
            if(Input.GetKeyDown(KeyCode.R))
            {
                firstMaterial = other.GetComponent<ItemID>()._item;
                playerInputText.enabled = false;
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator ItemCraft(int i)
    {
        Debug.Log("Sadwitch");
        firstMaterial = null;
        yield return new WaitForSeconds(5);
        Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position,itemSpawn.transform.rotation);
        StopAllCoroutines();
    }
}
