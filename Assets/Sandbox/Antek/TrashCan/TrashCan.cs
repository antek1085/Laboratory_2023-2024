using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInputText;
    
    [SerializeField] Transform playerTransform;
    private float distance;
    
    [SerializeField] Sprite highLightItem;
    private Sprite normalItem;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalItem = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, transform.position);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Material")
        {
            if (distance < 5)
            {
                spriteRenderer.sprite = highLightItem;
                playerInputText.enabled = true;
                playerInputText.text = "Click R to trash the material";
            }
            else
            {
                playerInputText.enabled = false;
            }
            
            if (Input.GetKey(KeyCode.R) && distance < 5)
            {
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
}
