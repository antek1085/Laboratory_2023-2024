using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    private readonly int isWalking = Animator.StringToHash("IsWalking");
    private readonly int isWalkingRight = Animator.StringToHash("IsWalkingRight");
    private readonly int isWalkingBack = Animator.StringToHash("IsWalkingBack");
    private readonly int isWalkingFront = Animator.StringToHash("IsWalkingFront");
    

    public Animator animator;
    
    private Camera mainCamera;
    private Vector3 newRotation;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0)
        { 
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, true);
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront ,false);
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack ,false);
            newRotation.z = 0;
            switch (Input.GetAxis("Horizontal"))
            {
                case > 0 :
                    animator.GetBool(isWalkingRight);
                    animator.SetBool(isWalkingRight, true);
                    newRotation = mainCamera.transform.eulerAngles;
                    newRotation.x = -90;
                    newRotation.z = 180;  
                    newRotation.y = 0;
                    transform.rotation = Quaternion.Euler(newRotation.x, newRotation.y ,newRotation.z);
                    return;
                case < 0:
                    animator.GetBool(isWalking);
                    animator.SetBool(isWalking, true);
                    newRotation = mainCamera.transform.eulerAngles;
                    newRotation.x = 90;
                    newRotation.z = 0;  
                    newRotation.y = 0;
                    transform.rotation = Quaternion.Euler(newRotation.x,newRotation.y,newRotation.z);
                    return;
            }
        }
        else
        {
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, false);
            animator.GetBool(isWalkingRight);
            animator.SetBool(isWalkingRight, false);
        }

        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            newRotation.x = 90;
            newRotation.z = 0;  
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront, true);
            transform.rotation = Quaternion.Euler(newRotation.x, 0 ,newRotation.z);
        }
        else
        {
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront ,false);
        }
        if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            newRotation.x = 90;
            newRotation.z = 0;  
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack, true);
            transform.rotation = Quaternion.Euler(newRotation.x, 0 ,newRotation.z);
        }
        else
        {
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack ,false);
        }
    }
}
