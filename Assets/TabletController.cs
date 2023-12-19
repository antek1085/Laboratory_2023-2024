using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class TabletController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] private Image image;

    [SerializeField] private List<Sprite> RecipeList = new List<Sprite>();
    private int placeInList = 0;
   // private int numberOfThingsInList;

    private bool isPlayerInRange;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerInRange == true)
        {
            canvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                placeInList -= 1;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                placeInList += 1;
            }
            
            placeInList = Mathf.Clamp(placeInList, 0, RecipeList.Count -1);
            image.sprite = RecipeList[placeInList];
        }
        else
        {
            canvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { 
            isPlayerInRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        { 
            isPlayerInRange = false; 
        }
    }
}
