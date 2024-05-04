using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 startPosition;

    private void Start()
    {
        GameObject restartPoint = GameObject.Find("RestartPoint");
        startPosition = restartPoint.transform.position;
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetPosition();
        Debug.Log("Collision Detected");
    }
}
