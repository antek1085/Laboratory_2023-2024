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
        if (Input.GetKeyUp(KeyCode.E))
        {
            Ray PickUpRay = new Ray(transform.position, transform.forward);
           
                    
                    if(Physics.SphereCast(PickUpRay,0.5f, out RaycastHit hitInfo,PickUpRange,PickUpLayer))
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
                            Audio.Play("PickUpEvent"); //MJ - Nieprzetestowane
                           // CurrentObjectCollider.enabled = false;
                           return;
                        }
                    }

                    if (CurrentObjectRigidbody && isInHand)
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

        if (CurrentObjectRigidbody == null)
        {
            spriteOnUi.sprite = null;
            isInHand = false;
            CurrentObjectRigidbody = null;
        }

    }




}

