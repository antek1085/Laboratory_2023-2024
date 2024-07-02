using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    
    void Update()
    {
        PlayerRotations();
    }
    
    void PlayerRotations()
    {
        horizontal = -Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 InputVector = new Vector2(horizontal, vertical);

        if(InputVector == Vector2.zero) 
                InputVector = new Vector2(0, -1);

        transform.rotation = Quaternion.Euler(0,Vector2.SignedAngle(Vector2.up, InputVector),0);
    }
}
