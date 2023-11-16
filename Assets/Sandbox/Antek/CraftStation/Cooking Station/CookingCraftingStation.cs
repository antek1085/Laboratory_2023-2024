using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CookingCraftingStation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInputText;
    [SerializeField] GameObject itemSpawn;

    private Item firstMaterial;
    private Item secondMaterial;
    private Item thirdMaterial;
    private Item firstItem;
    private Item secondItem;
    private Item thirdItem;

    [SerializeField] private ItemDBThreeIngridients recipeList;

    void Start()
    {
        playerInputText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstMaterial != null && secondMaterial != null)
        {
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
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Material")
            {
                playerInputText.enabled = true;

                if (Input.GetKeyDown(KeyCode.R))
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
                    // dodać bool
                    Destroy(other.gameObject);
                }
            }
        }

        IEnumerator ItemCraft(int i)
        {
            Debug.Log("Sadwitch");
            firstMaterial = null;
            secondMaterial = null;
            thirdMaterial = null;
            yield return new WaitForSeconds(5);
            Instantiate(recipeList.itemList[i].Result.itemToSpawn, itemSpawn.transform.position, itemSpawn.transform.rotation);
            StopAllCoroutines();
        }
    }
}