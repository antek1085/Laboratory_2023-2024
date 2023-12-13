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
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        //transform.LookAt(lookat.transform);
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, true);
        }
        else
        {
            animator.GetBool(isWalking);
            animator.SetBool(isWalking, false);
        }

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront, true);
        }
        else
        {
            animator.GetBool(isWalkingFront);
            animator.SetBool(isWalkingFront ,false);
        }
        if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
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
