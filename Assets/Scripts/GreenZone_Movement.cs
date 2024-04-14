using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZone_Movement : MonoBehaviour
{
    public float speed = 0.1f;
    public float treshold = 1;

    Vector3 newPosition;
    float startingY;

    void Start()
    {
        startingY = transform.position.y;
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector3(transform.position.x, startingY + Random.Range(-270.0f, 250.0f), transform.position.z);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, newPosition) < treshold)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
