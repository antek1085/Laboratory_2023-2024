using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Vanilla : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}