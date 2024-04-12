using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColliderSystem : MonoBehaviour
{
    public int score = 0;

    private Collision2D hit = null;

    void OnCollisionEnter2D(Collision2D collision) => OnEnter(collision);
    void OnCollisionExit2D(Collision2D collision) => OnExit(collision);

    void OnEnter(Collision2D collision)
    {
        hit = collision;
    }
    void OnExit(Collision2D collision)
    {
        hit = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfOverField();
        }
    }
    void CheckIfOverField()
    {
        if (hit != null)
        {
            hit = null;
            Debug.Log("Succesfully Hit");
            score += 1;
            UIManager.instance.AddPoint();
            if(score >= 10)
            {
                //Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        else
        {
            UIManager.instance.RemovePoint();
            if (score > 0)
            {
                score -= 1;
            }
        }
    }
}
