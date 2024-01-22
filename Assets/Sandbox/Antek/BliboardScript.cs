using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliboardScript : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = mainCamera.transform.eulerAngles;
        newRotation.x = 90;
        newRotation.z = 0;  
        transform.rotation = Quaternion.Euler(newRotation.x, 0,newRotation.z);
    }
}
