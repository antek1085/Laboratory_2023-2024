using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpItems : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask PickUpLayer;
    [SerializeField] private float PickUpRange;
    [SerializeField] private Transform Hand;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Ray PickUpRay = new Ray(transform.position, transform.forward);
                    
                    if(Physics.Raycast(PickUpRay, out RaycastHit hitInfo,PickUpRange,PickUpLayer))
                    {
                        if (CurrentObjectRigidbody)
                        {
                            CurrentObjectRigidbody.isKinematic = false;
                            CurrentObjectCollider.enabled = true;
                        }
                        else
                        {
                            CurrentObjectRigidbody = hitInfo.rigidbody;
                            CurrentObjectCollider = hitInfo.collider;
            
                            CurrentObjectRigidbody.isKinematic = true;
                            CurrentObjectCollider.enabled = false;
                        }
                        return;
                    }

                    if (CurrentObjectRigidbody)
                    {
                        CurrentObjectRigidbody.isKinematic = false;
                        CurrentObjectCollider.enabled = true;

                        CurrentObjectRigidbody = null;
                        CurrentObjectCollider = null;
                    }
                    
        }
        
        if (CurrentObjectRigidbody)
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;
        }




        // private void OnTriggerStay(Collider other)
    // { 
    //     if (isHeld && Input.GetKey(KeyCode.E))
    //     {
    //              other.GetComponent<Rigidbody>().isKinematic = false;
    //              other.GetComponent<CapsuleCollider>().isTrigger = false;
    //              isHeld = false;
    //              other.transform.parent = null;
    //     }
    //     if (other.tag == "Material" && Input.GetKey(KeyCode.E))
    //     {
    //         Debug.Log("ssss");
    //         other.transform.parent = this.transform;
    //         other.GetComponent<Rigidbody>().isKinematic = true;
    //         other.GetComponent<CapsuleCollider>().isTrigger = true;
    //         isHeld = true;
    //     }

       
    }




}

