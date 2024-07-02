using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] private LayerMask PickUpLayer;
    [SerializeField] private float PickUpRange;
    [SerializeField] private Transform Hand;
    private bool isInHand = false;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;
    [SerializeField] private SOSprite spriteOnUi;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.R))
        {
            Ray PickUpRay = new Ray(transform.position, transform.forward);
           
                    
                    if(Physics.SphereCast(PickUpRay,0.7f, out RaycastHit hitInfo,PickUpRange,PickUpLayer) && Input.GetKeyUp(KeyCode.E))
                    {
                        if (CurrentObjectRigidbody && isInHand == false) 
                        {
                            CurrentObjectRigidbody.isKinematic = true;
                            CurrentObjectCollider.enabled = true;
                            return;
                        }
                         
                        if(isInHand == false)
                        {
                            CurrentObjectRigidbody = hitInfo.rigidbody;
                            CurrentObjectCollider = hitInfo.collider;
                            spriteOnUi.sprite =  hitInfo.transform.GetComponent<SpriteRenderer>().sprite;
                            hitInfo.transform.GetComponent<SpriteRenderer>().enabled = false;
            
                            CurrentObjectRigidbody.isKinematic = true;
                            isInHand = true;
                            switch (hitInfo.transform.GetComponent<ItemID>().mainItemCategory)
                                {
                                    case itemCategory.pills:
                                        Audio.Play("PillsPickUpEvent");
                                        break;
                                    case itemCategory.syrup:
                                        Audio.Play("SyropPickUpEvent");
                                        break;
                                    case itemCategory.ointment:
                                        Audio.Play("BalsamPickUpEvent");
                                        break;
                                    default:
                                        Audio.Play("PickUpEvent");
                                        break;
                                }
                            // CurrentObjectCollider.enabled = false;
                            return;
                        }
                    }

                    if (CurrentObjectRigidbody && isInHand && Input.GetKeyUp(KeyCode.R))
                    {
                        CurrentObjectRigidbody.isKinematic = true;
                        CurrentObjectCollider.enabled = true;

                        CurrentObjectRigidbody = null;
                        CurrentObjectCollider = null;
                        isInHand = false;
                        hitInfo.transform.GetComponent<SpriteRenderer>().enabled = true;
                        spriteOnUi.sprite = null;
                        Audio.Play("PlaceDownEvent"); //MJ - Nieprzetestowane
                    }
                    
        }
        
        if (CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            //CurrentObjectRigidbody.rotation = Hand.rotation;
        } 
          else       //if (CurrentObjectRigidbody == null)
        {
            spriteOnUi.sprite = null;
            isInHand = false;
            CurrentObjectRigidbody = null;
        }

    }




}

