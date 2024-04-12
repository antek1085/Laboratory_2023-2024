using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenZone_Movement : MonoBehaviour
{
    public float speed = 0.1f;

    Vector3 newPosition;

    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(0f, 0f), Random.Range(-4.0f, 5.0f));
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
