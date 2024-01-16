using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControler : MonoBehaviour
{
    private readonly int isWalking = Animator.StringToHash("IsWalking");
    private readonly int isWalkingBack = Animator.StringToHash("IsWalkingBack");
    private readonly int isWalkingFront = Animator.StringToHash("IsWalkingFront");
    

    public Animator animator;

    [SerializeField] private GameObject lookat;
    private Camera mainCamera;
    private Vector3 newRotation;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    { 
        //transform.LookAt(lookat.transform);
        if (Input.GetAxis("Horizontal") != 0)
        { 
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, true);
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront ,false);
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack ,false);
            
            switch (Input.GetAxis("Horizontal"))
            {
                case > 0 :
                    newRotation = mainCamera.transform.eulerAngles;
                    newRotation.x = 0;
                    newRotation.z = 0;
                    newRotation.y = 180;
                    transform.eulerAngles = newRotation;
                    return;
                case < 0:
                    newRotation = mainCamera.transform.eulerAngles;
                    newRotation.x = 0;
                    newRotation.z = 0;
                    transform.eulerAngles = newRotation;
                    return;
            }
           
            // newRotation = mainCamera.transform.eulerAngles;
            // newRotation.x = 0;
            // newRotation.z = 0;
            // transform.eulerAngles = newRotation;
        }
        else
        {
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, false);
        }

        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront, true);
        }
        else
        {
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront ,false);
        }
        if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack, true);
        }
        else
        {
            animator.GetBool(isWalkingBack);
            animator.SetBool(isWalkingBack ,false);
        }
    }
}
