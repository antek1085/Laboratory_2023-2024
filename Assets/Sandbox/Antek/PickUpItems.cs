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
            isInHand = false;
            CurrentObjectRigidbody = null;
        }

    }




}

